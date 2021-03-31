﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.UIX.ColorSchema
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Data;
using Microsoft.Iris.Drawing;
using Microsoft.Iris.Library;
using Microsoft.Iris.Session;
using System.Collections.Generic;

namespace Microsoft.Iris.Markup.UIX
{
    internal static class ColorSchema
    {
        private static Dictionary<string, uint> s_NameToColorMap;
        private static readonly object s_Default = (object)new Color((int)byte.MaxValue, 0, 0, 0);
        public static UIXTypeSchema Type;

        private static object GetAlpha(object instanceObj) => (object)(float)((double)((Color)instanceObj).A / (double)byte.MaxValue);

        private static void SetAlpha(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            float num = (float)valueObj;
            Result result = SingleSchema.Validate0to1(valueObj);
            if (result.Failed)
            {
                ErrorManager.ReportError(result.Error);
            }
            else
            {
                color.A = (byte)((double)num * (double)byte.MaxValue);
                instanceObj = (object)color;
            }
        }

        private static object GetRed(object instanceObj) => (object)(float)((double)((Color)instanceObj).R / (double)byte.MaxValue);

        private static void SetRed(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            float num = (float)valueObj;
            Result result = SingleSchema.Validate0to1(valueObj);
            if (result.Failed)
            {
                ErrorManager.ReportError(result.Error);
            }
            else
            {
                color.R = (byte)((double)num * (double)byte.MaxValue);
                instanceObj = (object)color;
            }
        }

        private static object GetGreen(object instanceObj) => (object)(float)((double)((Color)instanceObj).G / (double)byte.MaxValue);

        private static void SetGreen(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            float num = (float)valueObj;
            Result result = SingleSchema.Validate0to1(valueObj);
            if (result.Failed)
            {
                ErrorManager.ReportError(result.Error);
            }
            else
            {
                color.G = (byte)((double)num * (double)byte.MaxValue);
                instanceObj = (object)color;
            }
        }

        private static object GetBlue(object instanceObj) => (object)(float)((double)((Color)instanceObj).B / (double)byte.MaxValue);

        private static void SetBlue(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            float num = (float)valueObj;
            Result result = SingleSchema.Validate0to1(valueObj);
            if (result.Failed)
            {
                ErrorManager.ReportError(result.Error);
            }
            else
            {
                color.B = (byte)((double)num * (double)byte.MaxValue);
                instanceObj = (object)color;
            }
        }

        private static object GetA(object instanceObj) => (object)((Color)instanceObj).A;

        private static void SetA(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            byte num = (byte)valueObj;
            color.A = num;
            instanceObj = (object)color;
        }

        private static object GetR(object instanceObj) => (object)((Color)instanceObj).R;

        private static void SetR(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            byte num = (byte)valueObj;
            color.R = num;
            instanceObj = (object)color;
        }

        private static object GetG(object instanceObj) => (object)((Color)instanceObj).G;

        private static void SetG(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            byte num = (byte)valueObj;
            color.G = num;
            instanceObj = (object)color;
        }

        private static object GetB(object instanceObj) => (object)((Color)instanceObj).B;

        private static void SetB(ref object instanceObj, object valueObj)
        {
            Color color = (Color)instanceObj;
            byte num = (byte)valueObj;
            color.B = num;
            instanceObj = (object)color;
        }

        private static object Construct() => ColorSchema.s_Default;

        private static object ConstructAlphaRedGreenBlue(object[] parameters)
        {
            object instanceObj = ColorSchema.Construct();
            ColorSchema.SetAlpha(ref instanceObj, parameters[0]);
            ColorSchema.SetRed(ref instanceObj, parameters[1]);
            ColorSchema.SetGreen(ref instanceObj, parameters[2]);
            ColorSchema.SetBlue(ref instanceObj, parameters[3]);
            return instanceObj;
        }

