﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.ZuneTagPropertyEditor
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

namespace ZuneUI
{
    public class ZuneTagPropertyEditor : WizardPropertyEditor
    {
        private static PropertyDescriptor[] s_dataProviderProperties;
        public static PropertyDescriptor s_ZuneTag = new ZuneTagPropertyDescriptor(nameof(ZuneTag), string.Empty, string.Empty);

        public override PropertyDescriptor[] PropertyDescriptors
        {
            get
            {
                if (s_dataProviderProperties == null)
                    s_dataProviderProperties = new PropertyDescriptor[1]
                    {
            s_ZuneTag
                    };
                return s_dataProviderProperties;
            }
        }

        public static PropertyDescriptor ZuneTag => s_ZuneTag;
    }
}
