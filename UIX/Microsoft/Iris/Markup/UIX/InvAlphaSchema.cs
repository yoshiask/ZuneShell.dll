﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.InvAlphaSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Render;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class InvAlphaSchema
    {
        public static UIXTypeSchema Type;

        private static object Construct() => (object)new InvAlphaElement();

        public static void Pass1Initialize() => InvAlphaSchema.Type = new UIXTypeSchema((short)123, "InvAlpha", (string)null, (short)80, typeof(InvAlphaElement), UIXTypeFlags.None);

        public static void Pass2Initialize() => InvAlphaSchema.Type.Initialize(new DefaultConstructHandler(InvAlphaSchema.Construct), (ConstructorSchema[])null, (PropertySchema[])null, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
    }
}