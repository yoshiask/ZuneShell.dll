﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Drawing.TextImageCache
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Queues;
using Microsoft.Iris.Render.Extensions;
using Microsoft.Iris.Session;
using System;

namespace Microsoft.Iris.Drawing
{
    internal sealed class TextImageCache : ImageCache
    {
        private static TextImageCache s_theOnlyCache;
        private static readonly DeferredHandler s_dhReschedule = new DeferredHandler(TextImageCache.Reschedule);
        private UISession _session;
        private TextImageCache.ScavengeCallback _callback;

        public static void Initialize(UISession session)
        {
            TextImageCache.s_theOnlyCache = new TextImageCache(session);
            TextImageCache.s_theOnlyCache.NumItemsToKeep = 500;
            TextImageCache.s_theOnlyCache.ItemRetainTime = TimeSpan.Zero;
        }

        public static void Uninitialize(UISession session)
        {
            if (TextImageCache.s_theOnlyCache == null)
                return;
            TextImageCache.s_theOnlyCache.Dispose();
        }

        public static TextImageCache Instance => TextImageCache.s_theOnlyCache;

        private TextImageCache(UISession session)
          : base(session.RenderSession, nameof(TextImageCache))
          => this._session = session;

        protected override void OnDispose()
        {
            TimeoutManager timeoutManager = this._session.Dispatcher.TimeoutManager;
            TextImageCache.ScavengeCallback callback = this._callback;
            if (callback != null)
                timeoutManager.CancelTimeout((QueueItem)callback);
            this._callback = (TextImageCache.ScavengeCallback)null;
            base.OnDispose();
        }

        protected override void ScheduleScavenge()
        {
            if (!this.CleanupPending)
                DeferredCall.Post(DispatchPriority.Idle, TextImageCache.s_dhReschedule, (object)this);
            base.ScheduleScavenge();
        }

        private static void Reschedule(object arg)
        {
            TextImageCache cache = arg as TextImageCache;
            if (!cache.CleanupPending)
                return;
            TimeoutManager timeoutManager = cache._session.Dispatcher.TimeoutManager;
            TextImageCache.ScavengeCallback callback = cache._callback;
            cache._callback = (TextImageCache.ScavengeCallback)null;
            if (callback != null)
                timeoutManager.CancelTimeout((QueueItem)callback);
            TextImageCache.ScavengeCallback scavengeCallback = new TextImageCache.ScavengeCallback(cache);
            timeoutManager.SetTimeoutRelative((QueueItem)scavengeCallback, TimeSpan.FromSeconds(5.0));
            cache._callback = scavengeCallback;
        }

        private class ScavengeCallback : QueueItem
        {
            private TextImageCache _cache;

            public ScavengeCallback(TextImageCache cache) => this._cache = cache;

            public override void Dispatch()
            {
                if (this._cache._callback != this)
                    return;
                this._cache._callback = (TextImageCache.ScavengeCallback)null;
                this._cache.CullObjects();
            }
        }
    }
}