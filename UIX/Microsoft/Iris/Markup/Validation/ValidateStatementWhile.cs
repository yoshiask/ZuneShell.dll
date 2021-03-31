﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Markup.Validation.ValidateStatementWhile
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Markup.UIX;

namespace Microsoft.Iris.Markup.Validation
{
    internal class ValidateStatementWhile : ValidateStatementLoop
    {
        private ValidateStatement _body;
        private ValidateExpression _condition;
        private bool _isDoWhile;

        public ValidateStatementWhile(
          SourceMarkupLoader owner,
          ValidateStatement body,
          ValidateExpression condition,
          bool isDoWhile,
          int line,
          int column)
          : base(owner, line, column, StatementType.While)
        {
            this._body = body;
            this._condition = condition;
            this._isDoWhile = isDoWhile;
        }

        public ValidateExpression Condition => this._condition;

        public ValidateStatement Body => this._body;

        public bool IsDoWhile => this._isDoWhile;

        public override void Validate(ValidateCode container, ValidateContext context)
        {
            context.NotifyScopedLocalFrameEnter(this);
            try
            {
                this._condition.Validate(new TypeRestriction(BooleanSchema.Type), context);
                if (this._condition.HasErrors)
                    this.MarkHasErrors();
                this._body.Validate(container, context);
                if (!this._body.HasErrors)
                    return;
                this.MarkHasErrors();
            }
            finally
            {
                context.NotifyScopedLocalFrameExit();
            }
        }
    }
}
