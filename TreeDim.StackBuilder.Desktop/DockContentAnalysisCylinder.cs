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
using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCylinder : DockContent, IView, IItemListener
    {
        #region Data members
        private IDocument _document;
        private CylinderPalletAnalysis _analysis;
        #endregion

        #region Constructor
        public DockContentAnalysisCylinder(IDocument document, CylinderPalletAnalysis analysis)
        {
            _document = document;
            _analysis = analysis;
            InitializeComponent();
        }
        #endregion

        #region Form override
        #endregion

        #region Fill grid
        private void FillGrid()
        { 
        }
        #endregion

        #region Helpers
        #endregion

        #region Event handlers
        #endregion

        #region Solution selection
        #endregion

        #region IItemListener implementation
        /// <summary>
        /// overrides IItemListener.Update
        /// </summary>
        /// <param name="item"></param>
        public void Update(ItemBase item)
        {
            // update grid
            FillGrid();
            // draw
            Draw();
        }
        /// <summary>
        /// overrides IItemListener.Kill
        /// handles analysis removal for any reason (deletion/document closing)
        /// </summary>
        /// <param name="item"></param>
        public void Kill(ItemBase item)
        {
            Close();
            _analysis.RemoveListener(this);
        }
        #endregion

        #region IView implementation
        public IDocument Document
        {
            get { return _document; }
        }
        #endregion

        #region Public properties
        #endregion

        #region Drawing
        private void Draw()
        { 
        }
        #endregion

        #region Handlers to define point of view
        #endregion
    }
}
