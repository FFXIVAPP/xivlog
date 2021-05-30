// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logging.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   Logging.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.Utilities {
    using System;

    using NLog;

    using XIVLOG.Controls;
    using XIVLOG.Helpers;
    using XIVLOG.Models;

    public static class Logging {
        public static void Debug(Logger logger, string message, Exception exception = null) {
            Debug(logger, new LogItem(message, exception));
        }

        public static void Debug(Logger logger, LogItem logItem) {
            Log(logger, logItem);

            // handle pre rendered cases in App.xaml.cs
            if (DebugTabItem.Instance is not null) {
                FlowDocHelper.AppendMessage(logItem.Message, DebugTabItem.Instance.DebugLogReader._FDR);
            }
        }

        public static void Log(Logger logger, string message, Exception exception = null) {
            Log(logger, new LogItem(message, exception));
        }

        public static void Log(Logger logger, LogItem logItem) {
            if (logItem.Exception == null) {
                logger.Log(logItem.LogLevel, logItem.Message);
            }
            else {
                logger.Log(logItem.LogLevel, logItem.Exception, logItem.Message);
            }
        }
    }
}