#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using log4net;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;
using TreeDim.StackBuilder.SQLite;
using TreeDim.StackBuilder.Engine;

using Sharp3D.Math.Core;

using TreeDim.StackBuilder.GUIExtension.Properties;
#endregion

namespace TreeDim.StackBuilder.GUIExtension
{
    public partial class FormDefineCaseOptimization : Form
    {
        #region Data members
        private string _boxName;
        private PalletProperties _palletProperties;
        private List<CaseOptimSolution> _solutions = new List<CaseOptimSolution>();
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormDefineCaseOptimization));
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormDefineCaseOptimization()
        {
            InitializeComponent();
        }
        #endregion

        #region Public properties
        public string BoxName
        {
            get { return _boxName; }
            set { _boxName = value; }
        }
        public double BoxLength
        {
            get { return Convert.ToDouble(nudBoxLength.Value); }
            set { nudBoxLength.Value = Convert.ToDecimal(value); }
        }
        public double BoxWidth
        {
            get { return Convert.ToDouble(nudBoxWidth.Value); }
            set { nudBoxWidth.Value = Convert.ToDecimal(value); }
        }
        public double BoxHeight
        {
            get { return Convert.ToDouble(nudBoxHeight.Value); }
            set { nudBoxHeight.Value = Convert.ToDecimal(value); }
        }

        public BoxProperties SelectedBox
        {
            get
            {
                BoxProperties bProperties = new BoxProperties(null, (double)nudBoxLength.Value, (double)nudBoxWidth.Value, (double)nudBoxHeight.Value);
                bProperties.Name = _boxName;
                bProperties.Description = _boxName;
                Color[] colors = new Color[6];
                for (int i = 0; i < 6; ++i) colors[i] = Color.Turquoise;
                bProperties.SetAllColors(colors);
                return bProperties;
            }
        }
        public PalletProperties SelectedPallet
        {
            get
            {
                PalletItem palletItem = cbPallet.SelectedItem as PalletItem;
                return palletItem != null ? palletItem.Item as PalletProperties : null;
            }
        }
        #endregion

        #region Private properties
        private double MaxLength { get { return (double)nudMaxCaseLength.Value; } }
        private double MaxWidth { get { return (double)nudMaxCaseWidth.Value; } }
        private double MaxHeight { get { return (double)nudMaxCaseHeight.Value; } }
        private double MinLength
        {
            get { return (double)nudMinCaseLength.Value; }
            set { nudMinCaseLength.Value = (decimal)value; }
        }
        private double MinWidth
        {
            get { return (double)nudMinCaseWidth.Value; }
            set { nudMinCaseWidth.Value = (decimal)value; }
        }
        private double MinHeight
        {
            get { return (double)nudMinCaseHeight.Value; }
            set { nudMinCaseHeight.Value = (decimal)value; }
        }
        private int BoxPerCase { get { return (int)nudNumber.Value; } }
        private int[] NoWalls
        {
            get
            {
                int[] noWalls = new int[3];
                noWalls[0] = (int)nudWallsLengthDir.Value;
                noWalls[1] = (int)nudWallsWidthDir.Value;
                noWalls[2] = (int)nudWallsHeightDir.Value;
                return noWalls;
            }
        }
        private double WallThickness { get { return (double)nudWallThickness.Value; } }
        private bool ForceVerticalBoxOrientation
        {
            get { return chkVerticalOrientationOnly.Checked; }
            set { chkVerticalOrientationOnly.Checked = value; }
        }
        #endregion

        #region Load / Close
        private void FormDefineCaseOptimization_Load(object sender, EventArgs e)
        {
            // load pallets
            LoadPallets();
            // set default pallet height
            nudPalletHeight.Value = (decimal)Settings.Default.MaximumPalletWeight;
            // set default wall numbers and thickness
            nudWallsLengthDir.Value = Settings.Default.NumberWallsLength;
            nudWallsWidthDir.Value = Settings.Default.NumberWallsWidth;
            nudWallsHeightDir.Value = Settings.Default.NumberWallsHeight;
            nudWallThickness.Value = (decimal)Settings.Default.WallThickness;
            nudNumber.Value = Settings.Default.NumberBoxesPerCase;
            // set vertical orientation
            ForceVerticalBoxOrientation = Settings.Default.ForceVerticalBoxOrientation;
            // set min / max case dimensions
            SetMinCaseDimensions();
            SetMaxCaseDimensions();
            // set event handler for grid selection change event
            gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(Selection_SelectionChanged);
            // fill grid
            FillGrid();
        }
        private void FormDefineCaseOptimization_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // save setings
                Settings.Default.NumberWallsLength = (int)nudWallsLengthDir.Value;
                Settings.Default.NumberWallsWidth = (int)nudWallsWidthDir.Value;
                Settings.Default.NumberWallsHeight = (int)nudWallsHeightDir.Value;
                Settings.Default.PalletHeight = (double)nudPalletHeight.Value;
                Settings.Default.WallThickness = (double)nudWallThickness.Value;
            }
            catch (Exception ex)
            { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Handlers
        private void cbPallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 == cbPallet.SelectedIndex)
                return;
            PalletItem item = cbPallet.Items[cbPallet.SelectedIndex] as PalletItem;
            _palletProperties = item.Item;
            // update pallet image
            DrawPallet();
        }
        private void btOptimize_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // build case optimizer and compute solutions
                CaseOptimizer caseOptimizer = new CaseOptimizer(
                    SelectedBox                     // BoxProperties
                    , SelectedPallet                // PalletProperties
                    , BuildPalletConstraintSet()    // ConstraintSet
                    , BuildCaseOptimConstraintSet() // CaseOptimConstraintSet
                    );
                _solutions = caseOptimizer.CaseOptimSolutions(BoxPerCase);

                // fill grid using solutions
                FillGrid();
                UpdateButtonAddSolutionStatus();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        void Selection_SelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            try
            {
                SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                // no selection -> exit
                if (indexes.Length == 0) return;
                // redraw
                Draw();
                // update "Add solution" button status
                UpdateButtonAddSolutionStatus();
            }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }

        private void btSetMinimum_Click(object sender, EventArgs e)
        {
            try { SetMinCaseDimensions(); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }

        private void btSetMaximum_Click(object sender, EventArgs e)
        {
            try { SetMaxCaseDimensions(); }
            catch (Exception ex) { _log.Error(ex.ToString()); }
        }
        #endregion

        #region Helpers
        private void LoadPallets()
        {
            string palletName = Properties.Settings.Default.PalletName;
            int selectedIndex = -1;

            using (ItemStore itemStore = new ItemStore())
            {
                List<PalletProperties> pallets = itemStore.GetAllPallets();
                int i = 0;
                foreach (PalletProperties pallet in pallets)
                {
                    cbPallet.Items.Add(new PalletItem(pallet));
                    if (palletName == pallet.Name)
                        selectedIndex = i;
                    ++i;
                }           
            }
            cbPallet.SelectedIndex = selectedIndex;
        }

        private void DrawPallet()
        {
            PalletToPictureBox.Draw(SelectedPallet, pbPallet);
        }
 
        private int SelectedSolutionIndex
        {
            get
            {
                SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                // no selection -> exit
                if (indexes.Length == 0) return -1;
                // return index
                return indexes[0] - 1;
            }
        }
        private CaseOptimSolution SelectedSolution
        {
            get
            {
                int iIndexSol = SelectedSolutionIndex;
                if (-1 == iIndexSol) return null;
                else return _solutions[iIndexSol];
            }
        }
        /// <summary>
        /// Use box dimensions to set min case dimensions
        /// </summary>
        private void SetMinCaseDimensions()
        {
            // get selected box
            BProperties boxProperties = SelectedBox;
            if (null == boxProperties) return;
            // compute min dimension
            double minDim = Math.Min(boxProperties.Length, Math.Min(boxProperties.Width, boxProperties.Height));
            if ((int)nudNumber.Value > 8)
                minDim *= 2;
            // set min dimension
            MinLength = minDim;
            MinWidth = minDim;
            MinHeight = minDim;

            // update message + enable/disable optimise button
            UpdateButtonOptimizeStatus();
        }
        private void SetMaxCaseDimensions()
        {
            PalletProperties palletProperties = SelectedPallet;
            if (null == palletProperties) return;
            // use pallet dimensions to set max case dimensions
            nudMaxCaseLength.Value = (decimal)(palletProperties.Length * 0.5);
            nudMaxCaseWidth.Value = (decimal)(palletProperties.Width * 0.5);
            nudMaxCaseHeight.Value = nudPalletHeight.Value * (decimal)0.5;
            // update message + enable/disable optimise button
            UpdateButtonOptimizeStatus();
        }
        private CaseOptimConstraintSet BuildCaseOptimConstraintSet()
        {
            return new CaseOptimConstraintSet(
                    NoWalls
                    , WallThickness
                    , new Vector3D(MinLength, MinWidth, MinHeight)
                    , new Vector3D(MaxLength, MaxWidth, MaxHeight)
                    , ForceVerticalBoxOrientation
                    );
        }
        private PalletConstraintSet BuildPalletConstraintSet()
        {
            // build pallet constraint set
            CasePalletConstraintSet palletConstraintSet = new CasePalletConstraintSet();
            palletConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, !ForceVerticalBoxOrientation);
            palletConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, !ForceVerticalBoxOrientation);
            palletConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, !ForceVerticalBoxOrientation);
            palletConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, !ForceVerticalBoxOrientation);
            palletConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, !ForceVerticalBoxOrientation);
            palletConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, true);

            // use all existing patterns
            palletConstraintSet.AllowedPatternString = "Column,Diagonale,Interlocked,Trilock,Spirale";

            // allow aligned and alternate layers
            palletConstraintSet.AllowAlignedLayers = true;
            palletConstraintSet.AllowAlternateLayers = true;

            // set maximum pallet height
            palletConstraintSet.MaximumHeight = (double)nudPalletHeight.Value;
            palletConstraintSet.UseMaximumHeight = true;

            // do not use other constraints
            palletConstraintSet.UseMaximumPalletWeight = false;
            palletConstraintSet.UseMaximumNumberOfCases = false;
            palletConstraintSet.UseMaximumWeightOnBox = false;

            return palletConstraintSet;
        }
        #endregion

        #region Grid
        private void FillGrid()
        {
            try
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
                viewColumnHeader.Font = new Font("Arial", 8, FontStyle.Regular);
                viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;

                // create the grid
                gridSolutions.BorderStyle = BorderStyle.FixedSingle;

                gridSolutions.ColumnsCount = 12;
                gridSolutions.FixedRows = 1;
                gridSolutions.Rows.Insert(0);

                // header
                SourceGrid.Cells.ColumnHeader columnHeader;
                // 0
                columnHeader = new SourceGrid.Cells.ColumnHeader("#");
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 0] = columnHeader;
                // 1
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_A1);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 1] = columnHeader;
                // 2
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_A2);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 2] = columnHeader;
                // 3
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_A3);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 3] = columnHeader;
                // 4
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_LENGTH);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 4] = columnHeader;
                // 5
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_WIDTH);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 5] = columnHeader;
                // 6
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_HEIGHT);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 6] = columnHeader;
                // 7
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_AREA);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 7] = columnHeader;
                // 8
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_CASESLAYER);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 8] = columnHeader;
                // 9
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_LAYERS);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 9] = columnHeader;
                // 10
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_CASESPALLET);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 10] = columnHeader;
                // 11
                columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_VOLUMEEFFICIENCY);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridSolutions[0, 11] = columnHeader;

                // column width
                gridSolutions.Columns[0].Width = 30;
                gridSolutions.Columns[1].Width = 30;
                gridSolutions.Columns[2].Width = 30;
                gridSolutions.Columns[3].Width = 30;
                gridSolutions.Columns[4].Width = 50;
                gridSolutions.Columns[5].Width = 50;
                gridSolutions.Columns[6].Width = 50;
                gridSolutions.Columns[7].Width = 50;
                gridSolutions.Columns[8].Width = 80;
                gridSolutions.Columns[9].Width = 50;
                gridSolutions.Columns[10].Width = 80;
                gridSolutions.Columns[11].Width = 100;

                // get BoxProperties
                BoxProperties boxProperties = SelectedBox;
                PalletProperties palletProperties = SelectedPallet;
                CaseOptimConstraintSet caseOptimConstraintSet = BuildCaseOptimConstraintSet();
                PalletConstraintSet palletConstraintSet = new CasePalletConstraintSet();
                palletConstraintSet.MaximumHeight = (double)nudPalletHeight.Value;
                // data
                int iIndex = 0;
                foreach (CaseOptimSolution sol in _solutions)
                {
                    // insert new row
                    gridSolutions.Rows.Insert(++iIndex);
                    // # (index)
                    gridSolutions[iIndex, 0] = new SourceGrid.Cells.Cell(string.Format("{0}", iIndex));
                    // A1
                    gridSolutions[iIndex, 1] = new SourceGrid.Cells.Cell(string.Format("{0}", sol.CaseDefinition.Arrangement._iLength));
                    // A2
                    gridSolutions[iIndex, 2] = new SourceGrid.Cells.Cell(string.Format("{0}", sol.CaseDefinition.Arrangement._iWidth));
                    // A3
                    gridSolutions[iIndex, 3] = new SourceGrid.Cells.Cell(string.Format("{0}", sol.CaseDefinition.Arrangement._iHeight));
                    // Case inner dimensions
                    Vector3D innerDim = sol.CaseDefinition.InnerDimensions(boxProperties);
                    // LENGTH
                    gridSolutions[iIndex, 4] = new SourceGrid.Cells.Cell(string.Format("{0:0.#}", innerDim.X));
                    // WIDTH
                    gridSolutions[iIndex, 5] = new SourceGrid.Cells.Cell(string.Format("{0:0.#}", innerDim.Y));
                    // HEIGHT
                    gridSolutions[iIndex, 6] = new SourceGrid.Cells.Cell(string.Format("{0:0.#}", innerDim.Z));
                    // AREA
                    gridSolutions[iIndex, 7] = new SourceGrid.Cells.Cell(string.Format("{0:0.00}", sol.CaseDefinition.Area(boxProperties, caseOptimConstraintSet) * 1.0E-06));
                    // CASES PER LAYER
                    gridSolutions[iIndex, 8] = new SourceGrid.Cells.Cell(string.Format("{0}", sol.PalletSolution[0].BoxCount));
                    // LAYERS
                    gridSolutions[iIndex, 9] = new SourceGrid.Cells.Cell(string.Format("{0}", sol.PalletSolution.Count));
                    // CASES PER PALLET
                    gridSolutions[iIndex, 10] = new SourceGrid.Cells.Cell(string.Format("{0}", sol.CaseCount));
                    // EFFICIENCY
                    double efficiency = sol.CaseCount * sol.CaseDefinition.InnerVolume(boxProperties) /
                        ((palletProperties.Length - palletConstraintSet.OverhangX)
                        * (palletProperties.Width - palletConstraintSet.OverhangY)
                        * (palletConstraintSet.MaximumHeight - palletProperties.Height)
                        );
                    gridSolutions[iIndex, 11] = new SourceGrid.Cells.Cell(string.Format("{0:0.00}", efficiency));
                }
                // select first solution
                if (_solutions.Count > 0)
                {
                    gridSolutions.Selection.EnableMultiSelection = false;
                    gridSolutions.Selection.SelectRow(1, true);
                }
            }
            catch (Exception ex)
            {   _log.Error(ex.ToString()); }
            Draw();
            UpdateButtonAddSolutionStatus();
        }
        #endregion

        #region Drawing
        private void Draw()
        {
            // ### draw case definition
            try
            {
                // sanity check
                if (pbBoxesLayout.Size.Width < 1 || pbBoxesLayout.Size.Height < 1)
                    return;
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pbBoxesLayout.Size);
                // set camera position
                graphics.CameraPosition = Graphics3D.Corner_0;
                // set camera target
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                // set light direction
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                // set viewport (not actually needed)
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // show images
                graphics.ShowTextures = true;
                // get selected solution
                CaseOptimSolution solution = SelectedSolution;
                if (null == solution) return;
                // instantiate case definition viewer
                CaseDefinitionViewer cdv = new CaseDefinitionViewer(SelectedSolution.CaseDefinition, SelectedBox, BuildCaseOptimConstraintSet());
                cdv.Orientation = SelectedSolution.PalletSolution.FirstCaseOrientation;
                cdv.Draw(graphics);
                // show generated bitmap on picture box control
                pbBoxesLayout.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            // ### draw associated pallet solution
            try
            {
                // sanity check
                if (pbPalletSolution.Size.Width < 1 || pbPalletSolution.Size.Height < 1)
                    return;
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(pbPalletSolution.Size);
                // set camera position
                graphics.CameraPosition = Graphics3D.Corner_0;
                // set camera target
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                // set light direction
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                // set viewport (not actually needed)
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // show images
                graphics.ShowTextures = true;
                // get selected solution
                CaseOptimSolution solution = SelectedSolution;
                // get selected box
                BoxProperties boxProperties = SelectedBox;
                // get selected pallet
                PalletProperties palletProperties = SelectedPallet;
                if (null != solution && null != boxProperties && null != palletProperties)
                {
                    Vector3D outerDim = solution.CaseDefinition.OuterDimensions(boxProperties, BuildCaseOptimConstraintSet());
                    BoxProperties caseProperties = new BoxProperties(null, outerDim.X, outerDim.Y, outerDim.Z);
                    caseProperties.SetColor(Color.Chocolate);
                    CasePalletSolutionViewer.Draw(graphics, solution.PalletSolution, caseProperties, null, palletProperties);
                }
                // show generated bitmap or picture box control
                pbPalletSolution.Image = graphics.Bitmap;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Status
        private void UpdateButtonOptimizeStatus()
        {
            BoxProperties box = SelectedBox;
            string message = string.Empty;
            // compute maximum volume
            double maxVol = MaxLength * MaxWidth * MaxHeight;
            // compare max vol with volume of Number 
            if (MaxLength <= MinLength)
                message = string.Format(Resources.ID_MAXLOWERTHANMIN, Resources.ID_LENGTH, Resources.ID_LENGTH);
            else if (MaxWidth <= MinWidth)
                message = string.Format(Resources.ID_MAXLOWERTHANMIN, Resources.ID_WIDTH, Resources.ID_WIDTH);
            else if (MaxHeight <= MinHeight)
                message = string.Format(Resources.ID_MAXLOWERTHANMIN, Resources.ID_HEIGHT, Resources.ID_HEIGHT);
            else if (maxVol < BoxPerCase * box.Volume)
                message = string.Format(Resources.ID_INSUFFICIENTVOLUME, BoxPerCase, box.Name);
            else if ((double)nudPalletHeight.Value < MinHeight + SelectedPallet.Height)
                message = string.Format(Resources.ID_INSUFFICIENTPALLETHEIGHT, (double)nudPalletHeight.Value, MinHeight + SelectedPallet.Height);
            // btOptimize
            btOptimize.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }

        private void UpdateButtonAddSolutionStatus()
        {
        }
        #endregion


    }
}
