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

using log4net;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewBoxCaseAnalysis : Form
    {
        #region Data members
        private BoxProperties[] _boxes, _cases;
        private TreeDim.StackBuilder.Basics.Document _document;
        private BoxCaseAnalysis _analysis;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBoxCaseAnalysis));
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="document">Parent document</param>
        public FormNewBoxCaseAnalysis(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // name
            tbName.Text = _document.GetValidNewAnalysisName(Resources.ID_ANALYSIS);
            tbDescription.Text = tbName.Text;
        }
        /// <summary>
        /// Constructor used while browsing/editing existing analysis
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="analysis">Analysis</param>
        public FormNewBoxCaseAnalysis(Document document, BoxCaseAnalysis analysis)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _analysis = analysis;
            // set caption text
            Text = string.Format(Properties.Resources.ID_EDIT, _analysis.Name);
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewBoxCaseAnalysis_Load(object sender, EventArgs e)
        {
            try
            {
                // name / description
                if (null != _analysis)
                {
                    tbName.Text = _analysis.Name;
                    tbDescription.Text = _analysis.Description;
                }
                // fill boxes combo
                ComboBoxHelpers.FillCombo(_boxes, cbBox, null == _analysis ? null : _analysis.BoxProperties);
                // fill case properties
                ComboBoxHelpers.FillCombo(_cases, cbCase, null == _analysis ? null : _analysis.CaseProperties);

                // allowed position box + allowed patterns
                if (null == _analysis)
                {
                    AllowVerticalX = Settings.Default.AllowVerticalX;
                    AllowVerticalY = Settings.Default.AllowVerticalY;
                    AllowVerticalZ = Settings.Default.AllowVerticalZ;
                }
                else
                {
                    BoxCaseConstraintSet constraintSet = _analysis.ConstraintSet;
                    AllowVerticalX = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_P);
                    AllowVerticalY = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_P);
                    AllowVerticalZ = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_P);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void FormNewBoxCaseAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }

        }
        #endregion

        #region Combo boxes
        /// <summary>
        /// Selected box
        /// </summary>
        public BoxProperties SelectedBox
        {
            get { return _boxes[cbBox.SelectedIndex]; }
        }
        /// <summary>
        /// Selected case
        /// </summary>
        public BoxProperties SelectedCase
        {
            get { return _cases[cbCase.SelectedIndex]; }
        }
        #endregion

        #region Handlers
        private void onFormContentChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }

        private void onBoxChanged(object sender, EventArgs e)
        {
            DrawBoxPositions();
            UpdateButtonOkStatus();
        }

        private void onCaseChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }

        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // name validity
            else if (!_document.IsValidNewAnalysisName(tbName.Text, _analysis))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // orientation
            else if (!AllowVerticalX && !AllowVerticalY && !AllowVerticalZ)
                message = Resources.ID_DEFINEATLEASTONEVERTICALAXIS;
            else if (UseMaximumCaseWeight && (MaximumCaseWeight < SelectedCase.Weight + SelectedBox.Weight))
                message = string.Format(Resources.ID_MAXIMUMCASEWEIGHTSHOULDEXCEED, SelectedCase.Weight + SelectedBox.Weight);
            // update nud boxes according to checkbox
            nudMaximumCaseWeight.Enabled = checkBoxMaximumCaseWeight.Checked;
            nudMaximumNumberOfBoxes.Enabled = checkBoxMaximumNumberOfBoxes.Checked;
            //---
            // button OK
            bnOk.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Analysis name
        /// </summary>
        public string AnalysisName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        /// <summary>
        /// Analysis description
        /// </summary>
        public string AnalysisDescription
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }
        /// <summary>
        /// Allow X vertical orientation
        /// </summary>
        public bool AllowVerticalX
        {
            get { return checkBoxPositionX.Checked; }
            set { checkBoxPositionX.Checked = value; }
        }
        /// <summary>
        /// Allow Y vertical orientation
        /// </summary>
        public bool AllowVerticalY
        {
            get { return checkBoxPositionY.Checked; }
            set { checkBoxPositionY.Checked = value; }
        }
        /// <summary>
        ///  Allow Z vertical orientation
        /// </summary>
        public bool AllowVerticalZ
        {
            get { return checkBoxPositionZ.Checked; }
            set { checkBoxPositionZ.Checked = value; }
        }
        /// <summary>
        /// List of boxes
        /// </summary>
        public BoxProperties[] Boxes
        {
            get { return _boxes; }
            set { _boxes = value; }
        }
        /// <summary>
        /// List of cases
        /// </summary>
        public BoxProperties[] Cases
        {
            get { return _cases; }
            set { _cases = value; }
        }
        /// <summary>
        /// Use maximum number of boxes criterion?
        /// </summary>
        public bool UseMaximumNumberOfBoxes
        {
            get { return checkBoxMaximumNumberOfBoxes.Checked; }
            set { checkBoxMaximumNumberOfBoxes.Checked = value; }
        }
        /// <summary>
        /// Maximum number of boxes
        /// </summary>
        public int MaximumNumberOfBoxes
        {
            get { return (int)nudMaximumNumberOfBoxes.Value; }
            set { nudMaximumNumberOfBoxes.Value = (decimal)value; }
        }
        /// <summary>
        /// Use maximum case weight ?
        /// </summary>
        public bool UseMaximumCaseWeight
        {
            get { return checkBoxMaximumCaseWeight.Checked; }
            set { checkBoxMaximumCaseWeight.Checked = value; }
        }
        /// <summary>
        /// Maximum case weight
        /// </summary>
        public double MaximumCaseWeight
        {
            get { return (double)nudMaximumCaseWeight.Value; }
            set { nudMaximumCaseWeight.Value = (decimal)value; }
        }
        #endregion

        #region Box position drawings
        private void DrawBoxPositions()
        { 
            // get current boxProperties
            BProperties selectedBox = SelectedBox;
            BoxToPictureBox.Draw(selectedBox, HalfAxis.HAxis.AXIS_X_P, pictureBoxPositionX);
            BoxToPictureBox.Draw(selectedBox, HalfAxis.HAxis.AXIS_Y_P, pictureBoxPositionY);
            BoxToPictureBox.Draw(selectedBox, HalfAxis.HAxis.AXIS_Z_P, pictureBoxPositionZ);
        }
        #endregion
    }
}
