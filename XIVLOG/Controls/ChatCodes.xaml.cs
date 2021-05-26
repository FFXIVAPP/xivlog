// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatCodes.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ChatCodes.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Controls {
    using System.Windows.Controls;

    using XIVLOG.ViewModels;

    /// <summary>
    /// Interaction logic for ChatCodes.xaml
    /// </summary>
    public partial class ChatCodes : UserControl {
        public static ChatCodes Instance;

        public ChatCodes() {
            this.InitializeComponent();

            Instance = this;

            this.DataContext = ChatCodesViewModel.Instance;
        }
    }
}