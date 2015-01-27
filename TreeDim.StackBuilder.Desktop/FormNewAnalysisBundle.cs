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
    public partial class FormNewAnalysisBundle : FormNewBase
    {
        #region Data members
        private BProperties[] _bundles;
        private PalletProperties[] _palletProperties;
        private CasePalletAnalysis _analysis;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisBundle));
        #endregion

        #region Combo box item private classes
        private class BoxItem
        {
            private BProperties _bProperties;

            public BoxItem(BProperties boxProperties)
            {
                _bProperties = boxProperties;
            }

            public BProperties Item
            {
                get { return _bProperties; }
            }

            public override string ToString()
            {
                return _bProperties.Name;
            }
        }
        private class PalletItem
        { 
            private PalletProperties _palletProperties;

            public PalletItem(PalletProperties palletProperties)
            {
                _palletProperties = palletProperties;
            }

            public PalletProperties Item
            {
                get { return _palletProperties; }
            }

            public override string ToString()
            {
                return _palletProperties.Name;
            }       
        }
        #endregion

        #region Constructor
        public FormNewAnalysisBundle(Document document, CasePalletAnalysis analysis)
            : base(document, analysis)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _analysis = analysis;
            // set caption text
            if (null != _analysis)
                Text = string.Format(Properties.Resources.ID_EDIT, _analysis.Name);
        }
        #endregion

        #region FormNewBase override
        public override void UpdateStatus(string message)
        {
            base.UpdateStatus(message);
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewAnalysisBundle_Load(object sender, EventArgs e)
        {
            try
            {
                // name / description
                if (null != _analysis)
                {
                    ItemName = _analysis.Name;
                    ItemDescription = _analysis.Description;
                }
                else
                {
                    ItemName = _document.GetValidNewAnalysisName(Resources.ID_ANALYSIS);
                    ItemDescription = ItemName;
                }
                // fill boxes combo
                foreach (BProperties bundle in _bundles)
                    cbBox.Items.Add(new BoxItem(bundle));
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

                // alternate / aligned layers
                if (null == _analysis)
                {
                    AllowAlignedLayers = Settings.Default.AllowAlignedLayer;
                    AllowAlternateLayers = Settings.Default.AllowAlternateLayer;
                    UseMaximumNumberOfBoxes = false;
                    UseMaximumPalletHeight = true;
                    UseMaximumPalletWeight = true;
                    MaximumNumberOfBoxes = 1000;
                    MaximumPalletHeight = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                    MaximumPalletWeight = UnitsManager.ConvertMassFrom(1000.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                }
                else
                {
                    AllowAlignedLayers = _analysis.ConstraintSet.AllowAlignedLayers; ;
                    AllowAlternateLayers = _analysis.ConstraintSet.AllowAlternateLayers;
                    UseMaximumNumberOfBoxes = _analysis.ConstraintSet.UseMaximumNumberOfCases;
                    UseMaximumPalletHeight = _analysis.ConstraintSet.UseMaximumHeight;
                    UseMaximumPalletWeight = _analysis.ConstraintSet.UseMaximumPalletWeight;
                    // stop stacking criterion
                    MaximumNumberOfBoxes = _analysis.ConstraintSet.MaximumNumberOfItems;
                    MaximumPalletHeight = _analysis.ConstraintSet.MaximumHeight;
                    MaximumPalletWeight = _analysis.ConstraintSet.MaximumPalletWeight;
                }
                if (null == _analysis)
                    AllowedPatternsString = Settings.Default.AllowedPatterns;
                else
                    AllowedPatternsString = _analysis.ConstraintSet.AllowedPatternString;

                UpdateCriterionFields();
                UpdateStatus(string.Empty);

                // windows settings
                if (null != Settings.Default.FormNewAnalysisPosition)
                    Settings.Default.FormNewAnalysisPosition.Restore(this);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FormNewAnalysisBundle_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // alternate / aligned layers
                Settings.Default.AllowAlignedLayer = AllowAlignedLayers;
                Settings.Default.AllowAlternateLayer = AllowAlternateLayers;
                // allowed patterns
                string allowedPatterns = string.Empty;
                for (int i = 0; i < checkedListBoxPatterns.Items.Count; ++i)
                    if (checkedListBoxPatterns.GetItemChecked(i))
                        allowedPatterns += checkedListBoxPatterns.GetItemText(checkedListBoxPatterns.Items[i]) + ";";
                Settings.Default.AllowedPatterns = allowedPatterns;
                // window position
                if (null == Settings.Default.FormNewAnalysisPosition)
                    Settings.Default.FormNewAnalysisPosition = new WindowSettings();
                Settings.Default.FormNewAnalysisPosition.Record(this);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Public properties
        public BProperties[] Boxes
        {
            get { return _bundles; }
            set { _bundles = value; }
        }
        public PalletProperties[] Pallets
        {
            get { return _palletProperties; }
            set { _palletProperties = value; }
        }
        public BProperties SelectedBundle
        {
            get { return _bundles[cbBox.SelectedIndex]; }
        }
        public PalletProperties SelectedPallet
        {
            get { return _palletProperties[cbPallet.SelectedIndex]; }
        }
        public bool UseMaximumNumberOfBoxes
        {
            get { return checkBoxMaximumNumberOfBoxes.Checked; }
            set { checkBoxMaximumNumberOfBoxes.Checked = value; }
        }
        public int MaximumNumberOfBoxes
        {
            get { return (int)nudMaximumNumberOfBoxes.Value; }
            set { nudMaximumNumberOfBoxes.Value = (decimal)value; }
        }
        public bool UseMaximumPalletHeight
        {
            get { return checkBoxMaximumPalletHeight.Checked; }
            set { checkBoxMaximumPalletHeight.Checked = value; }
        }
        public double MaximumPalletHeight
        {
            get { return (double)nudMaximumPalletHeight.Value; }
            set { nudMaximumPalletHeight.Value = (decimal)value; }
        }
        public bool UseMaximumPalletWeight
        {
            get { return checkBoxMaximumPalletWeight.Checked; }
            set { checkBoxMaximumPalletWeight.Checked = value; }
        }
        public double MaximumPalletWeight
        {
            get { return (double)nudMaximumPalletWeight.Value; }
            set { nudMaximumPalletWeight.Value = (decimal)value; }
        }
        public bool AllowAlternateLayers
        {
            get { return checkBoxAllowAlternateLayer.Checked; }
            set { checkBoxAllowAlternateLayer.Checked = value; }
        }
        public bool AllowAlignedLayers
        {
            get { return checkBoxAllowAlignedLayer.Checked; }
            set { checkBoxAllowAlignedLayer.Checked = value; }
        }
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
        public double OverhangX
        {
            get { return (double)nudPalletOverhangX.Value; }
            set { nudPalletOverhangX.Value = (decimal)value; }
        }
        public double OverhangY
        {
            get { return (double)nudPalletOverhangY.Value; }
            set { nudPalletOverhangY.Value = (decimal)value; }
        }
        #endregion

        #region Handles
        private void UpdateCriterionFields()
        { 
            nudMaximumNumberOfBoxes.Enabled = checkBoxMaximumNumberOfBoxes.Checked;
            nudMaximumPalletHeight.Enabled = checkBoxMaximumPalletHeight.Checked;
            nudMaximumPalletWeight.Enabled = checkBoxMaximumPalletWeight.Checked;
        }
        private void onCriterionCheckChanged(object sender, EventArgs e)
        {
            UpdateCriterionFields();
        }
        private void onCheckedChangedAlignedLayer(object sender, EventArgs e)
        {
            if (!checkBoxAllowAlignedLayer.Checked && !checkBoxAllowAlternateLayer.Checked)
                checkBoxAllowAlternateLayer.Checked = true;
        }
        private void onCheckedChangedAlternateLayer(object sender, EventArgs e)
        {
            if (!checkBoxAllowAlignedLayer.Checked && !checkBoxAllowAlternateLayer.Checked)
                checkBoxAllowAlignedLayer.Checked = true;
        }
        #endregion
    }
}
