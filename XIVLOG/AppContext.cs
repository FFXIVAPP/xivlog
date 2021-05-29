// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppContext.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   AppContext.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG {
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using MaterialDesignColors;

    using MaterialDesignThemes.Wpf;

    using Sharlayan;
    using Sharlayan.Models;

    using XIVLOG.Controls;
    using XIVLOG.Helpers;
    using XIVLOG.Models;
    using XIVLOG.Properties;
    using XIVLOG.SharlayanWrappers;
    using XIVLOG.Utilities;
    using XIVLOG.ViewModels;

    public class AppContext {
        private static Lazy<AppContext> _instance = new Lazy<AppContext>(() => new AppContext());

        private readonly ConcurrentDictionary<int, WorkerSet> _workerSets = new ConcurrentDictionary<int, WorkerSet>();

        private Process[] _gameInstances;

        public static AppContext Instance => _instance.Value;

        public void Initialize() {
            this.SetupCurrentUICulture();
            this.SetupDirectories();
            this.ApplyTheme();
            this.LoadChatCodes();
            this.LoadChatTabs();
            this.FindGameInstances();
            this.SetupSharlayanManager();
            this.SetupWorkerSets();
            this.StartAllSharlayanWorkers();
        }

        private void ApplyTheme() {
            ThemeUtilities.ModifyTheme(
                theme => theme.SetBaseTheme(
                    Settings.Default.DarkMode
                        ? Theme.Dark
                        : Theme.Light));
            SwatchesProvider swatchesProvider = new SwatchesProvider();
            Swatch primaryColor = swatchesProvider.Swatches.FirstOrDefault(a => string.Equals(a.Name, Settings.Default.UserThemePrimary, StringComparison.OrdinalIgnoreCase));
            if (primaryColor is not null) {
                ThemeUtilities.ModifyTheme(theme => theme.SetPrimaryColor(primaryColor.ExemplarHue.Color));
            }

            Swatch accentColor = swatchesProvider.Swatches.FirstOrDefault(a => string.Equals(a.Name, Settings.Default.UserThemeAccent, StringComparison.OrdinalIgnoreCase));
            if (accentColor is { AccentExemplarHue: not null, }) {
                ThemeUtilities.ModifyTheme(theme => theme.SetSecondaryColor(accentColor.AccentExemplarHue.Color));
            }
        }

        private void FindGameInstances() {
            this._gameInstances = Process.GetProcessesByName("ffxiv_dx11");
        }

        private void LoadChatCodes() {
            foreach (XElement xElement in AppViewModel.Instance.XChatCodes.Descendants().Elements("Code")) {
                string xKey = xElement.Attribute("Key")?.Value;
                string xColor = xElement.Element("Color")?.Value ?? "FFFFFF";
                string xDescription = xElement.Element("Description")?.Value ?? "Unknown";

                if (string.IsNullOrWhiteSpace(xKey)) {
                    continue;
                }

                AppViewModel.Instance.ChatCodes.Add(new ChatCode(xKey, xColor, xDescription));
            }
        }

        private void LoadChatTabs() {
            foreach (XElement xElement in AppViewModel.Instance.XChatTabs.Descendants().Elements("Tab")) {
                string xKey = xElement.Attribute("Key")?.Value;
                string xChatCodes = xElement.Element("ChatCodes")?.Value;
                string xRegEx = xElement.Element("RegEx")?.Value;

                if (string.IsNullOrWhiteSpace(xKey) || string.IsNullOrWhiteSpace(xChatCodes) || string.IsNullOrWhiteSpace(xRegEx)) {
                    continue;
                }

                List<ChatCode> chatCodes = new List<ChatCode>();

                foreach (string code in xChatCodes.Split(",")) {
                    chatCodes.Add(new ChatCode(code));
                }

                HomeTabItemViewModel.Instance.AddTabItem(xKey, xRegEx, chatCodes);
            }
        }

        private void MemoryHandler_OnExceptionEvent(object sender, Exception ex) {
            if (sender is not MemoryHandler memoryHandler) {
                return;
            }

            // TODO: this should be handled in sharlayan; when we can detect character changes this will be updated/removed and placed in sharlayan
            if (ex.GetType() != typeof(OverflowException)) {
                return;
            }

            if (ex.StackTrace is null || !ex.StackTrace.Contains("ChatLogReader")) {
                return;
            }

            SharlayanConfiguration configuration = memoryHandler.Configuration;

            if (!this._workerSets.TryGetValue(configuration.ProcessModel.ProcessID, out WorkerSet workerSet)) {
                return;
            }

            workerSet.ChatLogWorker.StopScanning();

            Task.Run(
                async () => {
                    await Task.Delay(1000);
                    workerSet.ChatLogWorker.Reset();
                    workerSet.ChatLogWorker.StartScanning();
                });
        }

        private void MemoryHandler_OnMemoryHandlerDisposedEvent(object sender) {
            if (sender is not MemoryHandler memoryHandler) {
                return;
            }

            memoryHandler.OnException -= this.MemoryHandler_OnExceptionEvent;
            memoryHandler.OnMemoryHandlerDisposed -= this.MemoryHandler_OnMemoryHandlerDisposedEvent;
            memoryHandler.OnMemoryLocationsFound -= this.MemoryHandler_OnMemoryLocationsFoundEvent;

            if (this._workerSets.TryRemove(memoryHandler.Configuration.ProcessModel.ProcessID, out WorkerSet workerSet)) {
                workerSet.StopMemoryWorkers();
            }
        }

        private void MemoryHandler_OnMemoryLocationsFoundEvent(object sender, ConcurrentDictionary<string, MemoryLocation> memoryLocations, long processingTime) {
            if (sender is not MemoryHandler memoryHandler) {
                return;
            }

            foreach (KeyValuePair<string, MemoryLocation> kvp in memoryLocations) {
                FlowDocHelper.AppendMessage(memoryHandler, $"MemoryLocation Found -> {kvp.Key} => {kvp.Value.GetAddress():X}", DebugTabItem.Instance.DebugLogReader._FDR);
            }
        }

        private void SetupCurrentUICulture() {
            string cultureInfo = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            CultureInfo currentCulture = new CultureInfo(cultureInfo);
            AppViewModel.Instance.CultureInfo = Settings.Default.CultureSet
                                                    ? Settings.Default.Culture
                                                    : currentCulture;
            Settings.Default.CultureSet = true;
        }

        private void SetupDirectories() {
            AppViewModel.Instance.CachePath = Constants.CachePath;
            AppViewModel.Instance.ConfigurationsPath = Constants.ConfigurationsPath;
            AppViewModel.Instance.LogsPath = Constants.LogsPath;
            AppViewModel.Instance.SettingsPath = Constants.SettingsPath;
            AppViewModel.Instance.SavedLogsDirectoryList = new List<string> {
                "Say",
                "Shout",
                "Party",
                "Tell",
                "LS",
                "CWLS",
                "FC",
                "Yell",
            };
        }

        private void SetupSharlayanManager() {
            foreach (Process process in this._gameInstances) {
                SharlayanConfiguration sharlayanConfiguration = new SharlayanConfiguration {
                    ProcessModel = new ProcessModel {
                        Process = process,
                    },
                };
                MemoryHandler handler = SharlayanMemoryManager.Instance.AddHandler(sharlayanConfiguration);
                handler.OnException += this.MemoryHandler_OnExceptionEvent;
                handler.OnMemoryHandlerDisposed += this.MemoryHandler_OnMemoryHandlerDisposedEvent;
                handler.OnMemoryLocationsFound += this.MemoryHandler_OnMemoryLocationsFoundEvent;
            }
        }

        private void SetupWorkerSets() {
            foreach (MemoryHandler memoryHandler in SharlayanMemoryManager.Instance.GetHandlers()) {
                WorkerSet workerSet = new WorkerSet(memoryHandler);
                this._workerSets.AddOrUpdate(memoryHandler.Configuration.ProcessModel.ProcessID, workerSet, (k, v) => workerSet);
            }
        }

        private void StartAllSharlayanWorkers() {
            this.StopAllSharlayanWorkers();

            foreach (WorkerSet workerSet in this._workerSets.Values.ToList()) {
                workerSet.StartMemoryWorkers();
            }
        }

        private void StopAllSharlayanWorkers() {
            foreach (WorkerSet workerSet in this._workerSets.Values.ToList()) {
                workerSet.StopMemoryWorkers();
            }
        }
    }
}