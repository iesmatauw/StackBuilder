using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace treeDiM.StackBuilder.Plugin
{
    public partial class FormNewINTEX : Form
    {
        #region Constructor
        public FormNewINTEX()
        {
            InitializeComponent();
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
            tbLength.Text = string.Format("{0}", _currentItem._length);
            tbWidth.Text = string.Format("{0}", _currentItem._width);
            tbHeight.Text = string.Format("{0}", _currentItem._height);
            tbWeight.Text = string.Format("{0}", _currentItem._weight);
            // set output file path
            fileSelectCtrl.FileName = BuildFilePath(_currentItem._ref);
            fileSelectCtrl.Filter = "StackBuilder (*.stb) |*.stb";
            fileSelectCtrl.SaveMode = true;
        }

        private void cbPallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPallet = (PalletINTEX)cbPallet.SelectedItem;
        }

        private void FormNewINTEX_Load(object sender, EventArgs e)
        {
            foreach (DataItemINTEX item in _list)
                cbRefDescription.Items.Add(item);
            if (cbRefDescription.Items.Count > 0)
                cbRefDescription.SelectedIndex = 0;

            List<PalletINTEX> pallets = PalletINTEX.BuildList();
            foreach (PalletINTEX pallet in pallets)
                cbPallet.Items.Add(pallet);
            if (cbPallet.Items.Count > 0)
                cbPallet.SelectedIndex = 0;
        }
        #endregion

        #region Public properties
        public string FilePath
        {
            get { return fileSelectCtrl.FileName; }
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
        public List<DataItemINTEX> _list;
        public DataItemINTEX _currentItem;
        public PalletINTEX _currentPallet;
        #endregion

    }
}
