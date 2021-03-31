﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.ImageElementSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Drawing;
using Microsoft.Iris.Render;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class ImageElementSchema
    {
        public static UIXTypeSchema Type;

        private static void SetImage(ref object instanceObj, object valueObj) => ((ImageElement)instanceObj).Image = ((UIImage)valueObj)?.RenderImage;

        private static object GetUVOffset(object instanceObj) => (object)((ImageElement)instanceObj).UVOffset;

        private static void SetUVOffset(ref object instanceObj, object valueObj) => ((ImageElement)instanceObj).UVOffset = (Vector2)valueObj;

        private static object Construct() => (object)new ImageElement();

        public static void Pass1Initialize() => ImageElementSchema.Type = new UIXTypeSchema((short)106, "ImageElement", (string)null, (short)77, typeof(ImageElement), UIXTypeFlags.None);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema1 = new UIXPropertySchema((short)106, "Image", (short)105, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, (GetValueHandler)null, new SetValueHandler(ImageElementSchema.SetImage), false);
            UIXPropertySchema uixPropertySchema2 = new UIXPropertySchema((short)106, "UVOffset", (short)233, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(ImageElementSchema.GetUVOffset), new SetValueHandler(ImageElementSchema.SetUVOffset), false);
            ImageElementSchema.Type.Initialize(new DefaultConstructHandler(ImageElementSchema.Construct), (ConstructorSchema[])null, new PropertySchema[2]
            {
        (PropertySchema) uixPropertySchema1,
        (PropertySchema) uixPropertySchema2
            }, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
        }
    }
}