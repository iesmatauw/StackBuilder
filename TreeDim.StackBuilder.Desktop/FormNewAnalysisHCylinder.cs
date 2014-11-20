#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Desktop.Properties;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewAnalysisHCylinder : Form
    {
        #region Data members
        private CylinderProperties[] _cylinderProperties;
        private PalletProperties[] _palletProperties;
        private TreeDim.StackBuilder.Basics.Document _document;
        private HCylinderPalletAnalysis _analysis;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisHCylinder));
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor used for creating analysis 
        /// </summary>
        public FormNewAnalysisHCylinder(Document document)
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
            // save document reference
            _document = document;
        }
        /// <summary>
        /// Constructor used while browsing/editing existing analysis
        /// </summary>
        public FormNewAnalysisHCylinder(Document document, HCylinderPalletAnalysis analysis)
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
        private void FormNewAnalysisHCylinder_Load(object sender, EventArgs e)
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

                    MaximumNumberOfItems = 500;
                    MaximumPalletHeight = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                    MaximumPalletWeight = UnitsManager.ConvertMassFrom(1000.0, UnitsManager.UnitSystem.UNIT_METRIC1);

                    AllowPatternDefault = true;
                    AllowPatternStaggered = false;
                    AllowPatternColumn = false;
                }
                else
                {
                    UseMaximumNumberOfItems = _analysis.ConstraintSet.UseMaximumNumberOfItems;
                    UseMaximumPalletHeight = _analysis.ConstraintSet.UseMaximumPalletHeight;
                    UseMaximumPalletWeight = _analysis.ConstraintSet.UseMaximumPalletWeight;

                    MaximumNumberOfItems = _analysis.ConstraintSet.MaximumNumberOfItems;
                    MaximumPalletHeight = _analysis.ConstraintSet.MaximumPalletHeight;
                    MaximumPalletWeight = _analysis.ConstraintSet.MaximumPalletWeight;
                    // patterns
                    AllowPatternDefault = _analysis.ConstraintSet.AllowPattern("Default");
                    AllowPatternColumn = _analysis.ConstraintSet.AllowPattern("Column");
                    AllowPatternStaggered = _analysis.ConstraintSet.AllowPattern("Staggered");
                }
                
                chkPatternColumnized_CheckedChanged(this, null);
                UpdateButtonOkStatus();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void FormNewAnalysisHCylinder_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Overgang X
        /// </summary>
        public double OverhangX
        {
            get { return (double)nudPalletOverhangX.Value; }
            set { nudPalletOverhangX.Value = (decimal)value; }
        }
        /// <summary>
        /// Overhang Y
        /// </summary>
        public double OverhangY
        {
            get { return (double)nudPalletOverhangY.Value; }
            set { nudPalletOverhangY.Value = (decimal)value; }
        }

        public bool AllowPatternDefault
        {
            get { return chkPatternDefault.Checked; }
            set { chkPatternDefault.Checked = value; }
        }
        public bool AllowPatternColumn
        {
            get { return chkPatternColumnized.Checked; }
            set { chkPatternColumnized.Checked = value; }
        }
        public bool AllowPatternStaggered
        {
            get { return chkPatternStaggered.Checked; }
            set { chkPatternStaggered.Checked = value; }
        }
        public double RowSpacing
        {
            get { return (double)nudRowSpacing.Value; }
            set { nudRowSpacing.Value = (decimal)value; }
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
            set { nudMaximumPalletHeight.Value = (decimal)value; }
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
            else if (UseMaximumPalletWeight && SelectedCylinder.Weight < 1.0E-06)
                message = string.Format(Resources.ID_CANNOTUSEWEIGHTLIMIT, SelectedCylinder.Name);

            // button OK
            bnOK.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        private void chkPatternColumnized_CheckedChanged(object sender, EventArgs e)
        {
            nudRowSpacing.Enabled = AllowPatternColumn;
            lbRowSpacing.Enabled = AllowPatternColumn;
            uLengthRowSpacing.Enabled = AllowPatternColumn;
        }
        #endregion
    }
}
