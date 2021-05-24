﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Constants.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG {
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;

    using XIVLOG.Helpers;
    using XIVLOG.Models;

    public class Constants : PropertyChangedBase {
        public static string AppPack = "pack://application:,,,/XIVLOG;component/";

        public static readonly string[] ChatAlliance = {
            "000F",
        };

        public static readonly string[] ChatCWLS = {
            "0025",
            "0026",
            "0027",
            "0028",
            "0029",
            "002A",
            "002B",
            "002C",
        };

        public static readonly string[] ChatFC = {
            "0018",
        };

        public static readonly string[] ChatLS = {
            "0010",
            "0011",
            "0012",
            "0013",
            "0014",
            "0015",
            "0016",
            "0017",
        };

        public static readonly string[] ChatNovice = {
            "001B",
        };

        public static readonly string[] ChatParty = {
            "000E",
        };

        public static readonly string[] ChatSay = {
            "000A",
        };

        public static readonly string[] ChatShout = {
            "000B",
        };

        public static readonly string[] ChatTell = {
            "000C",
            "000D",
        };

        public static readonly string[] ChatToTranslate = {
            "000A",
            "000B",
            "000C",
            "000D",
            "000E",
            "000F",
            "0010",
            "0011",
            "0012",
            "0013",
            "0014",
            "0015",
            "0016",
            "0017",
            "0018",
            "001B",
            "001E",
            "0025",
            "0026",
            "0027",
            "0028",
            "0029",
            "002A",
            "002B",
            "002C",
        };

        public static readonly string[] ChatYell = {
            "001E",
        };

        private static Lazy<Constants> _instance = new Lazy<Constants>(() => new Constants());

        private ObservableCollection<ChatCode> _chatCodes;

        private CultureInfo _cultureInfo;

        private XDocument _xChatCodes;

        private XDocument _xChatTabs;

        public static Constants Instance => _instance.Value;

        public string CachePath {
            get {
                try {
                    string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    return Path.Combine(documentsFolder, "XIVLOG");
                }
                catch (Exception) {
                    return Path.Combine(Directory.GetCurrentDirectory(), "AppCache");
                }
            }
        }

        public ObservableCollection<ChatCode> ChatCodes {
            get => this._chatCodes ??= new ObservableCollection<ChatCode>();
            set => this.SetProperty(ref this._chatCodes, value);
        }

        public string ConfigurationsPath => Path.Combine(this.CachePath, "Configurations");

        public CultureInfo CultureInfo {
            get => this._cultureInfo ??= new CultureInfo("en");
            set => this.SetProperty(ref this._cultureInfo, value);
        }

        public string LogsPath => Path.Combine(this.CachePath, "Logs");

        public string SettingsPath => Path.Combine(this.CachePath, "Settings");

        public XDocument XChatCodes {
            get {
                if (this._xChatCodes is not null) {
                    return this._xChatCodes;
                }

                string path = Path.Combine(this.CachePath, "Configurations", "ChatCodes.xml");
                try {
                    this._xChatCodes = File.Exists(path)
                                           ? XDocument.Load(path)
                                           : ResourceHelper.LoadXML($"{AppPack}Resources/ChatCodes.xml");
                }
                catch (Exception) {
                    this._xChatCodes = ResourceHelper.LoadXML($"{AppPack}Resources/ChatCodes.xml");
                }

                return this._xChatCodes;
            }
            set => this.SetProperty(ref this._xChatCodes, value);
        }

        public XDocument XChatTabs {
            get {
                if (this._xChatTabs is not null) {
                    return this._xChatTabs;
                }

                string path = Path.Combine(this.CachePath, "Settings", "Tabs.xml");
                try {
                    this._xChatTabs = File.Exists(path)
                                          ? XDocument.Load(path)
                                          : ResourceHelper.LoadXML($"{AppPack}Resources/ChatTabs.xml");
                }
                catch (Exception) {
                    this._xChatTabs = ResourceHelper.LoadXML($"{AppPack}Resources/ChatTabs.xml");
                }

                return this._xChatTabs;
            }
            set => this.SetProperty(ref this._xChatTabs, value);
        }
    }
}