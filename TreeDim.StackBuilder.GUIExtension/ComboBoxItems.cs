#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.GUIExtension
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
            return string.Format("{0}      ({1} x {2} x {3})"
                , _boxProperties.Name, _boxProperties.Length, _boxProperties.Width, _boxProperties.Height);
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
            return string.Format("{0}      ({1} x {2} x {3})"
                , _palletProperties.Name, _palletProperties.Length, _palletProperties.Width, _palletProperties.Height);
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
    #endregion
}
