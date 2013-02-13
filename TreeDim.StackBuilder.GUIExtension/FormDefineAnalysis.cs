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
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.SQLite;

#endregion

namespace TreeDim.StackBuilder.GUIExtension
{
    public partial class FormDefineAnalysis : Form
    {
        #region Constructor
        public FormDefineAnalysis()
        {
            InitializeComponent();
            _revertX = false;
            _revertY = false;
            _revertZ = false;
        }
        #endregion

        #region Public properties
        public string CaseName
        {
            get { return _caseName; }
            set { _caseName = value; }
        }
        public double CaseLength
        {
            get { return (double)nudCaseLength.Value; }
            set { nudCaseLength.Value = (decimal)value; }
        }
        public double CaseWidth
        {
            get { return (double)nudCaseWidth.Value; }
            set { nudCaseWidth.Value = (decimal)value; }
        }
        public double CaseHeight
        {
            get { return (double)nudCaseHeight.Value; }
            set { nudCaseHeight.Value = (decimal)value; }
        }
        public PalletProperties Pallet
        {
            get { return _palletProperties; }   
        }
        public BoxProperties Case
        {
            get
            {
                BoxProperties bProperties = new BoxProperties(null, (double)nudCaseLength.Value, (double)nudCaseWidth.Value, (double)nudCaseHeight.Value);
                bProperties.Name = _caseName;
                bProperties.Description = _caseName;
                bProperties.SetColor(Color.Chocolate);
                return bProperties;
            }
        }
        public InterlayerProperties Interlayer
        {
            get { return _interlayerProperties; }
        }
        public CasePalletConstraintSet Constraints
        {
            get
            {
                CasePalletConstraintSet constraintSet = new CasePalletConstraintSet();
                constraintSet.AllowAlignedLayers = true;
                constraintSet.AllowAlternateLayers = true;
                constraintSet.SetAllowedOrthoAxis(_revertX ? HalfAxis.HAxis.AXIS_X_N : HalfAxis.HAxis.AXIS_X_P, chkX.Checked);
                constraintSet.SetAllowedOrthoAxis(_revertY ? HalfAxis.HAxis.AXIS_Y_N : HalfAxis.HAxis.AXIS_Y_P, chkY.Checked);
                constraintSet.SetAllowedOrthoAxis(_revertZ ? HalfAxis.HAxis.AXIS_Z_N : HalfAxis.HAxis.AXIS_Z_P, chkZ.Checked);
                constraintSet.OverhangX = (double)nudOverhangX.Value;
                constraintSet.OverhangY = (double)nudOverhangY.Value;
                return constraintSet;
            }
        }
        #endregion


        #region Load / close 
        private void FormDefineAnalysis_Load(object sender, EventArgs e)
        {
            // loads pallets
            LoadPallets();
            // draw bow positions
            DrawBoxPositions();
            // allowed case positions
            chkX.Checked = Properties.Settings.Default.AllowOrientationX;
            chkY.Checked = Properties.Settings.Default.AllowOrientationY;
            chkZ.Checked = Properties.Settings.Default.AllowOrientationZ;
            // case weight
            nudCaseWeight.Value = (decimal)Properties.Settings.Default.CaseWeight;
            // overhang
            nudOverhangX.Value = (decimal)Properties.Settings.Default.OverhangX;
            nudOverhangY.Value = (decimal)Properties.Settings.Default.OverhangY;
            // pallet height
            nudMaxPalletHeight.Value = (decimal)Properties.Settings.Default.PalletHeight;
            // pallet weight
            chkMaxPalletWeight.Checked = Properties.Settings.Default.UseMaximumPalletWeight;
            nudMaxPalletWeight.Value = (decimal)Properties.Settings.Default.MaximumPalletWeight;
        }
        private void FormDefineAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save allowed case positions
            Properties.Settings.Default.AllowOrientationX = chkX.Checked;
            Properties.Settings.Default.AllowOrientationY = chkY.Checked;
            Properties.Settings.Default.AllowOrientationZ = chkZ.Checked;
            // save case weight
            Properties.Settings.Default.CaseWeight = (double)nudCaseWeight.Value;
            // save pallet name
            Properties.Settings.Default.PalletName = _palletProperties.Name;
            // save overhang values
            Properties.Settings.Default.OverhangX = (double)nudOverhangX.Value;
            Properties.Settings.Default.OverhangY = (double)nudOverhangY.Value;
            // save max. pallet height
            Properties.Settings.Default.PalletHeight = (double)nudMaxPalletHeight.Value;
            // save max. weight
            Properties.Settings.Default.UseMaximumPalletWeight = chkMaxPalletWeight.Checked;
            Properties.Settings.Default.MaximumPalletWeight = (double)nudMaxPalletWeight.Value;
        }
        #endregion

        #region Handlers
        private void cbPallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 == cbPallet.SelectedIndex)
                return;
            PalletItem item = cbPallet.Items[cbPallet.SelectedIndex] as PalletItem;
            _palletProperties = item.Item;
            // update description
            lbPalletDescription.Text = _palletProperties.Description;
            // update pallet image
            DrawPallet();
        }
        private void bnEditPalletList_Click(object sender, EventArgs e)
        {

        }

        private void chkMaxPalletWeight_CheckedChanged(object sender, EventArgs e)
        {
            nudMaxPalletWeight.Enabled = chkMaxPalletWeight.Checked;
        }
        private void bnRevertX_Click(object sender, EventArgs e)
        {   _revertX = !_revertX;    }
        private void bnRevertY_Click(object sender, EventArgs e)
        {   _revertY = !_revertY;    }
        private void bnRevertZ_Click(object sender, EventArgs e)
        {   _revertZ = !_revertZ;    }
        #endregion

        #region Helpers
        private void LoadPallets()
        {
            string palletName = Properties.Settings.Default.PalletName;
            int selectedIndex = -1;

            using (ItemStore itemStore = new ItemStore())
            {
                List<PalletProperties> pallets = itemStore.GetAllPallets();
                int i = 0;
                foreach (PalletProperties pallet in pallets)
                {
                    cbPallet.Items.Add(new PalletItem(pallet));
                    if (palletName == pallet.Name)
                        selectedIndex = i;
                    ++i;
                }
            }

            cbPallet.SelectedIndex = selectedIndex;
        }
        private void DrawBoxPositions()
        {
            BoxProperties currentCase = Case;
            BoxToPictureBox.Draw(currentCase, HalfAxis.HAxis.AXIS_X_P, pbCaseX);
            BoxToPictureBox.Draw(currentCase, HalfAxis.HAxis.AXIS_Y_P, pbCaseY);
            BoxToPictureBox.Draw(currentCase, HalfAxis.HAxis.AXIS_Z_P, pbCaseZ);
        }
        private void DrawPallet()
        {
            PalletToPictureBox.Draw(_palletProperties, pbPallet);
        }
        #endregion

        #region Data members
        private string _caseName;
        private PalletProperties _palletProperties;
        private InterlayerProperties _interlayerProperties;
        private bool _revertX, _revertY, _revertZ;
        #endregion
    }
}
