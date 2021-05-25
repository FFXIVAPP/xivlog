// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatCodesViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ChatCodesViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.ViewModels {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using XIVLOG.Controls;
    using XIVLOG.Models;

    public class ChatCodesViewModel {
        private static Lazy<ChatCodesViewModel> _instance = new Lazy<ChatCodesViewModel>(() => new ChatCodesViewModel());

        public ChatCodesViewModel() {
            this.CreateTabCommand = new DelegatedCommand(
                _ => {
                    List<ChatCode> selectedChatCodes = AppViewModel.Instance.ChatCodes.Where(code => code.IsSelected).ToList();
                    foreach (ChatCode selectedChatCode in selectedChatCodes) {
                        selectedChatCode.IsSelected = false;
                    }

                    string regEx = ChatCodes.Instance.RegEx.Text;
                    string tabName = ChatCodes.Instance.TabName.Text;

                    HomeTabItemViewModel.Instance.AddTabItem(tabName, regEx, selectedChatCodes);
                    HomeTabItem.Instance.MainTabControl.SelectedIndex = HomeTabItem.Instance.MainTabControl.Items.Count - 1;
                    MainWindowViewModel.Instance.HomeCommand.Execute(null);

                    ChatCodes.Instance.RegEx.Text = "*";
                    ChatCodes.Instance.TabName.Text = "";
                });
        }

        public static ChatCodesViewModel Instance => _instance.Value;
        public DelegatedCommand CreateTabCommand { get; }
    }
}