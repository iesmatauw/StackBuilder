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

        #region Constructors
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
                    MaximumPalletHeight = 1200.0;
                    MaximumPalletWeight = 1000.0;
                    MaximumLoadOnLowerCylinder = 100.0;
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
        public double OverhangX
        {
            get { return (double)nudPalletOverhangX.Value; }
            set { nudPalletOverhangX.Value = (decimal)value;}
        }
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
        #endregion

        #region Handlers
        #endregion
    }
}
