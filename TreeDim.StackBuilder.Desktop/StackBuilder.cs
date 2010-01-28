using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TreeDim.StackBuilder.Desktop
{
    public partial class StackBuilder : Form
    {
        #region Constructor
        public StackBuilder()
        {
            InitializeComponent();
        }
        #endregion

        #region About
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox dlg = new AboutBox();
            dlg.ShowDialog();
        }
        #endregion

        #region Handlers for item creation
        private void onToolsNewBox(object sender, EventArgs e)
        {
            FormNewBox form = new FormNewBox();
            if (DialogResult.OK == form.ShowDialog())
            { 
                
            }
        }

        private void onToolsNewPallet(object sender, EventArgs e)
        {
            FormNewPallet form = new FormNewPallet();
            if (DialogResult.OK == form.ShowDialog())
            { 
            
            }
        }

        private void onToolsNewAnalysis(object sender, EventArgs e)
        {
            FormNewAnalysis form = new FormNewAnalysis();
            if (DialogResult.OK == form.ShowDialog())
            { 
            
            }
        }
        #endregion

        #region Handler for form exit
        private void onFileExit(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Handlers to define point of view
        private void onViewSideSide(object sender, EventArgs e)
        {

        }

        private void onViewSideRearSide(object sender, EventArgs e)
        {

        }

        private void onViewSideBackSide(object sender, EventArgs e)
        {

        }

        private void onViewSideFront(object sender, EventArgs e)
        {

        }

        private void onViewCorner_0(object sender, EventArgs e)
        {

        }

        private void onViewCorner_90(object sender, EventArgs e)
        {

        }

        private void onViewCorner_180(object sender, EventArgs e)
        {

        }

        private void onViewCorner_270(object sender, EventArgs e)
        {

        }

        private void onViewTop(object sender, EventArgs e)
        {

        }
        #endregion
    }
}