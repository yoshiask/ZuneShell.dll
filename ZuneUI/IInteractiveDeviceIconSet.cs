﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.IInteractiveDeviceIconSet
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

namespace ZuneUI
{
    public interface IInteractiveDeviceIconSet
    {
        IBackgroundAwareDeviceIconSet Default { get; }

        IBackgroundAwareDeviceIconSet Hover { get; }

        IBackgroundAwareDeviceIconSet Drag { get; }

        IBackgroundAwareDeviceIconSet Click { get; }

        IBackgroundAwareDeviceIconSet Syncing { get; }
    }
}
