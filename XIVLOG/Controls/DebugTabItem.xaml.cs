// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugTabItem.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   DebugTabItem.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Controls {
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DebugTabItem.xaml
    /// </summary>
    public partial class DebugTabItem : UserControl {
        public static DebugTabItem Instance;

        public DebugTabItem() {
            this.InitializeComponent();

            Instance = this;
        }
    }
}