        private static Result ConvertFromStringAlphaRedGreenBlue(
          string[] splitString,
          out object instance)
        {
            instance = ColorSchema.Construct();
            object valueObj1;
            Result result1 = UIXLoadResult.ValidateStringAsValue(splitString[0], (TypeSchema)SingleSchema.Type, SingleSchema.Validate0to1, out valueObj1);
            if (result1.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result1.Error);
            ColorSchema.SetAlpha(ref instance, valueObj1);
            object valueObj2;
            Result result2 = UIXLoadResult.ValidateStringAsValue(splitString[1], (TypeSchema)SingleSchema.Type, SingleSchema.Validate0to1, out valueObj2);
            if (result2.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result2.Error);
            ColorSchema.SetRed(ref instance, valueObj2);
            object valueObj3;
            Result result3 = UIXLoadResult.ValidateStringAsValue(splitString[2], (TypeSchema)SingleSchema.Type, SingleSchema.Validate0to1, out valueObj3);
            if (result3.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result3.Error);
            ColorSchema.SetGreen(ref instance, valueObj3);
            object valueObj4;
            Result result4 = UIXLoadResult.ValidateStringAsValue(splitString[3], (TypeSchema)SingleSchema.Type, SingleSchema.Validate0to1, out valueObj4);
            if (result4.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result4.Error);
            ColorSchema.SetBlue(ref instance, valueObj4);
            return result4;
        }

        private static object ConstructARGB(object[] parameters)
        {
            object instanceObj = ColorSchema.Construct();
            ColorSchema.SetA(ref instanceObj, parameters[0]);
            ColorSchema.SetR(ref instanceObj, parameters[1]);
            ColorSchema.SetG(ref instanceObj, parameters[2]);
            ColorSchema.SetB(ref instanceObj, parameters[3]);
            return instanceObj;
        }

        private static Result ConvertFromStringARGB(string[] splitString, out object instance)
        {
            instance = ColorSchema.Construct();
            object valueObj1;
            Result result1 = UIXLoadResult.ValidateStringAsValue(splitString[0], (TypeSchema)ByteSchema.Type, (RangeValidator)null, out valueObj1);
            if (result1.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result1.Error);
            ColorSchema.SetA(ref instance, valueObj1);
            object valueObj2;
            Result result2 = UIXLoadResult.ValidateStringAsValue(splitString[1], (TypeSchema)ByteSchema.Type, (RangeValidator)null, out valueObj2);
            if (result2.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result2.Error);
            ColorSchema.SetR(ref instance, valueObj2);
            object valueObj3;
            Result result3 = UIXLoadResult.ValidateStringAsValue(splitString[2], (TypeSchema)ByteSchema.Type, (RangeValidator)null, out valueObj3);
            if (result3.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result3.Error);
            ColorSchema.SetG(ref instance, valueObj3);
            object valueObj4;
            Result result4 = UIXLoadResult.ValidateStringAsValue(splitString[3], (TypeSchema)ByteSchema.Type, (RangeValidator)null, out valueObj4);
            if (result4.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result4.Error);
            ColorSchema.SetB(ref instance, valueObj4);
            return result4;
        }

        private static object ConstructRedGreenBlue(object[] parameters)
        {
            object instanceObj = ColorSchema.Construct();
            ColorSchema.SetRed(ref instanceObj, parameters[0]);
            ColorSchema.SetGreen(ref instanceObj, parameters[1]);
            ColorSchema.SetBlue(ref instanceObj, parameters[2]);
            return instanceObj;
        }

        private static Result ConvertFromStringRedGreenBlue(
          string[] splitString,
          out object instance)
        {
            instance = ColorSchema.Construct();
            object valueObj1;
            Result result1 = UIXLoadResult.ValidateStringAsValue(splitString[0], (TypeSchema)SingleSchema.Type, SingleSchema.Validate0to1, out valueObj1);
            if (result1.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result1.Error);
            ColorSchema.SetRed(ref instance, valueObj1);
            object valueObj2;
            Result result2 = UIXLoadResult.ValidateStringAsValue(splitString[1], (TypeSchema)SingleSchema.Type, SingleSchema.Validate0to1, out valueObj2);
            if (result2.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result2.Error);
            ColorSchema.SetGreen(ref instance, valueObj2);
            object valueObj3;
            Result result3 = UIXLoadResult.ValidateStringAsValue(splitString[2], (TypeSchema)SingleSchema.Type, SingleSchema.Validate0to1, out valueObj3);
            if (result3.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result3.Error);
            ColorSchema.SetBlue(ref instance, valueObj3);
            return result3;
        }

        private static object ConstructRGB(object[] parameters)
        {
            object instanceObj = ColorSchema.Construct();
            ColorSchema.SetR(ref instanceObj, parameters[0]);
            ColorSchema.SetG(ref instanceObj, parameters[1]);
            ColorSchema.SetB(ref instanceObj, parameters[2]);
            return instanceObj;
        }

