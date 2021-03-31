﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.Vector3Schema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Data;
using Microsoft.Iris.Library;
using Microsoft.Iris.Render;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class Vector3Schema
    {
        public static UIXTypeSchema Type;

        private static object GetX(object instanceObj) => (object)((Vector3)instanceObj).X;

        private static void SetX(ref object instanceObj, object valueObj)
        {
            Vector3 vector3 = (Vector3)instanceObj;
            float num = (float)valueObj;
            vector3.X = num;
            instanceObj = (object)vector3;
        }

        private static object GetY(object instanceObj) => (object)((Vector3)instanceObj).Y;

        private static void SetY(ref object instanceObj, object valueObj)
        {
            Vector3 vector3 = (Vector3)instanceObj;
            float num = (float)valueObj;
            vector3.Y = num;
            instanceObj = (object)vector3;
        }

        private static object GetZ(object instanceObj) => (object)((Vector3)instanceObj).Z;

        private static void SetZ(ref object instanceObj, object valueObj)
        {
            Vector3 vector3 = (Vector3)instanceObj;
            float num = (float)valueObj;
            vector3.Z = num;
            instanceObj = (object)vector3;
        }

        private static object Construct() => (object)Vector3.Zero;

        private static object ConstructXYZ(object[] parameters)
        {
            object instanceObj = Vector3Schema.Construct();
            Vector3Schema.SetX(ref instanceObj, parameters[0]);
            Vector3Schema.SetY(ref instanceObj, parameters[1]);
            Vector3Schema.SetZ(ref instanceObj, parameters[2]);
            return instanceObj;
        }

        private static Result ConvertFromStringXYZ(string[] splitString, out object instance)
        {
            instance = Vector3Schema.Construct();
            object valueObj1;
            Result result1 = UIXLoadResult.ValidateStringAsValue(splitString[0], (TypeSchema)SingleSchema.Type, (RangeValidator)null, out valueObj1);
            if (result1.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Vector3", (object)result1.Error);
            Vector3Schema.SetX(ref instance, valueObj1);
            object valueObj2;
            Result result2 = UIXLoadResult.ValidateStringAsValue(splitString[1], (TypeSchema)SingleSchema.Type, (RangeValidator)null, out valueObj2);
            if (result2.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Vector3", (object)result2.Error);
            Vector3Schema.SetY(ref instance, valueObj2);
            object valueObj3;
            Result result3 = UIXLoadResult.ValidateStringAsValue(splitString[2], (TypeSchema)SingleSchema.Type, (RangeValidator)null, out valueObj3);
            if (result3.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Vector3", (object)result3.Error);
            Vector3Schema.SetZ(ref instance, valueObj3);
            return result3;
        }

        private static void EncodeBinary(ByteCodeWriter writer, object instanceObj)
        {
            Vector3 vector3 = (Vector3)instanceObj;
            writer.WriteSingle(vector3.X);
            writer.WriteSingle(vector3.Y);
            writer.WriteSingle(vector3.Z);
        }

        private static object DecodeBinary(ByteCodeReader reader) => (object)new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

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
                if (splitString.Length == 3)
                {
                    result = Vector3Schema.ConvertFromStringXYZ(splitString, out instance);
                    if (!result.Failed)
                        return result;
                }
                else
                    result = Result.Fail("Unable to convert \"{0}\" to type '{1}'", (object)from.ToString(), (object)"Vector3");
            }
            return result;
        }

        private static bool IsOperationSupported(OperationType op)
        {
            switch (op)
            {
                case OperationType.MathAdd:
                case OperationType.MathSubtract:
                case OperationType.MathMultiply:
                case OperationType.MathDivide:
                case OperationType.RelationalEquals:
                case OperationType.RelationalNotEquals:
                case OperationType.MathNegate:
                    return true;
                default:
                    return false;
            }
        }

        private static object ExecuteOperation(object leftObj, object rightObj, OperationType op)
        {
            Vector3 vector3_1 = (Vector3)leftObj;
            if (op == OperationType.MathNegate)
                return (object)-vector3_1;
            Vector3 vector3_2 = (Vector3)rightObj;
            switch (op - 1)
            {
                case (OperationType)0:
                    return (object)(vector3_1 + vector3_2);
                case OperationType.MathAdd:
                    return (object)(vector3_1 - vector3_2);
                case OperationType.MathSubtract:
                    return (object)(vector3_1 * vector3_2);
                case OperationType.MathMultiply:
                    return (object)(vector3_1 / vector3_2);
                case OperationType.LogicalOr:
                    return BooleanBoxes.Box(vector3_1 == vector3_2);
                case OperationType.RelationalEquals:
                    return BooleanBoxes.Box(vector3_1 != vector3_2);
                default:
                    return (object)null;
            }
        }

        public static void Pass1Initialize() => Vector3Schema.Type = new UIXTypeSchema((short)234, "Vector3", (string)null, (short)153, typeof(Vector3), UIXTypeFlags.Immutable);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema1 = new UIXPropertySchema((short)234, "X", (short)194, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(Vector3Schema.GetX), new SetValueHandler(Vector3Schema.SetX), false);
            UIXPropertySchema uixPropertySchema2 = new UIXPropertySchema((short)234, "Y", (short)194, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(Vector3Schema.GetY), new SetValueHandler(Vector3Schema.SetY), false);
            UIXPropertySchema uixPropertySchema3 = new UIXPropertySchema((short)234, "Z", (short)194, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(Vector3Schema.GetZ), new SetValueHandler(Vector3Schema.SetZ), false);
            UIXConstructorSchema constructorSchema = new UIXConstructorSchema((short)234, new short[3]
            {
        (short) 194,
        (short) 194,
        (short) 194
            }, new ConstructHandler(Vector3Schema.ConstructXYZ));
            Vector3Schema.Type.Initialize(new DefaultConstructHandler(Vector3Schema.Construct), new ConstructorSchema[1]
            {
        (ConstructorSchema) constructorSchema
            }, new PropertySchema[3]
            {
        (PropertySchema) uixPropertySchema1,
        (PropertySchema) uixPropertySchema2,
        (PropertySchema) uixPropertySchema3
            }, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, new TypeConverterHandler(Vector3Schema.TryConvertFrom), new SupportsTypeConversionHandler(Vector3Schema.IsConversionSupported), new EncodeBinaryHandler(Vector3Schema.EncodeBinary), new DecodeBinaryHandler(Vector3Schema.DecodeBinary), new PerformOperationHandler(Vector3Schema.ExecuteOperation), new SupportsOperationHandler(Vector3Schema.IsOperationSupported));
        }
    }
}