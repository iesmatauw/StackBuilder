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
    public partial class FormNewBox : Form
    {
        #region Data members
        private Document _document;
        public Color[] _faceColors = new Color[6];
        public BoxProperties _boxProperties;
        #endregion

        #region Constructor
        /// <summary>
        /// FormNewBox constructor used when defining a new BoxProperties item
        /// </summary>
        /// <param name="document">Document in which the BoxProperties item is to be created</param>
        public FormNewBox(Document document)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            // initialize value
            nudLength.Value = 400.0M;
            nudWidth.Value = 300.0M;
            nudHeight.Value = 200.0M;
            // set colors
            for (int i=0; i<6; ++i)
                _faceColors[i] = Color.Chocolate;
            // set default face
            cbFace.SelectedIndex = 0;
            // set horizontal angle
            trackBarHorizAngle.Value = 45;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        /// <summary>
        /// FormNewBox constructor used to edit existing boxes
        /// </summary>
        /// <param name="document">Document that contains the edited box</param>
        /// <param name="boxProperties">Edited box</param>
        public FormNewBox(Document document, BoxProperties boxProperties)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            _boxProperties = boxProperties;
            // set caption text
            Text = string.Format("Edit {0}...", _boxProperties.Name);
            // initialize value
            tbName.Text = _boxProperties.Name;
            tbDescription.Text = _boxProperties.Description;
            nudLength.Value = (decimal)_boxProperties.Length;
            nudWidth.Value = (decimal)_boxProperties.Width;
            nudHeight.Value = (decimal)_boxProperties.Height;
            nudWeight.Value = (decimal)_boxProperties.Weight;
            nudWeightOnTop.Value = (decimal)0.0;
            // set colors
            for (int i=0; i<6; ++i)
                _faceColors[i] = _boxProperties.Colors[i];
            // set default face
            cbFace.SelectedIndex = 0;
            // set horizontal angle
            trackBarHorizAngle.Value = 45;
            // disable Ok button
            UpdateButtonOkStatus();            
        }
        #endregion

        #region Public properties
        public string BoxName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        public double BoxLength
        {
            get { return (double)nudLength.Value; }
            set { nudLength.Value = (decimal)value; }
        }
        public double BoxWidth
        {
            get { return (double)nudWidth.Value; }
            set { nudWidth.Value = (decimal)value; }
        }
        public double BoxHeight
        {
            get { return (double)nudHeight.Value; }
            set { nudHeight.Value = (decimal)value; }
        }
        public double Weight
        {
            get { return (double)nudWeight.Value; }
            set { nudWeight.Value = (decimal)value; }
        }
        public double WeightOnTop
        {
            get { return (double)nudWeightOnTop.Value; }
            set { nudWeightOnTop.Value = (decimal)value; }
        }
        public Color[] Colors
        {
            get { return _faceColors; }
            set { }
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewBox_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormNewBoxPosition)
                Settings.Default.FormNewBoxPosition.Restore(this);
            DrawBox();
        }
        private void FormNewBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormNewBoxPosition)
                Settings.Default.FormNewBoxPosition = new WindowSettings();
            Settings.Default.FormNewBoxPosition.Record(this);
        }
        #endregion

        #region Form override
        protected override void  OnResize(EventArgs e)
        {
            DrawBox();
 	         base.OnResize(e);
        }
        #endregion

        #region Handlers

        private void onBoxPropertyChanged(object sender, EventArgs e)
        {
            DrawBox();
        }
        private void onSelectedFaceChanged(object sender, EventArgs e)
        {
            // get current index
            int iSel = cbFace.SelectedIndex;
            cbColor.Color = _faceColors[iSel];
            DrawBox();
        }
        private void onFaceColorChanged(object sender, EventArgs e)
        {
            int iSel = cbFace.SelectedIndex;
            _faceColors[iSel] = cbColor.Color;
            DrawBox();
        }
        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawBox();
        }
        private void UpdateButtonOkStatus()
        {
            bnAccept.Enabled =
                tbName.Text.Length > 0
                && tbDescription.Text.Length > 0
                && _document.IsValidNewTypeName(tbName.Text, _boxProperties);
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion

        #region Draw box
        private void DrawBox()
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
            BoxProperties boxProperties = new BoxProperties(null, (double)nudLength.Value, (double)nudWidth.Value, (double)nudHeight.Value);
            boxProperties.SetAllColors(_faceColors);
            Box box = new Box(0, boxProperties);
            graphics.AddBox(box);
            graphics.Flush();
            // set to picture box
            pictureBox.Image = graphics.Bitmap;
        }
        #endregion
    }
}