        private static Result ConvertFromStringRGB(string[] splitString, out object instance)
        {
            instance = ColorSchema.Construct();
            object valueObj1;
            Result result1 = UIXLoadResult.ValidateStringAsValue(splitString[0], (TypeSchema)ByteSchema.Type, (RangeValidator)null, out valueObj1);
            if (result1.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result1.Error);
            ColorSchema.SetR(ref instance, valueObj1);
            object valueObj2;
            Result result2 = UIXLoadResult.ValidateStringAsValue(splitString[1], (TypeSchema)ByteSchema.Type, (RangeValidator)null, out valueObj2);
            if (result2.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result2.Error);
            ColorSchema.SetG(ref instance, valueObj2);
            object valueObj3;
            Result result3 = UIXLoadResult.ValidateStringAsValue(splitString[2], (TypeSchema)ByteSchema.Type, (RangeValidator)null, out valueObj3);
            if (result3.Failed)
                return Result.Fail("Problem converting '{0}' ({1})", (object)"Color", (object)result3.Error);
            ColorSchema.SetB(ref instance, valueObj3);
            return result3;
        }

        private static void EncodeBinary(ByteCodeWriter writer, object instanceObj)
        {
            Color color = (Color)instanceObj;
            writer.WriteUInt32(color.Value);
        }

        private static object DecodeBinary(ByteCodeReader reader) => (object)new Color(reader.ReadUInt32());

        private static Result ConvertFromString(object valueObj, out object instanceObj)
        {
            string str = (string)valueObj;
            instanceObj = (object)null;
            uint num;
            if (!ColorSchema.s_NameToColorMap.TryGetValue(str.ToLowerInvariant(), out num))
                return Result.Fail("Unable to convert \"{0}\" to type '{1}'", (object)str, (object)"Color");
            Color color = new Color(num);
            instanceObj = (object)color;
            return Result.Success;
        }

        private static object FindCanonicalInstance(string name)
        {
            uint num;
            return ColorSchema.s_NameToColorMap.TryGetValue(name.ToLowerInvariant(), out num) ? (object)new Color(num) : (object)null;
        }

        private static bool IsConversionSupported(TypeSchema fromType) => StringSchema.Type.IsAssignableFrom(fromType);

        private static Result TryConvertFrom(
          object from,
          TypeSchema fromType,
          out object instance)
        {
            Result result1 = Result.Fail("Unsupported");
            instance = (object)null;
            if (StringSchema.Type.IsAssignableFrom(fromType))
            {
                result1 = ColorSchema.ConvertFromString(from, out instance);
                if (!result1.Failed)
                    return result1;
            }
            if (StringSchema.Type.IsAssignableFrom(fromType))
            {
                string[] splitString = StringUtility.SplitAndTrim(',', (string)from);
                switch (splitString.Length)
                {
                    case 3:
                        Result result2 = ColorSchema.ConvertFromStringRedGreenBlue(splitString, out instance);
                        if (!result2.Failed)
                            return result2;
                        result1 = ColorSchema.ConvertFromStringRGB(splitString, out instance);
                        if (!result1.Failed)
                            return result1;
                        break;
                    case 4:
                        Result result3 = ColorSchema.ConvertFromStringAlphaRedGreenBlue(splitString, out instance);
                        if (!result3.Failed)
                            return result3;
                        result1 = ColorSchema.ConvertFromStringARGB(splitString, out instance);
                        if (!result1.Failed)
                            return result1;
                        break;
                    default:
                        result1 = Result.Fail("Unable to convert \"{0}\" to type '{1}'", (object)from.ToString(), (object)"Color");
                        break;
                }
            }
            return result1;
        }

        private static object CallTryParseStringColor(object instanceObj, object[] parameters)
        {
            string parameter1 = (string)parameters[0];
            Color parameter2 = (Color)parameters[1];
            object instanceObj1;
            return ColorSchema.ConvertFromString((object)parameter1, out instanceObj1).Failed ? (object)parameter2 : instanceObj1;
        }

