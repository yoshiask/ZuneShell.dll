﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.EnumeratorSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using System.Collections;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class EnumeratorSchema
    {
        public static UIXTypeSchema Type;

        private static object GetCurrent(object instanceObj) => ((IEnumerator)instanceObj).Current;

        private static object CallMoveNext(object instanceObj, object[] parameters) => BooleanBoxes.Box(((IEnumerator)instanceObj).MoveNext());

        private static object CallReset(object instanceObj, object[] parameters)
        {
            ((IEnumerator)instanceObj).Reset();
            return (object)null;
        }

        public static void Pass1Initialize() => EnumeratorSchema.Type = new UIXTypeSchema((short)86, "Enumerator", (string)null, (short)153, typeof(IEnumerator), UIXTypeFlags.None);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema = new UIXPropertySchema((short)86, "Current", (short)153, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, true, new GetValueHandler(EnumeratorSchema.GetCurrent), (SetValueHandler)null, false);
            UIXMethodSchema uixMethodSchema1 = new UIXMethodSchema((short)86, "MoveNext", (short[])null, (short)15, new InvokeHandler(EnumeratorSchema.CallMoveNext), false);
            UIXMethodSchema uixMethodSchema2 = new UIXMethodSchema((short)86, "Reset", (short[])null, (short)240, new InvokeHandler(EnumeratorSchema.CallReset), false);
            EnumeratorSchema.Type.Initialize((DefaultConstructHandler)null, (ConstructorSchema[])null, new PropertySchema[1]
            {
        (PropertySchema) uixPropertySchema
            }, new MethodSchema[2]
            {
        (MethodSchema) uixMethodSchema1,
        (MethodSchema) uixMethodSchema2
            }, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
        }
    }
}
