#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using log4net;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    /// <summary>
    /// Form used to browse/select case analysis solutions
    /// </summary>
    public partial class DockContentCaseAnalysis : DockContent, IView, IItemListener
    {
        #region Data members
        /// <summary>
        /// document
        /// </summary>
        private IDocument _document;
        /// <summary>
        /// Case analysis
        /// </summary>
        CaseAnalysis _caseAnalysis;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysis));
        #endregion

        #region Constructor
        public DockContentCaseAnalysis(IDocument document, CaseAnalysis caseAnalysis)
        {
            InitializeComponent();
            _document = document;
            _caseAnalysis = caseAnalysis;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // text
            this.Text = _caseAnalysis.Name + " - " + _caseAnalysis.ParentDocument.Name;
            // fill grid
            FillGrid();

        }
        private void FillGrid()
        {
            // fill grid solutions
        }
        #endregion

        #region Public properties
        public CaseAnalysis CaseAnalysis
        {
            get { return _caseAnalysis; }
            set { _caseAnalysis = value; }
        }
        #endregion

        #region Event handlers
        private void DockContentCaseAnalysis_Load(object sender, EventArgs e)
        {

        }
        private void toolStripShowPallet_Click(object sender, EventArgs e)
        {
            toolStripShowPallet.Checked = !toolStripShowPallet.Checked;
            ShowHidePalletView();
        }
        #endregion

        #region Helpers
        private void ShowHidePalletView()
        {
 
        }
        #endregion

        #region ITemListener implementation
        public void Update(ItemBase item)
        { 
            // update grid
            // select first solution
            // draw
        }
        public void Kill(ItemBase item)
        {
            Close();
        }
        #endregion

        #region IView implementation
        public IDocument Document
        {
            get { return _document; }
        }
        #endregion




    }
}
