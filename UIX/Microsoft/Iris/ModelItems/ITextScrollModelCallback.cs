﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.ModelItems.ITextScrollModelCallback
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

namespace Microsoft.Iris.ModelItems
{
    internal interface ITextScrollModelCallback
    {
        void ScrollUp(TextScrollModel who);

        void ScrollDown(TextScrollModel who);

        void PageUp(TextScrollModel who);

        void PageDown(TextScrollModel who);

        void ScrollToPosition(TextScrollModel who, int whereTo);
    }
}