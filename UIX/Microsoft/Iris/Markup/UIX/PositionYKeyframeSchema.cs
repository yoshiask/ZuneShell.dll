﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.PositionYKeyframeSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Animations;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class PositionYKeyframeSchema
    {
        public static UIXTypeSchema Type;

        private static object GetValue(object instanceObj) => ((BaseFloatKeyframe)instanceObj).Value;

        private static void SetValue(ref object instanceObj, object valueObj) => ((BaseFloatKeyframe)instanceObj).Value = (float)valueObj;

        private static object Construct() => new PositionYKeyframe();

        public static void Pass1Initialize() => PositionYKeyframeSchema.Type = new UIXTypeSchema(166, "PositionYKeyframe", null, 130, typeof(PositionYKeyframe), UIXTypeFlags.None);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema = new UIXPropertySchema(166, "Value", 194, -1, ExpressionRestriction.None, false, null, false, new GetValueHandler(PositionYKeyframeSchema.GetValue), new SetValueHandler(PositionYKeyframeSchema.SetValue), false);
            PositionYKeyframeSchema.Type.Initialize(new DefaultConstructHandler(PositionYKeyframeSchema.Construct), null, new PropertySchema[1]
            {
         uixPropertySchema
            }, null, null, null, null, null, null, null, null, null);
        }
    }
}
