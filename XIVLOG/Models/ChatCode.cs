// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatCode.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   ChatCode.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Models {
    public class ChatCode : PropertyChangedBase {
        private string _color;

        private string _description;

        private bool _isSelected;

        public ChatCode(string code) {
            this.Code = code;
            this.Color = "FFFFFF";
            this.Description = "Unknown";
        }

        public bool IsSelected {
            get => this._isSelected;
            set => this.SetProperty(ref this._isSelected, value);
        }

        public ChatCode(string code, string color, string description) {
            this.Code = code;
            this.Color = color;
            this.Description = description;
        }

        public string Code { get; }

        public string Color {
            get => this._color;
            set => this.SetProperty(ref this._color, value);
        }

        public string Description {
            get => this._description;
            set => this.SetProperty(ref this._description, value);
        }
    }
}