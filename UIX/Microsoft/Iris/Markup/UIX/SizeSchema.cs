﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.SizeSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Data;
using Microsoft.Iris.Library;
using Microsoft.Iris.Render;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class SizeSchema
    {
        public static RangeValidator ValidateNotNegative = new RangeValidator(SizeSchema.RangeValidateNotNegative);
        public static UIXTypeSchema Type;

        private static object GetWidth(object instanceObj) => (object)((Size)instanceObj).Width;

        private static void SetWidth(ref object instanceObj, object valueObj)
        {
            Size size = (Size)instanceObj;
            int num = (int)valueObj;
            size.Width = num;
            instanceObj = (object)size;
        }

        private static object GetHeight(object instanceObj) => (object)((Size)instanceObj).Height;

        private static void SetHeight(ref object instanceObj, object valueObj)
        {
            Size size = (Size)instanceObj;
            int num = (int)valueObj;
            size.Height = num;
            instanceObj = (object)size;
        }

        private static object Construct() => (object)Size.Zero;

        private static object ConstructWidthHeight(object[] parameters)
        {
            object instanceObj = SizeSchema.Construct();
            SizeSchema.SetWidth(ref instanceObj, parameters[0]);
            SizeSchema.SetHeight(ref instanceObj, parameters[1]);
            return instanceObj;
        }

        private static Result ConvertFromStringWidthHeight(
          string[] splitString,
          out object instance)
        {
            instance = SizeSchema.Construct();
            object valueObj1;
            Result result1 = UIXLoadResult.ValidateStringAsValue(splitString[0], (TypeSchema)Int32Schema.Type, (RangeValidator)null, out valueObj1);
            if (result1.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Size", (object)result1.Error);
            SizeSchema.SetWidth(ref instance, valueObj1);
            object valueObj2;
            Result result2 = UIXLoadResult.ValidateStringAsValue(splitString[1], (TypeSchema)Int32Schema.Type, (RangeValidator)null, out valueObj2);
            if (result2.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Size", (object)result2.Error);
            SizeSchema.SetHeight(ref instance, valueObj2);
            return result2;
        }

        private static void EncodeBinary(ByteCodeWriter writer, object instanceObj)
        {
            Size size = (Size)instanceObj;
            writer.WriteInt32(size.Width);
            writer.WriteInt32(size.Height);
        }

        private static object DecodeBinary(ByteCodeReader reader) => (object)new Size(reader.ReadInt32(), reader.ReadInt32());

        private static bool IsConversionSupported(TypeSchema fromType) => StringSchema.Type.IsAssignableFrom(fromType);

        private static Result TryConvertFrom(
          object from,
          TypeSchema fromType,
          out object instance)
        {
            Result result = Result.Fail("Unsupported");
            instance = (object)null;
            if (StringSchema.Type.IsAssignableFrom(fromType))
            {
                string[] splitString = StringUtility.SplitAndTrim(',', (string)from);
                if (splitString.Length == 2)
                {
                    result = SizeSchema.ConvertFromStringWidthHeight(splitString, out instance);
                    if (!result.Failed)
                        return result;
                }
                else
                    result = Result.Fail("Unable to convert \"{0}\" to type '{1}'", (object)from.ToString(), (object)"Size");
            }
            return result;
        }

        private static Result RangeValidateNotNegative(object value)
        {
            Size size = (Size)value;
            return size.Width < 0 || size.Height < 0 ? Result.Fail("Expecting a non-negative value, but got {0}", (object)size.ToString()) : Result.Success;
        }

        public static void Pass1Initialize() => SizeSchema.Type = new UIXTypeSchema((short)195, "Size", (string)null, (short)153, typeof(Size), UIXTypeFlags.Immutable);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema1 = new UIXPropertySchema((short)195, "Width", (short)115, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(SizeSchema.GetWidth), new SetValueHandler(SizeSchema.SetWidth), false);
            UIXPropertySchema uixPropertySchema2 = new UIXPropertySchema((short)195, "Height", (short)115, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(SizeSchema.GetHeight), new SetValueHandler(SizeSchema.SetHeight), false);
            UIXConstructorSchema constructorSchema = new UIXConstructorSchema((short)195, new short[2]
            {
        (short) 115,
        (short) 115
            }, new ConstructHandler(SizeSchema.ConstructWidthHeight));
            SizeSchema.Type.Initialize(new DefaultConstructHandler(SizeSchema.Construct), new ConstructorSchema[1]
            {
        (ConstructorSchema) constructorSchema
            }, new PropertySchema[2]
            {
        (PropertySchema) uixPropertySchema2,
        (PropertySchema) uixPropertySchema1
            }, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, new TypeConverterHandler(SizeSchema.TryConvertFrom), new SupportsTypeConversionHandler(SizeSchema.IsConversionSupported), new EncodeBinaryHandler(SizeSchema.EncodeBinary), new DecodeBinaryHandler(SizeSchema.DecodeBinary), (PerformOperationHandler)null, (SupportsOperationHandler)null);
        }
    }
}
