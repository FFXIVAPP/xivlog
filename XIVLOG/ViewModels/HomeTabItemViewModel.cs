// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeTabItemViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   HomeTabItemViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.ViewModels {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    using XIVLOG.Controls;
    using XIVLOG.Models;
    using XIVLOG.Properties;
    using XIVLOG.Translation;
    using XIVLOG.Utilities;

    public class HomeTabItemViewModel : PropertyChangedBase {
        private static Lazy<HomeTabItemViewModel> _instance = new Lazy<HomeTabItemViewModel>(() => new HomeTabItemViewModel());

        private ObservableCollection<TabItem> _filteredChatTabItems;

        public HomeTabItemViewModel() {
            this.ManualTranslateCommand = new DelegatedCommand(
                value => {
                    string message = value.ToString();
                    if (message is null || message.Length == 0) {
                        return;
                    }

                    string? fromLanguage = Constants.LanguageMap[Settings.Default.ManualTranslateFrom].ToString();
                    string? toLanguage = Constants.LanguageMap[Settings.Default.ManualTranslateTo].ToString();

                    if (fromLanguage is null || toLanguage is null) {
                        return;
                    }

                    TranslationResult result = Translate.GetManualResult(message, fromLanguage, toLanguage);
                    if (result is not null) {
                        HomeTabItem.Instance.ManualTranslate.Text = result.Translated;
                    }
                });
        }

        public static HomeTabItemViewModel Instance => _instance.Value;

        public ObservableCollection<TabItem> FilteredChatTabItems {
            get => this._filteredChatTabItems ??= new ObservableCollection<TabItem>();
            set => this.SetProperty(ref this._filteredChatTabItems, value);
        }

        public DelegatedCommand ManualTranslateCommand { get; }

        public void AddTabItem(string header, string regEx, List<ChatCode> chatCodes) {
            TabItem tabItem = new TabItem {
                Header = header,
            };

            FilteredChatLog filteredChatLog = new FilteredChatLog();
            foreach (ChatCode chatCode in chatCodes) {
                filteredChatLog.ChatCodes.Items.Add(chatCode.Code);
            }

            filteredChatLog.TabName.Text = header;
            filteredChatLog.RegEx.Text = regEx;

            tabItem.Content = filteredChatLog;

            this.FilteredChatTabItems.Add(tabItem);
        }
    }
}