        static ColorSchema() => ColorSchema.s_NameToColorMap = new Dictionary<string, uint>(153)
    {
      {
        "aliceblue",
        4293982463U
      },
      {
        "antiquewhite",
        4294634455U
      },
      {
        "aqua",
        4278255615U
      },
      {
        "aquamarine",
        4286578644U
      },
      {
        "azure",
        4293984255U
      },
      {
        "beige",
        4294309340U
      },
      {
        "bisque",
        4294960324U
      },
      {
        "black",
        4278190080U
      },
      {
        "blanchedalmond",
        4294962125U
      },
      {
        "blue",
        4278190335U
      },
      {
        "blueviolet",
        4287245282U
      },
      {
        "brown",
        4289014314U
      },
      {
        "burlywood",
        4292786311U
      },
      {
        "cadetblue",
        4284456608U
      },
      {
        "chartreuse",
        4286578432U
      },
      {
        "chocolate",
        4291979550U
      },
      {
        "coral",
        4294934352U
      },
      {
        "cornflowerblue",
        4284782061U
      },
      {
        "cornsilk",
        4294965468U
      },
      {
        "crimson",
        4292613180U
      },
      {
        "cyan",
        4278255615U
      },
      {
        "darkblue",
        4278190219U
      },
      {
        "darkcyan",
        4278225803U
      },
      {
        "darkgoldenrod",
        4290283019U
      },
      {
        "darkgray",
        4289309097U
      },
      {
        "darkgreen",
        4278215680U
      },
      {
        "darkgrey",
        4289309097U
      },
      {
        "darkkhaki",
        4290623339U
      },
      {
        "darkmagenta",
        4287299723U
      },
      {
        "darkolivegreen",
        4283788079U
      },
      {
        "darkorange",
        4294937600U
      },
      {
        "darkorchid",
        4288230092U
      },
      {
        "darkred",
        4287299584U
      },
      {
        "darksalmon",
        4293498490U
      },
      {
        "darkseagreen",
        4287609999U
      },
      {
        "darkslateblue",
        4282924427U
      },
      {
        "darkslategray",
        4281290575U
      },
      {
        "darkslategrey",
        4281290575U
      },
      {
        "darkturquoise",
        4278243025U
      },
      {
        "darkviolet",
        4287889619U
      },
      {
        "deeppink",
        4294907027U
      },
      {
        "deepskyblue",
        4278239231U
      },
      {
        "dimgray",
        4285098345U
      },
      {
        "dimgrey",
        4285098345U
      },
      {
        "dodgerblue",
        4280193279U
      },
      {
        "feldspar",
        4291924597U
      },
      {
        "firebrick",
        4289864226U
      },
      {
        "floralwhite",
        4294966000U
      },
      {
        "forestgreen",
        4280453922U
      },
      {
        "fuchsia",
        4294902015U
      },
      {
        "gainsboro",
        4292664540U
      },
      {
        "ghostwhite",
        4294506751U
      },
      {
        "gold",
        4294956800U
      },
      {
        "goldenrod",
        4292519200U
      },
      {
        "gray",
        4286611584U
      },
      {
        "green",
        4278222848U
      },
      {
        "greenyellow",
        4289593135U
      },
      {
        "grey",
        4286611584U
      },
      {
        "honeydew",
        4293984240U
      },
      {
        "hotpink",
        4294928820U
      },
      {
        "indianred",
        4291648604U
      },
      {
        "indigo",
        4283105410U
      },
      {
        "ivory",
        4294967280U
      },
      {
        "khaki",
        4293977740U
      },
      {
        "lavender",
        4293322490U
      },
      {
        "lavenderblush",
        4294963445U
      },
      {
        "lawngreen",
        4286381056U
      },
      {
        "lemonchiffon",
        4294965965U
      },
      {
        "lightblue",
        4289583334U
      },
      {
        "lightcoral",
        4293951616U
      },
      {
        "lightcyan",
        4292935679U
      },
      {
        "lightgoldenrodyellow",
        4294638290U
      },
      {
        "lightgray",
        4292072403U
      },
      {
        "lightgreen",
        4287688336U
      },
      {
        "lightgrey",
        4292072403U
      },
      {
        "lightpink",
        4294948545U
      },
      {
        "lightsalmon",
        4294942842U
      },
      {
        "lightseagreen",
        4280332970U
      },
      {
        "lightskyblue",
        4287090426U
      },
      {
        "lightslateblue",
        4286869759U
      },
      {
        "lightslategray",
        4286023833U
      },
      {
        "lightslategrey",
        4286023833U
      },
      {
        "lightsteelblue",
        4289774814U
      },
      {
        "lightyellow",
        4294967264U
      },
      {
        "lime",
        4278255360U
      },
      {
        "limegreen",
        4281519410U
      },
      {
        "linen",
        4294635750U
      },
      {
        "magenta",
        4294902015U
      },
      {
        "maroon",
        4286578688U
      },
      {
        "mediumaquamarine",
        4284927402U
      },
      {
        "mediumblue",
        4278190285U
      },
      {
        "mediumorchid",
        4290401747U
      },
      {
        "mediumpurple",
        4287852760U
      },
      {
        "mediumseagreen",
        4282168177U
      },
      {
        "mediumslateblue",
        4286277870U
      },
      {
        "mediumspringgreen",
        4278254234U
      },
      {
        "mediumturquoise",
        4282962380U
      },
      {
        "mediumvioletred",
        4291237253U
      },
      {
        "midnightblue",
        4279834992U
      },
      {
        "mintcream",
        4294311930U
      },
      {
        "mistyrose",
        4294960353U
      },
      {
        "moccasin",
        4294960309U
      },
      {
        "navajowhite",
        4294958765U
      },
      {
        "navy",
        4278190208U
      },
      {
        "oldlace",
        4294833638U
      },
      {
        "olive",
        4286611456U
      },
      {
        "olivedrab",
        4285238819U
      },
      {
        "orange",
        4294944000U
      },
      {
        "orangered",
        4294919424U
      },
      {
        "orchid",
        4292505814U
      },
      {
        "palegoldenrod",
        4293847210U
      },
      {
        "palegreen",
        4288215960U
      },
      {
        "paleturquoise",
        4289720046U
      },
      {
        "palevioletred",
        4292374675U
      },
      {
        "papayawhip",
        4294963157U
      },
      {
        "peachpuff",
        4294957753U
      },
      {
        "peru",
        4291659071U
      },
      {
        "pink",
        4294951115U
      },
      {
        "plum",
        4292714717U
      },
      {
        "powderblue",
        4289781990U
      },
      {
        "purple",
        4286578816U
      },
      {
        "red",
        4294901760U
      },
      {
        "rosybrown",
        4290547599U
      },
      {
        "royalblue",
        4282477025U
      },
      {
        "saddlebrown",
        4287317267U
      },
      {
        "salmon",
        4294606962U
      },
      {
        "sandybrown",
        4294222944U
      },
      {
        "seagreen",
        4281240407U
      },
      {
        "seashell",
        4294964718U
      },
      {
        "sienna",
        4288696877U
      },
      {
        "silver",
        4290822336U
      },
      {
        "skyblue",
        4287090411U
      },
      {
        "slateblue",
        4285160141U
      },
      {
        "slategray",
        4285563024U
      },
      {
        "slategrey",
        4285563024U
      },
      {
        "snow",
        4294966010U
      },
      {
        "springgreen",
        4278255487U
      },
      {
        "steelblue",
        4282811060U
      },
      {
        "tvblack",
        4279242768U
      },
      {
        "tvwhite",
        4293651435U
      },
      {
        "tan",
        4291998860U
      },
      {
        "teal",
        4278222976U
      },
      {
        "thistle",
        4292394968U
      },
      {
        "tomato",
        4294927175U
      },
      {
        "transparent",
        0U
      },
      {
        "turquoise",
        4282441936U
      },
      {
        "violet",
        4293821166U
      },
      {
        "violetred",
        4291829904U
      },
      {
        "wheat",
        4294303411U
      },
      {
        "white",
        uint.MaxValue
      },
      {
        "whitesmoke",
        4294309365U
      },
      {
        "yellow",
        4294967040U
      },
      {
        "yellowgreen",
        4288335154U
      }
    };

