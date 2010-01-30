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
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewBox : Form
    {
        #region Constructor
        public FormNewBox()
        {
            InitializeComponent();

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
        }
        #endregion

        #region Public properties
        public string BoxName
        {
            get { return tbName.Text; }
        }
        public string Description
        {
            get { return tbDescription.Text; }
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
        }
        public double WeightOnTop
        {
            get { return (double)nudWeightOnTop.Value; }
        }
        public Color[] Colors
        {
            get { return _faceColors; }
        }
        #endregion

        #region Handlers
        private void FormNewBox_Load(object sender, EventArgs e)
        {
           DrawBox();
        }
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
        #endregion

        #region Draw box
        private void DrawBox()
        {
            double angle = trackBarHorizAngle.Value;
            Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , 10000.0);
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

            BoxProperties boxProperties = new BoxProperties((double)nudLength.Value, (double)nudWidth.Value, (double)nudHeight.Value);
            boxProperties.Colors = _faceColors;
            Box box = new Box(0, boxProperties);
            foreach (Face face in box.Faces)
                graphics.AddFace(face);
            graphics.Flush();
            pictureBox.Image = graphics.Bitmap;
        }
        #endregion

        #region Data members
        public Color[] _faceColors = new Color[6];
        #endregion
    }
}