﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatTab.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ChatTab.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Models {
    using System.Collections.Generic;

    public class ChatTab {
        public List<ChatCode> ChatCodes { get; set; }
        public string RegEx { get; set; }
        public string TabName { get; set; }
    }
}