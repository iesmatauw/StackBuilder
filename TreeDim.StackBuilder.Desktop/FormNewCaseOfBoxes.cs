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
    /// <summary>
    /// Form used to edit CaseOfBoxesProperties object
    /// </summary>
    public partial class FormNewCaseOfBoxes : Form
    {
        #region Data members
        private Document _document;
        public CaseOfBoxesProperties _caseOfBoxesProperties;
        public Color[] _faceColors = new Color[6];
        public List<Pair<HalfAxis.HAxis, Texture>> _textures;
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewCaseOfBoxes));
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormNewCaseOfBoxes(Document document, CaseOfBoxesProperties caseOfBoxProperties)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            // save CaseOfBoxesProperties
            _caseOfBoxesProperties = caseOfBoxProperties;
            // color : all faces set together / face by face
            chkAllFaces.Checked = caseOfBoxProperties.UniqueColor;
            chkAllFaces_CheckedChanged(this, null);
            // set colors
            for (int i = 0; i < 6; ++i)
                _faceColors[i] = caseOfBoxProperties.Colors[i];
            // set textures
            _textures = caseOfBoxProperties.TextureList;
            // set default face
            cbFace.SelectedIndex = 0;
            // set horizontal angle
            trackBarHorizAngle.Value = 45;
            // disable Ok button
            UpdateButtonOkStatus();
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewCaseOfBoxes_Load(object sender, EventArgs e)
        {
            // windows settings
            if (null != Settings.Default.FormNewCaseOfBoxesPosition)
                Settings.Default.FormNewCaseOfBoxesPosition.Restore(this);
            Draw();
        }
        private void FormNewCaseOfBoxes_FormClosing(object sender, FormClosingEventArgs e)
        {
            // window position
            if (null == Settings.Default.FormNewCaseOfBoxesPosition)
                Settings.Default.FormNewCaseOfBoxesPosition = new WindowSettings();
            Settings.Default.FormNewCaseOfBoxesPosition.Record(this);
        }
        #endregion

        #region public properties
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        /// <summary>
        /// Colors
        /// </summary>
        public Color[] Colors
        {
            get { return _faceColors; }
            set { }
        }
        /// <summary>
        /// Textures
        /// </summary>
        public List<Pair<HalfAxis.HAxis, Texture>> TextureList
        {
            get { return _textures; }
            set
            {
                _textures.Clear();
                _textures.AddRange(value);
            }
        }
        #endregion

        #region Event handlers
        private void onHorizAngleChanged(object sender, EventArgs e)
        {
            Draw();
        }
        private void chkAllFaces_CheckedChanged(object sender, EventArgs e)
        {
            lbFace.Enabled = !chkAllFaces.Checked;
            cbFace.Enabled = !chkAllFaces.Checked;
            if (chkAllFaces.Checked)
                cbColor.Color = _faceColors[0];
        }
        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            Draw();
        }
        private void onSelectedFaceChanged(object sender, EventArgs e)
        {
            // get current index
            int iSel = cbFace.SelectedIndex;
            cbColor.Color = _faceColors[iSel];
            Draw();
        }
        private void onFaceColorChanged(object sender, EventArgs e)
        {
            if (!chkAllFaces.Checked)
            {
                int iSel = cbFace.SelectedIndex;
                _faceColors[iSel] = cbColor.Color;
            }
            else
            {
                for (int i = 0; i < 6; ++i)
                    _faceColors[i] = cbColor.Color;
            }
            Draw();
        }
        private void btBitmaps_Click(object sender, EventArgs e)
        {
            try
            {
                FormEditBitmaps form = new FormEditBitmaps(_caseOfBoxesProperties);
                form.Textures = _textures;
                if (DialogResult.OK == form.ShowDialog())
                    _textures = form.Textures;
                Draw();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Draw
        private void Draw()
        {
            try
            {
                // get horizontal angle
                double angle = trackBarHorizAngle.Value;
                // instantiate graphics
                Graphics3DImage graphics1 = new Graphics3DImage(pictureBoxCase.Size);
                graphics1.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics1.Target = Vector3D.Zero;
                graphics1.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                graphics1.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // draw
                BoxProperties boxProperties = new BoxProperties(null
                    , _caseOfBoxesProperties.Length, _caseOfBoxesProperties.Width, _caseOfBoxesProperties.Height);
                boxProperties.SetAllColors(_faceColors);
                boxProperties.TextureList = _textures;
                Box box = new Box(0, boxProperties);
                graphics1.AddBox(box);
                graphics1.AddDimensions(new DimensionCube(_caseOfBoxesProperties.Length, _caseOfBoxesProperties.Width, _caseOfBoxesProperties.Height));
                graphics1.Flush();
                // set to picture box
                pictureBoxCase.Image = graphics1.Bitmap;

                // instantiate graphics
                Graphics3DImage graphics2 = new Graphics3DImage(pictureBoxCaseDefinition.Size);
                graphics2.CameraPosition = new Vector3D(
                    Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                    , 10000.0);
                graphics2.Target = Vector3D.Zero;
                graphics2.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                graphics2.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // view case definition
                CaseDefinitionViewer viewer = new CaseDefinitionViewer(_caseOfBoxesProperties.CaseDefinition, _caseOfBoxesProperties.InsideBoxProperties, _caseOfBoxesProperties.CaseOptimConstraintSet);
                viewer.Draw(graphics2);  
                graphics2.Flush();
                // set to picture box
                pictureBoxCaseDefinition.Image = graphics2.Bitmap;
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Helpers
        private void UpdateButtonOkStatus()
        {
            // status + message
            string message = string.Empty;
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // accept
            bnOK.Enabled = string.IsNullOrEmpty(message);
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion
    }
}
