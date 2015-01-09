#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewPalletCap : FormNewBase
    {
        #region Constructor
        public FormNewPalletCap(Document document, ItemBase item)
            : base(document, item)
        {
            InitializeComponent();
            // units
            UnitsManager.AdaptUnitLabels(this);

            if (null != Item)
            { 
                
            }
        }
        #endregion

        #region FormNewBase overrides
        public override ItemBase Item
        {
            get
            {
                PalletCapProperties palletCap = new PalletCapProperties(_document);
                return palletCap;
            }
        }
        #endregion

        #region Public properties
        public double CapLength
        {
            get { return (double)nudCapLength.Value; }
            set { nudCapLength.Value = (decimal)value; }
        }
        public double CapWidth
        {
            get { return (double)nudCapWidth.Value; }
            set { nudCapWidth.Value = (decimal)value; }
        }
        public double CapHeight
        {
            get { return (double)nudCapHeight.Value; }
            set { nudCapHeight.Value = (decimal)value; }
        }
        public double CapInnerLength
        {
            get { return (double)nudCapInnerLength.Value; }
            set { nudCapInnerLength.Value = (decimal)value; }
        }
        public double CapInnerWidth
        {
            get { return (double)nudCapInnerWidth.Value; }
            set { nudCapInnerWidth.Value = (decimal)value; }
        }
        public double CapInnerHeight
        {
            get { return (double)nudCapInnerHeight.Value; }
            set { nudCapInnerHeight.Value = (decimal)value; }
        }
        public double CapWeight
        {
            get { return (double)nudCapWeight.Value; }
            set { nudCapWeight.Value = (decimal)value; }
        }
        public Color Color
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        #endregion
    }
}
