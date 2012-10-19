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
    public partial class FormNewAnalysisBundle : Form
    {
        #region Data members
        private BProperties[] _bundles;
        private PalletProperties[] _palletProperties;
        private Document _document;
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
        public FormNewAnalysisBundle(Document document)
        {
            InitializeComponent();
            // save document reference
            _document = document;
        }
        public FormNewAnalysisBundle(Document document, CasePalletAnalysis analysis)
        {
            InitializeComponent();
            // save document reference
            _document = document;
            _analysis = analysis;
            // set caption text
            Text = string.Format("Edit {0}...", _analysis.Name);
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
                    tbName.Text = _analysis.Name;
                    tbDescription.Text = _analysis.Description;
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

                // alternate / aligned layers
                if (null == _analysis)
                {
                    AllowAlignedLayers = Settings.Default.AllowAlignedLayer;
                    AllowAlternateLayers = Settings.Default.AllowAlternateLayer;
                    UseMaximumNumberOfBoxes = false;
                    UseMaximumPalletHeight = true;
                    UseMaximumPalletWeight = true;
                    MaximumNumberOfBoxes = 1000;
                    MaximumPalletHeight = 1200.0;
                    MaximumPalletWeight = 1000.0;
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

                // check all patterns
                string allowedPatterns = Settings.Default.AllowedPatterns;
                int iCountAllowedPatterns = 0;
                for (int i = 0; i < checkedListBoxPatterns.Items.Count; ++i)
                {
                    string patternName = checkedListBoxPatterns.GetItemText(checkedListBoxPatterns.Items[i]);
                    bool patternAllowed = allowedPatterns.Contains(patternName);
                    checkedListBoxPatterns.SetItemChecked(i, patternAllowed);
                    if (patternAllowed)
                        ++iCountAllowedPatterns;
                }
                if (iCountAllowedPatterns == 0)
                    for (int i = 0; i < checkedListBoxPatterns.Items.Count; ++i)
                        checkedListBoxPatterns.SetItemChecked(i, true);

                // keep best solutions
                if (null == _analysis)
                {
                    UseNumberOfSolutionsKept = Settings.Default.KeepBestSolutions;
                    NumberOfSolutionsKept = Settings.Default.NoSolutionsToKeep;
                }
                else
                {
                    UseNumberOfSolutionsKept = _analysis.ConstraintSet.UseNumberOfSolutionsKept;
                    NumberOfSolutionsKept = _analysis.ConstraintSet.UseNumberOfSolutionsKept ? _analysis.ConstraintSet.NumberOfSolutionsKept : Settings.Default.NoSolutionsToKeep;
                }

                UpdateSolutionsToKeep();
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
                // keep best solutions
                Settings.Default.KeepBestSolutions = UseNumberOfSolutionsKept;
                Settings.Default.NoSolutionsToKeep = NumberOfSolutionsKept;                
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
        public string AnalysisName
        {
            get { return tbName.Text; }
        }
        public string AnalysisDescription
        {
            get { return tbDescription.Text; }
        }
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
                List<string> listAllowedPatterns = new List<string>();
                foreach (object itemChecked in checkedListBoxPatterns.CheckedItems)
                {
                    // use the IndexOf method to get the index of an item
                    if (checkedListBoxPatterns.GetItemCheckState(checkedListBoxPatterns.Items.IndexOf(itemChecked)) == CheckState.Checked)
                        listAllowedPatterns.Add(itemChecked.ToString());
                }
                return listAllowedPatterns;
            }
        }
        public double OverhangX
        {
            get { return (double)nudPalletOverhangX.Value; }
        }
        public double OverhangY
        {
            get { return (double)nudPalletOverhangY.Value; }
        }
        public bool UseNumberOfSolutionsKept
        {
            get { return checkBoxKeepSolutions.Checked; }
            set { checkBoxKeepSolutions.Checked = value; }
        }
        public int NumberOfSolutionsKept
        {
            get { return (int)nudSolutions.Value; }
            set { nudSolutions.Value = (decimal)value; }
        }
        #endregion

        #region Handles
        private void UpdateButtonOkStatus()
        {
            bnAccept.Enabled =
                tbName.Text.Length > 0
                && tbDescription.Text.Length > 0
                && _document.IsValidNewTypeName(tbName.Text, _analysis);
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
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
        private void UpdateSolutionsToKeep()
        {
            nudSolutions.Enabled = checkBoxKeepSolutions.Checked;
        }
        private void onCheckedChangedKeepSolutions(object sender, EventArgs e)
        {
            UpdateSolutionsToKeep();
        }
        #endregion
    }
}
