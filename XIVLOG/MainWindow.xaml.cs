// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   MainWindow.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG {
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Threading;

    using XIVLOG.Helpers;
    using XIVLOG.Properties;
    using XIVLOG.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            this.InitializeComponent();

            this.DataContext = MainWindowViewModel.Instance;
        }

        private void CloseApplication() {
            if (Application.Current.MainWindow != null) {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }

            Settings.Default.Save();

            SettingsHelper.SaveChatCodes();
            SettingsHelper.SaveChatTabs();
            SavedLogsHelper.SaveCurrentLog();

            Environment.Exit(0);
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e) {
            e.Cancel = true;
            DispatcherHelper.Invoke(this.CloseApplication, DispatcherPriority.Send);
        }

        private void MainWindow_OnContentRendered(object? sender, EventArgs e) {
            LocaleHelper.UpdateLocale(Settings.Default.Culture);
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
            AppContext.Instance.Initialize();
        }
    }
}