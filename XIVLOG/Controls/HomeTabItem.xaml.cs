// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeTabItem.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   HomeTabItem.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Controls {
    using System;
    using System.Linq;
    using System.Windows.Controls;

    using Sharlayan.Core;

    using XIVLOG.Helpers;
    using XIVLOG.Properties;
    using XIVLOG.SharlayanWrappers;
    using XIVLOG.SharlayanWrappers.Events;
    using XIVLOG.Translation;
    using XIVLOG.Utilities;
    using XIVLOG.ViewModels;

    using Constants = XIVLOG.Constants;

    /// <summary>
    /// Interaction logic for HomeTabItem.xaml
    /// </summary>
    public partial class HomeTabItem : UserControl, IDisposable {
        public static HomeTabItem Instance;

        public HomeTabItem() {
            this.InitializeComponent();

            Instance = this;

            this.DataContext = HomeTabItemViewModel.Instance;

            EventHost.Instance.OnNewChatLogItem += this.OnOnNewChatLogItem;
        }

        ~HomeTabItem() {
            this.Dispose();
        }

        public void Dispose() {
            EventHost.Instance.OnNewChatLogItem -= this.OnOnNewChatLogItem;
        }

        private void OnOnNewChatLogItem(object? sender, NewChatLogItemEvent e) {
            // unfiltered chat
            FlowDocHelper.AppendChatLogItem(e.MemoryHandler, e.EventData, this.UnfilteredChatLog._FDR);

            // handle translated chat
            if (!Settings.Default.EnableTranslate || !Constants.ChatToTranslate.Contains(e.EventData.Code)) {
                return;
            }

            TranslationResult result = Translate.GetAutomaticResult(e.EventData);
            if (result is null) {
                return;
            }

            if (e.EventData.Clone() is not ChatLogItem { } chatLogItem) {
                return;
            }

            chatLogItem.Message = result.Translated;
            FlowDocHelper.AppendChatLogItem(e.MemoryHandler, chatLogItem, this.TranslatedChatLog._FDR);
        }
    }
}