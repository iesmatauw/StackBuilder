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
    public partial class FormNewPalletFilm : FormNewBase
    {
        #region Constructor
        public FormNewPalletFilm(Document doc, PalletFilmProperties item)
            : base(doc, item)
        {
            InitializeComponent();

            if (null != item)
            {
                chkbTransparency.Checked = item.UseTransparency;
                chkbHatching.Checked = item.UseHatching;
                HatchSpacing = UnitsManager.ConvertLengthFrom(item.HatchSpacing, UnitsManager.UnitSystem.UNIT_METRIC1);
                HatchAngle = item.HatchAngle;
                FilmColor = item.Color;
            }
            else
            {
                chkbTransparency.Checked = true;
                chkbHatching.Checked = true;
                HatchSpacing = UnitsManager.ConvertLengthFrom(150.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                HatchAngle = 45.0;
                FilmColor = Color.LightSkyBlue;
            }
            chkbHatching_CheckedChanged(this, null);
            UpdateStatus(string.Empty);
            // units
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {   get { return Resources.ID_PALLETFILM; } }
        public override void UpdateStatus(string message)
        {
            if (!UseTransparency && !UseHatching)
                message = Resources.ID_USETRANSPARENCYORHATCHING;

            base.UpdateStatus(message);
        }
        #endregion

        #region Public properties
        public Color FilmColor
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
        public double HatchAngle
        {
            get { return (double)nudHatchAngle.Value; }
            set { nudHatchAngle.Value = (decimal)value; }
        }
        #endregion

        #region Event handlers
        private void chkbHatching_CheckedChanged(object sender, EventArgs e)
        {
            lbHatchSpacing.Enabled = UseHatching;
            nudHatchSpacing.Enabled = UseHatching;
            lbHatchAngle.Enabled = UseHatching;
            nudHatchAngle.Enabled = UseHatching;
            UpdateStatus(string.Empty);
        }
        #endregion
    }
}
