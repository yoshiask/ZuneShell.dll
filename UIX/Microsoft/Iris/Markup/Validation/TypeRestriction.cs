﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.Validation.TypeRestriction
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Markup.UIX;

namespace Microsoft.Iris.Markup.Validation
{
    internal struct TypeRestriction
    {
        private TypeSchema _primary;
        private TypeSchema _secondary;
        private bool _allow;
        public static TypeRestriction None;
        public static TypeRestriction NotVoid;

        public TypeRestriction(TypeSchema primary)
          : this(primary, (TypeSchema)null)
        {
        }

        public TypeRestriction(TypeSchema primary, TypeSchema secondary)
          : this(primary, secondary, true)
        {
        }

        private TypeRestriction(TypeSchema primary, TypeSchema secondary, bool allow)
        {
            this._primary = primary;
            this._secondary = secondary;
            this._allow = allow;
        }

        public static void InitializeStatics()
        {
            TypeRestriction.None = new TypeRestriction((TypeSchema)null, (TypeSchema)null, true);
            TypeRestriction.NotVoid = new TypeRestriction((TypeSchema)VoidSchema.Type, (TypeSchema)null, false);
        }

        public TypeSchema Primary => this._primary;

        public TypeSchema Secondary => this._secondary;

        public bool Check(ValidateObject subject, TypeSchema checkType) => this.Check(subject, "'{0}' cannot be used in this context (expecting types compatible with '{1}')", checkType);

        public bool Check(ValidateObject subject, string errorMessage, TypeSchema checkType)
        {
            bool flag = false;
            if (this._primary == null && this._secondary == null || this._primary.IsAssignableFrom(checkType) || this._secondary != null && this._secondary.IsAssignableFrom(checkType))
                flag = true;
            if (flag == this._allow)
                return true;
            string str1 = checkType.Name;
            string str2 = this._primary.Name;
            if (str1 == str2)
            {
                str1 = str1 + " (" + (object)checkType.Owner + ")";
                str2 = str2 + " (" + (object)this._primary.Owner + ")";
            }
            subject.ReportError(errorMessage, str1, str2);
            return false;
        }
    }
}
