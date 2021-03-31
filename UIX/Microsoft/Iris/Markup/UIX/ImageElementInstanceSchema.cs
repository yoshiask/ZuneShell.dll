﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.ImageElementInstanceSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Drawing;
using Microsoft.Iris.Render;
using Microsoft.Iris.UI;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class ImageElementInstanceSchema
    {
        public static UIXTypeSchema Type;

        private static void SetImage(ref object instanceObj, object valueObj) => ((EffectElementWrapper)instanceObj).SetProperty("Image", (UIImage)valueObj);

        private static void SetUVOffset(ref object instanceObj, object valueObj) => ((EffectElementWrapper)instanceObj).SetProperty("UVOffset", (Vector2)valueObj);

        public static void Pass1Initialize() => ImageElementInstanceSchema.Type = new UIXTypeSchema((short)107, "ImageElementInstance", (string)null, (short)74, typeof(EffectElementWrapper), UIXTypeFlags.None);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema1 = new UIXPropertySchema((short)107, "Image", (short)105, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, (GetValueHandler)null, new SetValueHandler(ImageElementInstanceSchema.SetImage), false);
            UIXPropertySchema uixPropertySchema2 = new UIXPropertySchema((short)107, "UVOffset", (short)233, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, (GetValueHandler)null, new SetValueHandler(ImageElementInstanceSchema.SetUVOffset), false);
            ImageElementInstanceSchema.Type.Initialize((DefaultConstructHandler)null, (ConstructorSchema[])null, new PropertySchema[2]
            {
        (PropertySchema) uixPropertySchema1,
        (PropertySchema) uixPropertySchema2
            }, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
        }
    }
}
