// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AboutTabItemViewModel.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   AboutTabItemViewModel.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.ViewModels {
    using System;

    using XIVLOG.Utilities;

    public class AboutTabItemViewModel {
        private static Lazy<AboutTabItemViewModel> _instance = new Lazy<AboutTabItemViewModel>(() => new AboutTabItemViewModel());

        public AboutTabItemViewModel() {
            this.OpenDiscordInvitePageCommand = new DelegatedCommand(
                _ => {
                    Link.OpenInBrowser("https://discord.gg/aCzSANp");
                });

            this.OpenGitHubSponsorsPageCommand = new DelegatedCommand(
                _ => {
                    Link.OpenInBrowser("https://github.com/sponsors/Icehunter");
                });

            this.OpenGitHubSourcePageCommand = new DelegatedCommand(
                _ => {
                    Link.OpenInBrowser("https://github.com/FFXIVAPP");
                });
        }

        public static AboutTabItemViewModel Instance => _instance.Value;

        public DelegatedCommand OpenDiscordInvitePageCommand { get; }
        public DelegatedCommand OpenGitHubSourcePageCommand { get; }
        public DelegatedCommand OpenGitHubSponsorsPageCommand { get; }
    }
}