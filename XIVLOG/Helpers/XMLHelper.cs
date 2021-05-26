// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XMLHelper.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   XMLHelper.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Helpers {
    using System.Collections.Generic;
    using System.Xml.Linq;

    public static class XMLHelper {
        public static void SaveXMLNode(XDocument xDoc, string xRoot, string xNode, string xKey, IEnumerable<KeyValuePair<string, string>> xValuePairs) {
            XElement element = xDoc.Element(xRoot);
            if (element == null) {
                return;
            }

            XElement newElement = new XElement(xNode, new XAttribute("Key", xKey));
            foreach (KeyValuePair<string, string> s in xValuePairs) {
                newElement.Add(new XElement(s.Key, s.Value));
            }

            element.Add(newElement);
        }
    }
}