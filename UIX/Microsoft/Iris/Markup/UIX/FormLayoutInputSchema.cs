﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.FormLayoutInputSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Layouts;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class FormLayoutInputSchema
    {
        public static UIXTypeSchema Type;

        private static object Construct() => (object)new FormLayoutInput();

        public static void Pass1Initialize() => FormLayoutInputSchema.Type = new UIXTypeSchema((short)95, "FormLayoutInput", (string)null, (short)8, typeof(FormLayoutInput), UIXTypeFlags.None);

        public static void Pass2Initialize() => FormLayoutInputSchema.Type.Initialize(new DefaultConstructHandler(FormLayoutInputSchema.Construct), (ConstructorSchema[])null, (PropertySchema[])null, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
    }
}
