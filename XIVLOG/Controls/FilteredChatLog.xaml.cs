// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilteredChatLog.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   FilteredChatLog.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Controls {
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;

    using Sharlayan;
    using Sharlayan.Core;

    using XIVLOG.Helpers;
    using XIVLOG.SharlayanWrappers;
    using XIVLOG.Utilities;
    using XIVLOG.ViewModels;

    /// <summary>
    /// Interaction logic for FilteredChatLog.xaml
    /// </summary>
    public partial class FilteredChatLog : UserControl, IDisposable {
        public static FilteredChatLog Instance;

        public FilteredChatLog() {
            this.InitializeComponent();

            Instance = this;

            EventHost.Instance.OnNewChatLogItem += this.OnNewChatLogItem;
        }

        ~FilteredChatLog() {
            this.Dispose();
        }

        public void Dispose() {
            EventHost.Instance.OnNewChatLogItem -= this.OnNewChatLogItem;
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e) {
            TabItem tabItem = HomeTabItemViewModel.Instance.FilteredChatTabItems.FirstOrDefault(item => item.Header.ToString() == this.TabName.Text);
            HomeTabItemViewModel.Instance.FilteredChatTabItems.Remove(tabItem);
        }

        private void OnNewChatLogItem(object? sender, MemoryHandler memoryHandler, ChatLogItem chatLogItem) {
            this.Dispatcher.Invoke(
                () => {
                    bool regExMatched = false;
                    string xRegularExpression = this.RegEx.Text;

                    switch (xRegularExpression) {
                        case "*":
                            regExMatched = true;
                            break;
                        default:
                            try {
                                Regex regex = new Regex(xRegularExpression);
                                if (SharedRegEx.IsValidRegex(xRegularExpression)) {
                                    Match match = regex.Match(chatLogItem.Message);
                                    if (match.Success) {
                                        regExMatched = true;
                                    }
                                }
                            }
                            catch {
                                regExMatched = true;
                            }

                            break;
                    }

                    if (regExMatched && this.ChatCodes.Items.Contains(chatLogItem.Code)) {
                        FlowDocHelper.AppendChatLogItem(memoryHandler, chatLogItem, this.ChatLogReader._FDR);
                    }
                });
        }
    }
}