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
using TreeDim.StackBuilder.Desktop.Properties;

using Sharp3D.Math.Core;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewCaseAnalysis : Form
    {
        #region Data members
        private BoxProperties[] _boxes;
        private Document _document;
        private CaseAnalysis _caseAnalysis;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewCaseAnalysis));
        #endregion

        #region Combo box item private classes
        /// <summary>
        /// Encapsulates a BoxProperties item to be used
        /// </summary>
        private class BoxItem
        {
            private BProperties _boxProperties;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="boxProperties">Encapsulated box properties</param>
            public BoxItem(BProperties boxProperties)
            {
                _boxProperties = boxProperties;
            }

            public BProperties Item { get { return _boxProperties; } }
            public override string ToString() { return _boxProperties.Name; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public FormNewCaseAnalysis(Document document)
        {
            InitializeComponent();
            _document = document;
        }
        /// <summary>
        /// Constructor used while browsing/editing case analysis
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="caseAnalysis">Case analysis</param>
        public FormNewCaseAnalysis(Document document, CaseAnalysis caseAnalysis)
        {
            InitializeComponent();

            _document = document;
            _caseAnalysis = caseAnalysis;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Case analysis name
        /// </summary>
        public string CaseAnalysisName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        /// <summary>
        /// Case analysis description
        /// </summary>
        public string CaseAnalysisDescription
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
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
        /// Selected box
        /// </summary>
        public BoxProperties SelectedBox
        {
            get { return _boxes[cbBoxes.SelectedIndex]; }
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
        /// Allowed patterns
        /// </summary>
        public List<string> AllowedPatterns
        {
            get
            {
                string[] patternNames = TreeDim.StackBuilder.Engine.Solver.PatternNames;
                List<string> listAllowedPatterns = new List<string>();
                foreach (object itemChecked in checkedListBoxPatterns.CheckedItems)
                {
                    // use the IndexOf method to get the index of an item
                    if (checkedListBoxPatterns.GetItemCheckState(checkedListBoxPatterns.Items.IndexOf(itemChecked)) == CheckState.Checked)
                        listAllowedPatterns.Add(patternNames[checkedListBoxPatterns.Items.IndexOf(itemChecked)]);
                }
                return listAllowedPatterns;
            }
        }
        /// <summary>
        /// Allowed patterns as a string
        /// </summary>
        public string AllowedPatternsString
        {
            set
            {
                // get list of existing patterns
                List<string> patternNameList = TreeDim.StackBuilder.Engine.Solver.PatternNameList;
                string allowedPatterns = value;
                int iCountAllowedPatterns = 0;
                string[] vPatternNames = value.Split(',');
                foreach (string patternName in vPatternNames)
                {
                    int index = patternNameList.FindIndex(delegate(string s) { return s == patternName; });
                    if (-1 != index)
                    {
                        checkedListBoxPatterns.SetItemChecked(index, true);
                        ++iCountAllowedPatterns;
                    }
                }
                if (iCountAllowedPatterns == 0)
                    for (int i = 0; i < checkedListBoxPatterns.Items.Count; ++i)
                        checkedListBoxPatterns.SetItemChecked(i, true);
            }
            get
            {
                string allowedPatterns = string.Empty;
                for (int i = 0; i < checkedListBoxPatterns.Items.Count; ++i)
                    if (checkedListBoxPatterns.GetItemChecked(i))
                        allowedPatterns += checkedListBoxPatterns.GetItemText(checkedListBoxPatterns.Items[i]) + ",";
                return allowedPatterns;
            }
        }
        /// <summary>
        /// Allow alternate layers ?
        /// </summary>
        public bool AllowAlternateLayers
        {
            get { return checkBoxAllowAlternateLayer.Checked; }
            set { checkBoxAllowAlternateLayer.Checked = value; }
        }
        /// <summary>
        /// Allow aligned layers
        /// </summary>
        public bool AllowAlignedLayers
        {
            get { return checkBoxAllowAlignedLayer.Checked; }
            set { checkBoxAllowAlignedLayer.Checked = value; }
        }
        public List<PalletSolutionDesc> PalletSolutionList
        {
            get
            {
                List<PalletSolutionDesc> list = new List<PalletSolutionDesc>();
                return PalletSolutionDatabase.Instance.QueryPalletSolutions(CurrentKey);
            }
            set
            {
                foreach (PalletSolutionDesc desc in value)
                {
                }
            }
        }
        /// <summary>
        /// Use maximum case weight criterion?
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
        /// <summary>
        /// Use maximum number of boxes criterion?
        /// </summary>
        public bool UseMaximumNumberOfItems
        {
            get { return checkBoxMaximumNumberOfBoxes.Checked; }
            set { checkBoxMaximumNumberOfBoxes.Checked = value; }
        }
        /// <summary>
        /// Maximum number of boxes
        /// </summary>
        public int MaximumNumberOfItems
        {
            get { return (int)nudMaximumNumberOfBoxes.Value; }
            set { nudMaximumNumberOfBoxes.Value = (decimal)value; }
        }
        /// <summary>
        /// Use minimum number of items
        /// </summary>
        public bool UseMinimumNumberOfItems
        {
            get { return checkBoxMinNumberOfItems.Checked; }
            set { checkBoxMinNumberOfItems.Checked = value;}
        }
        /// <summary>
        /// Minimum number of items
        /// </summary>
        public int MinimumNumberOfItems
        {
            get { return (int)nudMinBoxPerCase.Value; }
            set { nudMinBoxPerCase.Value = value; }
        }
        /// <summary>
        /// Use number of solutions kept?
        /// </summary>
        public bool UseNumberOfSolutionsKept
        {
            get { return checkBoxKeepSolutions.Checked; }
            set { checkBoxKeepSolutions.Checked = value; }
        }
        /// <summary>
        /// Number of solutions kept
        /// </summary>
        public int NumberOfSolutionsKept
        {
            get { return (int)nudSolutions.Value; }
            set { nudSolutions.Value = value; }
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewCaseAnalysis_Load(object sender, EventArgs e)
        {
            try
            {
                // name / description
                if (null != _caseAnalysis)
                {
                    tbName.Text = _caseAnalysis.Name;
                    tbDescription.Text = _caseAnalysis.Description;
                }
                // fill boxes combo
                foreach (BProperties box in _boxes)
                    cbBoxes.Items.Add(new BoxItem(box));
                // select box item
                if (cbBoxes.Items.Count > 0)
                {
                    if (null == _caseAnalysis)
                        cbBoxes.SelectedIndex = 0;
                    else
                    {
                        for (int i = 0; i < cbBoxes.Items.Count; ++i)
                        {
                            BoxItem boxItem = cbBoxes.Items[i] as BoxItem;
                            if (boxItem.Item == _caseAnalysis.BoxProperties)
                            {
                                cbBoxes.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                // Fill key combo
                FillKeyCombo();

                // allowed position box + allowed patterns
                if (null == _caseAnalysis)
                {
                    AllowAlignedLayers = Settings.Default.AllowAlignedLayer_CaseAnalysis;
                    AllowAlternateLayers = Settings.Default.AllowAlternateLayer_CaseAnalysis;

                    AllowVerticalX = Settings.Default.AllowVerticalX_CaseAnalysis;
                    AllowVerticalY = Settings.Default.AllowVerticalY_CaseAnalysis;
                    AllowVerticalZ = Settings.Default.AllowVerticalZ_CaseAnalysis;

                    AllowedPatternsString = Settings.Default.AllowedPatterns_CaseAnalysis;
                }
                else
                {
                    AllowAlignedLayers = _caseAnalysis.ConstraintSet.AllowAlignedLayers;
                    AllowAlternateLayers = _caseAnalysis.ConstraintSet.AllowAlternateLayers;

                    CaseConstraintSet constraintSet = _caseAnalysis.ConstraintSet;
                    AllowVerticalX = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_P);
                    AllowVerticalY = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_P);
                    AllowVerticalZ = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_P);

                    AllowedPatternsString = constraintSet.AllowedPatternString;
                }

                // update controls
                UpdateConditionStatus(this, null);
                UpdateButtonOkStatus();

                // windows settings
                if (null != Settings.Default.FormNewCaseAnalysisPosition)
                    Settings.Default.FormNewCaseAnalysisPosition.Restore(this);
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }

        private void FormNewCaseAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (null == Settings.Default.FormNewCaseAnalysisPosition)
                    Settings.Default.FormNewCaseAnalysisPosition = new WindowSettings();
                Settings.Default.FormNewCaseAnalysisPosition.Record(this);
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Event handlers
        private void onBoxChanged(object sender, EventArgs e)
        {
            DrawBoxPositions();
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            // name
            if (string.IsNullOrEmpty(tbName.Text))
                message = Resources.ID_FIELDNAMEEMPTY;
            // description
            else if (string.IsNullOrEmpty(tbDescription.Text))
                message = Resources.ID_FIELDDESCRIPTIONEMPTY;
            // name validity
            else if (!_document.IsValidNewAnalysisName(tbName.Text, _caseAnalysis))
                message = string.Format(Resources.ID_INVALIDNAME, tbName.Text);
            // orientation
            else if (!AllowVerticalX && !AllowVerticalY && !AllowVerticalZ)
                message = Resources.ID_DEFINEATLEASTONEVERTICALAXIS;
            // patterns
            else if (AllowedPatterns.Count < 1)
                message = Resources.ID_DEFINEATLEASTONEPATTERN;
            // AllowAlignedLayers / AllowAlternateLayers
            else if (!AllowAlignedLayers && !AllowAlternateLayers)
                message = Resources.ID_ALLOWALIGNEDORALTERNATELAYERS;
            //---
            // button OK
            bnOK.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }

        private void UpdateConditionStatus(object sender, EventArgs e)
        {
            nudMaximumCaseWeight.Enabled    = checkBoxMaximumCaseWeight.Checked;
            nudMaximumNumberOfBoxes.Enabled = checkBoxMaximumNumberOfBoxes.Checked;
            nudMinBoxPerCase.Enabled        = checkBoxMinNumberOfItems.Checked;
            nudSolutions.Enabled            = checkBoxKeepSolutions.Checked;
        }

        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        private void onCheckedChangedAlignedLayer(object sender, EventArgs e)
        {
            if (!checkBoxAllowAlignedLayer.Checked && !checkBoxAllowAlternateLayer.Checked)
                checkBoxAllowAlternateLayer.Checked = true;
            UpdateButtonOkStatus();
        }
        private void onCheckedChangedAlternateLayer(object sender, EventArgs e)
        {
            if (!checkBoxAllowAlignedLayer.Checked && !checkBoxAllowAlternateLayer.Checked)
                checkBoxAllowAlignedLayer.Checked = true;
            UpdateButtonOkStatus();
        }
        private void onVerticalAxisChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        private void onAllowedPatternsChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        #endregion

        #region Control update methods
        private void UpdateSolutionsToKeep()
        {
            nudSolutions.Enabled = checkBoxKeepSolutions.Checked;
        }
        private void UpdateCriterionFields()
        {
            nudMaximumNumberOfBoxes.Enabled = checkBoxMaximumNumberOfBoxes.Checked;
            nudMaximumCaseWeight.Enabled = checkBoxMaximumCaseWeight.Checked;
        }
        #endregion

        #region Pallet solutions
        private void FillKeyCombo()
        {
            // check if database is empty
            if (PalletSolutionDatabase.Instance.IsEmpty)
            {
                MessageBox.Show(Resources.ID_DATABASEEMPTY, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            // fill key combo box
            cbPalletDimensions.Items.Clear();
            cbPalletDimensions.Items.AddRange(PalletSolutionDatabase.Instance.Keys.ToArray());
            if (cbPalletDimensions.Items.Count > 0)
                cbPalletDimensions.SelectedIndex = 0;

            FillGrid();
        }
        private PalletSolutionKey CurrentKey
        {
            get
            {
                // sanity check
                if (cbPalletDimensions.Items.Count == 0) return null;
                // get selected item
                return cbPalletDimensions.Items[cbPalletDimensions.SelectedIndex] as PalletSolutionKey;
            }
        }
        private void FillGrid()
        {
            // fill grid solution
            gridSolutions.Rows.Clear();

            // border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

            // views
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            viewNormal.Border = cellBorder;
            CheckboxBackColorAlternate viewNormalCheck = new CheckboxBackColorAlternate(Color.LightBlue, Color.White);
            viewNormalCheck.Border = cellBorder;

            // column header view
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
            backHeader.BackColor = Color.LightGray;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.White;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;

            // create the grid
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;

            gridSolutions.ColumnsCount = 7;
            gridSolutions.FixedRows = 1;
            gridSolutions.Rows.Insert(0);

            // header
            SourceGrid.Cells.ColumnHeader columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Case");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 0] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Name");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 1] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Case dimensions\n(mm*mm*mm)");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 2] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Case inside dimensions\n(mm*mm*mm)");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 3] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Orientation");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 4] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Case count");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 5] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Selected");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 6] = columnHeader;

            int iIndex = 0;
            foreach (PalletSolutionDesc desc in PalletSolutionDatabase.Instance.QueryPalletSolutions(CurrentKey))
            {
                gridSolutions.Rows.Insert(++iIndex);
                gridSolutions[iIndex, 0] = new SourceGrid.Cells.Image(GetBoxBitmapFromDesc(desc));
                gridSolutions[iIndex, 1] = new SourceGrid.Cells.Cell(desc.FriendlyName);
                gridSolutions[iIndex, 2] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseDimensionsString));
                gridSolutions[iIndex, 3] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseInsideDimensionsString));
                gridSolutions[iIndex, 4] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseOrientation));
                gridSolutions[iIndex, 5] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseCount));
                gridSolutions[iIndex, 6] = new SourceGrid.Cells.CheckBox(null, true);
                SourceGrid.Cells.Controllers.Button buttonClickEvent = new SourceGrid.Cells.Controllers.Button();
            }

            // handling check box click
            SourceGrid.Cells.Controllers.CustomEvents solCheckboxClickEvent = new SourceGrid.Cells.Controllers.CustomEvents();

            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();

            // select first solution
            gridSolutions.Selection.SelectRow(-1, false);
        }
        private Bitmap GetBoxBitmapFromDesc(PalletSolutionDesc desc)
        {
            bool showDimensions = false;

            // load document
            Document document = new Document(desc.FullFilePath, null);
            if (document.Analyses.Count != 1)
                throw new Exception("Failed to load analysis.");
            // get analysis and solution
            PalletAnalysis analysis = document.Analyses[0];
            Graphics3DImage graphics = new Graphics3DImage(new Size(50,50));
            graphics.CameraPosition = Graphics3D.Corner_0;
            graphics.Target = Vector3D.Zero;
            Box box = new Box(0, analysis.BProperties);
            graphics.AddBox(box);
            if (showDimensions)
                graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
            graphics.Flush();
            return graphics.Bitmap;
        }
        #endregion

        #region Box position drawings
        private void DrawBoxPositions()
        {
            // get current boxProperties
            BProperties selectedBox = SelectedBox;
            DrawBoxPosition(selectedBox, HalfAxis.HAxis.AXIS_X_P, pictureBoxPositionX);
            DrawBoxPosition(selectedBox, HalfAxis.HAxis.AXIS_Y_P, pictureBoxPositionY);
            DrawBoxPosition(selectedBox, HalfAxis.HAxis.AXIS_Z_P, pictureBoxPositionZ);
        }

        private void DrawBoxPosition(BProperties boxProperties, HalfAxis.HAxis axis, PictureBox pictureBox)
        {
            // get horizontal angle
            double angle = 45;
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
            Box box = new Box(0, boxProperties);

            // set axes
            HalfAxis.HAxis lengthAxis = HalfAxis.HAxis.AXIS_X_P;
            HalfAxis.HAxis widthAxis = HalfAxis.HAxis.AXIS_Y_P;
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_P: lengthAxis = HalfAxis.HAxis.AXIS_Z_P; widthAxis = HalfAxis.HAxis.AXIS_X_P; break;
                case HalfAxis.HAxis.AXIS_Y_P: lengthAxis = HalfAxis.HAxis.AXIS_X_P; widthAxis = HalfAxis.HAxis.AXIS_Z_N; break;
                case HalfAxis.HAxis.AXIS_Z_P: lengthAxis = HalfAxis.HAxis.AXIS_X_P; widthAxis = HalfAxis.HAxis.AXIS_Y_P; break;
                default: break;
            }
            box.LengthAxis = TreeDim.StackBuilder.Basics.HalfAxis.ToVector3D(lengthAxis);
            box.WidthAxis = TreeDim.StackBuilder.Basics.HalfAxis.ToVector3D(widthAxis);

            // draw box
            graphics.AddBox(box);
            graphics.Flush();
            // set to picture box
            pictureBox.Image = graphics.Bitmap;
        }
        #endregion
    }
}
