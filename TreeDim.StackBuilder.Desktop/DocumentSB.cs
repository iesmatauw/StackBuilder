#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
using TreeDim.StackBuilder.Reporting;
#endregion

namespace TreeDim.StackBuilder.Desktop
{
    public class DocumentSB : Document, IDocument
    {
        #region Data members
        private string _filePath;
        private bool _dirty = false;
        private List<IView> _views = new List<IView>();
        private IView _activeView;
        public event EventHandler Modified;
        #endregion

        #region Constructor
        public DocumentSB(string filePath, IDocumentListener listener)
            :base(filePath, listener)
        {
            _filePath = filePath;
            _dirty = false;
        }
        public DocumentSB(string name, string description, string author, IDocumentListener listener)
            : base(name, description, author, DateTime.Now, listener)
        {
            _dirty = false;
        }
        #endregion

        #region Public properties
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        #endregion

        #region IDocument implementation
        public bool IsDirty { get { return _dirty; } }
        public bool IsNew { get { return string.IsNullOrEmpty(_filePath); } }
        public bool HasValidPath  {   get { return System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(_filePath)); } }
        public void Save()
        {
            if (IsNew) return;
            if (!HasValidPath)
                throw new System.IO.DirectoryNotFoundException(
                    string.Format("Directory {0} could not be found!", System.IO.Path.GetDirectoryName(_filePath))
                    );
            Write(_filePath);
            _dirty = false;
        }

        public void SaveAs(string filePath)
        {
            _filePath = filePath;
            Save();
        }

        public void Close(CancelEventArgs e)
        {
            while (_views.Count > 0)
                RemoveView(_views[0]);
            base.Close();
        }

        public override void Modify()
        {
            _dirty = true;
            if (null != Modified)
                Modified(this, new EventArgs());
        }

        public List<IView> Views { get { return _views; } }

        public IView ActiveView
        {
            set
            {
                _activeView = value;
                _activeView.Activate();
            }
            get
            {
                return _activeView;
            }
        }

        public void AddView(IView view)
        {
            _views.Add(view);
        }

        public void RemoveView(IView view)
        {
            // remove from list of attached views
            _views.Remove(view);
        }
        #endregion

        #region View creation methods
        /// <summary>
        /// Creates new DockContentAnalysis view
        /// </summary>
        /// <param name="analysis"></param>
        /// <returns></returns>
        public DockContentAnalysis CreateAnalysisView(PalletAnalysis analysis)
        {
            DockContentAnalysis form = new DockContentAnalysis(this, analysis);
            AddView(form);
            return form;
        }
        /// <summary>
        /// Creates new DockContentAnalysis view
        /// </summary>
        /// <param name="analysis"></param>
        /// <returns></returns>
        public DockContentAnalysisCaseOfBoxes CreateAnalysisViewCaseOfBoxes(PalletAnalysis analysis)
        {
            DockContentAnalysisCaseOfBoxes form = new DockContentAnalysisCaseOfBoxes(this, analysis);
            AddView(form);
            return form;
        }
        /// <summary>
        /// Creates a new DockContentTruckAnalysis view
        /// </summary>
        /// <param name="analysis"></param>
        /// <returns></returns>
        public DockContentTruckAnalysis CreateTruckAnalysisView(TruckAnalysis analysis)
        {
            DockContentTruckAnalysis form = new DockContentTruckAnalysis(this, analysis);
            AddView(form);
            return form;
        }
        /// <summary>
        /// Creates a new DockContentECTAnalysis view
        /// </summary>
        public DockContentECTAnalysis CreateECTAnalysisView(ECTAnalysis analysis)
        {
            DockContentECTAnalysis form = new DockContentECTAnalysis(this, analysis);
            AddView(form);
            return form;
        }
        /// <summary>
        /// Creates new case analysis view
        /// </summary>
        /// <param name="analysis"></param>
        /// <returns></returns>
        public DockContentCaseAnalysis CreateCaseAnalysisView(CaseAnalysis analysis)
        {
            DockContentCaseAnalysis form = new DockContentCaseAnalysis(this, analysis);
            AddView(form);
            return form;
        }

