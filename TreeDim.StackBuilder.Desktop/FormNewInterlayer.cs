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
using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewInterlayer : Form
    {
        #region Data members
        private Document _document;
        private InterlayerProperties _interlayerProperties;
        #endregion

        #region Constructor
        public FormNewInterlayer(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // name / description
            tbName.Text = _document.GetValidNewTypeName(Resources.ID_INTERLAYER);
            tbDescription.Text = tbName.Text;
            // initialize value
            InterlayerLength = 1200.0;
            InterlayerWidth = 1000.0;
            // set horizontal angle
            trackBarHorizAngle.Value = 225;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        public FormNewInterlayer(Document document, InterlayerProperties interlayerProperties)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _interlayerProperties = interlayerProperties;
            // set caption text
            Text = string.Format(Properties.Resources.ID_EDIT, _interlayerProperties.Name);
            // initialize value
            tbName.Text = _interlayerProperties.Name;
            tbDescription.Text = _interlayerProperties.Description;
            InterlayerLength = _interlayerProperties.Length;
            InterlayerWidth = _interlayerProperties.Width;
            Thickness = _interlayerProperties.Thickness;
            Weight = _interlayerProperties.Weight;
            this.Color = _interlayerProperties.Color;

            // set horizontal angle
            trackBarHorizAngle.Value = 225;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        #endregion

        #region Form override
        protected override void OnResize(EventArgs e)
        {
            DrawInterlayer();
            base.OnResize(e);
        }
        #endregion

        #region Public properties
        public string InterlayerName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double InterlayerLength
        {
            get { return (double)nudLength.Value; }
            set { nudLength.Value = (decimal)value; }
        }
        public double InterlayerWidth
        {
            get { return (double)nudWidth.Value; }
            set { nudWidth.Value = (decimal)value; }
        }
        public double Thickness
        {
            get { return (double)nudThickness.Value; }
            set { nudThickness.Value = (decimal)value; }
        }
        public double Weight
        {
            get { return (double)nudWeight.Value; }
            set { nudWeight.Value = (decimal)value; }
        }
        public Color Color
        {
            get { return cbColor.Color; }
            set { cbColor.Color = value; }
        }
        #endregion

        #region Handlers
        private void onLoad(object sender, EventArgs e)
        {
            DrawInterlayer();
        }
        private void onInterlayerPropertyChanged(object sender, EventArgs e)
        {
            DrawInterlayer();
        }
        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawInterlayer();
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // name validity
            else if (!_document.IsValidNewTypeName(tbName.Text, _interlayerProperties))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // button OK
            bnOk.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion

        #region Draw interlayer
        private void DrawInterlayer()
        { 
            // get horizontal angle
            double angle = trackBarHorizAngle.Value;
            // instantiate graphics
            Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , 10000.0);
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
            // draw
            InterlayerProperties interlayerProperties = new InterlayerProperties(
                null, tbName.Text, tbDescription.Text
                , InterlayerLength, InterlayerWidth
                , Thickness, Weight, Color);
            Box box = new Box(0, interlayerProperties);
            graphics.AddBox(box);
            graphics.Flush();
            // set to picture box
            pictureBox.Image = graphics.Bitmap;
        }
        #endregion

        #region Load / FormClosing
        private void FormNewInterlayer_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormNewInterlayerPosition)
                Settings.Default.FormNewInterlayerPosition.Restore(this);
            DrawInterlayer();
        }
        private void FormNewInterlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormNewInterlayerPosition)
                Settings.Default.FormNewInterlayerPosition = new WindowSettings();
            Settings.Default.FormNewInterlayerPosition.Record(this);
        }
        #endregion
    }
}