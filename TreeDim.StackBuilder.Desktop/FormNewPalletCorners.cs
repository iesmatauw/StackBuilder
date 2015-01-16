#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TreeDim.StackBuilder.Basics;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewPalletCorners : FormNewBase
    {
        #region Constructor
        public FormNewPalletCorners(Document doc, PalletCornerProperties palletCorners)
            : base(doc, palletCorners)
        {
            InitializeComponent();

            if (null != palletCorners)
            {
                CornerLength = palletCorners.Length;
                CornerWidth = palletCorners.Width;
                CornerThickness = palletCorners.Thickness;
                CornerWeight = palletCorners.Weight;
                Color = palletCorners.Color;
            }
            else
            { 
                CornerLength = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);;
                CornerWidth = UnitsManager.ConvertLengthFrom(40.0, UnitsManager.UnitSystem.UNIT_METRIC1);;
                CornerThickness = UnitsManager.ConvertLengthFrom(5.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                CornerWeight = UnitsManager.ConvertMassFrom(0.050, UnitsManager.UnitSystem.UNIT_METRIC1);           
            }
            UpdateStatus(string.Empty);
            // units
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {
            get { return Resources.ID_PALLETCORNERS; }
        }
        #endregion

        #region Public properties
        public double CornerLength
        {
            get { return (double)nudLength.Value; }
            set { nudLength.Value = (decimal)value; }
        }
        public double CornerWidth
        {
            get { return (double)nudWidth.Value; }
            set { nudWidth.Value = (decimal)value;}
        }
        public double CornerThickness
        {
            get { return (double)nudThickness.Value; }
            set { nudThickness.Value = (decimal)value; }
        }
        public double CornerWeight
        {
            get { return (double)nudWeight.Value; }
            set { nudWeight.Value = (decimal)value; }
        }
        public Color Color
        {
            get { return cbColorCorners.Color; }
            set { cbColorCorners.Color = value; }
        }
        #endregion
    }
}
