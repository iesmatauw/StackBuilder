#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class DockContentHCylinderPalletAnalysis : DockContent, IView, IItemListener
    {
        #region Data members
        /// <summary>
        /// document
        /// </summary>
        private IDocument _document;
        /// <summary>
        /// analysis
        /// </summary>
        private HCylinderPalletAnalysis _analysis;
        /// <summary>
        /// view parameters
        /// </summary>
        private const double _cameraDistance = 10000.0;
        /// <summary>
        /// Currently selected solution
        /// </summary>
        private HCylinderPalletSolution _sol;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentHCylinderPalletAnalysis));
        #endregion

        #region Constructor
        public DockContentHCylinderPalletAnalysis(IDocument document, HCylinderPalletAnalysis analysis)
        {
            _document = document;
            _analysis = analysis;

            _analysis.AddListener(this);

            _analysis.SolutionSelected += new HCylinderPalletAnalysis.SelectSolution(onSolutionSelectionChanged);
            _analysis.SolutionSelectionRemoved += new HCylinderPalletAnalysis.SelectSolution(onSolutionSelectionChanged);

            InitializeComponent();
        }
        void onSolutionSelectionChanged(HCylinderPalletAnalysis analysis, SelHCylinderPalletSolution selSolution)
        {
            UpdateSelectButtonText();
            UpdateGridCheckBoxes();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // set window caption
            this.Text = _analysis.Name + " - " + _analysis.ParentDocument.Name;
            // fill grid
            FillGrid();

            gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onGridSolutionSelectionChanged);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        #endregion

        #region Fill grid
        private void FillGrid()
        {
            // fill grid solution
            gridSolutions.Rows.Clear();

            // border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

            // views
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            viewNormal.Border = cellBorder;
            CheckboxBackColorAlternate viewNormalCheck = new CheckboxBackColorAlternate(Color.LightBlue, Color.White);
            viewNormalCheck.Border = cellBorder;

            // column header view
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
            backHeader.BackColor = Color.LightGray;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.White;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;

            // create the grid
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;

            gridSolutions.ColumnsCount = 6;
            gridSolutions.FixedRows = 1;
            gridSolutions.Rows.Insert(0);

            // header
            SourceGrid.Cells.ColumnHeader columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_INDEX);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 0] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_CYLINDERCOUNT);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 1] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Resources.ID_PALLETWEIGHT, UnitsManager.MassUnitString));
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 2] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Resources.ID_PALLETHEIGHT, UnitsManager.LengthUnitString));
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 3] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_PALLETLIMIT);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 4] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_SELECTED);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 5] = columnHeader;

            // handling check box click
            SourceGrid.Cells.Controllers.CustomEvents solCheckboxClickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            solCheckboxClickEvent.Click += new EventHandler(clickEvent_Click);

            // data rows
            int iIndex = 0;
            foreach (HCylinderPalletSolution sol in _analysis.Solutions)
            {
                // build case count string
                string sCaseCount = string.Format("{0}", sol.CylinderCount);
                // insert row
                gridSolutions.Rows.Insert(++iIndex);
                // filling columns
                gridSolutions[iIndex, 0] = new SourceGrid.Cells.Cell(string.Format("{0}", iIndex));
                gridSolutions[iIndex, 1] = new SourceGrid.Cells.Cell(sCaseCount);
                gridSolutions[iIndex, 2] = new SourceGrid.Cells.Cell(string.Format("{0:F}", sol.PalletWeight));
                gridSolutions[iIndex, 3] = new SourceGrid.Cells.Cell(string.Format("{0:F}", sol.PalletHeight));
                gridSolutions[iIndex, 4] = new SourceGrid.Cells.Cell(PalletSolutionLimitToString(sol.LimitReached));
                gridSolutions[iIndex, 5] = new SourceGrid.Cells.CheckBox(null, _analysis.HasSolutionSelected(iIndex - 1));

                gridSolutions[iIndex, 0].View = viewNormal;
                gridSolutions[iIndex, 1].View = viewNormal;
                gridSolutions[iIndex, 2].View = viewNormal;
                gridSolutions[iIndex, 3].View = viewNormal;
                gridSolutions[iIndex, 4].View = viewNormal;
                gridSolutions[iIndex, 5].View = viewNormalCheck;

                gridSolutions[iIndex, 5].AddController(solCheckboxClickEvent);
            }
            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();

            // select first solution
            gridSolutions.Selection.SelectRow(1, true);
            Draw();        
        }
        #endregion

        #region Helpers
        private string PalletSolutionLimitToString(Limit limit)
        {
            switch (limit)
            {
                case Limit.LIMIT_MAXHEIGHTREACHED: return Resources.ID_PALLETMAXHEIGHT;
                case Limit.LIMIT_MAXWEIGHTREACHED: return Resources.ID_PALLETMAXWEIGHT;
                case Limit.LIMIT_MAXNUMBERREACHED: return Resources.ID_PALLETMAXNUMBER;
                default: return string.Empty;
            }
        }
        #endregion

        #region Event handlers
        // checkbox event handler
        private void clickEvent_Click(object sender, EventArgs e)
        {
            SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
            int iSel = context.Position.Row - 1;
            if (!_analysis.HasSolutionSelected(iSel))
                _analysis.SelectSolutionByIndex(iSel);
            else
                _analysis.UnselectSolutionByIndex(iSel);
        }
        private void onGridSolutionSelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
            int[] indexes = region.GetRowsIndex();
            // no selection -> exit
            if (indexes.Length == 0) return;
            // get selected solution
            _sol = _analysis.Solutions[indexes[0] - 1];
            // update select/unselect button text
            UpdateSelectButtonText();
            // redraw
            Draw();
        }
        private void pictureBoxSolution_SizeChanged(object sender, EventArgs e)
        {
            // redraw
            Draw();
        }
        private void btSelectSolution_Click(object sender, EventArgs e)
        {
            try
            {
                int iSel = GetCurrentSolutionIndex();
                if (-1 == iSel) return;
                if (!_analysis.HasSolutionSelected(iSel))
                    _analysis.SelectSolutionByIndex(iSel);
                else
                    _analysis.UnselectSolutionByIndex(iSel);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Solution selection
        private void UpdateGridCheckBoxes()
        {
            int iRow = 0;
            foreach (HCylinderPalletSolution sol in _analysis.Solutions)
            {
                ++iRow;
                SourceGrid.Cells.CheckBox checkBox = gridSolutions[iRow, 5] as SourceGrid.Cells.CheckBox;
                if (null != checkBox)
                    checkBox.Checked = _analysis.HasSolutionSelected(iRow - 1);
            }
        }
        private void UpdateSelectButtonText()
        {
            int iSel = GetCurrentSolutionIndex();
            btSelectSolution.Enabled = (iSel != -1);
            if (-1 == iSel) return; // no valid selection
            btSelectSolution.Text = _analysis.HasSolutionSelected(iSel) ? Properties.Resources.ID_DESELECT : Properties.Resources.ID_SELECT;
        }
        private int GetCurrentSolutionIndex()
        {
            SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
            int[] indexes = region.GetRowsIndex();
            // no selection -> exit
            if (indexes.Length == 0) return -1;
            // return index
            return indexes[0] - 1;
        }
        private HCylinderPalletSolution GetCurrentSolution()
        {
            int iIndexSol = GetCurrentSolutionIndex();
            if (-1 == iIndexSol) return null;
            else return _analysis.Solutions[iIndexSol];
        }
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
            // select first solution
            if (gridSolutions.RowsCount > 0)
                gridSolutions.Selection.SelectRow(1, true);
            if (_analysis.Solutions.Count > 0)
                _sol = _analysis.Solutions[0];
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
        public HCylinderPalletAnalysis Analysis
        {
            get { return _analysis; }
        }
        #endregion

        #region Drawing
        private void Draw()
        {
            try
            {
                // sanity check
                if (pictureBoxSolution.Size.Width < 1 || pictureBoxSolution.Size.Height < 1)
                    return;
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
                // show images
                graphics.ShowTextures = false;
                // instantiate solution viewer
                HCylinderPalletSolutionViewer sv = new HCylinderPalletSolutionViewer(GetCurrentSolution());
                sv.Draw(graphics);

                // show generated bitmap on picture box control
                pictureBoxSolution.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString()); Program.SendCrashReport(ex);
            }
        }
        #endregion

        #region Handlers to define point of view
        private void onAngleHorizChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void onAngleVertChanged(object sender, EventArgs e)
        {
            Draw();
        }
        private void onViewSideFront(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 180;
            trackBarAngleVert.Value = 0;
            Draw();
        }

        private void onViewSideLeft(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 270;
            trackBarAngleVert.Value = 0;
            Draw();
        }

        private void onViewSideRear(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 90;
            trackBarAngleVert.Value = 0;
            Draw();
        }

        private void onViewSideRight(object sender, EventArgs e)
        {
            trackBarAngleHoriz.Value = 0;
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
    }
}
