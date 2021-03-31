﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.RenderAPI.Drawing.RectangleF
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.Library;
using Microsoft.Iris.Render;
using System;
using System.Globalization;
using System.Text;

namespace Microsoft.Iris.RenderAPI.Drawing
{
    [Serializable]
    internal struct RectangleF
    {
        public static readonly RectangleF Zero = new RectangleF(0.0f, 0.0f, 0.0f, 0.0f);
        private float x;
        private float y;
        private float width;
        private float height;

        public RectangleF(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RectangleF(PointF location, SizeF size)
        {
            this.x = location.X;
            this.y = location.Y;
            this.width = size.Width;
            this.height = size.Height;
        }

        public RectangleF(Point location, Microsoft.Iris.Render.Size size)
        {
            this.x = (float)location.X;
            this.y = (float)location.Y;
            this.width = (float)size.Width;
            this.height = (float)size.Height;
        }

        public static RectangleF FromLTRB(float left, float top, float right, float bottom) => new RectangleF(left, top, right - left, bottom - top);

        public static RectangleF FromRectangle(Rectangle r) => new RectangleF((float)r.X, (float)r.Y, (float)r.Width, (float)r.Height);

        public PointF Location
        {
            get => new PointF(this.X, this.Y);
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public SizeF Size
        {
            get => new SizeF(this.Width, this.Height);
            set
            {
                this.Width = value.Width;
                this.Height = value.Height;
            }
        }

        public float X
        {
            get => this.x;
            set => this.x = value;
        }

        public float Y
        {
            get => this.y;
            set => this.y = value;
        }

        public float Width
        {
            get => this.width;
            set => this.width = value;
        }

        public float Height
        {
            get => this.height;
            set => this.height = value;
        }

        public float Left => this.X;

        public float Top => this.Y;

        public float Right => this.X + this.Width;

        public float Bottom => this.Y + this.Height;

        public bool IsEmpty => Math2.WithinEpsilon(this.width, 0.0f) || Math2.WithinEpsilon(this.height, 0.0f);

        public override bool Equals(object obj) => obj is RectangleF rectangleF && (double)rectangleF.X == (double)this.X && ((double)rectangleF.Y == (double)this.Y && (double)rectangleF.Width == (double)this.Width) && (double)rectangleF.Height == (double)this.Height;

        public static bool operator ==(RectangleF left, RectangleF right) => (double)left.X == (double)right.X && (double)left.Y == (double)right.Y && (double)left.Width == (double)right.Width && (double)left.Height == (double)right.Height;

        public static bool operator !=(RectangleF left, RectangleF right) => !(left == right);

        public bool Contains(float x, float y) => (double)this.X <= (double)x && (double)x < (double)this.X + (double)this.Width && (double)this.Y <= (double)y && (double)y < (double)this.Y + (double)this.Height;

        public bool Contains(PointF pt) => this.Contains(pt.X, pt.Y);

        public bool Contains(RectangleF rect) => (double)this.X <= (double)rect.X && (double)rect.X + (double)rect.Width <= (double)this.X + (double)this.Width && (double)this.Y <= (double)rect.Y && (double)rect.Y + (double)rect.Height <= (double)this.Y + (double)this.Height;

        public override int GetHashCode() => (int)(uint)this.X ^ ((int)(uint)this.Y << 13 | (int)((uint)this.Y >> 19)) ^ ((int)(uint)this.Width << 26 | (int)((uint)this.Width >> 6)) ^ ((int)(uint)this.Height << 7 | (int)((uint)this.Height >> 25));

        public void Inflate(float x, float y)
        {
            this.X -= x;
            this.Y -= y;
            this.Width += 2f * x;
            this.Height += 2f * y;
        }

        public void Inflate(SizeF size) => this.Inflate(size.Width, size.Height);

        public static RectangleF Inflate(RectangleF rect, float x, float y)
        {
            RectangleF rectangleF = rect;
            rectangleF.Inflate(x, y);
            return rectangleF;
        }

        public void Intersect(RectangleF rect)
        {
            RectangleF rectangleF = RectangleF.Intersect(rect, this);
            this.X = rectangleF.X;
            this.Y = rectangleF.Y;
            this.Width = rectangleF.Width;
            this.Height = rectangleF.Height;
        }

        public static RectangleF Intersect(RectangleF a, RectangleF b)
        {
            float x = Math.Max(a.X, b.X);
            float num1 = Math.Min(a.X + a.Width, b.X + b.Width);
            float y = Math.Max(a.Y, b.Y);
            float num2 = Math.Min(a.Y + a.Height, b.Y + b.Height);
            return (double)num1 >= (double)x && (double)num2 >= (double)y ? new RectangleF(x, y, num1 - x, num2 - y) : RectangleF.Zero;
        }

        public bool IntersectsWith(RectangleF rect) => (double)this.Left < (double)rect.Right && (double)this.Top < (double)rect.Bottom && (double)this.Right > (double)rect.Left && (double)this.Bottom > (double)rect.Top;

        public static RectangleF Union(RectangleF a, RectangleF b)
        {
            float x = Math.Min(a.X, b.X);
            float num1 = Math.Max(a.X + a.Width, b.X + b.Width);
            float y = Math.Min(a.Y, b.Y);
            float num2 = Math.Max(a.Y + a.Height, b.Y + b.Height);
            return new RectangleF(x, y, num1 - x, num2 - y);
        }

        public void Offset(PointF pos) => this.Offset(pos.X, pos.Y);

        public void Offset(float x, float y)
        {
            this.X += x;
            this.Y += y;
        }

        public static RectangleF Offset(RectangleF rect, PointF pos)
        {
            rect.Offset(pos);
            return rect;
        }

        public PointF TopLeft => new PointF(this.Left, this.Top);

        public PointF TopRight => new PointF(this.Right, this.Top);

        public PointF BottomLeft => new PointF(this.Left, this.Bottom);

        public PointF BottomRight => new PointF(this.Right, this.Bottom);

        public PointF Center => new PointF(this.x + this.width / 2f, this.y + this.height / 2f);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(128);
            stringBuilder.Append("(X=");
            stringBuilder.Append(this.X.ToString((IFormatProvider)NumberFormatInfo.InvariantInfo));
            stringBuilder.Append(", Y=");
            stringBuilder.Append(this.Y.ToString((IFormatProvider)NumberFormatInfo.InvariantInfo));
            stringBuilder.Append(", Width=");
            stringBuilder.Append(this.Width.ToString((IFormatProvider)NumberFormatInfo.InvariantInfo));
            stringBuilder.Append(", Height=");
            stringBuilder.Append(this.Height.ToString((IFormatProvider)NumberFormatInfo.InvariantInfo));
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }
    }
}