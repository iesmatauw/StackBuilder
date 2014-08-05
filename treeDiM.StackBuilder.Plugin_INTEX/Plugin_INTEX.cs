#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Windows.Forms;
using System.IO;

using log4net;
using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    public class Plugin_INTEX : IPlugin
    {
        #region Implement IPlugin members
        public bool onFileNew(ref string fileName)
        {
            // INTEX data are in cms
            UnitsManager.CurrentUnitSystem = UnitsManager.UnitSystem.UNIT_METRIC2;

            string dbPath = Properties.Settings.Default.DatabasePathINTEX;
            if (string.IsNullOrWhiteSpace(dbPath) || !File.Exists(dbPath))
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.DefaultExt = "xls";
                fd.AddExtension = false;
                fd.Filter = "Microsoft Excel File (*.xls)|*.xls|All files (*.*)|*.*";
                fd.FilterIndex = 0;
                fd.RestoreDirectory = true;
                fd.CheckFileExists = true;
                if (DialogResult.OK != fd.ShowDialog())
                    return false;

                dbPath = fd.FileName;
                Properties.Settings.Default.DatabasePathINTEX = dbPath;
                Properties.Settings.Default.Save();
            }
            // load INTEX excel file
            List<DataItemINTEX> listItems = null;
            List<DataPalletINTEX> listPallets = null;
            List<DataCaseINTEX> listCases = null;
            try
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                // load excel file
                if (!ExcelDataReader.ExcelDataReader.LoadIntexFile(dbPath, ref listItems, ref listPallets, ref listCases))
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(
                        string.Format(Properties.Resources.ID_ERROR_INVALIDFILE, dbPath)
                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                    , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _log.Error(ex.Message);
            }
            finally
            { Cursor.Current = Cursors.Default; }
            // do we have a valid list
            if (null == listItems || 0 == listItems.Count)
                return false;
            // proceed : buid project file
            try
            {
                FormNewINTEX form = new FormNewINTEX();
                form._listItems = listItems;
                form._listPallets = listPallets;
                form._listCases = listCases;
                if (DialogResult.OK != form.ShowDialog())
                    return false;
                // create document
                DataItemINTEX item = form._currentItem;
                Document document = new Document(item._ref, item._description, "INTEX", DateTime.Now, null);
                // create box properties
                Color[] colorsCase = new Color[6];
                Color[] colorsBox = new Color[6];
                for (int i = 0; i < 6; ++i)
                {
                    colorsCase[i] = Color.Chocolate;
                    colorsBox[i] = Color.Turquoise;
                }
                BoxProperties itemProperties = null;
                if (!form.UseIntermediatePacking)
                {
                    itemProperties = document.CreateNewCase(
                        item._ref
                        , string.Format("{0};EAN14 : {1};UPC : {2};PCB : {3}", item._description, item._gencode, item._UPC, item._PCB)
                        , UnitsManager.ConvertLengthFrom(item._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._length - 0.6, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._width - 0.6, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._height - 0.6, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertMassFrom(item._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , colorsCase);
                    itemProperties.ShowTape = true;
                    itemProperties.TapeColor = Color.Beige;
                    itemProperties.TapeWidth = 5.0;
                }
                else
                {
                    itemProperties = document.CreateNewBox(
                        item._ref
                        , string.Format("{0};EAN14 : {1};UPC : {2};PCB : {3}", item._description, item._gencode, item._UPC, item._PCB)
                        , UnitsManager.ConvertLengthFrom(item._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(item._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertMassFrom(item._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , colorsBox);
                    itemProperties.ShowTape = false;
                }

                if (!form.UseIntermediatePacking)
                    InsertPictogram(ref itemProperties);

                BoxProperties currentCase = null;
                if (form.UseIntermediatePacking)
                { 
                    // create cases
                    foreach (DataCaseINTEX dataCase in listCases)
                    {
                        double lengthInt = dataCase._lengthInt > 0 ? dataCase._lengthInt : dataCase._lengthExt - 2* form.DefaultCaseThickness;
                        double widthInt = dataCase._widthInt > 0 ? dataCase._widthInt : dataCase._widthExt - 2 * form.DefaultCaseThickness;
                        double heightInt = dataCase._heightInt > 0 ? dataCase._heightInt : dataCase._heightExt - 2 * form.DefaultCaseThickness;

                        BoxProperties intercaseProperties = document.CreateNewCase(
                            dataCase._ref
                            , string.Format("{0}*{1}*{2}", dataCase._lengthExt, dataCase._widthExt, dataCase._heightExt)
                            , UnitsManager.ConvertLengthFrom(dataCase._lengthExt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(dataCase._widthExt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(dataCase._heightExt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(lengthInt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(widthInt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertLengthFrom(heightInt, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , UnitsManager.ConvertMassFrom(dataCase._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                            , colorsCase);
                        intercaseProperties.ShowTape = true;
                        intercaseProperties.TapeColor = Color.Beige;
                        intercaseProperties.TapeWidth = 5.0;

                        // textures
                        InsertPictogram(ref intercaseProperties);

                        if (string.Equals( form._currentCase._ref, intercaseProperties.Name))
                            currentCase = intercaseProperties;
                    }
                }

                if (form.UseIntermediatePacking)
                { 
                    // Case constraint set
                    BoxCaseConstraintSet boxCaseConstraintSet = new BoxCaseConstraintSet();
                    boxCaseConstraintSet.SetAllowedOrthoAxisAll();
                    if (boxCaseConstraintSet.IsValid)
                    {
                        // create case analysis
                        BoxCaseAnalysis analysis = document.CreateNewBoxCaseAnalysis(
                            string.Format(Properties.Resources.ID_PACKING, item._ref)
                            , item._description
                            , itemProperties
                            , currentCase
                            , boxCaseConstraintSet
                            , new BoxCaseSolver());
                    }
                }

                // create pallets
                PalletProperties currentPallet = null;
                foreach (DataPalletINTEX pallet in listPallets)
                {
                    PalletProperties palletProperties = document.CreateNewPallet(
                        pallet._type, pallet._type, "EUR"
                        , UnitsManager.ConvertLengthFrom(pallet._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(pallet._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(pallet._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertMassFrom(pallet._weight, UnitsManager.UnitSystem.UNIT_METRIC2));
                    if (string.Equals(form._currentPallet._type, pallet._type))
                        currentPallet = palletProperties;
                }

                // *** pallet analysis ***
                // constraint set
                CasePalletConstraintSet constraintSet = new CasePalletConstraintSet();
                constraintSet.UseMaximumHeight = true;
                constraintSet.MaximumHeight = UnitsManager.ConvertLengthFrom(form.PalletHeight, UnitsManager.UnitSystem.UNIT_METRIC2);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, true);
                constraintSet.AllowAlignedLayers = true;
                constraintSet.AllowAlternateLayers = true;
                constraintSet.SetAllowedPattern("Column");
                constraintSet.SetAllowedPattern("Diagonale");
                constraintSet.SetAllowedPattern("Interlocked");
                constraintSet.SetAllowedPattern("Trilock");
                constraintSet.SetAllowedPattern("Spirale");
                constraintSet.SetAllowedPattern("Enlarged spirale");
                if (constraintSet.IsValid)
                {
                    // create analysis
                    CasePalletSolver solver = new CasePalletSolver();
                    CasePalletAnalysis palletAnalysis = document.CreateNewCasePalletAnalysis(item._ref, item.ToString()
                        , form.UseIntermediatePacking ? currentCase : itemProperties
                        , currentPallet, null, constraintSet, solver);
                }
                // save document
                fileName = form.FilePath;
                document.Write(form.FilePath);
                // return true to let application open
                return File.Exists(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        #region Insert pictogram
        private void InsertPictogram(ref BoxProperties boxProperties)
        {
            string pictoPath = Properties.Settings.Default.pictoTOP;
            if (File.Exists(pictoPath))
            {
                // load image
                Bitmap bmp = new Bitmap(pictoPath);
                // case dimensions
                double length = boxProperties.Length;
                double width = boxProperties.Width;
                double height = boxProperties.Height;
                // dimensions and margins
                double margin = 2;
                double pictoSize = 10;
                double minDim = Math.Min(Math.Min(length, width), Math.Min(width, height));
                if (minDim < pictoSize) { margin = 0.0; pictoSize = minDim; }
                // top position
                double topPos = boxProperties.Height - margin - pictoSize;
                // insert picto as a texture
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_N
                    , UnitsManager.ConvertLengthFrom(new Vector2D(width - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_X_P
                    , UnitsManager.ConvertLengthFrom(new Vector2D(width - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_N
                    , UnitsManager.ConvertLengthFrom(new Vector2D(length - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
                boxProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_P
                    , UnitsManager.ConvertLengthFrom(new Vector2D(length - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                    , 0, bmp);
            }
        }
        #endregion

        #region Logging
        static readonly ILog _log = LogManager.GetLogger(typeof(Plugin_INTEX));
        #endregion
    }
}
