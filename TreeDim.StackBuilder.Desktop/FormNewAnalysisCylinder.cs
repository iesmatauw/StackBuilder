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
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCylinder : Form
    {
        #region Data members
        private CylinderProperties[] _cylinderProperties;
        private PalletProperties[] _palletProperties;
        private Document _document;
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

        #region Constructor
        /// <summary>
        /// Default constructor used for creating analysis 
        /// </summary>
        /// <param name="document"></param>
        public FormNewAnalysisCylinder(Document document)
        {
            InitializeComponent();
            // save document reference
            _document = document;
        }
        /// <summary>
        /// Constructor used while browsing/editing existing analysis
        /// </summary>
        public FormNewAnalysisCylinder(Document document, CylinderPalletAnalysis analysis)
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
                // fill boxes combo
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
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        } 
        #endregion

        #region Public properties
        public PalletProperties[] Pallets
        {
            get { return _palletProperties; }
            set { _palletProperties = value; }
        }
        public CylinderProperties[] Cylinders
        {
            get { return _cylinderProperties; }
            set { _cylinderProperties = value; }
        }
        #endregion





        #region Handlers
        #endregion
    }
}
