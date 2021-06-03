// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatCodesViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
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
    using System.Text;
    using System.Windows.Controls;

    using MaterialDesignThemes.Wpf;

    using XIVLOG.Controls;
    using XIVLOG.Models;

    public class ChatCodesViewModel {
        private static Lazy<ChatCodesViewModel> _instance = new Lazy<ChatCodesViewModel>(() => new ChatCodesViewModel());

        private StringBuilder _errors = new StringBuilder();

        public ChatCodesViewModel() {
            this.CreateTabCommand = new DelegatedCommand(
                async _ => {
                    this._errors.Clear();
                    this._errors.AppendLine("Tab not added for the following reasons:\n");

                    List<ChatCode> selectedChatCodes = AppViewModel.Instance.ChatCodes.Where(code => code.IsSelected).ToList();

                    string regEx = ChatCodes.Instance.RegEx.Text;
                    string tabName = ChatCodes.Instance.TabName.Text;

                    bool hasError = false;

                    if (string.IsNullOrWhiteSpace(regEx)) {
                        this._errors.AppendLine("'RegEx' cannot be empty");
                        hasError = true;
                    }

                    if (string.IsNullOrWhiteSpace(tabName)) {
                        this._errors.AppendLine("'TabName' cannot be empty");
                        hasError = true;
                    }

                    if (selectedChatCodes.Count == 0) {
                        this._errors.AppendLine("No ChatCodes are selected");
                        hasError = true;
                    }

                    foreach (TabItem tabItem in HomeTabItemViewModel.Instance.FilteredChatTabItems) {
                        if (tabItem.Content is not FilteredChatLog filteredChatLog) {
                            continue;
                        }

                        if (!string.Equals(filteredChatLog.TabName.Text, tabName, StringComparison.OrdinalIgnoreCase)) {
                            continue;
                        }

                        this._errors.AppendLine(" - 'TabName' already exists");
                        hasError = true;
                        break;
                    }

                    if (hasError) {
                        await DialogHost.Show(
                            new ErrorDialog {
                                DataContext = new ErrorDialogViewModel {
                                    Message = this._errors.ToString(),
                                },
                            }, "RootDialog");
                        return;
                    }

                    foreach (ChatCode selectedChatCode in selectedChatCodes) {
                        selectedChatCode.IsSelected = false;
                    }

                    HomeTabItemViewModel.Instance.AddTabItem(tabName, regEx, selectedChatCodes);
                    HomeTabItem.Instance.MainTabControl.SelectedIndex = HomeTabItem.Instance.MainTabControl.Items.Count - 1;
                    MainWindowViewModel.Instance.HomeCommand.Execute(null);

                    ChatCodes.Instance.RegEx.Text = ".+";
                    ChatCodes.Instance.TabName.Text = "";
                });

            this.SaveChatCodesCommand = new DelegatedCommand(
                _ => {
                    ChatCodes.Instance?.ChatCodesDataGrid.CommitEdit();
                });
        }

        public static ChatCodesViewModel Instance => _instance.Value;

        public DelegatedCommand CreateTabCommand { get; }

        public DelegatedCommand SaveChatCodesCommand { get; }
    }
}