        public static void Pass1Initialize() => ColorSchema.Type = new UIXTypeSchema((short)35, "Color", (string)null, (short)153, typeof(Color), UIXTypeFlags.Immutable);

        public static void Pass2Initialize()
        {
            UIXPropertySchema uixPropertySchema1 = new UIXPropertySchema((short)35, "Alpha", (short)194, (short)-1, ExpressionRestriction.None, false, SingleSchema.Validate0to1, false, new GetValueHandler(ColorSchema.GetAlpha), new SetValueHandler(ColorSchema.SetAlpha), false);
            UIXPropertySchema uixPropertySchema2 = new UIXPropertySchema((short)35, "Red", (short)194, (short)-1, ExpressionRestriction.None, false, SingleSchema.Validate0to1, false, new GetValueHandler(ColorSchema.GetRed), new SetValueHandler(ColorSchema.SetRed), false);
            UIXPropertySchema uixPropertySchema3 = new UIXPropertySchema((short)35, "Green", (short)194, (short)-1, ExpressionRestriction.None, false, SingleSchema.Validate0to1, false, new GetValueHandler(ColorSchema.GetGreen), new SetValueHandler(ColorSchema.SetGreen), false);
            UIXPropertySchema uixPropertySchema4 = new UIXPropertySchema((short)35, "Blue", (short)194, (short)-1, ExpressionRestriction.None, false, SingleSchema.Validate0to1, false, new GetValueHandler(ColorSchema.GetBlue), new SetValueHandler(ColorSchema.SetBlue), false);
            UIXPropertySchema uixPropertySchema5 = new UIXPropertySchema((short)35, "A", (short)19, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(ColorSchema.GetA), new SetValueHandler(ColorSchema.SetA), false);
            UIXPropertySchema uixPropertySchema6 = new UIXPropertySchema((short)35, "R", (short)19, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(ColorSchema.GetR), new SetValueHandler(ColorSchema.SetR), false);
            UIXPropertySchema uixPropertySchema7 = new UIXPropertySchema((short)35, "G", (short)19, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(ColorSchema.GetG), new SetValueHandler(ColorSchema.SetG), false);
            UIXPropertySchema uixPropertySchema8 = new UIXPropertySchema((short)35, "B", (short)19, (short)-1, ExpressionRestriction.None, false, (RangeValidator)null, false, new GetValueHandler(ColorSchema.GetB), new SetValueHandler(ColorSchema.SetB), false);
            UIXConstructorSchema constructorSchema1 = new UIXConstructorSchema((short)35, new short[4]
            {
        (short) 194,
        (short) 194,
        (short) 194,
        (short) 194
            }, new ConstructHandler(ColorSchema.ConstructAlphaRedGreenBlue));
            UIXConstructorSchema constructorSchema2 = new UIXConstructorSchema((short)35, new short[4]
            {
        (short) 19,
        (short) 19,
        (short) 19,
        (short) 19
            }, new ConstructHandler(ColorSchema.ConstructARGB));
            UIXConstructorSchema constructorSchema3 = new UIXConstructorSchema((short)35, new short[3]
            {
        (short) 194,
        (short) 194,
        (short) 194
            }, new ConstructHandler(ColorSchema.ConstructRedGreenBlue));
            UIXConstructorSchema constructorSchema4 = new UIXConstructorSchema((short)35, new short[3]
            {
        (short) 19,
        (short) 19,
        (short) 19
            }, new ConstructHandler(ColorSchema.ConstructRGB));
            UIXMethodSchema uixMethodSchema = new UIXMethodSchema((short)35, "TryParse", new short[2]
            {
        (short) 208,
        (short) 35
            }, (short)35, new InvokeHandler(ColorSchema.CallTryParseStringColor), true);
            ColorSchema.Type.Initialize(new DefaultConstructHandler(ColorSchema.Construct), new ConstructorSchema[4]
            {
        (ConstructorSchema) constructorSchema1,
        (ConstructorSchema) constructorSchema2,
        (ConstructorSchema) constructorSchema3,
        (ConstructorSchema) constructorSchema4
            }, new PropertySchema[8]
            {
        (PropertySchema) uixPropertySchema5,
        (PropertySchema) uixPropertySchema1,
        (PropertySchema) uixPropertySchema8,
        (PropertySchema) uixPropertySchema4,
        (PropertySchema) uixPropertySchema7,
        (PropertySchema) uixPropertySchema3,
        (PropertySchema) uixPropertySchema6,
        (PropertySchema) uixPropertySchema2
            }, new MethodSchema[1]
            {
        (MethodSchema) uixMethodSchema
            }, (EventSchema[])null, new FindCanonicalInstanceHandler(ColorSchema.FindCanonicalInstance), new TypeConverterHandler(ColorSchema.TryConvertFrom), new SupportsTypeConversionHandler(ColorSchema.IsConversionSupported), new EncodeBinaryHandler(ColorSchema.EncodeBinary), new DecodeBinaryHandler(ColorSchema.DecodeBinary), (PerformOperationHandler)null, (SupportsOperationHandler)null);
        }
    }
}