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
using TreeDim.StackBuilder.Desktop.Properties;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormNewAnalysisBundleCase : FormNewBase
    {
        #region Data members
        private BoxCaseAnalysis _analysis;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisBundleCase));
        #endregion

        #region Constructor
        public FormNewAnalysisBundleCase(Document document, BoxCaseAnalysis analysis)
            : base(document, analysis)
        {
            InitializeComponent();
            // units
            UnitsManager.AdaptUnitLabels(this);
            // analysis
            _analysis = analysis;
        }

        private void FillCombo(ComboBox cb, ItemBase[] items, ItemBase selectedItem)
        {
            cb.Items.Clear();
            foreach (ItemBase item in items)
                cb.Items.Add(new ItemBaseEncapsulator(item));
            if (cb.Items.Count > 0)
            {
                if (null == selectedItem)
                    cb.SelectedIndex = 0;
                else
                {
                    for (int i = 0; i < cb.Items.Count; ++i)
                    {
                        ItemBaseEncapsulator itemEncapsulator = cb.Items[i] as ItemBaseEncapsulator;
                        if (itemEncapsulator.Item == selectedItem)
                        {
                            cb.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                // fill bundle combo
                FillCombo(cbBundle, Bundles, (null == _analysis) ? null : _analysis.BProperties);
                // fill case combo
                FillCombo(cbCase, Cases, (null == _analysis) ? null : _analysis.CaseProperties);

                if (null != _analysis)
                {
                    UseMaximumNumberOfBoxes = _analysis.ConstraintSet.UseMaximumNumberOfBoxes;
                    MaximumNumberOfBoxes = _analysis.ConstraintSet.MaximumNumberOfBoxes;
                    UseMaximumCaseWeight = _analysis.ConstraintSet.UseMaximumCaseWeight;
                    MaximumCaseWeight = _analysis.ConstraintSet.MaximumCaseWeight;
                }
                else
                {
                    UseMaximumNumberOfBoxes = false;
                    MaximumNumberOfBoxes = 1000;
                }
                // update check boxes
                checkBoxMaximumNumberOfBoxes_CheckedChanged(this, null);
                checkBoxMaximumCaseWeight_CheckedChanged(this, null);

                // update status
                UpdateStatus(string.Empty);
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }
        #endregion

        #region FormBase override
        public override string ItemDefaultName
        { get { return Resources.ID_ANALYSIS; } }

        public override void UpdateStatus(string message)
        {
            base.UpdateStatus(message);
        } 
        #endregion

        #region Public properties
        public BundleProperties SelectedBundle
        {
            get { return Bundles[cbBundle.SelectedIndex] as BundleProperties; }
        }
        public BoxProperties SelectedCase
        {
            get { return Cases[cbCase.SelectedIndex]; }
        }
        #endregion

        #region Stop stacking criterions
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
        public bool UseMaximumCaseWeight
        {
            get { return checkBoxMaximumCaseWeight.Checked; }
            set { checkBoxMaximumCaseWeight.Checked = value; }
        }
        public double MaximumCaseWeight
        {
            get { return (double)nudMaximumCaseWeight.Value; }
            set { nudMaximumCaseWeight.Value = (decimal)value; }
        }
        #endregion

        #region Handlers
        private void checkBoxMaximumNumberOfBoxes_CheckedChanged(object sender, EventArgs e)
        {
            nudMaximumNumberOfBoxes.Enabled = checkBoxMaximumNumberOfBoxes.Checked;
        }
        private void checkBoxMaximumCaseWeight_CheckedChanged(object sender, EventArgs e)
        {
            nudMaximumCaseWeight.Enabled = checkBoxMaximumCaseWeight.Checked;
            uMassCase.Enabled = checkBoxMaximumCaseWeight.Checked;
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Build list of cases
        /// </summary>
        private BoxProperties[] Cases
        {
            get
            {
                return _document.Cases.ToArray();
            }
        }
        /// <summary>
        /// Build list of boxes
        /// </summary>
        private ItemBase[] Bundles
        {
            get
            {
                List<ItemBase> listBundles = _document.ListByType(typeof(BundleProperties));
                return listBundles.ToArray();
            }
        }
        #endregion
    }
}
