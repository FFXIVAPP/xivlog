// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeUtilities.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ThemeUtilities.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Utilities {
    using System;

    using MaterialDesignThemes.Wpf;

    public static class ThemeUtilities {
        public static void ModifyTheme(Action<ITheme> modificationAction) {
            PaletteHelper paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }
    }
}