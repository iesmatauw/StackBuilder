#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
// docking
using WeifenLuo.WinFormsUI.Docking;
// log4net
using log4net;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.Desktop.Properties;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    /// <summary>
    /// Form used to browse/select case analysis solutions
    /// </summary>
    public partial class DockContentBoxCasePalletAnalysis
        : DockContent, IView, IItemListener, IDrawingContainer
    {
        #region Data members
        /// <summary>
        /// document
        /// </summary>
        private IDocument _document;
        /// <summary>
        /// Case analysis
        /// </summary>
        BoxCasePalletAnalysis _caseAnalysis;
        /// <summary>
        /// view parameters
        /// </summary>
        private const double _cameraDistance = 10000.0;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentBoxCasePalletAnalysis));
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="document">Document to which the case analysis begins</param>
        /// <param name="caseAnalysis">Case analysis browsed</param>
        public DockContentBoxCasePalletAnalysis(IDocument document, BoxCasePalletAnalysis caseAnalysis)
        {
            _document = document;
            _caseAnalysis = caseAnalysis;
            _caseAnalysis.AddListener(this);

            _caseAnalysis.SolutionSelected += new Basics.BoxCasePalletAnalysis.SelectSolution(SolutionSelectionChanged);
            _caseAnalysis.SolutionSelectionRemoved += new Basics.BoxCasePalletAnalysis.SelectSolution(SolutionSelectionChanged);

            InitializeComponent();
        }

        void SolutionSelectionChanged(BoxCasePalletAnalysis analysis, SelBoxCasePalletSolution selSolution)
        {
            UpdateSelectButtonText();
            UpdateGridCheckBoxes();
         }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // set drawing container
            graphCtrlCaseSolution.DrawingContainer = this;
            graphCtrlPalletSolution.DrawingContainer = this;
            // text
            this.Text = _caseAnalysis.Name + " - " + _caseAnalysis.ParentDocument.Name;
            // fill grid
            FillGrid();
            // attach grid selection event handler
            gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onGridSolutionSelectionChanged);
        }
        #endregion

        #region Grid
        private void FillGrid()
        {
            // fill grid solutions
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

            gridSolutions.ColumnsCount = 7;
            gridSolutions.FixedRows = 1;
            gridSolutions.Rows.Insert(0);
            // header
            SourceGrid.Cells.ColumnHeader columnHeader;
            // index
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_INDEX);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 0] = columnHeader;
            // layers
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_LAYERPATTERNS);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 1] = columnHeader;
            // case dimensions
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_CASE);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 2] = columnHeader;
            // box / case count
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_BOXCASECOUNT);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 3] = columnHeader;
            // efficiency
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_EFFICIENCYPERCENTAGE);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 4] = columnHeader;
            // weights
            columnHeader = new SourceGrid.Cells.ColumnHeader(string.Format(Properties.Resources.ID_WEIGHT, UnitsManager.MassUnitString));
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 5] = columnHeader;
            // selected
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_SELECTED);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 6] = columnHeader;
            // handling check box click
            SourceGrid.Cells.Controllers.CustomEvents solCheckboxClickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            solCheckboxClickEvent.Click += new EventHandler(clickEvent_Click);
            // data rows
            int iIndex = 0;
            foreach (BoxCasePalletSolution sol in _caseAnalysis.Solutions)
            {
                if (null == sol.PalletSolutionDesc.LoadPalletSolution())
                    continue;
                // insert new row
                gridSolutions.Rows.Insert(++iIndex);
                // # (index)
                gridSolutions[iIndex, 0] = new SourceGrid.Cells.Cell(string.Format("{0}", iIndex));
                {
                    Graphics2DImage graphics = new Graphics2DImage(new Size(100, 50));
                    BoxCasePalletSolutionViewer sv = new BoxCasePalletSolutionViewer(sol);
                    sv.Draw(graphics);
                    // layers
                    gridSolutions[iIndex, 1] = new SourceGrid.Cells.Image(graphics.Bitmap);
                }
                // case dimensions
                gridSolutions[iIndex, 2] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "{0}\n({1:0.#}*{2:0.#}*{3:0.#})", sol.PalletSolutionDesc.FriendlyName, sol.CaseLength, sol.CaseWidth, sol.CaseHeight));
                // box / case count
                gridSolutions[iIndex, 3] = new SourceGrid.Cells.Cell(string.Format("Boxes/case: {0}\nCases/pallet: {1}\nBoxes/pallet:{2}", sol.BoxPerCaseCount, sol.CasePerPalletCount, sol.BoxPerPalletCount));
                // efficiency
                gridSolutions[iIndex, 4] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "Case :{0:0.#}\nPallet :{1:0.#}", sol.CaseEfficiency, sol.PalletEfficiency));
                // weights
                gridSolutions[iIndex, 5] = new SourceGrid.Cells.Cell(string.Format(CultureInfo.InvariantCulture, "Case :{0:0.#}\nPallet :{1:0.#}", sol.CaseWeight, sol.PalletWeight));
                // selected
                gridSolutions[iIndex, 6] = new SourceGrid.Cells.CheckBox(null, _caseAnalysis.HasSolutionSelected(iIndex - 1));

                gridSolutions[iIndex, 0].View = viewNormal;
                gridSolutions[iIndex, 1].View = viewNormal;
                gridSolutions[iIndex, 2].View = viewNormal;
                gridSolutions[iIndex, 3].View = viewNormal;
                gridSolutions[iIndex, 4].View = viewNormal;
                gridSolutions[iIndex, 5].View = viewNormal;
                gridSolutions[iIndex, 6].View = viewNormalCheck;

                gridSolutions[iIndex, 6].AddController(solCheckboxClickEvent);
            }
            try
            {
                gridSolutions.AutoStretchColumnsToFitWidth = true;
                gridSolutions.AutoSizeCells();
                gridSolutions.Columns.StretchToFit();
            }
            catch (Exception /*ex*/)
            { 
            }

            // select first solution
            gridSolutions.Selection.SelectRow(1, true);
            // draw
            graphCtrlCaseSolution.Invalidate();
            graphCtrlPalletSolution.Invalidate();
        }
        #endregion

        #region Public properties
        public BoxCasePalletAnalysis CaseAnalysis
        {
            get { return _caseAnalysis; }
            set { _caseAnalysis = value; }
        }
        #endregion

        #region Event handlers
        private void onGridSolutionSelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
            int[] indexes = region.GetRowsIndex();
            // no selection -> exit
            if (indexes.Length == 0) return;
            // update select/unselect button text
            UpdateSelectButtonText();
            // redraw
            graphCtrlCaseSolution.Invalidate();
            graphCtrlPalletSolution.Invalidate();
        }
        // checkbox event handler
        void clickEvent_Click(object sender, EventArgs e)
        {
            SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
            int iSel = context.Position.Row - 1;
            if (!_caseAnalysis.HasSolutionSelected(iSel))
                _caseAnalysis.SelectSolutionByIndex(iSel);
            else
                _caseAnalysis.UnselectSolutionByIndex(iSel);
        }
        #endregion

        #region Solution selection
        private void UpdateGridCheckBoxes()
        {
            int iRow = 0;
            foreach (BoxCasePalletSolution sol in _caseAnalysis.Solutions)
            {
                ++iRow;
                SourceGrid.Cells.CheckBox checkBox = gridSolutions[iRow, 6] as SourceGrid.Cells.CheckBox;
                checkBox.Checked = _caseAnalysis.HasSolutionSelected(iRow - 1);
            }
        }
        private void UpdateSelectButtonText()
        {
            int iSel = GetCurrentSolutionIndex();
            btSelectSolution.Enabled = (iSel != -1);
            if (-1 == iSel) return; // no valid selection
            btSelectSolution.Text = _caseAnalysis.HasSolutionSelected(iSel) ? Properties.Resources.ID_DESELECT : Properties.Resources.ID_SELECT;
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
        private BoxCasePalletSolution GetCurrentSolution()
        {
            int iIndexSol = GetCurrentSolutionIndex();
            if (-1 == iIndexSol) return null;
            else return _caseAnalysis.Solutions[iIndexSol];
        }
        private void btSelectSolution_Click(object sender, EventArgs e)
        {
            try
            {
                int iSel = GetCurrentSolutionIndex();
                if (-1 == iSel) return;
                if (!_caseAnalysis.HasSolutionSelected(iSel))
                    _caseAnalysis.SelectSolutionByIndex(iSel);
                else
                    _caseAnalysis.UnselectSolutionByIndex(iSel);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region ItemListener implementation
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
            // draw
            graphCtrlCaseSolution.Invalidate();
            graphCtrlPalletSolution.Invalidate();
        }
        /// <summary>
        /// overrides IItemListener.Kill
        /// handles analysis removal for any reason (deletion/document closing)
        /// </summary>
        /// <param name="item"></param>
        public void Kill(ItemBase item)
        {
            Close();
            _caseAnalysis.RemoveListener(this);
        }
        #endregion

        #region IView implementation
        /// <summary>
        /// referenced IDocument
        /// </summary>
        public IDocument Document
        {
            get { return _document; }
        }
        #endregion

        #region Drawing
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (graphCtrlCaseSolution == ctrl)
            {
                // instantiate solution viewer
                BoxCasePalletSolutionViewer sv = new BoxCasePalletSolutionViewer(GetCurrentSolution());
                sv.Draw(graphics);
            }
            else if (graphCtrlPalletSolution == ctrl)
            {
                    CasePalletSolution sol = GetCurrentSolution().PalletSolutionDesc.LoadPalletSolution();
                    // instantial solution viewer
                    CasePalletSolutionViewer svPallet = new CasePalletSolutionViewer(sol);
                    svPallet.Draw(graphics);
            }
        }
        #endregion
    }
}
