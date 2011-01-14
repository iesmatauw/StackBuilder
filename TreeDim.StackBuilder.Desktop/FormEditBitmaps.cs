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
    public partial class FormEditBitmaps : Form
    {
        #region Data members
        public BoxProperties _boxProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormEditBitmaps));
        #endregion

        #region Constructor
        public FormEditBitmaps()
        {
            InitializeComponent();
        }
        #endregion


        private void FormEditBitmaps_Load(object sender, EventArgs e)
        {

        }
        #region Draw box
        private void DrawBox()
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
                BoxProperties boxProperties = new BoxProperties(null, _boxProperties.Length, _boxProperties.Width, _boxProperties.Height);
                Box box = new Box(0, boxProperties);
                graphics.AddBox(box);
                graphics.AddDimensions(new DimensionCube(_boxProperties.Length, _boxProperties.Width, _boxProperties.Height));
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

        private void onSelectedFaceChanged(object sender, EventArgs e)
        {

        }
    }
}
