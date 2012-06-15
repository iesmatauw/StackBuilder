#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Drawing;
using System.Diagnostics;

// logging
using log4net;
using log4net.Config;

// sharp3D
using Sharp3D.Math.Core;

// stackbuilder
using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Graphics;

// properties
using TreeDim.StackBuilder.XmlFileProcessor.Properties;

// reporting
using TreeDim.StackBuilder.Reporting;
#endregion

namespace TreeDim.StackBuilder.XmlFileProcessor
{
    public class XmlFileLoader
    {
        #region Data members
        private STACKBUILDER _root;
        private ILog _log;
        private bool _success = true;
        #endregion

        #region Constructor
        public XmlFileLoader(string filePath)
        {
            // logging
            _log = LogManager.GetLogger(typeof(XmlFileLoader));
            XmlConfigurator.Configure();

            // check if file exists
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("File {0} not found", filePath), filePath);

            // validate file against schema
            if (Settings.Default.ValidateInputFile && !Validate(filePath))
                throw new XmlFileProcessorException(string.Format("File {0} failed to Validate", filePath));

            // load file using automatically generated classes
            _root = STACKBUILDER.LoadFromFile(filePath);
        }
        #endregion

        #region Validation
        private bool Validate(string infile)
        {
            _success = true;
            try
            {
                // build path to schema
                string schemaPath = Settings.Default.XmlSchemaFilePath;
                // check file existence
                if (!File.Exists(schemaPath))
                    throw new XmlFileProcessorException(string.Format("Schema file {0} could not be found!", schemaPath));
                // build schema set
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add("http://www.treedim.com/StackBuilderSchema.xsd", schemaPath);
                // build reader settings
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = schemas;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
                // create a validating reader.
                XmlReader vreader = XmlReader.Create(infile, settings);
                // set the validation event handler
                // read and validate the XML data.
                while (vreader.Read()) { }
            }
            catch (XmlException XmlExp)
            {
                _log.Error(XmlExp.Message);
                _success = false;
            }
            catch (XmlSchemaException XmlSchExp)
            {
                _log.Error(XmlSchExp.Message);
                _success = false;
            }
            catch (Exception GenExp)
            {
                _log.Error(GenExp.Message);
                _success = false;
            }
            finally
            {
            }
            return _success;
        }
        private void ValidationCallback(Object sender, ValidationEventArgs args)
        {
            _log.Error(args.Message);
            _success = false;
        }
        #endregion

