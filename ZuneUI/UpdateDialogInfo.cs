﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.UpdateDialogInfo
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

using Microsoft.Iris;
using Microsoft.Zune.Util;
using System;
using UIXControls;

namespace ZuneUI
{
    public class UpdateDialogInfo
    {
        internal static void Show(bool updateFound, bool fIsCritical, bool isUserInitiated)
        {
            if (updateFound)
            {
                EventHandler cancelCommand = null;
                string message = !fIsCritical ? Shell.LoadString(StringId.IDS_UPDATE_AVAILABLE) : Shell.LoadString(StringId.IDS_CRITICAL_UPDATE_AVAILABLE);
                string cancelText = Shell.LoadString(StringId.IDS_UPDATE_INSTALL_LATER);
                Command okCommand = new Command(null, Shell.LoadString(StringId.IDS_UPDATE_INSTALL_NOW), null);
                okCommand.Invoked += delegate
               {
                   SoftwareUpdates.Instance.InstallUpdates();
               };
                if (!isUserInitiated)
                    cancelCommand = (sender, e) => SQMLog.Log(SQMDataId.UserDeferredAutomaticUpdate, 1);
                MessageBox.Show(null, message, okCommand, cancelText, cancelCommand, true);
            }
            else
                MessageBox.Show(null, Shell.LoadString(StringId.IDS_UPDATE_NOT_REQUIRED), null);
        }
    }
}
