﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.RedeemCodePropertyEditor
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

namespace ZuneUI
{
    public class RedeemCodePropertyEditor : WizardPropertyEditor
    {
        private static PropertyDescriptor[] s_dataProviderProperties;
        public static PrepaidCodePropertyDescriptor s_code = new PrepaidCodePropertyDescriptor(nameof(Code), string.Empty, string.Empty, true);

        public override PropertyDescriptor[] PropertyDescriptors
        {
            get
            {
                if (s_dataProviderProperties == null)
                    s_dataProviderProperties = new PropertyDescriptor[1]
                    {
             s_code
                    };
                return s_dataProviderProperties;
            }
        }

        public static PropertyDescriptor Code => s_code;
    }
}
