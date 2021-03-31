﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.ContrastSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Library;
using Microsoft.Iris.Render;
using Microsoft.Iris.Session;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class ContrastSchema
    {
        public static UIXTypeSchema Type;

        private static object GetContrast(object instanceObj) => (object)((ContrastElement)instanceObj).Contrast;

        private static void SetContrast(ref object instanceObj, object valueObj)
        {
            ContrastElement contrastElement = (ContrastElement)instanceObj;
            float num = (float)valueObj;
            Result result = SingleSchema.ValidateNotNegative(valueObj);
            if (result.Failed)
                ErrorManager.ReportError(result.Error);
            else
                contrastElement.Contrast = num;
        }

        private static object Construct() => (object)new ContrastElement();

        public static void Pass1Initialize() => ContrastSchema.Type = new UIXTypeSchema((short)42, "Contrast", (string)null, (short)80, typeof(ContrastElement), UIXTypeFlags.None);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema = new UIXPropertySchema((short)42, "Contrast", (short)194, (short)-1, ExpressionRestriction.None, false, SingleSchema.ValidateNotNegative, false, new GetValueHandler(ContrastSchema.GetContrast), new SetValueHandler(ContrastSchema.SetContrast), false);
            ContrastSchema.Type.Initialize(new DefaultConstructHandler(ContrastSchema.Construct), (ConstructorSchema[])null, new PropertySchema[1]
            {
        (PropertySchema) uixPropertySchema
            }, (MethodSchema[])null, (EventSchema[])null, (FindCanonicalInstanceHandler)null, (TypeConverterHandler)null, (SupportsTypeConversionHandler)null, (EncodeBinaryHandler)null, (DecodeBinaryHandler)null, (PerformOperationHandler)null, (SupportsOperationHandler)null);
        }
    }
}