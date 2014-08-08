#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using log4net;

using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCylinder : Form
    {
        #region Data members
        private CylinderProperties[] _cylinderProperties;
        private PalletProperties[] _palletProperties;
        private InterlayerProperties[] _interlayerProperties;
        private TreeDim.StackBuilder.Basics.Document _document;
        private CylinderPalletAnalysis _analysis;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCylinder));
        #endregion

        #region Combo box item private classes
        private class CylinderItem
        {
            private CylinderProperties _cylinderProperties;
            public CylinderItem(CylinderProperties cylinderProperties)
            {
                _cylinderProperties = cylinderProperties;
            }
            public CylinderProperties Item
            {
                get { return _cylinderProperties; }
            }
            public override string ToString()
            {
                return _cylinderProperties.Name;
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

        #region Constructors
        /// <summary>
        /// Default constructor used for creating analysis 
        /// </summary>
        /// <param name="document"></param>
        public FormNewAnalysisCylinder(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            // update interlayer UI
            onInterlayerChecked(this, null);
        }
        /// <summary>
        /// Constructor used while browsing/editing existing analysis
        /// </summary>
        public FormNewAnalysisCylinder(Document document, CylinderPalletAnalysis analysis)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
            _analysis = analysis;
            // set caption text
            Text = string.Format(Properties.Resources.ID_EDIT, _analysis.Name);
            // update interlayer UI
            onInterlayerChecked(this, null);
        }
        #endregion

        #region Load / FormClosing event
        private void FormNewAnalysisCylinder_Load(object sender, EventArgs e)
        {
            try
            {
                // name / description
                if (null != _analysis)
                {
                    tbName.Text = _analysis.Name;
                    tbDescription.Text = _analysis.Description;
                }
                else
                {
                    tbName.Text = _document.GetValidNewAnalysisName(Resources.ID_ANALYSIS);
                    tbDescription.Text = tbName.Text;
                }
                // fill cylinders combo
                foreach (CylinderProperties cyl in _cylinderProperties)
                    cbCylinders.Items.Add(new CylinderItem(cyl));
                if (cbCylinders.Items.Count > 0)
                {
                    if (null == _analysis)
                        cbCylinders.SelectedIndex = 0;
                    else
                    {
                        for (int i = 0; i < cbCylinders.Items.Count; ++i)
                        {
                            CylinderItem boxItem = cbCylinders.Items[i] as CylinderItem;
                            if (boxItem.Item == _analysis.CylinderProperties)
                            {
                                cbCylinders.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                // fill pallet combo
                foreach (PalletProperties pallet in _palletProperties)
                    cbPallets.Items.Add(new PalletItem(pallet));
                if (cbPallets.Items.Count > 0)
                {
                    if (null == _analysis)
                        cbPallets.SelectedIndex = 0;
                    else
                    {
                        for (int i = 0; i < cbPallets.Items.Count; ++i)
                        {
                            PalletItem palletItem = cbPallets.Items[i] as PalletItem;
                            if (palletItem.Item == _analysis.PalletProperties)
                            {
                                cbPallets.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }

                // fill interlayer combo
                foreach (InterlayerProperties interlayer in _interlayerProperties)
                    cbInterlayers.Items.Add(new InterlayerItem(interlayer));
                if (cbInterlayers.Items.Count > 0)
                {
                    if (null == _analysis)
                        cbInterlayers.SelectedIndex = 0;
                    else
                    {
                        for (int i = 0; i < cbInterlayers.Items.Count; ++i)
                        {
                            InterlayerItem interlayerItem = cbInterlayers.Items[i] as InterlayerItem;
                            if (interlayerItem.Item == _analysis.InterlayerProperties)
                            {
                                cbInterlayers.SelectedIndex = i;
                                break;
                            }
                        }

                        checkBoxInterlayer.Checked = _analysis.ConstraintSet.HasInterlayer;
                        checkBoxInterlayer.Enabled = true;
                    }
                }
                else
                {
                    checkBoxInterlayer.Checked = false;
                    checkBoxInterlayer.Enabled = false;
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
                // stop stacking criterions
                if (null == _analysis)
                {
                    UseMaximumNumberOfItems = false;
                    UseMaximumPalletHeight = true;
                    UseMaximumPalletWeight = false;
                    UseMaximumLoadOnLowerCylinder = false;

                    MaximumNumberOfItems = 500;
                    MaximumPalletHeight = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                    MaximumPalletWeight = UnitsManager.ConvertMassFrom(1000.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                    MaximumLoadOnLowerCylinder = UnitsManager.ConvertMassFrom(100.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                }
                else
                {
                    UseMaximumNumberOfItems = _analysis.ConstraintSet.UseMaximumNumberOfItems;
                    UseMaximumPalletHeight = _analysis.ConstraintSet.UseMaximumPalletHeight;
                    UseMaximumPalletWeight = _analysis.ConstraintSet.UseMaximumPalletWeight;
                    UseMaximumLoadOnLowerCylinder = _analysis.ConstraintSet.UseMaximumLoadOnLowerCylinder;

                    MaximumNumberOfItems = _analysis.ConstraintSet.MaximumNumberOfItems;
                    MaximumPalletHeight = _analysis.ConstraintSet.MaximumPalletHeight;
                    MaximumPalletWeight = _analysis.ConstraintSet.MaximumPalletWeight;
                    MaximumLoadOnLowerCylinder = _analysis.ConstraintSet.MaximumLoadOnLowerCylinder;                                    
                }
                UpdateButtonOkStatus();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FormNewAnalysisCylinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
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
        private void onFormContentChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
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
        /// List of pallets
        /// </summary>
        public PalletProperties[] Pallets
        {
            get { return _palletProperties; }
            set { _palletProperties = value; }
        }
        /// <summary>
        /// List of cylinders
        /// </summary>
        public CylinderProperties[] Cylinders
        {
            get { return _cylinderProperties; }
            set { _cylinderProperties = value; }
        }
        /// <summary>
        /// Selected cylinder
        /// </summary>
        public CylinderProperties SelectedCylinder
        {
            get { return _cylinderProperties[cbCylinders.SelectedIndex]; }
        }
        /// <summary>
        /// Selected pallet
        /// </summary>
        public PalletProperties SelectedPallet
        {
            get { return _palletProperties[cbPallets.SelectedIndex]; }
        }
        /// <summary>
        /// List of interlayers
        /// </summary>
        public InterlayerProperties[] Interlayers
        {
            get { return _interlayerProperties; }
            set { _interlayerProperties = value; }
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
                    || -1 == cbInterlayers.SelectedIndex)
                    return null;
                else
                    return _interlayerProperties[cbInterlayers.SelectedIndex];
            }
        }
        /// <summary>
        /// Has interlayer ?
        /// </summary>
        public bool HasInterlayer
        {
            get { return checkBoxInterlayer.Checked; }
            set { checkBoxInterlayer.Checked = value; }
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
        /// Overgang X
        /// </summary>
        public double OverhangX
        {
            get { return (double)nudPalletOverhangX.Value; }
            set { nudPalletOverhangX.Value = (decimal)value;}
        }
        /// <summary>
        /// Overhang Y
        /// </summary>
        public double OverhangY
        {
            get { return (double)nudPalletOverhangY.Value; }
            set { nudPalletOverhangY.Value = (decimal)value; }
        }
        #endregion

        #region Stop criterions
        // Maximum pallet height
        public bool UseMaximumPalletHeight
        {
            get { return checkBoxMaximumPalletHeight.Checked; }
            set { checkBoxMaximumPalletHeight.Checked = value; }
        }
        public double MaximumPalletHeight
        {
            get { return (double)nudMaximumPalletHeight.Value; }
            set { nudMaximumPalletHeight.Value = (decimal) value;}
        }
        // Maximum pallet weight
        public bool UseMaximumPalletWeight
        {
            get { return checkBoxMaximumPalletHeight.Checked; }
            set { checkBoxMaximumPalletWeight.Checked = value; }
        }
        public double MaximumPalletWeight
        {
            get { return (double)nudMaximumPalletWeight.Value; }
            set { nudMaximumPalletWeight.Value = (decimal)value; }
        }
        // Maximum number of items
        public bool UseMaximumNumberOfItems
        {
            get { return checkBoxMaximumNumberOfItems.Checked; }
            set { checkBoxMaximumNumberOfItems.Checked = value; }
        }
        public int MaximumNumberOfItems
        {
            get { return (int)nudMaximumNumberOfItems.Value; }
            set { nudMaximumNumberOfItems.Value = (decimal)value; }
        }
        // Maximum load on lower cylinder
        public bool UseMaximumLoadOnLowerCylinder
        {
            get { return checkBoxMaximumLoadOnCylinder.Checked; }
            set { checkBoxMaximumLoadOnCylinder.Checked = value; }
        }
        public double MaximumLoadOnLowerCylinder
        {
            get { return (double)nudMaximumLoadOnBox.Value; }
            set { nudMaximumLoadOnBox.Value = (decimal)value;}
        }
        private void UpdateCriterionFields()
        {
            nudMaximumNumberOfItems.Enabled = checkBoxMaximumNumberOfItems.Checked;
            nudMaximumPalletHeight.Enabled = checkBoxMaximumPalletHeight.Checked;
            nudMaximumPalletWeight.Enabled = checkBoxMaximumPalletWeight.Checked;
            nudMaximumLoadOnBox.Enabled = checkBoxMaximumLoadOnCylinder.Checked;
        }
        private void onCriterionCheckChanged(object sender, EventArgs e)
        {
            UpdateCriterionFields();
        }
        #endregion

        #region Handlers
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
            // maximum load
            else if (!UseMaximumLoadOnLowerCylinder && !UseMaximumNumberOfItems && !UseMaximumPalletHeight && !UseMaximumPalletWeight)
                message = Resources.ID_USEATLEASTONESTOPSTACKINGCRITERION;
            // button OK
            bnOK.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void onInterlayerChecked(object sender, EventArgs e)
        {
            cbInterlayers.Enabled = checkBoxInterlayer.Checked;
            lbInterlayerFreq1.Enabled = checkBoxInterlayer.Checked;
            lbInterlayerFreq2.Enabled = checkBoxInterlayer.Checked;
            nudInterlayerFreq.Enabled = checkBoxInterlayer.Checked;
        }
        #endregion
    }
}
