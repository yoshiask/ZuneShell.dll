﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.Listener
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

namespace Microsoft.Iris.Markup
{
    internal class Listener : ListenerNodeBase
    {
        protected string _watch;

        public string Watch => this._watch;

        public override void Dispose()
        {
            this._watch = (string)null;
            base.Dispose();
        }

        public virtual void OnNotify()
        {
        }
    }
}
