﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GitHubRelease.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   GitHubRelease.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Launcher {
    using System.Collections.Generic;

    public class GitHubRelease {
        public List<GitHubReleaseAsset> assets { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
    }
}