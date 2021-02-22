﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.CartPanel
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

using Microsoft.Iris;

namespace ZuneUI
{
    public class CartPanel : LibraryPanel
    {
        private CartItem _selectedItem;

        public CartPanel(CartPage page)
          : base((IModelItemOwner)page)
        {
        }

        public CartItem SelectedItem
        {
            get => this._selectedItem;
            set
            {
                if (this._selectedItem == value)
                    return;
                this._selectedItem = value;
                this.FirePropertyChanged(nameof(SelectedItem));
            }
        }
    }
}