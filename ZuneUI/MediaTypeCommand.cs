﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.MediaTypeCommand
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

using Microsoft.Iris;

namespace ZuneUI
{
    public class MediaTypeCommand : Command
    {
        private MediaType _type;

        public MediaType Type
        {
            get => this._type;
            set
            {
                if (this._type == value)
                    return;
                this._type = value;
                this.FirePropertyChanged(nameof(Type));
            }
        }
    }
}
