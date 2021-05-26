// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   MainWindowViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.ViewModels {
    using System;
    using System.Linq;

    using XIVLOG.Controls;
    using XIVLOG.Models;
    using XIVLOG.Properties;

    public class MainWindowViewModel : PropertyChangedBase {
        private static Lazy<MainWindowViewModel> _instance = new Lazy<MainWindowViewModel>(() => new MainWindowViewModel());

        private int _selectedIndex;

        private LanguageItem? _selectedInterfaceLanguage;

        private ViewItem? _selectedItem;

        public MainWindowViewModel() {
            this.HomeView = new ViewItem("Home", typeof(HomeTabItem));
            this.SettingsView = new ViewItem("Settings", typeof(SettingsTabItem));
            this.DebugView = new ViewItem("Debug", typeof(DebugTabItem));
            this.AboutView = new ViewItem("About", typeof(AboutTabItem));

            this.SelectedItem = this.HomeView;
            this.SelectedInterfaceLanguage = AppViewModel.Instance.InterfaceLanguages.FirstOrDefault(item => string.Equals(item.Language, Settings.Default.InterfaceLanguage, StringComparison.OrdinalIgnoreCase));

            this.HomeCommand = new DelegatedCommand(
                _ => {
                    this.SelectedIndex = 0;
                    this.SelectedItem = this.HomeView;
                });
            this.SettingsCommand = new DelegatedCommand(
                _ => {
                    this.SelectedIndex = 1;
                    this.SelectedItem = this.SettingsView;
                });
            this.DebugCommand = new DelegatedCommand(
                _ => {
                    this.SelectedIndex = 2;
                    this.SelectedItem = this.DebugView;
                });

            this.AboutCommand = new DelegatedCommand(
                _ => {
                    this.SelectedIndex = 3;
                    this.SelectedItem = this.AboutView;
                });

            this.UpdateInterfaceLanguage = new DelegatedCommand(
                value => {
                    if (value is not LanguageItem item) {
                        return;
                    }

                    this.SelectedInterfaceLanguage = item;
                    Settings.Default.InterfaceLanguage = item.Language;
                });
        }

        public static MainWindowViewModel Instance => _instance.Value;

        public DelegatedCommand AboutCommand { get; }
        public ViewItem AboutView { get; set; }

        public DelegatedCommand DebugCommand { get; }
        public ViewItem DebugView { get; set; }

        public DelegatedCommand HomeCommand { get; }
        public ViewItem HomeView { get; set; }

        public int SelectedIndex {
            get => this._selectedIndex;
            set => this.SetProperty(ref this._selectedIndex, value);
        }

        public LanguageItem? SelectedInterfaceLanguage {
            get => this._selectedInterfaceLanguage;
            set => this.SetProperty(ref this._selectedInterfaceLanguage, value);
        }

        public ViewItem? SelectedItem {
            get => this._selectedItem;
            set {
                this.SetProperty(ref this._selectedItem, value);
                AppViewModel.Instance.AppTitle = value?.Name;
            }
        }

        public DelegatedCommand SettingsCommand { get; }
        public ViewItem SettingsView { get; set; }

        public DelegatedCommand UpdateInterfaceLanguage { get; }
    }
}