        #region File processing
        public void Process()
        {
            foreach (viewItem vItem in _root.output.viewItem)
            {
                try { ProcessViewItem(vItem); }
                catch (Exception ex) { _log.Error(ex.ToString()); }
            }
            foreach (analysisSolutionList solutionList in _root.output.analysisSolutionList)
            {
                try { ProcessAnalysisSolutionList(solutionList); }
                catch (Exception ex) { _log.Error(ex.ToString()); }
            }
            foreach (viewSolution vSolution in _root.output.viewSolution)
            {
                try { ProcessViewSolution(vSolution); }
                catch (Exception ex) { _log.Error(ex.ToString()); }
            }
            foreach (reportSolution rSolution in _root.output.reportSolution)
            {
                try { ProcessReportSolution(rSolution); }
                catch (Exception ex) { _log.Error(ex.ToString()); }
            }
            foreach (genDocument doc in _root.output.genDocument)
            {
                try { ProcessDocument(doc); }
                catch (Exception ex) { _log.Error(ex.ToString()); }
            }
        }
        private void ProcessViewItem(viewItem vItem)
        {
            Graphics3DImage graphics = InitializeImageFromViewParameters(vItem.viewParameters);
            // load case
            BoxProperties bProperties = LoadCaseById(null, _root.data.items.library_cases, vItem.itemId);
            if (null != bProperties)
            {
                graphics.AddBox(new Box(0, bProperties));
                if (vItem.viewParameters.showDimensions)
                    graphics.AddDimensions(new DimensionCube(bProperties.Length, bProperties.Width, bProperties.Height));

            }
            // load pallet
            PalletProperties palletProperties = LoadPalletById(null, _root.data.items.library_pallets, vItem.itemId);
            if (null != palletProperties)
            {
                Pallet pallet = new Pallet(palletProperties);
                pallet.Draw(graphics, Transform3D.Identity);
                if (vItem.viewParameters.showDimensions)
                    graphics.AddDimensions(new DimensionCube(palletProperties.Length, palletProperties.Width, palletProperties.Height));
            }
            // load interlayer
            InterlayerProperties interlayerProperties = LoadInterlayerById(null, _root.data.items.library_interlayers, vItem.itemId);
            if (null != interlayerProperties)
            {
                graphics.AddBox(new Box(0, interlayerProperties));
                if (vItem.viewParameters.showDimensions)
                    graphics.AddDimensions(new DimensionCube(interlayerProperties.Length, interlayerProperties.Width, interlayerProperties.Thickness));
            }
            // load bundle
            BundleProperties bundleProperties = LoadBundleById(null, _root.data.items.library_bundles, vItem.itemId);
            if (null != bundleProperties)
            {
                graphics.AddBox(new Box(0, bundleProperties));
                if (vItem.viewParameters.showDimensions)
                    graphics.AddDimensions(new DimensionCube(bundleProperties.Length, bundleProperties.Width, bundleProperties.Height));
            }
            // load truck
            TruckProperties truckProperties = null;
            if (null != truckProperties)
            {
                Truck truck = new Truck(truckProperties);
                truck.Draw(graphics);
                if (vItem.viewParameters.showDimensions)
                    graphics.AddDimensions(new DimensionCube(truckProperties.Length, truckProperties.Width, truckProperties.Height));
            }

            FinalizeImageFromViewParameters(vItem.viewParameters, graphics);
        }


        private void ProcessViewSolution(viewSolution vSol)
        {
            // instantiate graphics
            Graphics3DImage graphics = InitializeImageFromViewParameters(vSol.viewParameters);
            // load analysis
            PalletAnalysis analysis = LoadPalletAnalysis(null, vSol.solutionRef.analysisId);
            // compute solutions
            TreeDim.StackBuilder.Engine.Solver solver = new TreeDim.StackBuilder.Engine.Solver();
            solver.ProcessAnalysis(analysis);
            // retrieve wanted solution
            List<Basics.PalletSolution> solutions = analysis.Solutions;
            if (vSol.solutionRef.index >= solutions.Count)
                throw new Exception(string.Format("Analysis {0} has no solution with index {1}", analysis.Name, vSol.solutionRef.index));
            Basics.PalletSolution sol = solutions[(int)vSol.solutionRef.index];
            // display solution
            SolutionViewer solViewer = new SolutionViewer(sol);
            solViewer.Draw(graphics);
            FinalizeImageFromViewParameters(vSol.viewParameters, graphics);
        }

        private void ProcessAnalysisSolutionList(analysisSolutionList solutionList)
        {
            // load analysis
            PalletAnalysis analysis = LoadPalletAnalysis(null, solutionList.analysisId);
            if (solutionList.maxNumberOfSolutionsSpecified)
                analysis.ConstraintSet.NumberOfSolutionsKept = (int)solutionList.maxNumberOfSolutions;
            // compute solutions
            TreeDim.StackBuilder.Engine.Solver solver = new TreeDim.StackBuilder.Engine.Solver();
            solver.ProcessAnalysis(analysis);
            // instantiate pallet solution list
            PALLETSOLUTIONLIST palletSolutionList = new PALLETSOLUTIONLIST();
            // saves solutions to list
            foreach (PalletSolution sol in analysis.Solutions)
            {
                palletSolution xmlPalletSol = new palletSolution();
                xmlPalletSol.title = sol.Title;
                xmlPalletSol.caseCount = sol.CaseCount;
                xmlPalletSol.efficiency = sol.VolumeEfficiencyCases;
                xmlPalletSol.weight = sol.PalletWeight;
                xmlPalletSol.palletDimensions.Add(sol.PalletLength);
                xmlPalletSol.palletDimensions.Add(sol.PalletWidth);
                xmlPalletSol.palletDimensions.Add(sol.PalletHeight);
                xmlPalletSol.homogeneousLayer = sol.HasHomogeneousLayers;

                palletSolutionList.palletSolution.Add(xmlPalletSol);
            }

            palletSolutionList.SaveToFile(solutionList.path);
        }

