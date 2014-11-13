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
            nudRadiusOuter.Value = (decimal)UnitsManager.ConvertLengthFrom(75.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            nudHeight.Value = (decimal)UnitsManager.ConvertLengthFrom(150.0, UnitsManager.UnitSystem.UNIT_METRIC1);
            cbColorWall.Color = System.Drawing.Color.LightSkyBlue;
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
            nudRadiusOuter.Value = (decimal)cylinder.RadiusOuter;
            nudHeight.Value = (decimal)cylinder.Height;
            cbColorWall.Color = cylinder.ColorWall;
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
        public double Radius
        {
            get { return (double)nudRadiusOuter.Value; }
            set { nudRadiusOuter.Value = (decimal)value; }
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
        public Color ColorWall
        {
            get { return cbColorWall.Color; }
            set { cbColorWall.Color = value; }
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
                    , Radius, CylinderHeight, Weight
                    , ColorTop, ColorWall);
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
