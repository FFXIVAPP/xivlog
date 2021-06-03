﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocaleHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   LocaleHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Helpers {
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Linq;
    using System.Resources;
    using System.Threading;

    using XIVLOG.Properties;
    using XIVLOG.ViewModels;

    public static class LocaleHelper {
        public static void UpdateLocale(CultureInfo cultureInfo) {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            ResourceSet? baseResourceSet = Resources.ResourceManager.GetResourceSet(new CultureInfo("en"), true, true);
            ResourceSet? resourceSet = Resources.ResourceManager.GetResourceSet(cultureInfo, true, true);

            if (baseResourceSet is null || resourceSet is null) {
                return;
            }

            ConcurrentDictionary<string, string> baseCultureDictionary = new ConcurrentDictionary<string, string>(baseResourceSet.Cast<DictionaryEntry>().ToDictionary(item => (string) item.Key, item => (string) item.Value));
            ConcurrentDictionary<string, string> locale = new ConcurrentDictionary<string, string>(resourceSet.Cast<DictionaryEntry>().ToDictionary(item => (string) item.Key, item => (string) item.Value));

            foreach ((string key, string value) in baseCultureDictionary) {
                locale.AddOrUpdate(key, value, (k, v) => v);
            }

            AppViewModel.Instance.Locale = locale;
        }
    }
}