        public DockContentReport CreateReportHtml(ReportData reportObject, string htmlFilePath)
        {
            DockContentReport form = new DockContentReport(this, reportObject, htmlFilePath);
            AddView(form);
            return form;
        }
        #endregion

        #region UI item creation
        /// <summary>
        /// Creates a new BoxProperties object
        /// </summary>
        public void CreateNewBoxUI()
        {
            FormNewBox form = new FormNewBox(this, FormNewBox.Mode.MODE_BOX);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewBox(form.BoxName, form.Description
                    , form.BoxLength, form.BoxWidth, form.BoxHeight
                    , form.Weight, form.Colors);
        }
        /// <summary>
        /// Creates a new 
        /// </summary>
        public void CreateNewCaseUI()
        {
            FormNewBox form = new FormNewBox(this, FormNewBox.Mode.MODE_CASE);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewCase(form.BoxName, form.Description
                    , form.BoxLength, form.BoxWidth, form.BoxHeight
                    , form.InsideLength, form.InsideWidth, form.InsideHeight
                    , form.Weight, form.Colors);
        }
        /// <summary>
        /// Creates a new BundleProperties object
        /// </summary>
        public void CreateNewBundleUI()
        { 
            FormNewBundle form = new FormNewBundle(this);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewBundle(
                    form.BundleName, form.Description
                    , form.BundleLength, form.BundleWidth, form.UnitThickness
                    , form.UnitWeight
                    , form.Color
                    , form.NoFlats);
        }
        /// <summary>
        /// Creates a new InterlayerProperties object
        /// </summary>
        public void CreateNewInterlayerUI()
        { 
            FormNewInterlayer form = new FormNewInterlayer(this);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewInterlayer(
                    form.InterlayerName, form.Description
                    , form.InterlayerLength, form.InterlayerWidth, form.Thickness
                    , form.Weight
                    , form.Color);
        }
        /// <summary>
        /// creates a new PalletProperties object
        /// </summary>
        public void CreateNewPalletUI()
        {        
            FormNewPallet form = new FormNewPallet(this);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewPallet(form.PalletName, form.Description, form.PalletTypeName
                    , form.PalletLength, form.PalletWidth, form.PalletHeight
                    , form.Weight);
        }
        /// <summary>
        /// Creates a new TruckProperties
        /// </summary>
        public void CreateNewTruckUI()
        {
            FormNewTruck form = new FormNewTruck(this);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewTruck(form.TruckName, form.Description
                    , form.TruckLength, form.TruckWidth, form.TruckHeight
                    , form.TruckAdmissibleLoadWeight
                    , form.TruckColor);
        }
        /// <summary>
        /// Creates a new palet analysis
        /// </summary>
        /// <returns>created palet analysis</returns>
        public PalletAnalysis CreateNewAnalysisUI()
        {
            if (!CanCreatePalletAnalysis) return null;

            FormNewAnalysis form = new FormNewAnalysis(this);
            form.Cases = Cases.ToArray();
            form.Pallets = Pallets.ToArray();
            form.Interlayers = Interlayers.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                // build constraint set
                PalletConstraintSetBox constraintSet = new PalletConstraintSetBox();
                // overhang / underhang
                constraintSet.OverhangX = form.OverhangX;
                constraintSet.OverhangY = form.OverhangY;
                // allowed axes
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, form.AllowVerticalZ);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, form.AllowVerticalZ);
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
                constraintSet.UseMaximumNumberOfCases = form.UseMaximumNumberOfBoxes;
                constraintSet.UseMaximumPalletWeight = form.UseMaximumPalletWeight;
                constraintSet.UseMaximumWeightOnBox = form.UseMaximumLoadOnBox;
                constraintSet.MaximumHeight = form.MaximumPalletHeight;
                constraintSet.MaximumNumberOfItems = form.MaximumNumberOfBoxes;
                constraintSet.MaximumPalletWeight = form.MaximumPalletWeight;
                constraintSet.MaximumWeightOnBox = form.MaximumLoadOnBox;
                // number of solution kept
                constraintSet.UseNumberOfSolutionsKept = form.UseNumberOfSolutionsKept;
                if (form.UseNumberOfSolutionsKept)
                    constraintSet.NumberOfSolutionsKept = form.NumberOfSolutionsKept;

                return CreateNewAnalysis(
                    form.AnalysisName, form.AnalysisDescription,
                    form.SelectedBox, form.SelectedPallet, form.SelectedInterlayer
                    , constraintSet
                    , new Solver());
            }
            return null;
        }
        /// <summary>
        /// Creates a new bundle analysis
        /// </summary>
        /// <returns>created bundle analysis</returns>
        public PalletAnalysis CreateNewAnalysisBundleUI()
        {
            FormNewAnalysisBundle form = new FormNewAnalysisBundle(this);
            form.Boxes = Bundles.ToArray();
            form.Pallets = Pallets.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                // build constraintSet
                PalletConstraintSetBundle constraintSet = new PalletConstraintSetBundle();
                // overhang / underhang
                constraintSet.OverhangX = form.OverhangX;
                constraintSet.OverhangY = form.OverhangY;
                // allowed patterns
                foreach (string s in form.AllowedPatterns)
                    constraintSet.SetAllowedPattern(s);
                // allow aligned / alternate layer
                constraintSet.AllowAlternateLayers = form.AllowAlternateLayers;
                constraintSet.AllowAlignedLayers = form.AllowAlignedLayers;
                // stop criterion
                constraintSet.UseMaximumHeight = form.UseMaximumPalletHeight;
                constraintSet.UseMaximumNumberOfCases = form.UseMaximumNumberOfBoxes;
                constraintSet.UseMaximumPalletWeight = form.UseMaximumPalletWeight;
                constraintSet.MaximumHeight = form.MaximumPalletHeight;
                constraintSet.MaximumNumberOfItems = form.MaximumNumberOfBoxes;
                constraintSet.MaximumPalletWeight = form.MaximumPalletWeight;
                // number of solution kept
                constraintSet.UseNumberOfSolutionsKept = form.UseNumberOfSolutionsKept;
                if (form.UseNumberOfSolutionsKept)
                    constraintSet.NumberOfSolutionsKept = form.NumberOfSolutionsKept;
 
                return CreateNewAnalysis(form.AnalysisName, form.AnalysisDescription,
                    form.SelectedBundle, form.SelectedPallet, null
                    , constraintSet
                    , new Solver());
            }                
            return null;
        }

        /// <summary>
        /// Creates a new case analysis
        /// </summary>
        /// <returns>created case analysis</returns>
        public CaseAnalysis CreateNewCaseAnalysisUI()
        {
            FormNewCaseAnalysis form = new FormNewCaseAnalysis(this);
            form.Boxes = Boxes.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                CaseConstraintSet constraintSet = new CaseConstraintSet();
                // aligned / alternate layers
                constraintSet.AllowAlignedLayers = form.AllowAlignedLayers;
                constraintSet.AllowAlternateLayers = form.AllowAlternateLayers;
                // patterns
                foreach (string patternName in form.AllowedPatterns)
                    constraintSet.SetAllowedPattern(patternName);
                // allowed axes
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, form.AllowVerticalZ);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, form.AllowVerticalZ);
                // use maximum case weight
                constraintSet.UseMaximumCaseWeight = form.UseMaximumCaseWeight;
                constraintSet.MaximumCaseWeight = form.MaximumCaseWeight;
                // use maximum number of boxes
                constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfItems;
                constraintSet.MaximumNumberOfItems = form.MaximumNumberOfItems;
                // minimum number of items
                constraintSet.MinimumNumberOfItems = form.MinimumNumberOfItems;
                constraintSet.UseMinimumNumberOfItems = form.UseMinimumNumberOfItems;
                // number of solutions kept
                constraintSet.NumberOfSolutionsKept = form.NumberOfSolutionsKept;

                if (!constraintSet.IsValid)
                {
                    MessageBox.Show(string.Format(Properties.Resources.ID_CASEANALYSIS_INVALIDCONSTRAINTSET));
                    return null; // invalid constraint set -> exit
                }

                 return CreateNewCaseAnalysis(
                    form.CaseAnalysisName
                    , form.CaseAnalysisDescription
                    , form.SelectedBox
                    , constraintSet
                    , form.PalletSolutionList
                    , new CaseSolver());
            }
            return null;
        }
        #endregion

        #region UI item edition
        /// <summary>
        /// Edit specified pallet analysis
        /// </summary>
        /// <param name="analysis"></param>
        public void EditPalletAnalysis(PalletAnalysis analysis)
        {
            // do we need to recompute analysis
            bool recomputeRequired = false;

            if (analysis.IsBoxAnalysis)
            {
                FormNewAnalysis form = new FormNewAnalysis(this, analysis);
                form.Cases = Cases.ToArray();
                form.Pallets = Pallets.ToArray();
                form.Interlayers = Interlayers.ToArray();

                if (recomputeRequired = (DialogResult.OK == form.ShowDialog()))
                {
                    // analysis name / description
                    analysis.Name = form.AnalysisName;
                    analysis.Description = form.AnalysisDescription;
                    // box / applet / interlayer
                    analysis.BProperties = form.SelectedBox;
                    analysis.PalletProperties = form.SelectedPallet;
                    analysis.InterlayerProperties = form.SelectedInterlayer;
                    // build constraint set
                    PalletConstraintSetBox constraintSet = analysis.ConstraintSet as PalletConstraintSetBox;
                    // overhang / underhang
                    constraintSet.OverhangX = form.OverhangX;
                    constraintSet.OverhangY = form.OverhangY;
                    // allowed axes
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, form.AllowVerticalX);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, form.AllowVerticalX);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, form.AllowVerticalY);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, form.AllowVerticalY);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, form.AllowVerticalZ);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, form.AllowVerticalZ);
                    // allowed patterns
                    constraintSet.ClearAllowedPatterns();
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
                    constraintSet.UseMaximumNumberOfCases = form.UseMaximumNumberOfBoxes;
                    constraintSet.UseMaximumPalletWeight = form.UseMaximumPalletWeight;
                    constraintSet.UseMaximumWeightOnBox = form.UseMaximumLoadOnBox;
                    constraintSet.MaximumHeight = form.MaximumPalletHeight;
                    constraintSet.MaximumNumberOfItems = form.MaximumNumberOfBoxes;
                    constraintSet.MaximumPalletWeight = form.MaximumPalletWeight;
                    constraintSet.MaximumWeightOnBox = form.MaximumLoadOnBox;
                    // number of solution kept
                    constraintSet.UseNumberOfSolutionsKept = form.UseNumberOfSolutionsKept;
                    if (form.UseNumberOfSolutionsKept)
                        constraintSet.NumberOfSolutionsKept = form.NumberOfSolutionsKept;
                }
            }
            else if (analysis.IsBundleAnalysis)
            {
                FormNewAnalysisBundle form = new FormNewAnalysisBundle(this, analysis);
                form.Boxes = Bundles.ToArray();
                form.Pallets = Pallets.ToArray();

                if (recomputeRequired = (DialogResult.OK == form.ShowDialog()))
                {
                    // analysis name / description
                    analysis.Name = form.AnalysisName;
                    analysis.Description = form.AnalysisDescription;
                    // analysis bundle / pallet
                    analysis.BProperties = form.SelectedBundle;
                    analysis.PalletProperties = form.SelectedPallet;
                    // build constraintSet
                    PalletConstraintSetBundle constraintSet = analysis.ConstraintSet as PalletConstraintSetBundle;
                    // overhang / underhang
                    constraintSet.OverhangX = form.OverhangX;
                    constraintSet.OverhangY = form.OverhangY;
                    // allowed patterns
                    foreach (string s in form.AllowedPatterns)
                        constraintSet.SetAllowedPattern(s);
                    // allow aligned / alternate layer
                    constraintSet.AllowAlternateLayers = form.AllowAlternateLayers;
                    constraintSet.AllowAlignedLayers = form.AllowAlignedLayers;
                    // stop criterion
                    constraintSet.UseMaximumHeight = form.UseMaximumPalletHeight;
                    constraintSet.UseMaximumNumberOfCases = form.UseMaximumNumberOfBoxes;
                    constraintSet.UseMaximumPalletWeight = form.UseMaximumPalletWeight;
                    constraintSet.MaximumHeight = form.MaximumPalletHeight;
                    constraintSet.MaximumNumberOfItems = form.MaximumNumberOfBoxes;
                    constraintSet.MaximumPalletWeight = form.MaximumPalletWeight;
                    // number of solution kept
                    constraintSet.UseNumberOfSolutionsKept = form.UseNumberOfSolutionsKept;
                    if (form.UseNumberOfSolutionsKept)
                        constraintSet.NumberOfSolutionsKept = form.NumberOfSolutionsKept;
                }
            }
            if (recomputeRequired)
                analysis.OnEndUpdate(null);
        }
        /// <summary>
        /// Edit given case analysis
        /// </summary>
        /// <param name="caseAnalysis"></param>
        public void EditCaseAnalysis(CaseAnalysis caseAnalysis)
        {
            // do we need to recompute analysis
            bool recomputeRequired = false;

            FormNewCaseAnalysis form = new FormNewCaseAnalysis(caseAnalysis.ParentDocument, caseAnalysis);
            form.Boxes = Boxes.ToArray();
            if (recomputeRequired = (DialogResult.OK == form.ShowDialog()))
            {
                // analysis name / description
                caseAnalysis.Name = form.CaseAnalysisName;
                caseAnalysis.Description = form.CaseAnalysisDescription;
                // selected box
                caseAnalysis.BoxProperties = form.SelectedBox;
                // constraint set
                CaseConstraintSet constraintSet = caseAnalysis.ConstraintSet;
                // aligned / alternate layers
                constraintSet.AllowAlignedLayers = form.AllowAlignedLayers;
                constraintSet.AllowAlternateLayers = form.AllowAlternateLayers;
                // patterns
                constraintSet.AllowedPatternString = form.AllowedPatternsString;
                // allowed axes
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, form.AllowVerticalX);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, form.AllowVerticalY);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, form.AllowVerticalZ);
                constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, form.AllowVerticalZ);
                // use maximum case weight
                constraintSet.UseMaximumCaseWeight = form.UseMaximumCaseWeight;
                constraintSet.MaximumCaseWeight = form.MaximumCaseWeight;
                // use maximum number of boxes
                constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfItems;
                constraintSet.MaximumNumberOfItems = form.MaximumNumberOfItems;
                // minimum number of items
                constraintSet.MinimumNumberOfItems = form.MinimumNumberOfItems;
                constraintSet.UseMinimumNumberOfItems = form.UseMinimumNumberOfItems;
                // number of solutions kept
                constraintSet.NumberOfSolutionsKept = form.NumberOfSolutionsKept;
            }
            if (recomputeRequired)
                caseAnalysis.OnEndUpdate(null);
        }
        /// <summary>
        /// Edit given truck analysis
        /// </summary>
        /// <param name="truckAnalysis"></param>
        public void EditTruckAnalysis(TruckAnalysis truckAnalysis)
        {
            // instantiate form
            FormNewTruckAnalysis form = new FormNewTruckAnalysis(truckAnalysis.ParentDocument, truckAnalysis);
            form.Trucks = Trucks.ToArray();

            // show form
            bool recomputeRequired = false;
            if (recomputeRequired = (DialogResult.OK == form.ShowDialog()))
            {
                truckAnalysis.TruckProperties = form.SelectedTruck;
            }
            if (recomputeRequired)
                truckAnalysis.OnEndUpdate(null);
        }

        /// <summary>
        /// Edit given ECT analysis
        /// </summary>
        /// <param name="ectAnalysis"></param>
        public void EditECTAnalysis(ECTAnalysis ectAnalysis)
        {
            // uses FormMain.CreateOrActivateViewECTAnalysis
        }
        #endregion
    }
}
