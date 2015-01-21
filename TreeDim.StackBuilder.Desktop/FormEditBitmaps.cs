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
        private  BoxProperties _boxProperties;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormEditBitmaps));
        private List<Pair<HalfAxis.HAxis, Texture>> _textures;
        private bool _preventHandling = false;
        #endregion

        #region Constructors
        /// <summary>
        /// constructor (from existing BoxProperties)
        /// </summary>
        public FormEditBitmaps(BoxProperties boxProperties)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // set internal box properties
            _boxProperties = boxProperties;
            // get textures
            _textures = _boxProperties.TextureListCopy;
            // set default face
            cbFace.SelectedIndex = 0;
            // set horizontal angle
            trackBarHorizAngle.Value = 225;
        }
        /// <summary>
        /// constructor (from length, width, height)
        /// </summary>
        public FormEditBitmaps(double length, double width, double height, Color[] faceColors)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // set internal box properties
            _boxProperties = new BoxProperties(null, length, width, height);
            _boxProperties.SetAllColors(faceColors);
            // get textures
            _textures = _boxProperties.TextureListCopy;
            // set default face
            cbFace.SelectedIndex = 0;
            // set horizontal angle
            trackBarHorizAngle.Value = 225;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Box properties
        /// </summary>
        public BoxProperties BoxProperties
        {
            get { return _boxProperties; }
            set { _boxProperties = value; }
        }
        public List<Pair<HalfAxis.HAxis, Texture>> Textures
        {
            get { return _textures; }
            set
            {
                _textures.Clear();
                _textures.AddRange(value); 
            }
        }
        #endregion

        #region Load / Closing
        private void FormEditBitmaps_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormEditBitmapsPosition)
                Settings.Default.FormEditBitmapsPosition.Restore(this);
            DrawBox();
        }
        private void FormEditBitmaps_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormEditBitmapsPosition)
                Settings.Default.FormEditBitmapsPosition = new WindowSettings();
            Settings.Default.FormEditBitmapsPosition.Record(this);
        }
        #endregion

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
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // draw
                BoxProperties boxProperties = new BoxProperties(null, _boxProperties.Length, _boxProperties.Width, _boxProperties.Height);
                boxProperties.SetAllColors(_boxProperties.Colors);
                boxProperties.TextureList = _textures;
                Box box = new Box(0, boxProperties);
                graphics.AddBox(box);
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

        #region Handlers
        private void onSelectedFaceChanged(object sender, EventArgs e)
        {
            try
            {
                FillBitmapControl(SelectedFace);
                if (listBoxTextures.Items.Count > 0)
                    listBoxTextures.SelectedIndex = 0;
                onSelectedTextureChanged(listBoxTextures, null);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FillBitmapControl(HalfAxis.HAxis iFace)
        {
            List<Texture> listTexture = new List<Texture>();
            foreach (Pair<HalfAxis.HAxis, Texture> p in _textures)
                if (p.first == iFace)
                    listTexture.Add(p.second);
            listBoxTextures.SetTextureList(listTexture);
        }

        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            DrawBox();
        }

        private void bnMoveUpDown_Click(object sender, EventArgs e)
        {
            // try and find selected texture
            Pair<HalfAxis.HAxis, Texture> texturePair = _textures.Find(
                delegate(Pair<HalfAxis.HAxis, Texture> tex) { return tex.second == SelectedTexture; });
            // get index
            int index = _textures.IndexOf(texturePair);
            if (sender == bnMoveUp)
            {
                // remove and insert at index - 1
                if (index > 0 && _textures.Remove(texturePair))
                    _textures.Insert(index - 1, texturePair);
            }
            else if (sender == bnMoveDown)
            { 
                // remove and insert at index + 1
                if (index < _textures.Count - 1 && _textures.Remove(texturePair))
                    _textures.Insert(index + 1, texturePair);
            }
            // rebuild list
            FillBitmapControl(SelectedFace);
            // select current item
            SelectedTexture = texturePair.second;
            // refresh
            DrawBox();
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == openImageFileDialog.ShowDialog())
                {
                    double faceLength = 0.0, faceHeight = 0.0;
                    SelectedFaceLengthHeight(out faceLength, out faceHeight);
                    Pair<HalfAxis.HAxis, Texture> faceTexturePair = null;
                    foreach (string filePath in openImageFileDialog.FileNames)
                    {
                        Bitmap bmp = new Bitmap(filePath);
                        faceTexturePair = new Pair<HalfAxis.HAxis, Texture>(SelectedFace, new Texture(bmp, Vector2D.Zero, new Vector2D(faceLength, faceHeight), 0.0));
                        _textures.Add(faceTexturePair);
                    }
                    FillBitmapControl(SelectedFace);
                    SelectedTexture = faceTexturePair.second;
                    // refresh drawing
                    DrawBox();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void bnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                HalfAxis.HAxis currentAxis = SelectedFace;
                Texture currentTexture = SelectedTexture;
                _textures.RemoveAll(delegate(Pair<HalfAxis.HAxis, Texture> p) { return p.first == currentAxis && p.second == currentTexture; });
                // update bitmap control
                FillBitmapControl(SelectedFace);
                // select first texture available in list
                if (listBoxTextures.Items.Count > 0)
                {
                    ListBoxImagesItem item = listBoxTextures.Items[0] as ListBoxImagesItem;
                    SelectedTexture = item.Texture;
                }
                else
                    onSelectedTextureChanged(this, null);
                // draw box
                DrawBox();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// Handling changes in texture position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void texturePosition_ValueChanged(object sender, EventArgs e)
        {
            if (_preventHandling)
                return;
            try
            {
                // get selected texture
                Texture texture = SelectedTexture;
                if (null == texture) return;
                // set position / size / angle
                texture.Position = new Vector2D((double)nudPositionX.Value, (double)nudPositionY.Value);
                texture.Size = new Vector2D((double)nudSizeX.Value, (double)nudSizeY.Value);
                texture.Angle = (double)nudAngle.Value;
                // redraw box
                DrawBox();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void onSelectedTextureChanged(object sender, EventArgs e)
        {
            int index = listBoxTextures.SelectedIndex;

            Texture texture = SelectedTexture;

            nudPositionX.Enabled = null != texture;
            nudPositionY.Enabled = null != texture;
            nudSizeX.Enabled = null != texture;
            nudSizeY.Enabled = null != texture;
            nudAngle.Enabled = null != texture;

            lbOrigin.Enabled = null != texture;
            lbSize.Enabled = null != texture;
            lbAngle.Enabled = null != texture;
            uLengthOriginX.Enabled = null != texture;
            uLengthOriginY.Enabled = null != texture;
            uLengthSizeX.Enabled = null != texture;
            uLengthSizeY.Enabled = null != texture;
            lbUnitAngle.Enabled = null != texture;

            if (null != texture)
            {
                _preventHandling = true;
                nudPositionX.Value = (decimal)texture.Position.X;
                nudPositionY.Value = (decimal)texture.Position.Y;
                nudSizeX.Value = (decimal)texture.Size.X;
                nudSizeY.Value = (decimal)texture.Size.Y;
                nudAngle.Value = (decimal)texture.Angle;
                _preventHandling = false;
            }

            // enable/disable up and down button
        }
        private void FormEditBitmaps_Resize(object sender, EventArgs e)
        {
            // refresh drawing
            DrawBox();
        }
        #endregion

        #region Private properties (Helpers)
        private HalfAxis.HAxis SelectedFace
        {
            get
            {
                if (-1 == cbFace.SelectedIndex)
                    throw new Exception("No face selected");
                return (HalfAxis.HAxis)cbFace.SelectedIndex; 
            }
            set
            {
                cbFace.SelectedIndex = (int)value;
            }
        }

        private Texture SelectedTexture
        {
            get
            { 
                // get ListBoxImageItem
                ListBoxImagesItem item = listBoxTextures.SelectedItem as ListBoxImagesItem;
                // sanity check
                if (null == item) return null;
                // return texture
                return item.Texture;
            }
            set
            {
                foreach (object item in listBoxTextures.Items)
                {
                    ListBoxImagesItem imageItem = item as ListBoxImagesItem;
                    if (imageItem.Texture == value)
                    {
                        listBoxTextures.SelectedItem = item;
                        break;
                    }
                }
            }
        }
        #endregion

        #region Private helpers
        private void SelectedFaceLengthHeight(out double length, out double height)
        {
            switch (SelectedFace)
            { 
                case HalfAxis.HAxis.AXIS_X_N:
                case HalfAxis.HAxis.AXIS_X_P:
                    length = _boxProperties.Width;
                    height = _boxProperties.Height;
                    break;
                case HalfAxis.HAxis.AXIS_Y_N:
                case HalfAxis.HAxis.AXIS_Y_P:
                    length = _boxProperties.Length;
                    height = _boxProperties.Height;
                    break;
                case HalfAxis.HAxis.AXIS_Z_N:
                case HalfAxis.HAxis.AXIS_Z_P:
                    length = _boxProperties.Length;
                    height = _boxProperties.Width;
                    break;
                default:
                    length = 0.0;
                    height = 0.0;
                    break;
            }
        }
        #endregion


    }
}
