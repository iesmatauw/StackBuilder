#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class DockContentDocumentExplorer : DockContent
    {
        public DockContentDocumentExplorer()
        {
            InitializeComponent();
        }

        private void FloatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockState = DockState.Float;
        }

        private void DockableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockState = ShowHint;
        }

        private void TabbedDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DockState = DockState.Document;
        }

        private void AutoHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (DockState)
            {
                case DockState.DockBottom:
                    DockState = DockState.DockBottomAutoHide;
                    break;
                case DockState.DockTop:
                    DockState = DockState.DockTopAutoHide;
                    break;
                case DockState.DockLeft:
                    DockState = DockState.DockLeftAutoHide;
                    break;
                case DockState.DockRight:
                    DockState = DockState.DockRightAutoHide;
                    break;
                default:
                    break;
            }
        }

        #region Public properties
        public AnalysisTreeView DocumentTreeView
        {
            get { return _documentTreeView; }
        }
        #endregion
    }
}
