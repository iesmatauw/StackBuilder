#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using log4net;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Desktop.Properties;
using TreeDim.EdgeCrushTest;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public partial class DockContentECTAnalysis : DockContent, IView, IItemListener
    {
        #region Data members
        /// <summary>
        /// ECT analysis
        /// </summary>
        private ECTAnalysis _ectAnalysis;
        /// <summary>
        /// document
        /// </summary>
        private IDocument _document;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentECTAnalysis));
        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        public DockContentECTAnalysis(DocumentSB document, ECTAnalysis ectAnalysis)
        {
            _document = document;
            _ectAnalysis = ectAnalysis;
            _ectAnalysis.AddListener(this);

            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // text
            this.Text = _ectAnalysis.Name + " - " + _ectAnalysis.ParentDocument.Name;
            // Fill case type
            cbCaseType.DataSource = new BindingSource(McKeeFormula.CaseTypeDictionary, null);
            cbCaseType.DisplayMember = "Key";
            cbCaseType.ValueMember = "Value";
            // Fill printed surface combo
            cbPrintedSurface.DataSource = new BindingSource(McKeeFormula.PrintCoefDictionary, null);
            cbPrintedSurface.DisplayMember = "Key";
            cbPrintedSurface.ValueMember = "Value";
            // Fill cardboard combo
            cbCardboard.DataSource = new BindingSource(McKeeFormula.CardboardQualityDictionary, null);
            cbCardboard.DisplayMember = "Key";
            cbCardboard.ValueMember = "Value";
     
            // formula
            rbFormula1.Checked = _ectAnalysis.UseClassicFormula;
            rbFormula2.Checked = _ectAnalysis.UseImprovedFormula;
            
            InitializeGrid();

            int caseTypeIndex = cbCaseType.FindString(_ectAnalysis.CaseType);
            cbCaseType.SelectedIndex = caseTypeIndex != -1 ? caseTypeIndex : 0;
            int printedSurfaceIndex = cbPrintedSurface.FindString(_ectAnalysis.PrintSurface);
            cbPrintedSurface.SelectedIndex = printedSurfaceIndex != -1 ? printedSurfaceIndex : 0;
            int cardboardIndex = cbCardboard.FindString(_ectAnalysis.Cardboard.Id);
            cbCardboard.SelectedIndex = cardboardIndex != -1 ? cardboardIndex : 0;

            rbFormula1.CheckedChanged +=new EventHandler(UpdateResults);
            rbFormula2.CheckedChanged += new EventHandler(UpdateResults);
            cbCaseType.SelectedIndexChanged += new EventHandler(UpdateResults);
            cbPrintedSurface.SelectedIndexChanged += new EventHandler(UpdateResults);
            cbCardboard.SelectedIndexChanged += new EventHandler(UpdateResults);

            UpdateResults(this, null);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // remove from list of view attached to document
            Document.RemoveView(this);
        }
        #endregion

        #region Public properties
        public ECTAnalysis ECTAnalysis
        {
            get { return _ectAnalysis; }
        }
        #endregion
 
        #region IItemListener implementation
        public void Update(ItemBase item)
        { 
        }
        public void Kill(ItemBase item)
        {
            Close();
            _ectAnalysis.RemoveListener(this);
        }
        #endregion

        #region IView implementation
        public IDocument Document
        {
            get { return _document; }
        }
        #endregion

        #region Handlers
        private void UpdateResults(object sender, EventArgs e)
        {
            // update quality data
            KeyValuePair<string, McKeeFormula.QualityData> keyValuePair = (KeyValuePair<string, McKeeFormula.QualityData>)cbCardboard.SelectedItem;
            McKeeFormula.QualityData qualityData = keyValuePair.Value;
            lbValueThickness.Text = string.Format("{0}", qualityData.Thickness);
            lbValueStiffnessX.Text = string.Format("{0}", qualityData.RigidityDX);
            lbValueStiffnessY.Text = string.Format("{0}", qualityData.RigidityDY);
            lbECTCoefficient.Text = string.Format("{0}", qualityData.ECT);

            // get cardboard id
            KeyValuePair<string, McKeeFormula.QualityData> keyCardboardPair = (KeyValuePair<string, McKeeFormula.QualityData>)cbCardboard.SelectedItem;
            _ectAnalysis.Cardboard = keyCardboardPair.Value;
            // get case type
            KeyValuePair<string, double> caseTypeKeyValue = (KeyValuePair<string, double>)cbCaseType.SelectedItem;
            _ectAnalysis.CaseType = caseTypeKeyValue.Key;
            // get printed surface
            KeyValuePair<string, double> printSurfaceKeyValue = (KeyValuePair<string, double>)cbPrintedSurface.SelectedItem;
            _ectAnalysis.PrintSurface = printSurfaceKeyValue.Key;
            // set improved or not
            _ectAnalysis.UseImprovedFormula =  rbFormula2.Checked;

            lbStaticBCTValue.Text = string.Format("{0:0.00}",_ectAnalysis.StaticBCT);
            // fill dynamic grid
            FillGrid(_ectAnalysis.DynamicBCTDictionary);
        }
        #endregion

        #region Grid
        private void InitializeGrid()
        {
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
            viewColumnHeader.ForeColor = Color.Black;
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;

            // row header view
            SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader backRowHeader = new DevAge.Drawing.VisualElements.RowHeader();
            backRowHeader.BackColor = Color.LightGray;
            backRowHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewRowHeader.Background = backRowHeader;
            viewRowHeader.ForeColor = Color.Black;

            // create the grid
            gridDynamicBCT.BorderStyle = BorderStyle.FixedSingle;

            gridDynamicBCT.ColumnsCount = McKeeFormula.HumidityCoefDictionary.Count + 1;
            gridDynamicBCT.RowsCount = McKeeFormula.StockCoefDictionary.Count + 1;

            // column header
            SourceGrid.Cells.ColumnHeader columnHeader;
            int indexCol = 0;

            columnHeader = new SourceGrid.Cells.ColumnHeader("Humidity (%)/Storage");
            columnHeader.AutomaticSortEnabled = false;
            columnHeader.View = viewColumnHeader;
            gridDynamicBCT[0, indexCol++] = columnHeader;

            foreach (string key in McKeeFormula.HumidityCoefDictionary.Keys)
            {
                columnHeader = new SourceGrid.Cells.ColumnHeader(key);
                columnHeader.AutomaticSortEnabled = false;
                columnHeader.View = viewColumnHeader;
                gridDynamicBCT[0, indexCol++] = columnHeader;
            }

            SourceGrid.Cells.RowHeader rowHeader;
            int indexRow = 1;

            foreach (string key in McKeeFormula.StockCoefDictionary.Keys)
            {
                rowHeader = new SourceGrid.Cells.RowHeader(key);
                rowHeader.View = viewRowHeader;
                gridDynamicBCT[indexRow++, 0] = rowHeader;
            }

            gridDynamicBCT.AutoStretchColumnsToFitWidth = true;
            gridDynamicBCT.AutoSizeCells();
            gridDynamicBCT.Columns.StretchToFit();
        }

        private void FillGrid(Dictionary<KeyValuePair<string, string>, double> dynamicBCTDictionnary)
        {
            int indexCol = 1;

            // views
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkBlue, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
            CellColorFromValue viewNormal = new CellColorFromValue(_ectAnalysis.LoadOnFirstLayerCase * 9.81 / 10); // convert mass in kg to load in daN
            viewNormal.Border = cellBorder;

            foreach (string keyHumidity in McKeeFormula.HumidityCoefDictionary.Keys)
            {
                int indexRow = 1;
                foreach (string keyStorage in McKeeFormula.StockCoefDictionary.Keys)
                {
                    gridDynamicBCT[indexRow, indexCol] = new SourceGrid.Cells.Cell(
                        string.Format("{0:0.00}", dynamicBCTDictionnary[new KeyValuePair<string,string>(keyStorage, keyHumidity)]));
                    gridDynamicBCT[indexRow, indexCol].View = viewNormal;
                    ++indexRow;
                }
                ++indexCol;
            }
            gridDynamicBCT.Invalidate();
        }
        #endregion
    }

    #region CellColorFromValue for grid view
    internal class CellColorFromValue : SourceGrid.Cells.Views.Cell
    {
        #region Data members
        private double _lowestAdmissibleValue;
        private DevAge.Drawing.VisualElements.IVisualElement mCorrectValueBackground;
        private DevAge.Drawing.VisualElements.IVisualElement mInsufficientValueBackground;
        #endregion
        #region Constructor
        public CellColorFromValue(double lowestAdmissibleValue)
        {
            _lowestAdmissibleValue = lowestAdmissibleValue;
            correctValueBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(Color.White);
            insufficientValueBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(Color.Red);
        }
        #endregion
        #region Public properties
        public DevAge.Drawing.VisualElements.IVisualElement correctValueBackground
        {
            get { return mCorrectValueBackground; }
            set { mCorrectValueBackground = value; }
        }
        public DevAge.Drawing.VisualElements.IVisualElement insufficientValueBackground
        {
            get { return mInsufficientValueBackground; }
            set { mInsufficientValueBackground = value; }
        }
        #endregion
        #region SourceGrid.Cells.Views.Cell override
        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);
            string sText = context.DisplayText;
            // sTest might not be a number
            // -> exceptions might be thrown when attempting to parse it
            try
            {
                double doubleValue = double.Parse(sText);
                if (doubleValue < _lowestAdmissibleValue)
                    Background = insufficientValueBackground;
                else
                    Background = correctValueBackground;
            }
            catch (System.Exception /**/)
            {
            }
        }
        #endregion
    }
    #endregion
}
