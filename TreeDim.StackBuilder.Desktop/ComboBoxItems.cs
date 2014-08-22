#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;
using System.Windows.Forms;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    #region Combo box item private classes
    public class BoxItem
    {
        private BProperties _boxProperties;

        public BoxItem(BProperties boxProperties)
        {
            _boxProperties = boxProperties;
        }

        public BProperties Item
        {
            get { return _boxProperties; }
        }

        public override string ToString()
        {
            return _boxProperties.Name;
        }
    }
    public class PalletItem
    {
        private PalletProperties _palletProperties;

        public PalletItem(PalletProperties palletProperties)
        {
            _palletProperties = palletProperties;
        }

        public PalletProperties Item
        {
            get { return _palletProperties; }
        }

        public override string ToString()
        {
            return _palletProperties.Name;
        }
    }
    public class InterlayerItem
    {
        private InterlayerProperties _interlayerProperties;

        public InterlayerItem(InterlayerProperties interlayerProperties)
        {
            _interlayerProperties = interlayerProperties;
        }

        public InterlayerProperties Item
        {
            get { return _interlayerProperties; }
        }

        public override string ToString()
        {
            return _interlayerProperties.Name;
        }
    }
    public class ItemBaseCB
    {
        private ItemBase _itemBase;

        public ItemBaseCB(ItemBase itemBase)
        {
            _itemBase = itemBase;
        }
        public ItemBase Item
        {
            get { return _itemBase; }
        }
        public override string ToString()
        {
            return _itemBase.Name;
        }
    }
    #endregion

    #region ComboBoxHelpers
    public class ComboBoxHelpers
    {
        static public void FillCombo(ItemBase[] items, ComboBox cb, ItemBase item)
        {
            cb.Items.Clear();
            foreach (ItemBase it in items)
                cb.Items.Add(new ItemBaseCB(it));
            if (cb.Items.Count > 0)
            {
                if (null == item)
                    cb.SelectedIndex = 0;
                else
                {
                    for (int i = 0; i < cb.Items.Count; ++i)
                    {
                        ItemBaseCB cbItem = cb.Items[i] as ItemBaseCB;
                        if (cbItem.Item == item)
                        {
                            cb.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }        
        }
    }
    #endregion
}
