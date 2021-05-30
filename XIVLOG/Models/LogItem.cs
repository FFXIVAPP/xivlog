// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogItem.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   LogItem.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Models {
    using System;

    using NLog;

    public class LogItem {
        public LogItem(string message) {
            this.Message = string.IsNullOrWhiteSpace(message)
                               ? "LogItem: Called Without Message"
                               : message;
        }

        public LogItem(Exception exception) {
            this.Message = exception?.Message ?? "LogItem: Called Without Exception";
            this.Exception = exception;
            this.LogLevel = LogLevel.Error;
        }

        public LogItem(string message, Exception exception) {
            this.Message = string.IsNullOrWhiteSpace(message)
                               ? exception?.Message ?? "LogItem: Called Without Message"
                               : message;
            this.Exception = exception;
            if (this.Exception != null) {
                this.LogLevel = LogLevel.Error;
            }
        }

        public Exception Exception { get; set; }

        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        public string Message { get; set; }
    }
}