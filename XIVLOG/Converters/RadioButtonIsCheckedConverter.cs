// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RadioButtonIsCheckedConverter.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   RadioButtonIsCheckedConverter.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Converters {
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class RadioButtonIsCheckedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is { } && value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is { } && value.Equals(true)
                ? parameter
                : Binding.DoNothing;
        }
    }
}