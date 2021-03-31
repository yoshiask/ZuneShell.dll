﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Input.KeyFocusInfo
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

namespace Microsoft.Iris.Input
{
    internal class KeyFocusInfo : KeyInfo
    {
        private static InputInfo.InfoType s_poolType = InputInfo.InfoType.KeyFocus;
        private bool _state;
        private ICookedInputSite _other;
        private KeyFocusReason _focusReason;

        static KeyFocusInfo() => InputInfo.SetPoolLimitMode(KeyFocusInfo.s_poolType, true);

        private KeyFocusInfo()
        {
        }

        public static KeyFocusInfo Create(
          bool state,
          ICookedInputSite other,
          KeyFocusReason focusReason)
        {
            KeyFocusInfo keyFocusInfo = (KeyFocusInfo)InputInfo.GetFromPool(KeyFocusInfo.s_poolType) ?? new KeyFocusInfo();
            keyFocusInfo.Initialize(state, other, focusReason);
            return keyFocusInfo;
        }

        private void Initialize(bool state, ICookedInputSite other, KeyFocusReason focusReason)
        {
            this._state = state;
            this._other = other;
            this._focusReason = focusReason;
            this.Initialize(state ? InputEventType.GainKeyFocus : InputEventType.LoseKeyFocus);
        }

        protected override void Zombie()
        {
            base.Zombie();
            this._other = null;
        }

        public bool State => this._state;

        public ICookedInputSite Other => this._other;

        public KeyFocusReason FocusReason => this._focusReason;

        protected override InputInfo.InfoType PoolType => KeyFocusInfo.s_poolType;
    }
}
