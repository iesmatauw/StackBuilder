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
        private PalletAnalysisCylinder _analysis;
        private PalletSolution _solution; 
        #endregion

        #region Constructor
        public DockContentAnalysisCylinder(IDocument document, PalletAnalysisCylinder analysis)
        {
            _document = document;

            _analysis = analysis;

            InitializeComponent();
        }
        #endregion

        #region Form override
        #endregion

        #region Fill grid
        #endregion

        #region Helpers
        #endregion

        #region Event handlers
        #endregion

        #region Solution selection
        #endregion

        #region IItemListener implementation
        #endregion

        #region IView implementation
        #endregion

        #region Public properties
        #endregion

        #region Drawing
        #endregion

        #region Handlers to define point of view
        #endregion
    }
}
