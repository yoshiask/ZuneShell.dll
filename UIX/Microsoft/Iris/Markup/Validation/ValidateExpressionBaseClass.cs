﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.Validation.ValidateExpressionBaseClass
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

namespace Microsoft.Iris.Markup.Validation
{
    internal class ValidateExpressionBaseClass : ValidateExpression
    {
        public ValidateExpressionBaseClass(SourceMarkupLoader owner, int line, int column)
          : base(owner, line, column, ExpressionType.BaseClass)
        {
        }

        public override void Validate(TypeRestriction typeRestriction, ValidateContext context)
        {
            if (this.Usage == ExpressionUsage.LValue)
                this.ReportError("Expression cannot be used as the target an assignment (related symbol: '{0}')", "this");
            if (context.CurrentMethod == null || !context.CurrentMethod.HasOverrideKeyword)
                this.ReportError("'base' keyword can only be used in an override method");
            this.DeclareEvaluationType((TypeSchema)context.Owner.TypeExport, TypeRestriction.None);
        }
    }
}
