﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.SizeXKeyframeSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Animations;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class SizeXKeyframeSchema
    {
        public static UIXTypeSchema Type;

        private static object GetValue(object instanceObj) => ((BaseFloatKeyframe)instanceObj).Value;

        private static void SetValue(ref object instanceObj, object valueObj) => ((BaseFloatKeyframe)instanceObj).Value = (float)valueObj;

        private static object Construct() => new SizeXKeyframe();

        public static void Pass1Initialize() => SizeXKeyframeSchema.Type = new UIXTypeSchema(197, "SizeXKeyframe", null, 130, typeof(SizeXKeyframe), UIXTypeFlags.None);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema = new UIXPropertySchema(197, "Value", 194, -1, ExpressionRestriction.None, false, null, false, new GetValueHandler(SizeXKeyframeSchema.GetValue), new SetValueHandler(SizeXKeyframeSchema.SetValue), false);
            SizeXKeyframeSchema.Type.Initialize(new DefaultConstructHandler(SizeXKeyframeSchema.Construct), null, new PropertySchema[1]
            {
         uixPropertySchema
            }, null, null, null, null, null, null, null, null, null);
        }
    }
}