        private void ProcessReportSolution(reportSolution rSol)
        {
            // create document
            Document doc = new Document(rSol.reportParameters.name, rSol.reportParameters.description, rSol.reportParameters.author, DateTime.Now, null);
            // load analysis
            PalletAnalysis analysis = LoadPalletAnalysis(doc, rSol.solutionRef.analysisId);
            if (null == analysis)
                return;
            // compute solutions
            TreeDim.StackBuilder.Engine.Solver solver = new TreeDim.StackBuilder.Engine.Solver();
            solver.ProcessAnalysis(analysis);
            // retrieve wanted solution
            List<Basics.PalletSolution> solutions = analysis.Solutions;
            if (rSol.solutionRef.index >= solutions.Count)
                throw new Exception(string.Format("Analysis {0} has no solution with index {1}", analysis.Name, rSol.solutionRef.index));
            Basics.PalletSolution sol = solutions[(int)rSol.solutionRef.index];
            // selected solution
            SelSolution selSolution = new SelSolution(doc, analysis, sol);
            // generate report
            ReporterMSWord reporter = new ReporterMSWord();
            reporter.BuildAnalysisReport(new ReportData(analysis, selSolution), rSol.reportParameters.templateDir, rSol.reportParameters.outputPath);
        }

        private void ProcessDocument(genDocument genDoc)
        { 
            // create document
            Document document = new Document(genDoc.name, genDoc.description, genDoc.author, DateTime.Now, null);

            foreach (analysisRef aRef in genDoc.analysisRef)
            {
                // get analysis
                PalletAnalysis analysis = LoadPalletAnalysis(document, aRef.analysisId);
                // load case if any
                // load bundle if any
                // load pallet
                // load interlayer if any
                // load pallet analysis
            }
            // save document
            document.Write(genDoc.path);
            // open generated document using TreeDim.StackBuilder.Desktop
            if (genDoc.open)
            { 
                // build start info
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TreeDim.StackBuilder.Desktop.exe");
                startInfo.Arguments = "\"" + genDoc.path + "\"";
                System.Diagnostics.Process.Start(startInfo);
            }
        }

        private Graphics3DImage InitializeImageFromViewParameters(viewParameters vParam)
        {
            long[] iSize = vParam.imageSize.ToArray();
            Graphics3DImage graphics = new Graphics3DImage(new Size((int)iSize[0], (int)iSize[1]));
            if (vParam.predefinedPointOfViewSpecified)
            {
                switch (vParam.predefinedPointOfView)
                {
                    case pointOfViewValue.CORNER0: graphics.CameraPosition = Graphics3D.Corner_0; break;
                    case pointOfViewValue.CORNER1: graphics.CameraPosition = Graphics3D.Corner_90; break;
                    case pointOfViewValue.CORNER2: graphics.CameraPosition = Graphics3D.Corner_180; break;
                    case pointOfViewValue.CORNER3: graphics.CameraPosition = Graphics3D.Corner_270; break;
                    case pointOfViewValue.FRONT: graphics.CameraPosition = Graphics3D.Front; break;
                    case pointOfViewValue.BACK: graphics.CameraPosition = Graphics3D.Back; break;
                    case pointOfViewValue.LEFT: graphics.CameraPosition = Graphics3D.Left; break;
                    case pointOfViewValue.RIGHT: graphics.CameraPosition = Graphics3D.Right; break;
                    case pointOfViewValue.TOP: graphics.CameraPosition = Graphics3D.Top; break;
                    default: break;
                }
            }
            return graphics;
        }

