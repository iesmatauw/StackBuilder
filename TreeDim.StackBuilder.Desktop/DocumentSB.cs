#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
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
        public void Save()
        {
            if (IsNew) return;
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
            foreach (IView view in Views)
                view.Close();
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
        #endregion

        #region View creation methods
        public DockContentAnalysis CreateAnalysisView(Analysis analysis)
        {
            DockContentAnalysis form = new DockContentAnalysis(this, analysis);
            _views.Add(form);
            return form;
        }
        public DockContentTruckAnalysis CreateTruckAnalysisView(TruckAnalysis analysis)
        {
            DockContentTruckAnalysis form = new DockContentTruckAnalysis(this, analysis);
            _views.Add(form);
            return form;
        }
        #endregion

        #region UI item creation
        public void CreateNewBoxUI()
        {
            FormNewBox form = new FormNewBox(this);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewBox(form.BoxName, form.Description, form.BoxLength, form.BoxWidth, form.BoxHeight, form.Weight, form.Colors);
        }
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
        public void CreateNewPalletUI()
        {        
            FormNewPallet form = new FormNewPallet(this);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewPallet(form.PalletName, form.Description, form.PalletType
                    , form.PalletLength, form.PalletWidth, form.PalletHeight
                    , form.Weight
                    , form.AdmissibleLoadWeight, form.AdmissibleLoadHeight);
        }
        public void CreateNewTruckUI()
        {
            FormNewTruck form = new FormNewTruck(this);
            if (DialogResult.OK == form.ShowDialog())
                CreateNewTruck(form.TruckName, form.Description
                    , form.TruckLength, form.TruckWidth, form.TruckHeight
                    , form.TruckAdmissibleLoadWeight
                    , form.TruckColor);
        }
        public Analysis CreateNewAnalysisUI()
        {
            if (!CanCreateAnalysis) return null;

            FormNewAnalysis form = new FormNewAnalysis(this);
            form.Boxes = Boxes.ToArray();
            form.Pallets = Pallets.ToArray();
            form.Interlayers = Interlayers.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                // build constraint set
                ConstraintSetBox constraintSet = new ConstraintSetBox();
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
                constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfBoxes;
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
        public Analysis CreateNewAnalysisBundleUI()
        {
            FormNewAnalysisBundle form = new FormNewAnalysisBundle(this);
            form.Boxes = Bundles.ToArray();
            form.Pallets = Pallets.ToArray();
            if (DialogResult.OK == form.ShowDialog())
            {
                // build constraintSet
                ConstraintSetBundle constraintSet = new ConstraintSetBundle();
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
                constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfBoxes;
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
        #endregion

        #region UI item edition
        public void EditAnalysis(Analysis analysis)
        {
            if (analysis.IsBoxAnalysis)
            {
                FormNewAnalysis form = new FormNewAnalysis(this, analysis);
                form.Boxes = Boxes.ToArray();
                form.Pallets = Pallets.ToArray();
                form.Interlayers = Interlayers.ToArray();

                // build constraint set
                ConstraintSetBox constraintSet = analysis.ConstraintSet as ConstraintSetBox;

                if (DialogResult.OK == form.ShowDialog())
                {
                    // analysis name / description
                    analysis.Name = form.AnalysisName;
                    analysis.Description = form.AnalysisDescription;
                    // box / applet / interlayer
                    analysis.BProperties = form.SelectedBox;
                    analysis.PalletProperties = form.SelectedPallet;
                    analysis.InterlayerProperties = form.SelectedInterlayer;
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
                    constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfBoxes;
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

                if (DialogResult.OK == form.ShowDialog())
                {
                    // analysis name / description
                    analysis.Name = form.AnalysisName;
                    analysis.Description = form.AnalysisDescription;
                    // analysis bundle / pallet
                    analysis.BProperties = form.SelectedBundle;
                    analysis.PalletProperties = form.SelectedPallet;
                    // build constraintSet
                    ConstraintSetBundle constraintSet = analysis.ConstraintSet as ConstraintSetBundle;
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
                    constraintSet.UseMaximumNumberOfItems = form.UseMaximumNumberOfBoxes;
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

            analysis.OnEndUpdate(null);
        }
        #endregion
    }
}
