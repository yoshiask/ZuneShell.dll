﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.VoidSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

namespace Microsoft.Iris.Markup.UIX
{
    internal static class VoidSchema
    {
        public static UIXTypeSchema Type;

        public static void Pass1Initialize() => VoidSchema.Type = new UIXTypeSchema((short)240, "Void", "void", (short)-1, typeof(void), UIXTypeFlags.None);

        public static void Pass2Initialize() => VoidSchema.Type.Initialize((DefaultConstructHandler)null, (ConstructorSchema[])null, (PropertySchema[])null, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
    }
}