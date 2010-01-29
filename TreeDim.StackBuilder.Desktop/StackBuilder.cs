#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
using TreeDim.StackBuilder.Graphics;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class StackBuilder : Form
    {
        #region Data members
        private double _angleHoriz = 45.0, _angleVert = 45.0;
        private Analysis _currentAnalysis;
        #endregion

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

        #region Drawing
        private void Draw()
        {
            if (null != _currentAnalysis)
            { 
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBoxSolution.Size);
            }
        }
        #endregion

        #region Handlers to define point of view

        private void onViewSideFront(object sender, EventArgs e)
        {
            _angleHoriz = 0.0;
            _angleVert = 0.0;
            Draw();
         }

        private void onViewSideLeft(object sender, EventArgs e)
        {
            _angleHoriz = 90.0;
            _angleVert = 0.0;
            Draw();
        }

        private void onViewSideRear(object sender, EventArgs e)
        {
            _angleHoriz = 180.0;
            _angleVert = 0.0;
            Draw();
        }

        private void onViewSideRight(object sender, EventArgs e)
        {
            _angleHoriz = 270.0;
            _angleVert = 0.0;
            Draw();
        }

        private void onViewCorner_0(object sender, EventArgs e)
        {
            _angleHoriz = 45.0 + 0.0;
            _angleVert = 45.0;
            Draw();
        }

        private void onViewCorner_90(object sender, EventArgs e)
        {
            _angleHoriz = 45.0 + 90.0;
            _angleVert = 45.0;
            Draw();
        }

        private void onViewCorner_180(object sender, EventArgs e)
        {
            _angleHoriz = 45.0 + 180.0;
            _angleVert = 45.0;
            Draw();
        }

        private void onViewCorner_270(object sender, EventArgs e)
        {
            _angleHoriz = 45.0 + 270.0;
            _angleVert = 45.0;
            Draw();
        }

        private void onViewTop(object sender, EventArgs e)
        {
            _angleHoriz = 0.0;
            _angleVert = 90.0;
            Draw();
        }
        #endregion
    }
}