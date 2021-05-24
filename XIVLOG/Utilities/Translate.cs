// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Translate.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Translate.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Utilities {
    using System;

    using NLog;

    using Sharlayan.Core;

    using XIVLOG.Models;
    using XIVLOG.Properties;
    using XIVLOG.Translation;

    internal static class Translate {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static CognitiveTranslateProvider _cognitiveTranslateProvider;

        private static GoogleTranslateProvider _googleTranslateProvider;

        public static TranslationResult GetAutomaticResult(ChatLogItem chatLogItem) {
            try {
                Logging.Log(Logger, "Begin Translation");
                Logging.Log(Logger, $"Player [{chatLogItem.PlayerName}] said [{chatLogItem.Message}]");

                TranslationResult result = TranslateText(chatLogItem);

                Logging.Log(Logger, $"Translation Result: {result?.Translated}");

                if (result is null) {
                    return null;
                }

                if (result.Translated.Length <= 0 || string.Equals(chatLogItem.Message, result.Translated, StringComparison.InvariantCultureIgnoreCase)) {
                    return new TranslationResult {
                        Original = chatLogItem.Message,
                    };
                }

                return result;
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            return null;
        }

        public static TranslationResult GetManualResult(string text, string fromLanguage, string toLanguage) {
            try {
                return GetTranslationProvider().TranslateText(text, fromLanguage, toLanguage, false);
            }
            catch (Exception ex) {
                Logging.Log(Logger, new LogItem(ex, true));
            }

            return null;
        }

        private static ITranslationProvider GetTranslationProvider() {
            switch (Settings.Default.TranslationProvider) {
                case "Google":
                    if (string.IsNullOrWhiteSpace(Settings.Default.GoogleServiceKey)) {
                        throw new NotImplementedException($"{Settings.Default.TranslationProvider} is missing service key");
                    }

                    return _googleTranslateProvider ??= new GoogleTranslateProvider(Settings.Default.GoogleServiceKey);
                case "Cognitive":
                    if (string.IsNullOrWhiteSpace(Settings.Default.CognitiveServiceKey)) {
                        throw new NotImplementedException($"{Settings.Default.TranslationProvider} is missing service key");
                    }

                    if (string.IsNullOrWhiteSpace(Settings.Default.CognitiveServiceRegion)) {
                        throw new NotImplementedException($"{Settings.Default.TranslationProvider} is missing service region");
                    }

                    return _cognitiveTranslateProvider ??= new CognitiveTranslateProvider(Settings.Default.CognitiveServiceKey, Settings.Default.CognitiveServiceRegion);
            }

            throw new NotImplementedException($"{Settings.Default.TranslationProvider} is not a valid translation provider");
        }

        private static TranslationResult TranslateText(ChatLogItem chatLogItem) {
            TranslationResult result = null;

            string? fromLanguage = Constants.LanguageMap[Settings.Default.TranslateFromLanguage]?.ToString();
            string? toLanguage = Constants.LanguageMap[Settings.Default.TranslateToLanguage]?.ToString();

            if (fromLanguage is null || toLanguage is null) {
                return null;
            }

            if (Settings.Default.TranslateInternationalOnly) {
                if (chatLogItem.IsInternational) {
                    result = GetTranslationProvider().TranslateText(chatLogItem.Message, fromLanguage, toLanguage, chatLogItem.IsInternational);
                }
            }
            else {
                result = GetTranslationProvider().TranslateText(chatLogItem.Message, fromLanguage, toLanguage, chatLogItem.IsInternational);
            }

            return result;
        }
    }
}