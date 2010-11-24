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
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.Desktop.Properties;

using log4net;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class FormEditPalletSolutionDB : Form
    {
        #region Data members
        protected static readonly ILog _log = LogManager.GetLogger(typeof(FormEditPalletSolutionDB));
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormEditPalletSolutionDB()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void FormEditPalletSolutionDB_Load(object sender, EventArgs e)
        {
            try
            {
                FillKeyCombo();
                // set event handler for grid selection change event
                gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onGridSolutionSelectionChanged);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private PalletSolutionKey CurrentKey
        { 
            get
            {
                // sanity check
                if (cbPalletDimensions.Items.Count == 0) return null;
                // get selected item
                return cbPalletDimensions.Items[cbPalletDimensions.SelectedIndex] as PalletSolutionKey;
            }
        }

        private PalletSolutionDesc CurrentSolutionDesc
        {
            get
            {
                // get list of solution desc
                List<PalletSolutionDesc> solutionDescList = PalletSolutionDatabase.Instance.QueryPalletSolutions(CurrentKey);
                // get selected row
                SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                // no selection -> exit
                if (indexes.Length == 0) return null;
                return solutionDescList[indexes[0]-1];
            }
        }
        private void FillKeyCombo()
        {
            // check if database is empty
            if (PalletSolutionDatabase.Instance.IsEmpty)
            {
                MessageBox.Show(Resources.ID_DATABASEEMPTY, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information );
                this.Close();
            }
            // fill key combo box
            cbPalletDimensions.Items.Clear();
            cbPalletDimensions.Items.AddRange(PalletSolutionDatabase.Instance.Keys.ToArray());
            if (cbPalletDimensions.Items.Count > 0)
                cbPalletDimensions.SelectedIndex = 0;

            FillGrid();
        }

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

            columnHeader = new SourceGrid.Cells.ColumnHeader("Name");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 0] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Case dimensions\n(mm*mm*mm)");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 1] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Case inside dimensions\n(mm*mm*mm)");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 2] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Orientation");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 3] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Case count");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 4] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader();
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 5] = columnHeader;

            int iIndex = 0;
            foreach (PalletSolutionDesc desc in PalletSolutionDatabase.Instance.QueryPalletSolutions(CurrentKey))
            {
                gridSolutions.Rows.Insert(++iIndex);
                gridSolutions[iIndex, 0] = new SourceGrid.Cells.Cell(desc.FriendlyName);
                gridSolutions[iIndex, 1] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseDimensionsString));
                gridSolutions[iIndex, 2] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseInsideDimensionsString));
                gridSolutions[iIndex, 3] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseOrientation));
                gridSolutions[iIndex, 4] = new SourceGrid.Cells.Cell(string.Format("{0}", desc.CaseCount));
                gridSolutions[iIndex, 5] = new SourceGrid.Cells.Button("");
                gridSolutions[iIndex, 5].Image = Properties.Resources.Delete;
                SourceGrid.Cells.Controllers.Button buttonClickEvent = new SourceGrid.Cells.Controllers.Button();
                buttonClickEvent.Executed += new EventHandler(DeleteButton_Click);
                gridSolutions[iIndex, 5].Controller.AddController(buttonClickEvent);
            }

            // handling check box click
            SourceGrid.Cells.Controllers.CustomEvents solCheckboxClickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            solCheckboxClickEvent.Click += new EventHandler(clickEvent_Click);

            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();

            // select first solution
            if (gridSolutions.RowsCount > 1)
                gridSolutions.Selection.SelectRow(1, true);
            Draw();
        }
        #endregion

        #region Event handlers
        private void cbPalletDimensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        // checkbox event handler
        void clickEvent_Click(object sender, EventArgs e)
        {
            SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
            int iSel = context.Position.Row - 1;
        }

        void DeleteButton_Click(object sender, EventArgs e)
        {
            SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
            if (context.Position.Row > 0)
            {
                PalletSolutionDesc desc = PalletSolutionDatabase.Instance.QueryPalletSolutions(CurrentKey)[context.Position.Row - 1];
                PalletSolutionDatabase.Instance.RemoveByGuid(desc.Guid);
                if (PalletSolutionDatabase.Instance.HasKey(CurrentKey))
                    FillGrid();
                else
                    FillKeyCombo();
            }
        }

        private void onGridSolutionSelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
            int[] indexes = region.GetRowsIndex();
            // no selection -> exit
            if (indexes.Length == 0) return;
            // redraw
            Draw();
        }

        private void pictureBoxSolution_SizeChanged(object sender, EventArgs e)
        {
            Draw();
        }
        #endregion

        #region Drawing
        private void Draw()
        {
            try
            {
                // get current descriptor
                PalletSolutionDesc desc = CurrentSolutionDesc;
                // sanity check
                if (null == desc
                    || pictureBoxCase.Size.Width < 1 || pictureBoxCase.Size.Height < 1
                    || pictureBoxSolution.Size.Width < 1 || pictureBoxSolution.Size.Height < 1)
                    return;

                // load document
                Document document = new Document(desc.FullFilePath, null);
                if (document.Analyses.Count == 0) return;
                // get analysis and solution
                Analysis analysis = document.Analyses[0];
                {
                    Graphics3DImage graphics = new Graphics3DImage(pictureBoxCase.Size);
                    graphics.CameraPosition = Graphics3D.Corner_0;
                    graphics.Target = Vector3D.Zero;
                    Box box = new Box(0, analysis.BProperties);
                    graphics.AddBox(box);
                    graphics.AddDimensions(new DimensionCube(box.Length, box.Width, box.Height));
                    graphics.Flush();
                    pictureBoxCase.Image = graphics.Bitmap;
                }

                {
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pictureBoxSolution.Size);
                // set camera position 
                graphics.CameraPosition = Graphics3D.Corner_0;
                graphics.Target = Vector3D.Zero;
                // instantiate solution viewer
                SolutionViewer sv = new SolutionViewer(analysis.Solutions[0]);
                sv.Draw(graphics);
                // show generated bitmap on picture box control
                pictureBoxSolution.Image = graphics.Bitmap;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }

        }
        #endregion




    }
}
