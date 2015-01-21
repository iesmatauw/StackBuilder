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
    public partial class FormNewCaseOfBoxes
        : Form, IDrawingContainer
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
            // name / description
            if (null != caseOfBoxProperties)
            {
                tbName.Text = caseOfBoxProperties.Name;
                tbDescription.Text = caseOfBoxProperties.Description;
            }
            else
            {
                tbName.Text = _document.GetValidNewTypeName(Resources.ID_CASEOFBOXES);
                tbDescription.Text = tbName.Text;
            }
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
            // disable Ok button
            UpdateButtonOkStatus();
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewCaseOfBoxes_Load(object sender, EventArgs e)
        {
            graphCtrlBoxCase.DrawingContainer = this;
            graphCtrlCaseDefinition.DrawingContainer = this;
            // windows settings
            if (null != Settings.Default.FormNewCaseOfBoxesPosition)
                Settings.Default.FormNewCaseOfBoxesPosition.Restore(this);
            graphCtrlBoxCase.Invalidate();
            graphCtrlCaseDefinition.Invalidate();
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
        public string CaseName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string CaseDescription
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
        private void chkAllFaces_CheckedChanged(object sender, EventArgs e)
        {
            lbFace.Enabled = !chkAllFaces.Checked;
            cbFace.Enabled = !chkAllFaces.Checked;
            if (chkAllFaces.Checked)
                cbColor.Color = _faceColors[0];
        }
        private void onSelectedFaceChanged(object sender, EventArgs e)
        {
            // get current index
            int iSel = cbFace.SelectedIndex;
            cbColor.Color = _faceColors[iSel];
            graphCtrlBoxCase.Invalidate();
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
            graphCtrlBoxCase.Invalidate();
        }
        private void btBitmaps_Click(object sender, EventArgs e)
        {
            try
            {
                FormEditBitmaps form = new FormEditBitmaps(_caseOfBoxesProperties);
                form.Textures = _textures;
                if (DialogResult.OK == form.ShowDialog())
                    _textures = form.Textures;
                graphCtrlBoxCase.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Draw
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (graphCtrlBoxCase == ctrl)
            {
                BoxProperties boxProperties = new BoxProperties(null
                    , _caseOfBoxesProperties.Length, _caseOfBoxesProperties.Width, _caseOfBoxesProperties.Height);
                boxProperties.SetAllColors(_faceColors);
                boxProperties.TextureList = _textures;
                Box box = new Box(0, boxProperties);
                graphics.AddBox(box);
                graphics.AddDimensions(new DimensionCube(_caseOfBoxesProperties.Length, _caseOfBoxesProperties.Width, _caseOfBoxesProperties.Height));
            }
            else if (graphCtrlCaseDefinition == ctrl)
            {
                CaseDefinitionViewer viewer = new CaseDefinitionViewer(_caseOfBoxesProperties.CaseDefinition, _caseOfBoxesProperties.InsideBoxProperties, _caseOfBoxesProperties.CaseOptimConstraintSet);
                viewer.CaseProperties = _caseOfBoxesProperties;
                viewer.Orientation = new Basics.Orientation(HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                viewer.Draw(graphics);  
            }
        }
        #endregion

        #region Helpers
        private void UpdateButtonOkStatus()
        {
            // status + message
            string message = string.Empty;
            // name validity
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            else if (!_document.IsValidNewTypeName(tbName.Text, _caseOfBoxesProperties))
                message = Resources.ID_FIELDNAMEINVALID;
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // button OK
            bnOK.Enabled = string.IsNullOrEmpty(message);
            // status bar
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
