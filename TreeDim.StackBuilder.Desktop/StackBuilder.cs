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
        /// <summary>
        /// View parameters
        /// </summary>
        private double _angleHoriz = 45.0, _angleVert = 45.0;
        private const double _cameraDistance = 10000.0;
        /// <summary>
        /// Document class to hold data (boxes/pallets/anslyses)
        /// </summary>
        List<Document> _documents = new List<Document>();
        Document _currentDocument;
        /// <summary>
        /// Currently selected analysis
        /// </summary>
        private Analysis _currentAnalysis;
        /// <summary>
        /// Currently selected solution
        /// </summary>
        private Solution _sol;
        #endregion

        #region Constructor
        public StackBuilder()
        {
            InitializeComponent();
            // connect event handlers
            analysisTreeView.AnalysisSelected += new AnalysisTreeView.AnalysisSelectHandler(onAnalysisSelected);
            // update tools menu/toolbar state
            UpdateToolbarState();
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
                _currentDocument.CreateNewBox(form.BoxName, form.Description, form.BoxLength, form.BoxWidth, form.BoxHeight, form.Weight, form.Colors);
            UpdateToolbarState();
        }

        private void onToolsNewPallet(object sender, EventArgs e)
        {
            FormNewPallet form = new FormNewPallet();
            if (DialogResult.OK == form.ShowDialog())
                _currentDocument.CreateNewPallet(form.PalletName, form.Description, form.PalletType
                    , form.PalletLength, form.PalletWidth, form.PalletHeight
                    , form.Weight
                    , form.AdmissibleLoadWeight, form.AdmissibleLoadHeight);
            UpdateToolbarState();
        }

        private void onToolsNewAnalysis(object sender, EventArgs e)
        {
            if (null == CurrentDocument || !CurrentDocument.CanCreateAnalysis)
                return;

            FormNewAnalysis form = new FormNewAnalysis();
            form.Boxes = CurrentDocument.Boxes.ToArray();
            form.Pallets = CurrentDocument.Pallets.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                ConstraintSet constraintSet = new ConstraintSet();
                _currentDocument.CreateNewAnalysis(form.AnalysisName, form.AnalysisDescription,
                    form.SelectedBox, form.SelectedPallet, constraintSet);

                onAnalysisSelected();
            }
        }
        #endregion

        #region File menu handlers
        private void onFileNew(object sender, EventArgs e)
        {
            Document doc = new Document();
            _documents.Add(doc);
            _currentDocument = doc;
            doc.AddListener(analysisTreeView);
        }

        private void onFileOpen(object sender, EventArgs e)
        {
            
        }

        private void onFileSave(object sender, EventArgs e)
        {
            Document doc = CurrentDocument;
            if (null != doc)
                doc.Save();
        }

        private void onFileSaveAll(object sender, EventArgs e)
        {
            foreach (Document doc in _documents)
                doc.Save();                 

        }
        private void onFileExit(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Update toolbar state
        void UpdateToolbarState()
        {
            // new box
             newBoxToolStripMenuItem.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);
             toolStripButtonAddNewBox.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);

             newPalletToolStripMenuItem.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);
             toolStripButtonAddNewPallet.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);

             newAnalysisToolStripMenuItem.Enabled = (null != CurrentDocument) && CurrentDocument.CanCreateAnalysis;
             toolStripButtonCreateNewAnalysis.Enabled = (null != CurrentDocument) && CurrentDocument.CanCreateAnalysis;
        }
        #endregion

        #region Drawing
        private void Draw()
        {
            // instantiate graphics
            Graphics3DImage graphics = new Graphics3DImage(pictureBoxSolution.Size);
            // set camera position 
            double angleHorizRad = _angleHoriz * Math.PI / 180.0;
            double angleVertRad = _angleVert * Math.PI / 180.0;
            graphics.CameraPosition = new Vector3D(
                _cameraDistance * Math.Cos(angleHorizRad)
                , _cameraDistance * Math.Sin(angleHorizRad)
                , _cameraDistance * Math.Cos(angleVertRad));
            // set camera target
            graphics.Target = new Vector3D(0.0, 0.0, 0.0);
            // set light direction
            graphics.LightDirection = new Vector3D(0.0, 0.0, 1.0);
            // set viewport (not actually needed)
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);

            if (null != _currentAnalysis)
            {
                // instantiate solution viewer
                SolutionViewer sv = new SolutionViewer(_currentAnalysis, _sol);
                sv.Draw(graphics);
            }
            else
                graphics.Flush();

            // show generated bitmap on picture box control
            pictureBoxSolution.Image = graphics.Bitmap;
        }
        #endregion

        #region Private properties
        private Document CurrentDocument
        {
            get { return _currentDocument; }
        }
        private Analysis CurrentAnalysis
        {
            get { return _currentAnalysis; }
        }
        #endregion

        #region Selection handlers
        public void onAnalysisSelected(object sender, AnalysisTreeViewEventArgs treeViewEventArgs)
        {
            _currentAnalysis = treeViewEventArgs.Analysis;
            this.onAnalysisSelected();
        }

        private void onAnalysisSelected()
        {
            UpdateToolbarState();


            // select first solution
            

            onSolutionSelected();
        }
        public void onSolutionSelected()
        {
            Draw();
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