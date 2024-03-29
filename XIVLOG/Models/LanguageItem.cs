﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageItem.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   LanguageItem.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Models {
    using System.Globalization;

    public class LanguageItem {
        public CultureInfo CultureInfo { get; set; }
        public string ImageURI { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }
    }
}