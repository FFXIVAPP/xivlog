﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TargetWorker.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson <syndicated.life@gmail.com> (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   TargetWorker.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.SharlayanWrappers.Workers {
    using System;
    using System.Timers;

    using Sharlayan;
    using Sharlayan.Models.ReadResults;

    using XIVLOG.Properties;

    internal class TargetWorker : PropertyChangedBase, IDisposable {
        private readonly MemoryHandler _memoryHandler;

        private readonly Timer _scanTimer;

        private bool _isScanning;

        public TargetWorker(MemoryHandler memoryHandler) {
            this._memoryHandler = memoryHandler;
            this._scanTimer = new Timer(250);
            this._scanTimer.Elapsed += this.ScanTimerElapsed;
        }

        ~TargetWorker() {
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

            this._scanTimer.Interval = Settings.Default.TargetWorkerTiming;

            this._isScanning = true;

            TargetResult result = this._memoryHandler.Reader.GetTargetInfo();

            EventHost.Instance.RaiseNewTargetInfoEvent(this._memoryHandler, result.TargetInfo);

            this._isScanning = false;
        }
    }
}