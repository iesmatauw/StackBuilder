#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using log4net;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewCylinder : Form
    {
        #region Data members
        [NonSerialized]
        private Document _document;
        public CylinderProperties _cylProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBox));
        #endregion

        #region Constructors
        public FormNewCylinder(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            tbName.Text = _document.GetValidNewTypeName(Resources.ID_CYLINDER);
            tbDescription.Text = tbName.Text;
            // properties
            nudDiameterOuter.Value = (decimal)UnitsManager.ConvertLengthFrom(2.0*75.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            nudDiameterInner.Value = (decimal)UnitsManager.ConvertLengthFrom(0.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            nudHeight.Value = (decimal)UnitsManager.ConvertLengthFrom(150.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            cbColorWallOuter.Color = System.Drawing.Color.LightSkyBlue;
            cbColorWallInner.Color = System.Drawing.Color.Chocolate;
            cbColorTop.Color = System.Drawing.Color.Gray;
            // set horizontal angle
            trackBarHorizAngle.Value = 225;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        public FormNewCylinder(Document document, CylinderProperties cylinder)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _cylProperties = cylinder;
            // properties
            tbName.Text = cylinder.Name;
            tbDescription.Text = cylinder.Description;
            nudDiameterOuter.Value = 2.0M * (decimal)cylinder.RadiusOuter;
            nudDiameterInner.Value = 2.0M * (decimal)cylinder.RadiusInner;
            nudHeight.Value = (decimal)cylinder.Height;
            cbColorWallOuter.Color = cylinder.ColorWallOuter;
            cbColorWallInner.Color = cylinder.ColorWallInner;
            cbColorTop.Color = cylinder.ColorTop;
            nudWeight.Value = (decimal)cylinder.Weight;
            // set horizontal angle
            trackBarHorizAngle.Value = 225;
            // disable Ok button
            UpdateButtonOkStatus();        
        }
        #endregion

        #region Public properties
        public string CylinderName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double RadiusOuter
        {
            get { return 0.5 * (double)nudDiameterOuter.Value; }
            set { nudDiameterOuter.Value = 2.0M * (decimal)value; }
        }
        public double RadiusInner
        {
            get { return 0.5 * (double)nudDiameterInner.Value; }
            set { nudDiameterInner.Value = 2.0M * (decimal)value; }
        }
        public double CylinderHeight
        {
            get { return (double) nudHeight.Value; }
            set { nudHeight.Value = (decimal)value; }
        }
        public double Weight
        {
            get { return (double) nudWeight.Value; }
            set { nudWeight.Value = (decimal)value; }
        }
        public Color ColorTop
        {
            get { return cbColorTop.Color; }
            set { cbColorTop.Color = value; }
        }
        public Color ColorWallOuter
        {
            get { return cbColorWallOuter.Color; }
            set { cbColorWallOuter.Color = value; }
        }
        public Color ColorWallInner
        {
            get { return cbColorWallInner.Color; }
            set { cbColorWallInner.Color = value; }
        }
        #endregion

        #region Handlers
        private void onCylinderPropertiesChanged(object sender, EventArgs e)
        {
            // update ok button status
            UpdateButtonOkStatus();
            // update cylinder drawing
            DrawCylinder();
        }

        private void UpdateButtonOkStatus()
        {
            // status + message
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // name validity
            else if (!_document.IsValidNewTypeName(tbName.Text, _cylProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            else if (RadiusInner > RadiusOuter)
                message = Resources.ID_INVALIDDIAMETER;
            // accept
            bnOK.Enabled = string.IsNullOrEmpty(message);
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawCylinder();
        }
        private void btBitmapsWall_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Draw cylinder
        public void DrawCylinder()
        {
            try
            {
                // get horizontal angle
                double angle = trackBarHorizAngle.Value;
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
                graphics.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics.Target = Vector3D.Zero;
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // draw
                CylinderProperties cylProperties = new CylinderProperties(
                    null, CylinderName, Description
                    , RadiusOuter, RadiusInner, CylinderHeight, Weight
                    , ColorTop, ColorWallOuter, ColorWallInner);
                Cylinder cyl = new Cylinder(0, cylProperties);
                graphics.AddCylinder(cyl);
                graphics.Flush();
                // set to picture box
                pictureBox.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
