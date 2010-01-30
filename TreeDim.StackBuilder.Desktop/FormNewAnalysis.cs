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
        #endregion
    }
}