// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   SettingsHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Helpers {
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Controls;
    using System.Xml.Linq;

    using XIVLOG.Controls;
    using XIVLOG.Models;
    using XIVLOG.ViewModels;

    public static class SettingsHelper {
        public static void SaveChatCodes() {
            IEnumerable<XElement> xElements = AppViewModel.Instance.XChatCodes.Descendants().Elements("Code");
            XElement[] enumerable = xElements as XElement[] ?? xElements.ToArray();

            foreach (ChatCode chatCode in AppViewModel.Instance.ChatCodes) {
                XElement element = enumerable.FirstOrDefault(e => e.Attribute("Key")?.Value == chatCode.Code);

                string xKey = chatCode.Code;
                string xColor = chatCode.Color;
                string xDescription = chatCode.Description;

                List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();

                keyValuePairs.Add(new KeyValuePair<string, string>("Color", xColor));
                keyValuePairs.Add(new KeyValuePair<string, string>("Description", xDescription));

                if (element is null) {
                    XMLHelper.SaveXMLNode(AppViewModel.Instance.XChatCodes, "Codes", "Code", xKey, keyValuePairs);
                }
                else {
                    XElement xColorElement = element.Element("Color");
                    if (xColorElement != null) {
                        xColorElement.Value = xColor;
                    }
                    else {
                        element.Add(new XElement("Color", xColor));
                    }

                    XElement xDescriptionElement = element.Element("Description");
                    if (xDescriptionElement != null) {
                        xDescriptionElement.Value = xDescription;
                    }
                    else {
                        element.Add(new XElement("Description", xDescription));
                    }
                }
            }

            AppViewModel.Instance.XChatCodes.Save(Path.Combine(AppViewModel.Instance.ConfigurationsPath, "ChatCodes.xml"));
        }

        public static void SaveChatTabs() {
            IEnumerable<XElement> xElements = AppViewModel.Instance.XChatTabs.Descendants().Elements("Tab");
            XElement[] enumerable = xElements as XElement[] ?? xElements.ToArray();

            foreach (TabItem filteredChatTabItem in HomeTabItemViewModel.Instance.FilteredChatTabItems) {
                string xKey = filteredChatTabItem.Header.ToString();
                XElement element = enumerable.FirstOrDefault(e => e.Attribute("Key")?.Value == xKey);

                if (filteredChatTabItem.Content is not FilteredChatLog filteredChatLog) {
                    continue;
                }

                string xChatCodes = filteredChatLog.ChatCodes.Items.Cast<object>().Aggregate(string.Empty, (c, code) => c + "," + code).Substring(1);
                string xRegEx = filteredChatLog.RegEx.Text;

                List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();

                keyValuePairs.Add(new KeyValuePair<string, string>("ChatCodes", xChatCodes));
                keyValuePairs.Add(new KeyValuePair<string, string>("RegEx", xRegEx));

                if (element is null) {
                    XMLHelper.SaveXMLNode(AppViewModel.Instance.XChatTabs, "Tabs", "Tab", xKey, keyValuePairs);
                }
                else {
                    XElement xChatCodesElement = element.Element("ChatCodes");
                    if (xChatCodesElement != null) {
                        xChatCodesElement.Value = xChatCodes;
                    }
                    else {
                        element.Add(new XElement("ChatCodes", xChatCodes));
                    }

                    XElement xDescriptionElement = element.Element("RegEx");
                    if (xDescriptionElement != null) {
                        xDescriptionElement.Value = xRegEx;
                    }
                    else {
                        element.Add(new XElement("RegEx", xRegEx));
                    }
                }
            }

            AppViewModel.Instance.XChatTabs.Save(Path.Combine(AppViewModel.Instance.SettingsPath, "ChatTabs.xml"));
        }
    }
}