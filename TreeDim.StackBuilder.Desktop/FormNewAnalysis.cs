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
    public partial class FormNewAnalysis : Form
    {
        #region Data members
        private BProperties[] _cases;
        private PalletProperties[] _palletProperties;
        private InterlayerProperties[] _interlayerProperties;
        private ItemBase[] _palletCornerProperties;
        private ItemBase[] _palletCapProperties;
        private ItemBase[] _palletFilmProperties;
        private Document _document;
        private CasePalletAnalysis _analysis;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysis));
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="document"></param>
        public FormNewAnalysis(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // name / description
            tbName.Text = document.GetValidNewAnalysisName(Resources.ID_ANALYSIS);
            tbDescription.Text = tbName.Text;
            // update interlayer UI
            onInterlayerChecked(this, null);
            onAntiSlipInterlayerChecked(this, null);
        }
        /// <summary>
        /// Constructor used while browsing/editing existing analysis
        /// </summary>
        /// <param name="document">Parent document</param>
        /// <param name="analysis">Analysis</param>
        public FormNewAnalysis(Document document, CasePalletAnalysis analysis)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _analysis = analysis;
            // set caption text
            Text = string.Format(Properties.Resources.ID_EDIT, _analysis.Name);

            onInterlayerChecked(this, null);
            onAntiSlipInterlayerChecked(this, null);
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewAnalysis_Load(object sender, EventArgs e)
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
                foreach (BProperties box in _cases)
                    cbBox.Items.Add(new BoxItem(box));
                if (cbBox.Items.Count > 0)
                {
                    if (null == _analysis)
                        cbBox.SelectedIndex = 0;
                    else
                    {
                        for (int i = 0; i < cbBox.Items.Count; ++i)
                        {
                            BoxItem boxItem = cbBox.Items[i] as BoxItem;
                            if (boxItem.Item == _analysis.BProperties)
                            {
                                cbBox.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                // fill pallet combo
                foreach (PalletProperties pallet in _palletProperties)
                    cbPallet.Items.Add(new PalletItem(pallet));
                if (cbPallet.Items.Count > 0)
                {
                    if (null == _analysis)
                        cbPallet.SelectedIndex = 0;
                    else
                    {
                        for (int i = 0; i < cbPallet.Items.Count; ++i)
                        {
                            PalletItem palletItem = cbPallet.Items[i] as PalletItem;
                            if (palletItem.Item == _analysis.PalletProperties)
                            {
                                cbPallet.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                // fill other combo
                FillCombo(checkBoxInterlayer, cbInterlayer, _interlayerProperties, (null == _analysis) ? null : _analysis.InterlayerProperties);
                FillCombo(checkBoxAntiSlipInterlayer, cbInterlayerAntiSlip, _interlayerProperties, (null == _analysis) ? null : _analysis.InterlayerPropertiesAntiSlip);
                FillCombo(chkbCorners, cbCorners, _palletCornerProperties, (null == _analysis) ? null : _analysis.PalletCornerProperties);
                FillCombo(chkbPalletCap, cbPalletCap, _palletCapProperties, (null == _analysis) ? null : _analysis.PalletCapProperties);
                FillCombo(chkbFilm, cbPalletFilm, _palletFilmProperties, (null == _analysis) ? null : _analysis.PalletFilmProperties);
                // overhang
                if (null == _analysis)
                {
                    OverhangX = Settings.Default.OverhangX;
                    OverhangY = Settings.Default.OverhangY;
                }
                else
                {
                    OverhangX = _analysis.ConstraintSet.OverhangX;
                    OverhangY = _analysis.ConstraintSet.OverhangY;
                }

                // allowed position box + allowed patterns
                if (null == _analysis)
                {
                    AllowVerticalX = Settings.Default.AllowVerticalX;
                    AllowVerticalY = Settings.Default.AllowVerticalY;
                    AllowVerticalZ = Settings.Default.AllowVerticalZ;

                    AllowedPatternsString = Settings.Default.AllowedPatterns;

                    AllowTwoLayerOrientations = Settings.Default.AllowLayerOrientChange;
                    AllowLastLayerOrientationChange = Settings.Default.AllowLayerOrientChangeLastOnly;

                }
                else
                {
                    PalletConstraintSet constraintSet = _analysis.ConstraintSet;
                    AllowVerticalX = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_X_P);
                    AllowVerticalY = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Y_P);
                    AllowVerticalZ = constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_N) || constraintSet.AllowOrthoAxis(HalfAxis.HAxis.AXIS_Z_P);

                    AllowTwoLayerOrientations = constraintSet.AllowTwoLayerOrientations;
                    AllowLastLayerOrientationChange = constraintSet.AllowLastLayerOrientationChange;

                    AllowedPatternsString = constraintSet.AllowedPatternString;
                }

                // alternate / aligned layers + stop stacking criterion
                if (null == _analysis)
                {
                    AllowAlignedLayers = Settings.Default.AllowAlignedLayer;
                    AllowAlternateLayers = Settings.Default.AllowAlternateLayer;

                    UseMaximumNumberOfBoxes = false;
                    UseMaximumPalletHeight = true;
                    UseMaximumPalletWeight = true;
                    UseMaximumLoadOnBox = false;

                    MaximumNumberOfBoxes = 500;
                    MaximumPalletHeight = UnitsManager.ConvertLengthFrom(Properties.Settings.Default.MaximumPalletHeight, UnitsManager.UnitSystem.UNIT_METRIC1);
                    MaximumPalletWeight = UnitsManager.ConvertMassFrom(Properties.Settings.Default.MaximumPalletWeight, UnitsManager.UnitSystem.UNIT_METRIC1);
                    MaximumLoadOnBox = 100.0;
                }
                else
                { 
                    AllowAlignedLayers = _analysis.ConstraintSet.AllowAlignedLayers;
                    AllowAlternateLayers = _analysis.ConstraintSet.AllowAlternateLayers;
                    UseMaximumNumberOfBoxes = _analysis.ConstraintSet.UseMaximumNumberOfCases;
                    UseMaximumPalletHeight = _analysis.ConstraintSet.UseMaximumHeight;
                    UseMaximumPalletWeight = _analysis.ConstraintSet.UseMaximumPalletWeight;
                    UseMaximumLoadOnBox = _analysis.ConstraintSet.UseMaximumWeightOnBox;

                    MaximumNumberOfBoxes = _analysis.ConstraintSet.MaximumNumberOfItems;
                    MaximumPalletHeight = _analysis.ConstraintSet.MaximumHeight;
                    MaximumPalletWeight = _analysis.ConstraintSet.MaximumPalletWeight;
                    MaximumLoadOnBox = _analysis.ConstraintSet.MaximumWeightOnBox;
                }

                UpdateCriterionFields();
                UpdateButtonOkStatus();

                // windows settings
                if (null != Settings.Default.FormNewAnalysisPosition)
                    Settings.Default.FormNewAnalysisPosition.Restore(this);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void FillCombo(CheckBox chkb, ComboBox cb, ItemBase[] items, ItemBase selectedItem)
        {
            foreach (ItemBase item in items)
                cb.Items.Add(new ItemBaseEncapsulator(item));
            if (cb.Items.Count > 0)
            {
                if (null == selectedItem)
                    cb.SelectedIndex = 0;
                else
                {
                    for (int i = 0; i < cb.Items.Count; ++i)
                    {
                        ItemBaseEncapsulator itemEncapsulator = cbInterlayer.Items[i] as ItemBaseEncapsulator;
                        if (itemEncapsulator.Item == selectedItem)
                        {
                            cb.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            chkb.Checked = null != selectedItem;
            chkb.Enabled = null != selectedItem;
        }

        private void FormNewAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // overhang
                Settings.Default.OverhangX = OverhangX;
                Settings.Default.OverhangY = OverhangY;
                // allowed position box
                Settings.Default.AllowVerticalX = AllowVerticalX;
                Settings.Default.AllowVerticalY = AllowVerticalY;
                Settings.Default.AllowVerticalZ = AllowVerticalZ;
                // alternate / aligned layers
                Settings.Default.AllowAlignedLayer = AllowAlignedLayers;
                Settings.Default.AllowAlternateLayer = AllowAlternateLayers;
                // allowed patterns
                Settings.Default.AllowedPatterns = AllowedPatternsString;
                // Maximum pallet height / weight
                Settings.Default.MaximumPalletHeight = UnitsManager.ConvertLengthTo(MaximumPalletHeight, UnitsManager.UnitSystem.UNIT_METRIC1);
                Settings.Default.MaximumPalletWeight = UnitsManager.ConvertMassTo(MaximumPalletWeight, UnitsManager.UnitSystem.UNIT_METRIC1);
                // window position
                if (null == Settings.Default.FormNewAnalysisPosition)
                    Settings.Default.FormNewAnalysisPosition = new WindowSettings();
                Settings.Default.FormNewAnalysisPosition.Record(this);
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Analysis name
        /// </summary>
        public string AnalysisName
        {
            get { return tbName.Text; }
        }
        /// <summary>
        /// Analysis description
        /// </summary>
        public string AnalysisDescription
        {
            get { return tbDescription.Text; }
        }
        /// <summary>
        /// List of boxes
        /// </summary>
        public BProperties[] Cases
        {
            get { return _cases;}
            set { _cases = value; }
        }
        /// <summary>
        /// List of pallets
        /// </summary>
        public PalletProperties[] Pallets
        {
            get { return _palletProperties; }
            set { _palletProperties = value; }
        }
        /// <summary>
        /// List of interlayers
        /// </summary>
        public InterlayerProperties[] Interlayers
        {
            get { return _interlayerProperties; }
            set { _interlayerProperties = value; }
        }
        public ItemBase[] PalletCorners
        {
            get { return _palletCornerProperties; }
            set { _palletCornerProperties = value; }
        }
        public ItemBase[] PalletCaps
        {
            get { return _palletCapProperties; }
            set { _palletCapProperties = value; }
        }
        public ItemBase[] PalletFilms
        {
            get { return _palletFilmProperties; }
            set { _palletFilmProperties = value; }
        }
        /// <summary>
        /// Selected box
        /// </summary>
        public BProperties SelectedBox
        {
            get { return _cases[cbBox.SelectedIndex]; }
        }
        /// <summary>
        /// Selected pallet
        /// </summary>
        public PalletProperties SelectedPallet
        {
            get { return _palletProperties[cbPallet.SelectedIndex]; }
        }
        /// <summary>
        /// Selected interlayer
        /// </summary>
        public InterlayerProperties SelectedInterlayer
        {
            get
            {
                if (null == _interlayerProperties
                    || _interlayerProperties.Length == 0
                    || !checkBoxInterlayer.Checked
                    || -1 == cbInterlayer.SelectedIndex)
                    return null;
                else
                    return _interlayerProperties[cbInterlayer.SelectedIndex]; 
            }
        }
        /// <summary>
        /// Selected anti-slip interlayer
        /// </summary>
        public InterlayerProperties SelectedInterlayerAntiSlip
        {
            get
            {
                if (null == _interlayerProperties
                    || _interlayerProperties.Length == 0
                    || !checkBoxAntiSlipInterlayer.Checked
                    || -1 == cbInterlayerAntiSlip.SelectedIndex)
                    return null;
                else
                    return _interlayerProperties[cbInterlayerAntiSlip.SelectedIndex];
            }
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
        /// Use maximum pallet height criterion ?
        /// </summary>
        public bool UseMaximumPalletHeight
        {
            get { return checkBoxMaximumPalletHeight.Checked; }
            set { checkBoxMaximumPalletHeight.Checked = value; }
        }
        /// <summary>
        /// Maximum pallet height
        /// </summary>
        public double MaximumPalletHeight
        {
            get { return (double)nudMaximumPalletHeight.Value; }
            set { nudMaximumPalletHeight.Value = (decimal)value; }
        }
        /// <summary>
        /// Use maximum pallet weight ?
        /// </summary>
        public bool UseMaximumPalletWeight
        {
            get { return checkBoxMaximumPalletWeight.Checked; }
            set { checkBoxMaximumPalletWeight.Checked = value; }
        }
        /// <summary>
        /// Maximum pallet height
        /// </summary>
        public double MaximumPalletWeight
        {
            get { return (double)nudMaximumPalletWeight.Value; }
            set { nudMaximumPalletWeight.Value = (decimal)value; }
        }
        /// <summary>
        /// Use maximum load on box
        /// </summary>
        public bool UseMaximumLoadOnBox
        {
            get { return checkBoxMaximumLoadOnBox.Checked; }
            set { checkBoxMaximumLoadOnBox.Checked = value; }
        }
        /// <summary>
        /// Maximum load on box
        /// </summary>
        public double MaximumLoadOnBox
        {
            get { return (double)nudMaximumLoadOnBox.Value; }
            set { nudMaximumLoadOnBox.Value = (decimal) value; }
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
        /// Allow using a combination two layer orientations
        /// </summary>
        public bool AllowTwoLayerOrientations
        {
            get { return checkBoxAllowTwoLayerOrient.Checked; }
            set { checkBoxAllowTwoLayerOrient.Checked = value; }
        }
        /// <summary>
        /// Allow changing last layer direction to use remaining space
        /// </summary>
        public bool AllowLastLayerOrientationChange
        {
            get { return checkBoxAllowChangingLastLayerOrient.Checked; }
            set { checkBoxAllowChangingLastLayerOrient.Checked = value; }
        }
        /// <summary>
        /// Allowed patterns
        /// </summary>
        public List<string> AllowedPatterns
        {
            get
            {
                string[] patternNames = TreeDim.StackBuilder.Engine.CasePalletSolver.PatternNames;
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
                List<string> patternNameList = TreeDim.StackBuilder.Engine.CasePalletSolver.PatternNameList;
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
                        allowedPatterns += checkedListBoxPatterns.GetItemText(checkedListBoxPatterns.Items[i]) + ";";
                return allowedPatterns;
            }
        }
        /// <summary>
        /// Has interlayer ?
        /// </summary>
        public bool HasInterlayers
        {
            get { return checkBoxInterlayer.Checked; }
            set { checkBoxInterlayer.Checked = value; }
        }
        public bool HasInterlayerAntiSlip
        {
            get { return checkBoxAntiSlipInterlayer.Checked; }
            set { checkBoxAntiSlipInterlayer.Checked = value; }
        }
        /// <summary>
        /// Interlayer period
        /// </summary>
        public int InterlayerPeriod
        {
            get { return (int)nudInterlayerFreq.Value; }
            set { nudInterlayerFreq.Value = (decimal)value; }
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
        /// <summary>
        /// Length overhang
        /// </summary>
        public double OverhangX
        {
            get { return (double)nudPalletOverhangX.Value; }
            set { nudPalletOverhangX.Value = (decimal)value; }
        }
        /// <summary>
        /// Width overhang
        /// </summary>
        public double OverhangY
        {
            get { return (double)nudPalletOverhangY.Value; }
            set { nudPalletOverhangY.Value = (decimal)value; }
        }
        #endregion

        #region Handlers
        private void onBoxChanged(object sender, EventArgs e)
        {
            DrawCasePositions();
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
            else if (!_document.IsValidNewAnalysisName(tbName.Text, _analysis))
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
            else if (!UseMaximumLoadOnBox && !UseMaximumNumberOfBoxes && !UseMaximumPalletHeight && !UseMaximumPalletWeight)
                message = Resources.ID_USEATLEASTONESTOPSTACKINGCRITERION;
            //---
            // button OK
            bnOk.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void onFormContentChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        private void UpdateCriterionFields()
        { 
            nudMaximumNumberOfBoxes.Enabled = checkBoxMaximumNumberOfBoxes.Checked;
            nudMaximumPalletHeight.Enabled = checkBoxMaximumPalletHeight.Checked;
            nudMaximumPalletWeight.Enabled = checkBoxMaximumPalletWeight.Checked;
            nudMaximumLoadOnBox.Enabled = checkBoxMaximumLoadOnBox.Checked;
        }
        private void onCriterionCheckChanged(object sender, EventArgs e)
        {
            UpdateCriterionFields();
        }
        private void onInterlayerChecked(object sender, EventArgs e)
        {
            cbInterlayer.Enabled = checkBoxInterlayer.Checked;
            lbInterlayerFreq1.Enabled = checkBoxInterlayer.Checked;
            lbInterlayerFreq2.Enabled = checkBoxInterlayer.Checked;
            nudInterlayerFreq.Enabled = checkBoxInterlayer.Checked;
        }
        private void onAntiSlipInterlayerChecked(object sender, EventArgs e)
        {
            cbInterlayerAntiSlip.Enabled = checkBoxAntiSlipInterlayer.Checked;
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
        #endregion

        #region Box position drawings
        private void DrawCasePositions()
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