﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.TypeConstraint
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

namespace Microsoft.Iris.Markup
{
    internal class TypeConstraint
    {
        private TypeSchema _constraint;
        private TypeSchema _type;

        public TypeSchema Constraint
        {
            get => this._constraint;
            set => this._constraint = value;
        }

        public TypeSchema Type
        {
            get => this._type;
            set => this._type = value;
        }
    }
}