        private void FinalizeImageFromViewParameters(viewParameters vParam, Graphics3DImage graphics)
        {
            graphics.Flush();

            // check that directory exists
            if (!Directory.Exists(Path.GetDirectoryName(vParam.path)))
                throw new Exception(string.Format("Directory {0} does not exist! Can not generate output file!", Path.GetDirectoryName(vParam.path)));

            graphics.SaveAs(vParam.path);
            _log.Info(string.Format("Successfully saved file {0}", vParam.path));
        }
        #endregion

        #region Loading case / pallet / interlayer / analysis
        private static BoxProperties LoadCaseById(Document doc, List<@case> listCase, string sid)
        {
            @case caseItem = listCase.Find(delegate(@case c) { return c.id == sid; });
            if (null == caseItem)
                return null;
            else
            {
                double[] outerLength = caseItem.outerdimensions.ToArray();
                double[] insideLength = caseItem.innerDimensions.ToArray();
                // instantiate BoxProperties
                BoxProperties bProperties = new BoxProperties(doc, outerLength[0], outerLength[1], outerLength[2], insideLength[0], insideLength[1], insideLength[2]);
                // name
                bProperties.Name = caseItem.name;
                // description
                bProperties.Description = caseItem.description;
                // face colors
                foreach (FaceColor fc in caseItem.FaceColors)
                {
                    System.Drawing.Color color = System.Drawing.Color.FromArgb((int)fc.color[0], (int)fc.color[1], (int)fc.color[2], (int)fc.color[3]);
                    switch (fc.FaceNormal)
                    {
                        case AxisDir.XN: bProperties.SetColor(HalfAxis.HAxis.AXIS_X_N, color); break;
                        case AxisDir.XP: bProperties.SetColor(HalfAxis.HAxis.AXIS_X_P, color); break;
                        case AxisDir.YN: bProperties.SetColor(HalfAxis.HAxis.AXIS_Y_N, color); break;
                        case AxisDir.YP: bProperties.SetColor(HalfAxis.HAxis.AXIS_Y_P, color); break;
                        case AxisDir.ZN: bProperties.SetColor(HalfAxis.HAxis.AXIS_Z_N, color); break;
                        case AxisDir.ZP: bProperties.SetColor(HalfAxis.HAxis.AXIS_Z_P, color); break;
                        default: break;
                    }
                }
                // face textures
                // weight
                bProperties.Weight = caseItem.weight;
                // insert in list
                if (null != doc)
                    doc.AddType(bProperties);
                return bProperties;
            }
        }

        private static BundleProperties LoadBundleById(Document doc, List<bundle> listBundles, string sid)
        {
            bundle bundleItem = listBundles.Find(delegate(bundle b) { return b.id == sid; });
            if (null == bundleItem)
                return null;
            else
            {
                double[] bundleDim = bundleItem.flatDimensions.ToArray();
                // instantiate bundle
                BundleProperties bundleProperties = new BundleProperties(
                    doc, bundleItem.name, bundleItem.description
                    , bundleDim[0], bundleDim[1], bundleDim[2]
                    , bundleItem.flatWeight, (int)bundleItem.numberFlats
                    , System.Drawing.Color.FromArgb((int)bundleItem.color[0], (int)bundleItem.color[1], (int)bundleItem.color[2]));
                // insert in list
                if (null != doc)
                    doc.AddType(bundleProperties);
                return bundleProperties;
            }
        }

