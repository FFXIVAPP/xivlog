// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleTranslateProvider.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   GoogleTranslateProvider.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Translation {
    using System;
    using System.Net.Http;

    using Newtonsoft.Json.Linq;

    using NLog;

    using XIVLOG.Models;
    using XIVLOG.Utilities;

    public class GoogleTranslateProvider : ITranslationProvider {
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private string _baseUrl = "https://translation.googleapis.com/language/translate/v2?key={0}&source={1}&target={2}&q={3}&format=text";

        private string _serviceKey;

        public GoogleTranslateProvider(string serviceKey) {
            this._serviceKey = serviceKey;
        }

        public TranslationResult TranslateText(string textToTranslate, string fromLanguage, string toLanguage, bool isInternational) {
            Logging.Log(this.Logger, "Calling Google");

            TranslationResult result = new TranslationResult {
                Original = textToTranslate,
            };

            try {
                string url = string.Format(
                    this._baseUrl, this._serviceKey, isInternational
                                                         ? fromLanguage
                                                         : "", toLanguage, textToTranslate);

                Logging.Log(this.Logger, $"Resolved URL: {url}");

                using HttpRequestMessage request = new HttpRequestMessage {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                };

                using HttpClient httpClient = new HttpClient();
                using HttpResponseMessage response = httpClient.SendAsync(request).GetAwaiter().GetResult();
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                JObject translateResult = JObject.Parse(responseBody);
                JToken? translation = translateResult["data"]?["translations"]?[0]?["translatedText"];

                if (translation is not null) {
                    result.Translated = translation.ToString();
                }
            }
            catch (Exception ex) {
                Logging.Log(this.Logger, new LogItem(ex, true));
            }

            return result;
        }
    }
}