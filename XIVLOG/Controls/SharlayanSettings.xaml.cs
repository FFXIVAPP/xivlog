// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharlayanSettings.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SharlayanSettings.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Controls {
    using System.Windows.Controls;

    using XIVLOG.ViewModels;

    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SharlayanSettings : UserControl {
        public SharlayanSettings() {
            this.InitializeComponent();

            this.DataContext = SharlayanSettingsViewModel.Instance;
        }
    }
}