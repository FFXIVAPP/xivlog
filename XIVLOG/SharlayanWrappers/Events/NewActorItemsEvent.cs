﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewActorItemsEvent.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   NewActorItemsEvent.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace XIVLOG.SharlayanWrappers.Events {
    using System.Collections.Concurrent;

    using Sharlayan;
    using Sharlayan.Core;

    public class NewActorItemsEvent : SharlayanDataEvent<ConcurrentDictionary<uint, ActorItem>> {
        public NewActorItemsEvent(object sender, MemoryHandler memoryHandler, ConcurrentDictionary<uint, ActorItem> eventData) : base(sender, memoryHandler, eventData) { }
    }
}