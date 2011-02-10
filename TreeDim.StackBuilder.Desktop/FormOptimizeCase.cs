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
using TreeDim.StackBuilder.Desktop.Properties;
using log4net;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    /// <summary>
    /// This forms enables optimizing case dimensions
    /// </summary>
    public partial class FormOptimizeCase : Form
    {
        #region Combo box item private classes
        private class BoxItem
        {
            private BProperties _boxProperties;

            public BoxItem(BProperties boxProperties)
            {
                _boxProperties = boxProperties;
            }

            public BProperties Item
            {
                get { return _boxProperties; }
            }

            public override string ToString()
            {
                return _boxProperties.Name;
            }
        }
        private class PalletItem
        {
            private PalletProperties _palletProperties;

            public PalletItem(PalletProperties palletProperties)
            {
                _palletProperties = palletProperties;
            }

            public PalletProperties Item
            {
                get { return _palletProperties; }
            }

            public override string ToString()
            {
                return _palletProperties.Name;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// constructor takes document as argument
        /// </summary>
        public FormOptimizeCase(DocumentSB document)
        {
            InitializeComponent();
            // document
            _document = document;

        }
        #endregion

        #region Load / Close methods
        private void FormOptimizeCase_Load(object sender, EventArgs e)
        {
            // intialize box combo
            foreach (BoxProperties bProperties in _document.Boxes)
                cbBoxes.Items.Add(new BoxItem(bProperties));
            if (cbBoxes.Items.Count > 0)
                cbBoxes.SelectedIndex = 0;
            // initialize pallet combo
            foreach (PalletProperties palletProperties in _document.Pallets)
                cbPallet.Items.Add(new PalletItem(palletProperties));
            if (cbPallet.Items.Count > 0)
                cbPallet.SelectedIndex = 0;
            // set default wall thickness
            nudWallsLengthDir.Value = Settings.Default.NumberWallsLength;
            nudWallsWidthDir.Value = Settings.Default.NumberWallsWidth;
            nudWallsHeightDir.Value = Settings.Default.NumberWallsHeight;
            nudPalletHeight.Value = (decimal)Settings.Default.PalletHeight;
            nudWallThickness.Value = (decimal)Settings.Default.WallThickness;
            nudNumber.Value = Settings.Default.NumberBoxesPerCase;
            // set min / max case dimensions
            SetMinCaseDimensions();
            SetMaxCaseDimensions();
            // set event handler for grid selection change event
            gridSolutions.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(Selection_SelectionChanged);
            // fill grid
            FillGrid();

            UpdateButtonOptimizeStatus();
            // windows settings
            if (null != Settings.Default.FormOptimizeCasePosition)
                Settings.Default.FormOptimizeCasePosition.Restore(this);

        }        

        private void FormOptimizeCase_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // save settings
                Settings.Default.NumberWallsLength = (int)nudWallsLengthDir.Value;
                Settings.Default.NumberWallsWidth = (int)nudWallsWidthDir.Value;
                Settings.Default.NumberWallsHeight = (int)nudWallsHeightDir.Value;
                Settings.Default.PalletHeight = (double)nudPalletHeight.Value;
                Settings.Default.WallThickness = (double)nudWallThickness.Value;
                Settings.Default.NumberBoxesPerCase = (int)nudNumber.Value;
                // window position
                if (null == Settings.Default.FormOptimizeCasePosition)
                    Settings.Default.FormOptimizeCasePosition = new WindowSettings();
                Settings.Default.FormOptimizeCasePosition.Record(this);
            }
            catch (Exception ex)
            {   _log.Error(ex.ToString()); }
        }
        private void FormOptimizeCase_SizeChanged(object sender, EventArgs e)
        {

        }

        private void UpdateButtonOptimizeStatus()
        {
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
            else if (maxVol < BoxPerCase * SelectedBox.Volume)
                message = string.Format(Resources.ID_INSUFFICIENTVOLUME, BoxPerCase, SelectedBox.Name);

            // btOptimize
            btOptimize.Enabled = string.IsNullOrEmpty(message);
            // status bar
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        #endregion

        #region Event handlers
        private void cbBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoxItem boxItem = cbBoxes.SelectedItem as BoxItem;
            BProperties bProperties = null != boxItem ? boxItem.Item : null;
            lbBoxDimensions.Text = null != bProperties ?
                string.Format("({0}*{1}*{2})", bProperties.Length, bProperties.Width, bProperties.Height)
                : string.Empty;
        }
        private void cbPallet_SelectedIndexChanged(object sender, EventArgs e)
        {
            PalletItem palletItem = cbPallet.SelectedItem as PalletItem;
            PalletProperties palletProperties = null != palletItem ? palletItem.Item : null;
            lbPalletDimensions.Text = null != palletProperties ?
                string.Format("({0}*{1}*{2})", palletProperties.Length, palletProperties.Width, palletProperties.Height)
                : string.Empty;
        }
        private void btOptimize_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void btAddSolution_Click(object sender, EventArgs e)
        {
            try
            {
                // add new case
                // add new case analysis
                // add new pallet analysis
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
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
        void Selection_SelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
        }
        #endregion

        #region Private properties
        private double MaxLength { get { return (double)nudMaxCaseLength.Value; } }
        private double MaxWidth { get { return (double)nudMaxCaseWidth.Value; } }
        private double MaxHeight { get { return (double)nudMaxCaseHeight.Value; } }
        private double MinLength { get { return (double)nudMinCaseLength.Value; } }
        private double MinWidth { get { return (double)nudMinCaseWidth.Value; } }
        private double MinHeight { get { return (double)nudMinCaseHeight.Value; } }
        private int BoxPerCase { get { return (int)nudNumber.Value; } }
        #endregion

        #region Grid
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
            columnHeader = new SourceGrid.Cells.ColumnHeader(Resources.ID_EFFICIENCY);
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridSolutions[0, 11] = columnHeader; 
            // data


            // column width
            gridSolutions.Columns[0].Width = 20;
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

            // select first solution
            gridSolutions.Selection.SelectRow(1, true);
            Draw();
        }

        private void Draw()
        { 
        }
        #endregion

        #region Helpers
        private BoxProperties SelectedBox
        {
            get
            {
                BoxItem boxItem = cbBoxes.SelectedItem as BoxItem;
                return boxItem != null ? boxItem.Item as BoxProperties : null;
            }
        }
        private PalletProperties SelectedPallet
        {
            get
            {
                PalletItem palletItem = cbPallet.SelectedItem as PalletItem;
                return palletItem != null ? palletItem.Item as PalletProperties : null;
            }
        }
        private void SetMinCaseDimensions()
        {
            BProperties boxProperties = SelectedBox;
            if (null == boxProperties)  return;
            // use box dimensions to set min case dimensions
            nudMinCaseLength.Value = (decimal)boxProperties.Length;
            nudMinCaseWidth.Value = (decimal)boxProperties.Width;
            nudMinCaseHeight.Value = (decimal)boxProperties.Height;
        }
        private void SetMaxCaseDimensions()
        {
            PalletProperties palletProperties = SelectedPallet;
            if (null == palletProperties) return;
            // use pallet dimensions to set max case dimensions
            nudMaxCaseLength.Value = (decimal)palletProperties.Length;
            nudMaxCaseWidth.Value = (decimal)palletProperties.Width;
            nudMaxCaseHeight.Value = nudPalletHeight.Value;
        }
        #endregion

        #region Data members
        private DocumentSB _document;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormOptimizeCase));
        #endregion

    }
}
