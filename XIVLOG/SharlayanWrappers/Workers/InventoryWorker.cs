﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InventoryWorker.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   InventoryWorker.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.SharlayanWrappers.Workers {
    using System;
    using System.Timers;

    using Sharlayan;
    using Sharlayan.Models.ReadResults;

    using XIVLOG.Properties;

    internal class InventoryWorker : PropertyChangedBase, IDisposable {
        private readonly MemoryHandler _memoryHandler;

        private readonly Timer _scanTimer;

        private bool _isScanning;

        public InventoryWorker(MemoryHandler memoryHandler) {
            this._memoryHandler = memoryHandler;
            this._scanTimer = new Timer(250);
            this._scanTimer.Elapsed += this.ScanTimerElapsed;
        }

        ~InventoryWorker() {
            this.Dispose();
        }

        public void Dispose() {
            this._scanTimer.Elapsed -= this.ScanTimerElapsed;
        }

        public void StartScanning() {
            this._scanTimer.Enabled = true;
        }

        public void StopScanning() {
            this._scanTimer.Enabled = false;
        }

        private void ScanTimerElapsed(object sender, ElapsedEventArgs e) {
            if (this._isScanning) {
                return;
            }

            this._scanTimer.Interval = Settings.Default.InventoryWorkerTiming;

            this._isScanning = true;

            InventoryResult result = this._memoryHandler.Reader.GetInventory();

            EventHost.Instance.RaiseNewInventoryContainersEvent(this._memoryHandler, result.InventoryContainers);

            this._isScanning = false;
        }
    }
}