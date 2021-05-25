// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   MainWindow.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Launcher {
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static MainWindow Instance;

        public MainWindow() {
            this.InitializeComponent();

            Instance = this;
        }

        private void CleanupTemporary() {
            try {
                string path = Directory.GetCurrentDirectory();
                FileInfo[] files = new DirectoryInfo(path).GetFiles();
                foreach (FileInfo file in files.Where(t => t.Extension == ".tmp" || t.Extension == ".PendingOverwrite")) {
                    file.Delete();
                }
            }
            catch (Exception) {
                // IGNORED
            }
        }

        private void CloseUpdater_OnClick(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown(0);
        }

        private void MainWindow_OnClosed(object? sender, EventArgs e) {
            this.CleanupTemporary();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e) {
            this.CleanupTemporary();

            Process[] processes = Process.GetProcessesByName("XIVLOG");
            foreach (Process process in processes) {
                try {
                    process.Kill();
                }
                catch (Exception) {
                    // IGNORED
                }
            }

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(UpdateManager.DownloadUpdate));
        }

        private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (Mouse.LeftButton == MouseButtonState.Pressed) {
                this.DragMove();
            }
        }
    }
}