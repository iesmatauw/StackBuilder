#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.Desktop.Properties;

using log4net;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewPalletCap : FormNewBase
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewPalletCap));
        #endregion

        #region Constructor
        public FormNewPalletCap(Document document, PalletCapProperties capProperties)
            : base(document, capProperties)
        {
            InitializeComponent();
            // units
            UnitsManager.AdaptUnitLabels(this);

            if (null != capProperties)
            {
                CapLength = capProperties.Length;
                CapWidth = capProperties.Width;
                CapHeight = capProperties.Height;

                CapInnerLength = capProperties.InsideLength;
                CapInnerWidth = capProperties.InsideWidth;
                CapInnerHeight = capProperties.InsideHeight;

                CapWeight = capProperties.Weight;
                CapColor = capProperties.Color;
            }
            else
            {
                CapLength = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                CapWidth = UnitsManager.ConvertLengthFrom(1000.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                CapHeight = UnitsManager.ConvertLengthFrom(50.0, UnitsManager.UnitSystem.UNIT_METRIC1);

                CapWeight = UnitsManager.ConvertSurfaceMassFrom(0.5, UnitsManager.UnitSystem.UNIT_METRIC1);
                CapColor = Color.Beige;
            }
            UpdateStatus(string.Empty);
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        { get { return Resources.ID_PALLETCAP; } }

        public override void UpdateStatus(string message)
        {
            if (CapInnerLength > CapLength)
                message = string.Format(Resources.ID_INVALIDINSIDELENGTH, CapInnerLength, CapLength);
            else if (CapInnerWidth > CapWidth)
                message = string.Format(Resources.ID_INVALIDINSIDEWIDTH, CapInnerWidth, CapWidth);
            else if (CapInnerHeight > CapHeight)
                message = string.Format(Resources.ID_INVALIDINSIDEHEIGHT, CapInnerHeight, CapHeight);
            base.UpdateStatus(message);
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
        public Color CapColor
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        #endregion

        #region Handlers
        private void cbColor_SelectedColorChanged(object sender, EventArgs e)
        {
            DrawBox();
        }
        private void UpdateThicknesses(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            if (null != nud)
            {
                double thickness = UnitsManager.ConvertLengthFrom(5.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                if (nudCapLength == nud && CapLength > thickness)
                    CapInnerLength = CapLength - thickness;
                if (nudCapWidth == nud && CapWidth > thickness)
                    CapInnerWidth = CapWidth - thickness;
                if (nudCapHeight == nud && CapHeight > thickness)
                    CapInnerHeight = CapHeight - thickness;
            }

            DrawBox();
            UpdateStatus(string.Empty);
        }
        #endregion

        #region Draw box
        private void DrawBox()
        {
            try
            {
                double angle = 45;
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pbPalletCap.Size);
                graphics.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics.Target = Vector3D.Zero;
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

                if (CapLength > 0 && CapWidth > 0 && CapHeight > 0)
                {
                    // draw
                    PalletCapProperties palletCapProperties = new PalletCapProperties(
                        null, ItemName, ItemDescription, CapLength, CapWidth, CapHeight,
                        CapInnerLength, CapInnerWidth, CapInnerHeight,
                        CapWeight, CapColor);

                    Box box = new Box(0, palletCapProperties, Vector3D.Zero);
                    graphics.AddBox(box);
                    graphics.AddDimensions(new DimensionCube(CapLength, CapWidth, CapHeight));
                    graphics.Flush();
                }
                pbPalletCap.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion


    }
}
