﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.DebugSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.OS;
using System;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class DebugSchema
    {
        public static UIXTypeSchema Type;

        private static object CallTraceString(object instanceObj, object[] parameters)
        {
            NativeApi.SpLogTrace((string)null, (string)parameters[0], 0);
            return (object)null;
        }

        private static object CallTraceStringObject(object instanceObj, object[] parameters)
        {
            DebugSchema.Trace((string)parameters[0], parameters[1], (object)null, (object)null, (object)null, (object)null);
            return (object)null;
        }

        private static object CallTraceStringObjectObject(object instanceObj, object[] parameters)
        {
            DebugSchema.Trace((string)parameters[0], parameters[1], parameters[2], (object)null, (object)null, (object)null);
            return (object)null;
        }

        private static object CallTraceStringObjectObjectObject(object instanceObj, object[] parameters)
        {
            DebugSchema.Trace((string)parameters[0], parameters[1], parameters[2], parameters[3], (object)null, (object)null);
            return (object)null;
        }

        private static object CallTraceStringObjectObjectObjectObject(
          object instanceObj,
          object[] parameters)
        {
            DebugSchema.Trace((string)parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], (object)null);
            return (object)null;
        }

        private static object CallTraceStringObjectObjectObjectObjectObject(
          object instanceObj,
          object[] parameters)
        {
            DebugSchema.Trace((string)parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
            return (object)null;
        }

        private static void Trace(
          string format,
          object param1,
          object param2,
          object param3,
          object param4,
          object param5)
        {
            string message;
            try
            {
                message = string.Format(format, param1, param2, param3, param4, param5);
            }
            catch (FormatException ex)
            {
                message = string.Format("Invalid format for Debug.Trace [{0}].", (object)format);
            }
            NativeApi.SpLogTrace((string)null, message, 0);
        }

        public static void Pass1Initialize() => DebugSchema.Type = new UIXTypeSchema((short)49, "Debug", (string)null, (short)153, typeof(object), UIXTypeFlags.Static);

        public static void Pass2Initialize()
        {
            UIXMethodSchema uixMethodSchema1 = new UIXMethodSchema((short)49, "Trace", new short[1]
            {
        (short) 208
            }, (short)240, new InvokeHandler(DebugSchema.CallTraceString), true);
            UIXMethodSchema uixMethodSchema2 = new UIXMethodSchema((short)49, "Trace", new short[2]
            {
        (short) 208,
        (short) 153
            }, (short)240, new InvokeHandler(DebugSchema.CallTraceStringObject), true);
            UIXMethodSchema uixMethodSchema3 = new UIXMethodSchema((short)49, "Trace", new short[3]
            {
        (short) 208,
        (short) 153,
        (short) 153
            }, (short)240, new InvokeHandler(DebugSchema.CallTraceStringObjectObject), true);
            UIXMethodSchema uixMethodSchema4 = new UIXMethodSchema((short)49, "Trace", new short[4]
            {
        (short) 208,
        (short) 153,
        (short) 153,
        (short) 153
            }, (short)240, new InvokeHandler(DebugSchema.CallTraceStringObjectObjectObject), true);
            UIXMethodSchema uixMethodSchema5 = new UIXMethodSchema((short)49, "Trace", new short[5]
            {
        (short) 208,
        (short) 153,
        (short) 153,
        (short) 153,
        (short) 153
            }, (short)240, new InvokeHandler(DebugSchema.CallTraceStringObjectObjectObjectObject), true);
            UIXMethodSchema uixMethodSchema6 = new UIXMethodSchema((short)49, "Trace", new short[6]
            {
        (short) 208,
        (short) 153,
        (short) 153,
        (short) 153,
        (short) 153,
        (short) 153
            }, (short)240, new InvokeHandler(DebugSchema.CallTraceStringObjectObjectObjectObjectObject), true);
            DebugSchema.Type.Initialize((DefaultConstructHandler)null, (ConstructorSchema[])null, (PropertySchema[])null, new MethodSchema[6]
            {
        (MethodSchema) uixMethodSchema1,
        (MethodSchema) uixMethodSchema2,
        (MethodSchema) uixMethodSchema3,
        (MethodSchema) uixMethodSchema4,
        (MethodSchema) uixMethodSchema5,
        (MethodSchema) uixMethodSchema6
            }, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
        }
    }
}
