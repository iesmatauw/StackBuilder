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
    public partial class FormNewPalletFilm : FormNewBase
    {
        #region Constructor
        public FormNewPalletFilm(Document doc)
            : base(doc, null)
        {
            InitializeComponent();

            // initialize hatching
            chkbHatching.Checked = true;
            nudHatchSpacing.Value = (decimal)UnitsManager.ConvertLengthFrom(100.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            chkbHatching_CheckedChanged(this, null);
            // units
            UnitsManager.AdaptUnitLabels(this);
        }
        public FormNewPalletFilm(Document doc, PalletFilmProperties item)
            : base(doc, item)
        {
        }
        #endregion

        #region Public properties
        public Color Color
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        public bool UseTransparency
        {
            get { return chkbTransparency.Checked; }
            set { chkbTransparency.Checked = value; }
        }
        public bool UseHatching
        {
            get { return chkbHatching.Checked; }
            set { chkbHatching.Checked = value; }
        }
        public double HatchSpacing
        {
            get { return (double)nudHatchSpacing.Value; }
            set { nudHatchSpacing.Value = (decimal)value; }
        }
        #endregion

        #region Event handlers
        private void chkbHatching_CheckedChanged(object sender, EventArgs e)
        {
            lbHatchSpacing.Enabled = UseHatching;
            nudHatchSpacing.Enabled = UseHatching;
        }
        #endregion
    }
}
