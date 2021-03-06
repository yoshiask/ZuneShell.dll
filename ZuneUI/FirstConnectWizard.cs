﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.FirstConnectWizard
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

using Microsoft.Zune.Util;

namespace ZuneUI
{
    public class FirstConnectWizard : DeviceWizard
    {
        public FirstConnectWizard()
        {
            this.AddPage(new FirstConnectDeviceNamePage(this));
            if (FeatureEnablement.IsFeatureEnabled(Features.eSocial) || FeatureEnablement.IsFeatureEnabled(Features.eMarketplace))
                this.AddPage(new FirstConnectDeviceMarketplacePage(this));
            this.AddPage(new FirstConnectDeviceSyncOptionsPage(this));
            if (this.ActiveDevice.SupportsUsageData)
                this.AddPage(new FirstConnectDeviceCustomPrivacyPage(this));
            else
                ZuneShell.DefaultInstance.Management.DeviceManagement.PrivacyChoice.Value = false;
            ZuneShell.DefaultInstance.Management.DeviceManagement.DevicePartnership = DeviceRelationship.Permanent;
        }

        protected override bool OnCommitChanges()
        {
            ZuneShell.DefaultInstance.Management.CommitListSave();
            ZuneShell.DefaultInstance.Management.DeviceManagement.SetupComplete(this.ActiveDevice.SupportsBrandingType(DeviceBranding.Kin));
            return base.OnCommitChanges();
        }
    }
}
