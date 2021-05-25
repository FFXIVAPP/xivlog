// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   App.xaml.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Launcher {
    using System;
    using System.Diagnostics;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App() {
            this.Startup += this.OnStartup;

            this.InitializeComponent();
        }

        private void LaunchApplication() {
            try {
                Process process = new Process {
                    StartInfo = {
                        FileName = "XIVLOG.exe",
                    },
                };
                process.Start();
            }
            catch (Exception ex) {
                MessageBox.Show($"{ex.Message} [XIVLOG.exe]", "Exception");
            }
            finally {
                Environment.Exit(0);
            }
        }

        private void OnStartup(object sender, StartupEventArgs e) {
            GitHubRelease currentRelease = GitHub.GetCurrentRelease();
            if (currentRelease is null) {
                this.LaunchApplication();
            }
            else {
                AppContext.Instance.ReleaseInfo = currentRelease;
            }
        }
    }
}