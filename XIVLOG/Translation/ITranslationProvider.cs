// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITranslationProvider.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ITranslationProvider.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Translation {
    public interface ITranslationProvider {
        public TranslationResult TranslateText(string textToTranslate, string fromLanguage, string toLanguage, bool isInternational);
    }
}