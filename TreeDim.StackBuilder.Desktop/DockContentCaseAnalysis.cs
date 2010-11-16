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