        private static PalletProperties LoadPalletById(Document doc, List<pallet> listPallet, string sid)
        {
            pallet palletItem = listPallet.Find(delegate(pallet p) { return p.id == sid; });
            if (null == palletItem)
                return null;
            else
            {
                // dimensions
                double[] dimensions = palletItem.dimensions.ToArray();
                // type
                string typeName = string.Empty;
                switch (palletItem.type)
                {
                    case palletType.BLOCK: typeName = "BLOCK"; break;
                    case palletType.EUR: typeName = "EUR"; break;
                    case palletType.EUR2: typeName = "EUR2"; break;
                    case palletType.EUR3: typeName = "EUR3"; break;
                    case palletType.EUR6: typeName = "EUR6"; break;
                    case palletType.GMA: typeName = "GMA"; break;
                    case palletType.STANDARD_UK: typeName = "STANDARD_UK"; break;
                    default:
                        throw new Exception("Pallet with id = {0} has an unknown pallet type");
                }
                // instantiate pallet properties
                PalletProperties palletProperties = new PalletProperties(doc, typeName, dimensions[0], dimensions[1], dimensions[2]);
                // name
                palletProperties.Name = palletItem.name;
                // description
                palletProperties.Description = palletItem.description;
                // color
                palletProperties.Color = System.Drawing.Color.FromArgb((int)palletItem.color[0], (int)palletItem.color[1], (int)palletItem.color[2], (int)palletItem.color[3]);
                // weight
                palletProperties.Weight = palletItem.weight;
                // insert in list
                if (null != doc)
                    doc.AddType(palletProperties);

                return palletProperties;
            }
        }

        private static InterlayerProperties LoadInterlayerById(Document doc, List<interlayer> listInterlayer, string sid)
        {
            interlayer interlayerItem = listInterlayer.Find(delegate(interlayer i) { return i.id == sid; });
            if (null == interlayerItem)
                return null;
            else
            {
                // dimensions
                double[] dimensions = interlayerItem.dimensions.ToArray();
                // instantiate interlayer properties
                InterlayerProperties interlayerProperties = new InterlayerProperties(
                    doc
                    , interlayerItem.name
                    , interlayerItem.description
                    , dimensions[0], dimensions[1], dimensions[2]
                    , interlayerItem.weight
                    , Color.FromArgb((int)interlayerItem.color[0], (int)interlayerItem.color[1], (int)interlayerItem.color[2], (int)interlayerItem.color[3])
                    );
                // insert in list
                if (null != doc)
                    doc.AddType(interlayerProperties);

                return interlayerProperties;
            }
        }

