﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.RenderAPI.Audio.SoundManager
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Data;
using Microsoft.Iris.Library;
using Microsoft.Iris.Render;
using Microsoft.Iris.Session;
using System;
using System.Collections.Generic;

namespace Microsoft.Iris.RenderAPI.Audio
{
    internal class SoundManager : IDisposable
    {
        private UISession _uiSession;
        private IRenderSession _renderSession;
        private Dictionary<string, SoundManager.SoundContent> _dictContent;
        private SystemSoundEventTable _systemSoundEventTable;

        internal SoundManager(UISession uiSession, IRenderSession renderSession)
        {
            this._uiSession = uiSession;
            this._renderSession = renderSession;
            this._dictContent = new Dictionary<string, SoundManager.SoundContent>(InvariantString.OrdinalComparer);
        }

        ~SoundManager() => this.Dispose(false);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        protected virtual void Dispose(bool fInDispose)
        {
            if (fInDispose && this._dictContent != null)
            {
                foreach (SoundManager.SoundContent soundContent in this._dictContent.Values)
                {
                    if (soundContent.soundBuffer != null)
                        soundContent.soundBuffer.UnregisterUsage(this);
                    if (soundContent.soundData != null)
                    {
                        soundContent.soundData.Unload();
                        soundContent.soundData.Dispose();
                    }
                }
                this._dictContent.Clear();
            }
            this._dictContent = null;
            this._renderSession = null;
            this._uiSession = null;
        }

        internal string GetSystemSoundEventSource(SystemSoundEvent systemSoundEvent)
        {
            if (this._systemSoundEventTable == null)
                this._systemSoundEventTable = new SystemSoundEventTable();
            string filePath = this._systemSoundEventTable.GetFilePath(systemSoundEvent);
            return string.IsNullOrEmpty(filePath) ? null : string.Format("file://{0}", filePath);
        }

        public void SetVolume(float flVolume)
        {
            if (this._renderSession.SoundDevice == null)
                return;
            this._renderSession.SoundDevice.Volume = flVolume;
        }

        public void SetMute(bool fMute)
        {
            if (this._renderSession.SoundDevice == null)
                return;
            this._renderSession.SoundDevice.Mute = fMute;
        }

        internal ISoundBuffer GetSoundBuffer(string source)
        {
            bool flag = false;
            string cacheKey = SoundData.GetCacheKey(source);
            SoundManager.SoundContent soundContent;
            if (!this._dictContent.TryGetValue(cacheKey, out soundContent))
            {
                Resource resource = ResourceManager.Instance.GetResource(source);
                if (resource == null)
                    return null;
                soundContent = new SoundManager.SoundContent();
                soundContent.soundData = new SoundData(cacheKey, resource);
                soundContent.soundData.Load();
                flag = true;
            }
            if (soundContent.soundBuffer == null && soundContent.soundData.IsAvailable && this._renderSession.SoundDevice != null)
                soundContent.soundBuffer = this._renderSession.SoundDevice.CreateSoundBuffer(this, soundContent.soundData);
            if (flag)
                this._dictContent[cacheKey] = soundContent;
            return soundContent.soundBuffer;
        }

        private class SoundContent
        {
            public SoundData soundData;
            public ISoundBuffer soundBuffer;
        }
    }
}
