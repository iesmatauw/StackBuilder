#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewAnalysis : Form
    {
        #region Data members
        private BoxProperties[] _boxes;
        private PalletProperties[] _palletProperties;
        #endregion

        #region Combo box item private classes
        private class BoxItem
        {
            private BoxProperties _boxProperties;

            public BoxItem(BoxProperties boxProperties)
            {
                _boxProperties = boxProperties;
            }

            public BoxProperties Item
            {
                get { return _boxProperties; }
            }

            public override string ToString()
            {
                return _boxProperties.Name;
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
        public FormNewAnalysis()
        {
            InitializeComponent();

        }

        private void onFormLoad(object sender, EventArgs e)
        {
            // fill boxes combo
            foreach (BoxProperties box in _boxes)
                cbBox.Items.Add(new BoxItem(box));
            if (cbBox.Items.Count > 0)
                cbBox.SelectedIndex = 0;
            // fill pallet combo
            foreach (PalletProperties pallet in _palletProperties)
                cbPallet.Items.Add(new PalletItem(pallet));
            if (cbPallet.Items.Count > 0)
                cbPallet.SelectedIndex = 0;

            // allowed position box
            AllowVerticalX = true;
            AllowVerticalY = true;
            AllowVerticalZ = true;

            // stop stacking criterion
            UseMaximumNumberOfBoxes = false;
            UseMaximumPalletHeight = true;
            UseMaximumPalletWeight = true;
            UseMaximumLoadOnBox = false;
            MaximumNumberOfBoxes = 500;
            MaximumPalletHeight = 3000.0;
            MaximumPalletWeight = 1000.0;
            MaximumLoadOnBox = 100.0;

            // check all patterns
            for (int i = 0; i < checkedListBoxPatterns.Items.Count; ++i)
                checkedListBoxPatterns.SetItemChecked(i, true);

            UpdateCriterionTextBoxes();
            UpdateButtonOkStatus();
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
        public BoxProperties[] Boxes
        {
            get { return _boxes;}
            set { _boxes = value; }
        }
        public PalletProperties[] Pallets
        {
            get { return _palletProperties; }
            set { _palletProperties = value; }
        }
        public BoxProperties SelectedBox
        {
            get { return _boxes[cbBox.SelectedIndex]; }
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
            get { return System.Convert.ToInt32(tbMaximumNumberOfBoxes.Text); }
            set { tbMaximumNumberOfBoxes.Text = string.Format("{0}", value); }
        }
        public bool UseMaximumPalletHeight
        {
            get { return checkBoxMaximumPalletHeight.Checked; }
            set { checkBoxMaximumPalletHeight.Checked = value; }
        }
        public double MaximumPalletHeight
        {
            get { return System.Convert.ToDouble(tbMaximumPalletHeight.Text); }
            set { tbMaximumPalletHeight.Text = string.Format("{0}", value); }
        }
        public bool UseMaximumPalletWeight
        {
            get { return checkBoxMaximumPalletWeight.Checked; }
            set { checkBoxMaximumPalletWeight.Checked = value; }
        }
        public double MaximumPalletWeight
        {
            get { return System.Convert.ToDouble(tbMaximumPalletWeight.Text); }
            set { tbMaximumPalletWeight.Text = string.Format("{0}", value); }
        }
        public bool UseMaximumLoadOnBox
        {
            get { return checkBoxMaximumLoadOnBox.Checked; }
            set { checkBoxMaximumLoadOnBox.Checked = value; }
        }
        public double MaximumLoadOnBox
        {
            get { return System.Convert.ToDouble(tbMaximumLoadOnBox.Text); }
            set { tbMaximumLoadOnBox.Text = string.Format("{0}", value); }
        }
        public bool AllowVerticalX
        {
            get { return checkBoxPositionX.Checked; }
            set { checkBoxPositionX.Checked = value; }
        }
        public bool AllowVerticalY
        {
            get { return checkBoxPositionY.Checked; }
            set { checkBoxPositionY.Checked = value; }
        }
        public bool AllowVerticalZ
        {
            get { return checkBoxPositionZ.Checked; }
            set { checkBoxPositionZ.Checked = value; }
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
        #endregion

        #region Handlers
        private void UpdateButtonOkStatus()
        {
            bnAccept.Enabled = tbName.Text.Length > 0 && tbDescription.Text.Length > 0;
        }
        private void onNameDescriptionChanged(object sender, EventArgs e)
        {
            UpdateButtonOkStatus();
        }
        private void UpdateCriterionTextBoxes()
        { 
            tbMaximumNumberOfBoxes.Enabled = checkBoxMaximumNumberOfBoxes.Checked;
            tbMaximumPalletHeight.Enabled = checkBoxMaximumPalletHeight.Checked;
            tbMaximumPalletWeight.Enabled = checkBoxMaximumPalletWeight.Checked;
            tbMaximumLoadOnBox.Enabled = checkBoxMaximumLoadOnBox.Checked;
        }
        private void onCriterionCheckChanged(object sender, EventArgs e)
        {
            UpdateCriterionTextBoxes();
        }
        #endregion
    }
}