        private PalletAnalysis LoadPalletAnalysis(Document doc, string sid)
        {
            PalletAnalysis analysis = null;

            palletAnalysis xmlAnalysis = _root.data.analyses.palletAnalysis.Find(delegate(palletAnalysis pa) { return pa.id == sid; });
            if (null == xmlAnalysis)
                throw new XmlFileProcessorException(string.Format("Failed to load analysis with Id = {0}", xmlAnalysis.id));

            BoxProperties caseProperties = LoadCaseById(doc, _root.data.items.library_cases, xmlAnalysis.caseId);
            BundleProperties bundleProperties = LoadBundleById(doc, _root.data.items.library_bundles, xmlAnalysis.bundleId);

            BProperties bProperties;
            PalletConstraintSet constraintSet;

            if (null != caseProperties)
            {
                PalletConstraintSetBox caseConstraintSet = new PalletConstraintSetBox();
                // interlayer
                caseConstraintSet.HasInterlayer = xmlAnalysis.interlayerPeriodSpecified;
 
                // allowed ortho axes
                caseConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, true);
                caseConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, true);
                caseConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, true);
                caseConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, true);
                caseConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, true);
                caseConstraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, true);

                // interlayer period
                caseConstraintSet.InterlayerPeriod = xmlAnalysis.interlayerPeriodSpecified ? (int)xmlAnalysis.interlayerPeriod : 1;

                bProperties = caseProperties;
                constraintSet = caseConstraintSet;
            }
            else if (null != bundleProperties)
            {
                PalletConstraintSetBundle bundleConstraintSet = new PalletConstraintSetBundle();

                bProperties = bundleProperties;
                constraintSet = bundleConstraintSet;
            }
            else
                throw new XmlFileProcessorException(string.Format("Failed to load analysis with Id = {0}", xmlAnalysis.id));

           // generic constraintSet properties
           // allow aligned / alternate layers
            constraintSet.AllowAlignedLayers = false;
            constraintSet.AllowAlternateLayers = false;
            foreach (LayerArrangement layerArr in xmlAnalysis.allowedLayerArrangements)
            {
                if (layerArr == LayerArrangement.ALIGNED)
                    constraintSet.AllowAlignedLayers = true;
                if (layerArr == LayerArrangement.ROTATED180 | layerArr == LayerArrangement.ROTATED90)
                    constraintSet.AllowAlternateLayers = true;
            }
            // allowed patterns
            foreach (PatternName patternName in xmlAnalysis.allowedLayerPatterns)
            {
                switch (patternName)
                {
                    case PatternName.COLUMN: constraintSet.SetAllowedPattern("Column"); break;
                    case PatternName.DIAGONAL: constraintSet.SetAllowedPattern("Diagonal"); break;
                    case PatternName.INTERLOCK: constraintSet.SetAllowedPattern("Interlock"); break;
                    case PatternName.TRILOCK: constraintSet.SetAllowedPattern("Trilock"); break;
                    case PatternName.SPIRAL: constraintSet.SetAllowedPattern("Spiral"); break;
                    case PatternName.ENLARGED_SPIRAL: constraintSet.SetAllowedPattern("Enlarged spiral"); break;
                    default: break;
                }
            }
            // overhang
            constraintSet.OverhangX = xmlAnalysis.overhang[0];
            constraintSet.OverhangY = xmlAnalysis.overhang[1];

            // stop criterions
            // max height
            if (xmlAnalysis.stackingStopCriterions.stopMaxHeight.maxHeightSpecified)
            {
                constraintSet.UseMaximumHeight = true;
                constraintSet.MaximumHeight = xmlAnalysis.stackingStopCriterions.stopMaxHeight.maxHeight;
            }
            else
                constraintSet.UseMaximumHeight = false;
            // max weight
            if (xmlAnalysis.stackingStopCriterions.stopMaxWeight.maxWeightSpecified)
            {
                constraintSet.UseMaximumPalletWeight = true;
                constraintSet.MaximumPalletWeight = xmlAnalysis.stackingStopCriterions.stopMaxWeight.maxWeight;
            }
            else
                constraintSet.UseMaximumPalletWeight = false;
            // max number of box/bundle
            if (xmlAnalysis.stackingStopCriterions.stopMaxNumber.maxNumberSpecified)
            {
                constraintSet.UseMaximumNumberOfCases = true;
                constraintSet.MaximumNumberOfItems = (int)xmlAnalysis.stackingStopCriterions.stopMaxNumber.maxNumber;
            }
            else
                constraintSet.UseMaximumNumberOfCases = false;
            // max weight on case
            if (xmlAnalysis.stackingStopCriterions.stopMaxWeightOnCase.maxWeightOnCaseSpecified)
            {
                constraintSet.UseMaximumWeightOnBox = true;
                constraintSet.MaximumWeightOnBox = xmlAnalysis.stackingStopCriterions.stopMaxWeightOnCase.maxWeightOnCase;
            }
            else
                constraintSet.UseMaximumWeightOnBox = false;

            if (null != doc)
            {
                analysis = doc.CreateNewAnalysis(xmlAnalysis.name, xmlAnalysis.description
                    , bProperties
                    , LoadPalletById(doc, _root.data.items.library_pallets, xmlAnalysis.palletId)
                    , LoadInterlayerById(doc, _root.data.items.library_interlayers, xmlAnalysis.interlayerId)
                    , constraintSet
                    , new TreeDim.StackBuilder.Engine.Solver());
            }
            else
            {
                // instantiate pallet analysis
                analysis = new PalletAnalysis(
                    bProperties
                    , LoadPalletById(null, _root.data.items.library_pallets, xmlAnalysis.palletId)
                    , LoadInterlayerById(null, _root.data.items.library_interlayers, xmlAnalysis.interlayerId)
                    , constraintSet);
                // name
                analysis.Name = xmlAnalysis.name;
                // description
                analysis.Description = xmlAnalysis.description;
            }
            return analysis;
        }
        #endregion
    }
}
