﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.AnchorLayoutSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Data;
using Microsoft.Iris.Layout;
using Microsoft.Iris.Layouts;
using Microsoft.Iris.Library;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class AnchorLayoutSchema
    {
        public static UIXTypeSchema Type;

        private static object GetSizeToHorizontalChildren(object instanceObj) => BooleanBoxes.Box(((AnchorLayout)instanceObj).SizeToHorizontalChildren);

        private static void SetSizeToHorizontalChildren(ref object instanceObj, object valueObj) => ((AnchorLayout)instanceObj).SizeToHorizontalChildren = (bool)valueObj;

        private static object GetSizeToVerticalChildren(object instanceObj) => BooleanBoxes.Box(((AnchorLayout)instanceObj).SizeToVerticalChildren);

        private static void SetSizeToVerticalChildren(ref object instanceObj, object valueObj) => ((AnchorLayout)instanceObj).SizeToVerticalChildren = (bool)valueObj;

        private static object GetDefaultChildAlignment(object instanceObj) => ((AnchorLayout)instanceObj).DefaultChildAlignment;

        private static void SetDefaultChildAlignment(ref object instanceObj, object valueObj) => ((AnchorLayout)instanceObj).DefaultChildAlignment = (ItemAlignment)valueObj;

        private static object Construct() => new AnchorLayout();

        private static object ConstructSizeToHorizontalChildrenSizeToVerticalChildren(
          object[] parameters)
        {
            object instanceObj = AnchorLayoutSchema.Construct();
            AnchorLayoutSchema.SetSizeToHorizontalChildren(ref instanceObj, parameters[0]);
            AnchorLayoutSchema.SetSizeToVerticalChildren(ref instanceObj, parameters[1]);
            return instanceObj;
        }

        private static Result ConvertFromStringSizeToHorizontalChildrenSizeToVerticalChildren(
          string[] splitString,
          out object instance)
        {
            instance = AnchorLayoutSchema.Construct();
            object valueObj1;
            Result result1 = UIXLoadResult.ValidateStringAsValue(splitString[0], BooleanSchema.Type, null, out valueObj1);
            if (result1.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", "AnchorLayout", result1.Error);
            AnchorLayoutSchema.SetSizeToHorizontalChildren(ref instance, valueObj1);
            object valueObj2;
            Result result2 = UIXLoadResult.ValidateStringAsValue(splitString[1], BooleanSchema.Type, null, out valueObj2);
            if (result2.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", "AnchorLayout", result2.Error);
            AnchorLayoutSchema.SetSizeToVerticalChildren(ref instance, valueObj2);
            return result2;
        }

        private static bool IsConversionSupported(TypeSchema fromType) => StringSchema.Type.IsAssignableFrom(fromType);

        private static Result TryConvertFrom(
          object from,
          TypeSchema fromType,
          out object instance)
        {
            Result result = Result.Fail("Unsupported");
            instance = null;
            if (StringSchema.Type.IsAssignableFrom(fromType))
            {
                string[] splitString = StringUtility.SplitAndTrim(',', (string)from);
                if (splitString.Length == 2)
                {
                    result = AnchorLayoutSchema.ConvertFromStringSizeToHorizontalChildrenSizeToVerticalChildren(splitString, out instance);
                    if (!result.Failed)
                        return result;
                }
                else
                    result = Result.Fail("Unable to convert \"{0}\" to type '{1}'", from.ToString(), "AnchorLayout");
            }
            return result;
        }

        public static void Pass1Initialize() => AnchorLayoutSchema.Type = new UIXTypeSchema(7, "AnchorLayout", null, 132, typeof(AnchorLayout), UIXTypeFlags.Immutable);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema1 = new UIXPropertySchema(7, "SizeToHorizontalChildren", 15, -1, ExpressionRestriction.None, false, null, false, new GetValueHandler(AnchorLayoutSchema.GetSizeToHorizontalChildren), new SetValueHandler(AnchorLayoutSchema.SetSizeToHorizontalChildren), false);
            UIXPropertySchema uixPropertySchema2 = new UIXPropertySchema(7, "SizeToVerticalChildren", 15, -1, ExpressionRestriction.None, false, null, false, new GetValueHandler(AnchorLayoutSchema.GetSizeToVerticalChildren), new SetValueHandler(AnchorLayoutSchema.SetSizeToVerticalChildren), false);
            UIXPropertySchema uixPropertySchema3 = new UIXPropertySchema(7, "DefaultChildAlignment", sbyte.MaxValue, -1, ExpressionRestriction.None, false, null, false, new GetValueHandler(AnchorLayoutSchema.GetDefaultChildAlignment), new SetValueHandler(AnchorLayoutSchema.SetDefaultChildAlignment), false);
            UIXConstructorSchema constructorSchema = new UIXConstructorSchema(7, new short[2]
            {
         15,
         15
            }, new ConstructHandler(AnchorLayoutSchema.ConstructSizeToHorizontalChildrenSizeToVerticalChildren));
            AnchorLayoutSchema.Type.Initialize(new DefaultConstructHandler(AnchorLayoutSchema.Construct), new ConstructorSchema[1]
            {
         constructorSchema
            }, new PropertySchema[3]
            {
         uixPropertySchema3,
         uixPropertySchema1,
         uixPropertySchema2
            }, null, null, null, new TypeConverterHandler(AnchorLayoutSchema.TryConvertFrom), new SupportsTypeConversionHandler(AnchorLayoutSchema.IsConversionSupported), null, null, null, null);
        }
    }
}
