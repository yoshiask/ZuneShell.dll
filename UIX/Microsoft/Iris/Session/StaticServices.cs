﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Iris.Session.StaticServices
// Assembly: UIX, Version=4.8.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: A56C6C9D-B7F6-46A9-8BDE-B3D9B8D60B11
// Assembly location: C:\Program Files\Zune\UIX.dll

using Microsoft.Iris.ViewItems;

namespace Microsoft.Iris.Session
{
    internal static class StaticServices
    {
        public static void Initialize() => Text.Initialize();

        public static void Uninitialize() => Text.Uninitialize();
    }
}
