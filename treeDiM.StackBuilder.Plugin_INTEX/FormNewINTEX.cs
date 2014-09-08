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
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    public partial class FormNewINTEX : Form
    {
        #region Constructor
        public FormNewINTEX()
        {
            InitializeComponent();
            // set unit labels
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region Event handlers
        private void cbRefDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentItem = (DataItemINTEX)cbRefDescription.SelectedItem;
            if (null == _currentItem)
                return;
            tbUPC.Text = _currentItem._UPC;
            tbGenCode.Text = _currentItem._gencode;
            tbLength.Text = string.Format("{0:0.0}", _currentItem._length);
            tbWidth.Text = string.Format("{0:0.0}", _currentItem._width);
            tbHeight.Text = string.Format("{0:0.0}", _currentItem._height);
            tbWeight.Text = string.Format("{0:0.000}", _currentItem._weight);
            // set output file path
            fileSelectCtrl.FileName = BuildFilePath(_currentItem._ref);
            // update pallet height if necessary
            UpdatePalletHeight();
            UpdateButtonOkStatus();
        }
        private void cbPallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPallet = (DataPalletINTEX)cbPallet.SelectedItem;
            // update pallet height if necessary
            UpdatePalletHeight();
            UpdateButtonOkStatus();
        }
        private void cbCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCase = (DataCaseINTEX)cbCases.SelectedItem;
            UpdateButtonOkStatus();
        }
        private void chkUseIntermediatePacking_CheckedChanged(object sender, EventArgs e)
        {
            lbCase.Enabled = chkUseIntermediatePacking.Checked;
            cbCases.Enabled = chkUseIntermediatePacking.Checked;
            lbThickness.Enabled = chkUseIntermediatePacking.Checked;
            nudThickness.Enabled = chkUseIntermediatePacking.Checked;
            uLengthThickness.Enabled = chkUseIntermediatePacking.Checked;
            // update status and enable/disable OK button
            UpdateButtonOkStatus();
        }
        #endregion

        #region Form Loading & Closing
        private void FormNewINTEX_Load(object sender, EventArgs e)
        {
            foreach (DataItemINTEX item in _listItems)
                cbRefDescription.Items.Add(item);
            if (cbRefDescription.Items.Count > 0)
                cbRefDescription.SelectedIndex = 0;

            foreach (DataPalletINTEX pallet in _listPallets)
                cbPallet.Items.Add(pallet);
            if (cbPallet.Items.Count > 0)
                cbPallet.SelectedIndex = 0;

            foreach (DataCaseINTEX interCase in _listCases)
                cbCases.Items.Add(interCase);
            if (cbCases.Items.Count > 0)
                cbCases.SelectedIndex = 0;

            // initialize pallet height
            PalletHeight = Properties.Settings.Default.PalletHeight;
            // initialize intermediate packing
            chkUseIntermediatePacking.Checked = _listCases.Count > 0 && Properties.Settings.Default.IntermediatePacking;
            chkUseIntermediatePacking.Enabled = _listCases.Count > 0;
            chkUseIntermediatePacking_CheckedChanged(null, null);
            // initialize thickness
            DefaultCaseThickness = Properties.Settings.Default.DefaultCaseThickness;
            // update status and enable/disable OK button
            UpdateButtonOkStatus();
        }
        private void FormNewINTEX_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IntermediatePacking = UseIntermediatePacking;
            Properties.Settings.Default.DefaultCaseThickness = DefaultCaseThickness;
            Properties.Settings.Default.PalletHeight = PalletHeight;
            Properties.Settings.Default.Save();
        } 
        #endregion

        #region Update status
        private void UpdatePalletHeight()
        { 
            // set minimal pallet height
            if (null != _currentPallet && null != _currentItem)
            {
                nudPalletHeight.Minimum = (decimal)(_currentPallet._height + _currentItem._height);
                if (PalletHeight < (double)nudPalletHeight.Minimum)
                    PalletHeight = (double)nudPalletHeight.Minimum;
            }
        }
        private void UpdateButtonOkStatus()
        {
            string message = string.Empty;
            if (null != _currentPallet)
            {
                if (UseIntermediatePacking && (null != _currentCase))
                {
                    if (_currentCase._heightExt + _currentPallet._height > PalletHeight)
                        message = Properties.Resources.ID_PALLETHEIGHTINSUFFICIENT;
                }
                else if (!UseIntermediatePacking && (null != _currentItem))
                {
                    if (_currentItem._height + _currentPallet._height > PalletHeight)
                        message = Properties.Resources.ID_PALLETHEIGHTINSUFFICIENT;
                }
            }
            if (UseIntermediatePacking && null != _currentCase && null != _currentItem)
            {
                if (!_currentCase.CanContain(_currentItem, DefaultCaseThickness))
                    message = string.Format(Properties.Resources.ID_CASECANNOTCONTAINITEM
                        , _currentCase._ref, _currentItem._ref);
            }
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Properties.Resources.ID_READY : message;
            bnOK.Enabled = string.IsNullOrEmpty(message);
        }
        #endregion

        #region Public properties
        public bool UseIntermediatePacking
        {
            get { return chkUseIntermediatePacking.Checked; }
            set { chkUseIntermediatePacking.Checked = value; }
        }
        public string FilePath
        {
            get { return fileSelectCtrl.FileName; }
        }
        public double PalletHeight
        {
            get { return (double)nudPalletHeight.Value; }
            set { nudPalletHeight.Value = (decimal)value; }
        }
        public double DefaultCaseThickness
        {
            get { return (double)nudThickness.Value; }
            set { nudThickness.Value = (decimal)value; }
        }
        #endregion

        #region Helpers
        private string BuildFilePath(string sRef)
        {
            string defaultDir = Properties.Settings.Default.DefaultDir;
            if (!System.IO.Directory.Exists(defaultDir))
                defaultDir = System.IO.Path.GetTempPath();

            string filePath = System.IO.Path.Combine(defaultDir, sRef);
            return System.IO.Path.ChangeExtension(filePath, "stb");
        }
        #endregion

        #region Data members
        public List<DataItemINTEX> _listItems;
        public List<DataPalletINTEX> _listPallets;
        public List<DataCaseINTEX> _listCases;
        public DataItemINTEX _currentItem;
        public DataPalletINTEX _currentPallet;
        public DataCaseINTEX _currentCase;
        #endregion
    }
}
