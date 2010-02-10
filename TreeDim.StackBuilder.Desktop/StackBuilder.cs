#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
        private const double _cameraDistance = 10000.0;
        /// <summary>
        /// Document class to hold data (boxes/pallets/anslyses)
        /// </summary>
        private List<Document> _documents = new List<Document>();
        private Document _currentDocument;
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
            FormNewBox form = new FormNewBox(CurrentDocument);
            if (DialogResult.OK == form.ShowDialog())
                _currentDocument.CreateNewBox(form.BoxName, form.Description, form.BoxLength, form.BoxWidth, form.BoxHeight, form.Weight, form.Colors);
            UpdateToolbarState();
        }

        private void onToolsNewPallet(object sender, EventArgs e)
        {
            FormNewPallet form = new FormNewPallet(CurrentDocument);
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

            FormNewAnalysis form = new FormNewAnalysis(CurrentDocument);
            form.Boxes = CurrentDocument.Boxes.ToArray();
            form.Pallets = CurrentDocument.Pallets.ToArray();
            form.Interlayers = CurrentDocument.Interlayers.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                // build constraint set
                ConstraintSet constraintSet = new ConstraintSet();
                // overhang / underhang
                constraintSet.OverhangX = form.OverhangX;
                constraintSet.OverhangY = form.OverhangY;
                // allowed axes
                constraintSet.SetAllowedOrthoAxis(HalfAxis.AXIS_X_N, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.AXIS_X_P, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.AXIS_Y_N, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.AXIS_Y_P, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.AXIS_Z_N, form.AllowVerticalZ);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.AXIS_Z_P, form.AllowVerticalZ);
                // allowed patterns
                foreach (string s in form.AllowedPatterns)
                    constraintSet.SetAllowedPattern(s);
                // allow alternate layer
                constraintSet.AllowAlternateLayers = form.AllowAlternateLayers;
                constraintSet.AllowAlignedLayers = form.AllowAlignedLayers;
                // interlayers
                constraintSet.HasInterlayer = form.HasInterlayers;
                constraintSet.InterlayerPeriod = form.InterlayerPeriod;
                // stop criterion
                constraintSet.UseMaximumHeight = form.UseMaximumPalletHeight;
                constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfBoxes;
                constraintSet.UseMaximumPalletWeight = form.UseMaximumPalletWeight;
                constraintSet.UseMaximumWeightOnBox = form.UseMaximumLoadOnBox;
                constraintSet.MaximumHeight = form.MaximumPalletHeight;
                constraintSet.MaximumNumberOfItems = form.MaximumNumberOfBoxes;
                constraintSet.MaximumPalletWeight = form.MaximumPalletWeight;
                
                Analysis analysis = _currentDocument.CreateNewAnalysis(
                    form.AnalysisName, form.AnalysisDescription,
                    form.SelectedBox, form.SelectedPallet, form.SelectedInterlayer
                    , constraintSet);
                _currentAnalysis = analysis;
                if (analysis.Solutions.Count > 0)
                    _sol = analysis.Solutions[0];
                onAnalysisSelected();
            }
        }

        private void onToolsNewInterlayer(object sender, EventArgs e)
        {
            FormNewInterlayer form = new FormNewInterlayer(CurrentDocument);
            if (DialogResult.OK == form.ShowDialog())
                _currentDocument.CreateNewInterlayer(
                    form.InterlayerName, form.Description
                    , form.InterlayerLength, form.InterlayerWidth, form.Thickness
                    , form.Weight
                    , form.Color);
        }

        private void onToolsNewBundle(object sender, EventArgs e)
        {
            FormNewBundle form = new FormNewBundle(CurrentDocument);
            if (DialogResult.OK == form.ShowDialog())
                _currentDocument.CreateNewBundle(
                    form.BundleName, form.Description
                    , form.BundleLength, form.BundleWidth, form.UnitThickness
                    , form.UnitWeight
                    , form.Color
                    , form.NoFlats);
            UpdateToolbarState();            
        }
        #endregion

        #region File menu handlers
        private void onFileNew(object sender, EventArgs e)
        {
            FormNewDocument form = new FormNewDocument();
            if (DialogResult.OK == form.ShowDialog())
            {
                Document doc = new Document(form.DocName, form.DocDescription, form.Author, form.DateCreated);
                doc.AddListener(analysisTreeView);
                _documents.Add(doc);
                _currentDocument = doc;
            }
        }

        private void onFileOpen(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialogSB.ShowDialog())
            {
                foreach (string fileName in openFileDialogSB.FileNames)
                {
                    if (File.Exists(fileName))
                    {
                        Document doc = Document.Load(openFileDialogSB.FileName, analysisTreeView);
                        _documents.Add(doc);
                    }
                }
            }
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
            // new pallet
            newPalletToolStripMenuItem.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);
            toolStripButtonAddNewPallet.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);

            newInterlayerToolStripMenuItem.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);
            toolStripButtonCreateNewInterlayer.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);

            newBundleToolStripMenuItem.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);
            toolStripButtonCreateNewBundle.Enabled = (null != CurrentDocument) && (null == CurrentAnalysis);

            newAnalysisToolStripMenuItem.Enabled = (null != CurrentDocument) && CurrentDocument.CanCreateAnalysis;
            toolStripButtonCreateNewAnalysis.Enabled = (null != CurrentDocument) && CurrentDocument.CanCreateAnalysis;
        }
        #endregion

        #region Drawing
        private void Draw()
        {
            try
            {
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBoxSolution.Size);
                // set camera position 
                double angleHorizRad = trackBarAngleHoriz.Value * Math.PI / 180.0;
                double angleVertRad = trackBarAngleVert.Value * Math.PI / 180.0;
                graphics.CameraPosition = new Vector3D(
                    _cameraDistance * Math.Cos(angleHorizRad) * Math.Cos(angleVertRad)
                    , _cameraDistance * Math.Sin(angleHorizRad) * Math.Cos(angleVertRad)
                    , _cameraDistance * Math.Sin(angleVertRad));
                // set camera target
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                // set light direction
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Fail(ex.ToString());
            }
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

            // fill grid solution
            gridSolutions.Rows.Clear();

            if (null == _currentAnalysis)
                return;

            // border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

            // views
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            viewNormal.Border = cellBorder;

            // column header view
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
            backHeader.BackColor = Color.LightGray;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.White;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Bold);

            // create the grid
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;

            gridSolutions.ColumnsCount = 5;
            gridSolutions.FixedRows = 1;
            gridSolutions.Rows.Insert(0);

            // header
            SourceGrid.Cells.ColumnHeader columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Index");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 0] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Box count");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 1] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Efficiency (%)");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 2] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Pallet weight (kg)");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 3] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Pallet height (mm)");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 4] = columnHeader;

            // data rows
            int iIndex = 0;
            foreach (Solution sol in _currentAnalysis.Solutions)
            {
                ++iIndex;
                gridSolutions.Rows.Insert(iIndex);
                gridSolutions[iIndex, 0] = new SourceGrid.Cells.Cell(string.Format("{0}", iIndex));
                gridSolutions[iIndex, 1] = new SourceGrid.Cells.Cell(string.Format("{0}", sol.BoxCount));
                gridSolutions[iIndex, 2] = new SourceGrid.Cells.Cell(string.Format("{0:F}", sol.Efficiency(_currentAnalysis)));
                gridSolutions[iIndex, 3] = new SourceGrid.Cells.Cell(string.Format("{0:F}", sol.PalletWeight(_currentAnalysis)));
                gridSolutions[iIndex, 4] = new SourceGrid.Cells.Cell(string.Format("{0:F}", sol.PalletHeight(_currentAnalysis)));

                gridSolutions[iIndex, 0].View = viewNormal;
                gridSolutions[iIndex, 1].View = viewNormal;
                gridSolutions[iIndex, 2].View = viewNormal;
                gridSolutions[iIndex, 3].View = viewNormal;
                gridSolutions[iIndex, 4].View = viewNormal;
            }
            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();

            // select first solution
            onSolutionSelected();
        }
        public void onSolutionSelected()
        {
            Draw();
        }

        private void onPictureBoxSizeChanged(object sender, EventArgs e)
        {
            Draw();
        }
        #endregion

        #region Handlers to define point of view
        private void onAngleHorizChanged(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = trackBarAngleHoriz.Value;
            Draw();
        }

        private void onAngleVertChanged(object sender, EventArgs e)
        {
            trackBarAngleVert.Value = trackBarAngleVert.Value;
            Draw();
        }
        private void onViewSideFront(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 0;
            trackBarAngleVert.Value = 0;
            Draw();
         }

        private void onViewSideLeft(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 90;
            trackBarAngleVert.Value = 0;
            Draw();
        }

        private void onViewSideRear(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 180;
            trackBarAngleVert.Value = 0;
            Draw();
        }

        private void onViewSideRight(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 270;
            trackBarAngleVert.Value = 0;
            Draw();
        }

        private void onViewCorner_0(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 45 + 0;
            trackBarAngleVert.Value = 45;
            Draw();
        }

        private void onViewCorner_90(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 45 + 90;
            trackBarAngleVert.Value = 45;
            Draw();
        }

        private void onViewCorner_180(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 45 + 180;
            trackBarAngleVert.Value = 45;
            Draw();
        }

        private void onViewCorner_270(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 45 + 270;
            trackBarAngleVert.Value = 45;
            Draw();
        }

        private void onViewTop(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 0;
            trackBarAngleVert.Value = 90;
            Draw();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

            // views
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.DarkBlue);
            viewNormal.Border = cellBorder;

            // column header view
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
            backHeader.BackColor = Color.LightGray;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.White;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Bold);

            // create the grid
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;

            gridSolutions.ColumnsCount = 5;
            gridSolutions.FixedRows = 1;
            gridSolutions.Rows.Insert(0);

            SourceGrid.Cells.ColumnHeader columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Index");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 0] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Box count");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 1] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Efficiency");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 2] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Pallet weight");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 3] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Pallet height");
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 4] = columnHeader;

            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();

            gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onGridSolutionSelectionChanged);
        }

        void onGridSolutionSelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
            int[] indexes = region.GetRowsIndex();
            if (null == _currentAnalysis || indexes.Length == 0)
                return;

            _sol = _currentAnalysis.Solutions[indexes[0]-1];
            Draw();
        }
        #endregion

        #region CellBackColorAlternate
        private class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
        {
            public CellBackColorAlternate(Color firstColor, Color secondColor)
            {
                FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
                SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
            }

            private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
            public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
            {
                get { return mFirstBackground; }
                set { mFirstBackground = value; }
            }

            private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
            public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
            {
                get { return mSecondBackground; }
                set { mSecondBackground = value; }
            }

            protected override void PrepareView(SourceGrid.CellContext context)
            {
                base.PrepareView(context);

                if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                    Background = FirstBackground;
                else
                    Background = SecondBackground;
            }
        }
        #endregion
    }
}