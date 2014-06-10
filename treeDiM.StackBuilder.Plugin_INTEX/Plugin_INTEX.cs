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
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName))
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
            List<DataItemINTEX> list = null;
            try
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                // load excel file
                if (!ExcelDataReader.ExcelDataReader.LoadIntexFile(dbPath, ref list))
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(
                        string.Format("Failed to load any valid record from file {0}", dbPath)
                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            { _log.Error(ex.Message); }
            finally
            { Cursor.Current = Cursors.Default; }

            // proceed : buid project file
            try
            {
                FormNewINTEX form = new FormNewINTEX();
                form._list = list;
                if (DialogResult.OK != form.ShowDialog())
                    return false;
                // create document
                DataItemINTEX item = form._currentItem;
                Document document = new Document(item._ref, item._description, "INTEX", DateTime.Now, null);
                // create box properties
                Color[] colors = new Color[6];
                for (int i = 0; i < 6; ++i) colors[i] = Color.Chocolate;
                BoxProperties caseProperties = document.CreateNewCase(
                    item._ref
                    , string.Format("{0} / EAN14 : {1} / UPC : {2} / PCB : {3}", item._description, item._gencode, item._UPC, item._PCB)
                    , UnitsManager.ConvertLengthFrom(item._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(item._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(item._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(item._length - 0.6, UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(item._width - 0.6, UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertLengthFrom(item._height - 0.6, UnitsManager.UnitSystem.UNIT_METRIC2)
                    , UnitsManager.ConvertMassFrom(item._weight, UnitsManager.UnitSystem.UNIT_METRIC2)
                    , colors);
                caseProperties.TapeColor = Color.Beige;
                caseProperties.TapeWidth = 5.0;
                caseProperties.ShowTape = true;
                // textures
                string pictoPath = Properties.Settings.Default.TopPictoPath;
                if (File.Exists(pictoPath))
                {
                    // load image
                    Bitmap bmp = new Bitmap(pictoPath);
                    // case dimensions
                    double length = caseProperties.Length;
                    double width = caseProperties.Width;
                    double height = caseProperties.Height;
                    // dimensions and margins
                    double margin = 2;
                    double pictoSize = 10;
                    double minDim = Math.Min(Math.Min(length, width), Math.Min(width, height));
                    if (minDim < pictoSize) { margin = 0.0; pictoSize = minDim; }
                    // top position
                    double topPos = caseProperties.Height - margin - pictoSize;
                    // insert picto as a texture
                    caseProperties.AddTexture(HalfAxis.HAxis.AXIS_X_N
                        , UnitsManager.ConvertLengthFrom(new Vector2D(width - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , 0, bmp);
                    caseProperties.AddTexture(HalfAxis.HAxis.AXIS_X_P
                        , UnitsManager.ConvertLengthFrom(new Vector2D(width - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , 0, bmp);
                    caseProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_N
                        , UnitsManager.ConvertLengthFrom(new Vector2D(length - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , 0, bmp);
                    caseProperties.AddTexture(HalfAxis.HAxis.AXIS_Y_P
                        , UnitsManager.ConvertLengthFrom(new Vector2D(length - margin - pictoSize, topPos), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(new Vector2D(pictoSize, pictoSize), UnitsManager.UnitSystem.UNIT_METRIC2)
                        , 0, bmp);
                }
                // create pallets
                PalletProperties currentPallet = null;
                foreach (PalletINTEX pallet in PalletINTEX.BuildList())
                {
                    PalletProperties palletProperties = document.CreateNewPallet(
                        pallet._name, pallet._name, "EUR"
                        , UnitsManager.ConvertLengthFrom(pallet._length, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(pallet._width, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertLengthFrom(pallet._height, UnitsManager.UnitSystem.UNIT_METRIC2)
                        , UnitsManager.ConvertMassFrom(0.0, UnitsManager.UnitSystem.UNIT_METRIC2));
                    if (string.Equals(form._currentPallet._name, pallet._name))
                        currentPallet = palletProperties;
                }
                // constraint set
                CasePalletConstraintSet constraintSet = new CasePalletConstraintSet();
                constraintSet.UseMaximumHeight = true;
                constraintSet.MaximumHeight = UnitsManager.ConvertLengthFrom(220, UnitsManager.UnitSystem.UNIT_METRIC2);
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
                    CasePalletAnalysis palletAnalysis = document.CreateNewCasePalletAnalysis(item._ref, item.ToString(), caseProperties, currentPallet, null, constraintSet, solver);
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

        #region Logging
        static readonly ILog _log = LogManager.GetLogger(typeof(Plugin_INTEX));
        #endregion
    }
}
