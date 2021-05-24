// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CognitiveTranslateProvider.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   CognitiveTranslateProvider.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Translation {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using NLog;

    using XIVLOG.Models;
    using XIVLOG.Utilities;

    public class CognitiveTranslateProvider : ITranslationProvider {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static string _baseUrl = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from={0}&to={1}";

        private string _region;

        private string _serviceKey;

        public CognitiveTranslateProvider(string serviceKey, string region) {
            this._serviceKey = serviceKey;
            this._region = region;
        }

        public TranslationResult TranslateText(string textToTranslate, string fromLanguage, string toLanguage, bool isInternational) {
            Logging.Log(Logger, "Calling Cognitive");

            TranslationResult result = new TranslationResult {
                Original = textToTranslate,
            };

            try {
                string url = string.Format(
                    _baseUrl, isInternational
                                  ? fromLanguage
                                  : this.DetectLanguage(textToTranslate), toLanguage);

                Object[] body = {
                    new {
                        Text = textToTranslate,
                    },
                };
                string requestBody = JsonConvert.SerializeObject(body);

                using HttpRequestMessage request = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Content = new StringContent(requestBody, Encoding.UTF8, "application/json"),
                };
                request.Headers.Add("Ocp-Apim-Subscription-Key", this._serviceKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", this._region);
                request.Headers.Add("X-ClientTraceId", Guid.NewGuid().ToString());

                using HttpClient httpClient = new HttpClient();
                using HttpResponseMessage response = httpClient.SendAsync(request).GetAwaiter().GetResult();
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                List<Dictionary<string, List<Dictionary<string, string>>>> translateResult = JsonConvert.DeserializeObject<List<Dictionary<string, List<Dictionary<string, string>>>>>(responseBody);
                string translation = translateResult[0]["translations"][0]["text"];

                // Update the translation field
                result.Translated = translation;
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            return result;
        }

        private string DetectLanguage(string text) {
            string url = "https://api.cognitive.microsofttranslator.com/detect?api-version=3.0";

            // Create request to Detect languages with Translator Text
            HttpWebRequest detectLanguageWebRequest = (HttpWebRequest) WebRequest.Create(url);
            detectLanguageWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", this._serviceKey);
            detectLanguageWebRequest.Headers.Add("Ocp-Apim-Subscription-Region", this._region);
            detectLanguageWebRequest.ContentType = "application/json; charset=utf-8";
            detectLanguageWebRequest.Method = "POST";

            // Send request
            string body = "[{ \"Text\": " + JsonConvert.SerializeObject(text) + " }]";
            byte[] data = Encoding.UTF8.GetBytes(body);

            detectLanguageWebRequest.ContentLength = data.Length;

            using Stream requestStream = detectLanguageWebRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);

            using HttpWebResponse response = (HttpWebResponse) detectLanguageWebRequest.GetResponse();

            // Read and parse JSON response
            using Stream responseStream = response.GetResponseStream();
            string json = new StreamReader(responseStream, Encoding.GetEncoding("utf-8")).ReadToEnd();
            JArray items = JArray.Parse(json);

            // Fish out the detected language code
            dynamic language = items?[0];
            return language?["score"] > (decimal) 0.5
                       ? (string) language?["language"]
                       : "en";
        }
    }
}