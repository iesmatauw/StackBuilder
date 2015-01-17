#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    #region Layer classes (box layer + interlayer)
    /// <summary>
    /// Layer interface to be implemented by either BoxLayer or InterlayerPos
    /// </summary>
    public interface ILayer
    {
        double ZLow { get; }
        int BoxCount { get; }
        int CylinderCount { get; }
        int InterlayerCount { get; }
    }

    public class InterlayerPos : ILayer
    {
        #region Data members
        private double _zLower = 0.0;
        private int _typeId = 0;
        #endregion

        #region Constructor
        public InterlayerPos(double zLow, int typeId)
        {
            _zLower = zLow;
            _typeId = typeId;
        }
        #endregion

        #region Interlayer specific properties
        public int TypeId { get { return _typeId; } }
        #endregion

        #region ILayer implementation
        public double ZLow { get { return _zLower; } }
        public int BoxCount { get { return 0; } }
        public int InterlayerCount {  get { return 1; } }
        public int CylinderCount {  get { return 0; } }
        #endregion
    }

    /// <summary>
    /// A layer of box
    /// </summary>
    public class BoxLayer : List<BoxPosition>, ILayer
    {
        #region Data members
        double _zLower = 0.0;
        string _patternName;
        #endregion

        #region Constructor
        public BoxLayer(double zLow, string layerType)
        {
            _zLower = zLow;
            _patternName = layerType;
        }
        #endregion

        #region Public properties
        public double ZLow
        {
            get { return _zLower; }
        }
        public int BoxCount { get { return Count; } }
        public int InterlayerCount { get { return 0; } }
        public int CylinderCount { get { return 0; } }
        public string PatternName { get { return _patternName; } }
        #endregion

        #region Public methods
        /// <summary>
        /// adds a case position
        /// </summary>
        /// <param name="vPosition">Box 'origin' position (origin: lower left corner)</param>
        /// <param name="dirLength">Length axis direction</param>
        /// <param name="dirWidth">Width axis direction</param>
        public void AddPosition(Vector3D vPosition, HalfAxis.HAxis dirLength, HalfAxis.HAxis dirWidth)
        {
            Add(new BoxPosition(vPosition, dirLength, dirWidth));
        }
        /// <summary>
        /// Compute layer bouding box
        /// </summary>
        /// <param name="bProperties">Case properties</param>
        /// <returns>bounding box</returns>
        public BBox3D BoundingBox(BProperties bProperties)
        {
            BBox3D bbox = new BBox3D();

            foreach (BoxPosition bpos in this)
            {
                Vector3D[] pts = new Vector3D[8];
                Vector3D vI = HalfAxis.ToVector3D(bpos.DirectionLength);
                Vector3D vJ = HalfAxis.ToVector3D(bpos.DirectionWidth);
                Vector3D vK = Vector3D.CrossProduct(vI, vJ);
                pts[0] = bpos.Position;
                pts[1] = bpos.Position + bProperties.Length * vI;
                pts[2] = bpos.Position + bProperties.Width * vJ;
                pts[3] = bpos.Position + bProperties.Length * vI + bProperties.Width * vJ;
                pts[4] = bpos.Position + bProperties.Height * vK;
                pts[5] = bpos.Position + bProperties.Width * vJ + bProperties.Height * vK; ;
                pts[6] = bpos.Position + HalfAxis.ToVector3D(bpos.DirectionWidth) * bProperties.Width;
                pts[7] = bpos.Position + HalfAxis.ToVector3D(bpos.DirectionLength) * bProperties.Length + HalfAxis.ToVector3D(bpos.DirectionWidth) * bProperties.Width;

                foreach (Vector3D pt in pts)
                    bbox.Extend(pt);
            }

            return bbox;
        }

        public double Thickness(BProperties bProperties)
        {
            if (Count == 0) return 0.0;
            BoxPosition bPos = this[0];
            Vector3D diagonale = bProperties.Length * HalfAxis.ToVector3D(bPos.DirectionLength)
                                + bProperties.Width * HalfAxis.ToVector3D(bPos.DirectionWidth)
                                + bProperties.Height * Vector3D.CrossProduct(HalfAxis.ToVector3D(bPos.DirectionLength), HalfAxis.ToVector3D(bPos.DirectionWidth));
            return Math.Abs(diagonale.Z);
        }
        #endregion
    }

    /// <summary>
    /// A layer of cylinders
    /// </summary>
    public class CylinderLayer : List<Vector3D>, ILayer
    {
        #region Data members
        double _zLower;
        #endregion

        #region Constructor
        public CylinderLayer(double zLow)
        {
            _zLower = zLow;
        }
        #endregion

        #region Public properties
        public double ZLow
        {
            get { return _zLower; }
        }
        public int BoxCount { get { return 0; } }
        public int InterlayerCount { get { return 0; } }
        public int CylinderCount { get { return Count; } }
        #endregion

        #region Public methods
        /// <summary>
        /// Compute layer bouding box
        /// </summary>
        /// <param name="bProperties">Case properties</param>
        /// <returns>bounding box</returns>
        public BBox3D BoundingBox(CylinderProperties cylProperties)
        {
            BBox3D bbox = new BBox3D();

            double radius = cylProperties.RadiusOuter;
            double height = cylProperties.Height;

            foreach (Vector3D pos in this)
            {
                Vector3D[] pts = new Vector3D[8];
                pts[0] = pos - radius * Vector3D.XAxis - radius * Vector3D.YAxis;
                pts[1] = pos + radius * Vector3D.XAxis - radius * Vector3D.YAxis;
                pts[2] = pos + radius * Vector3D.XAxis + radius * Vector3D.YAxis;
                pts[3] = pos - radius * Vector3D.XAxis + radius * Vector3D.YAxis;
                pts[4] = pos - radius * Vector3D.XAxis - radius * Vector3D.YAxis + height * Vector3D.ZAxis;
                pts[5] = pos + radius * Vector3D.XAxis - radius * Vector3D.YAxis + height * Vector3D.ZAxis;
                pts[6] = pos + radius * Vector3D.XAxis + radius * Vector3D.YAxis + height * Vector3D.ZAxis;
                pts[7] = pos - radius * Vector3D.XAxis + radius * Vector3D.YAxis + height * Vector3D.ZAxis;

                foreach (Vector3D pt in pts)
                    bbox.Extend(pt);
            }
            return bbox;
        }

        public double Thickness(CylinderProperties cylProperties)
        {
            if (Count == 0) return 0.0;
            return cylProperties.Height;
        }
        #endregion
    }
    #endregion

    #region PalletSolution
    /// <summary>
    /// A set of box position and orientation that represent a valid solution
    /// </summary>
    public class CasePalletSolution : List<ILayer>, IComparable
    {
        #region Limit enum : the different reasons the stacking process might be stopped
        public enum Limit
        {
            LIMIT_MAXHEIGHTREACHED
            , LIMIT_MAXWEIGHTREACHED
            , LIMIT_MAXNUMBERREACHED
            , LIMIT_UNKNOWN
        };
        #endregion

        #region Data members
        private string _title;
        private bool _homogeneousLayer = false;
        private CasePalletAnalysis _parentAnalysis = null;
        private Limit _limitReached = Limit.LIMIT_UNKNOWN;
        private BBox3D _bbox = new BBox3D();
        #endregion

        #region Constructor
        public CasePalletSolution(CasePalletAnalysis analysis, string title, bool homogenousLayer)
        {
            _parentAnalysis = analysis;
            _title = title;
            _homogeneousLayer = homogenousLayer;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Solution title (generated by solver)
        /// </summary>
        public string Title
        {
            get { return _title; }
        }
        /// <summary>
        /// Parent analysis
        /// </summary>
        public CasePalletAnalysis Analysis
        {
            get { return _parentAnalysis; }
            set { _parentAnalysis = value; }
        }
        /// <summary>
        /// Case count
        /// </summary>
        public int CaseCount
        {
            get
            {
                int iCount = 0;
                foreach (ILayer layer in this)
                    iCount += layer.BoxCount;
                return iCount;
            }
        }
        /// <summary>
        /// Interlayer count
        /// </summary>
        public int InterlayerCount
        {
            get
            {
                int iCount = 0;
                foreach (ILayer layer in this)
                    iCount += layer.InterlayerCount;
                return iCount;
            }
        }

        /// <summary>
        /// Case per layer count
        /// </summary>
        public int CasePerLayerCount
        {
            get
            {
                if (Count == 0) return 0;
                return this[0].BoxCount;
            }
        }
        /// <summary>
        /// case layers count
        /// </summary>
        public int CaseLayersCount
        {
            get
            {
                int caseLayerCount = 0;
                foreach (ILayer layer in this)
                    if (layer is BoxLayer)
                        ++caseLayerCount;
                return caseLayerCount;
            }
        }

        public BoxLayer CaseLayerFirst
        {
            get
            {
                foreach (ILayer layer in this)
                {
                    if (layer is BoxLayer)
                        return layer as BoxLayer;
                }
                return null;
            }
        }

        public BoxLayer CaseLayerSecond
        {
            get
            {
                bool first = true;
                foreach (ILayer layer in this)
                {
                    if (layer is BoxLayer)
                    {
                        if (first)
                            first = false;
                        else
                            return layer as BoxLayer;
                    }
                }
                return null;
            }
        }

        public bool HasSameCountLayers
        {
            get
            {
                bool first = true;
                int count1 = 0;
                foreach (ILayer layer in this)
                {
                    if (layer is BoxLayer)
                    {
                        if (first)
                        {
                            count1 = layer.BoxCount;
                            first = false;
                        }
                        else
                            return (count1 == layer.BoxCount);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Efficiency percentage
        /// </summary>
        public double VolumeEfficiencyCases
        {
            get
            {
                return 100.0 * CaseCount * Analysis.BProperties.Volume
                    /
                    (
                        (Analysis.PalletProperties.Length + Analysis.ConstraintSet.OverhangX)
                        * (Analysis.PalletProperties.Width + Analysis.ConstraintSet.OverhangY)
                        * (Analysis.ConstraintSet.MaximumHeight - Analysis.PalletProperties.Height)
                    );
            }
        }
        /// <summary>
        /// Volume efficiency (percentage)
        /// </summary>
        public double VolumeEfficiencyBoxes
        {
            get
            {
                CaseOfBoxesProperties caseOfBoxes = Analysis.BProperties as CaseOfBoxesProperties;
                if (null == caseOfBoxes)
                    return 0.0;
                return 100.0 * CaseCount * caseOfBoxes.NumberOfBoxes * caseOfBoxes.InsideBoxProperties.Volume
                    /
                    (
                        (Analysis.PalletProperties.Length + Analysis.ConstraintSet.OverhangX)
                        * (Analysis.PalletProperties.Width + Analysis.ConstraintSet.OverhangY)
                        * (Analysis.ConstraintSet.MaximumHeight - Analysis.PalletProperties.Height)
                    );
            }
        }
        /// <summary>
        /// Weight efficiency (percentage)
        /// </summary>
        public double WeightEfficiency
        {
            get
            {
                return 100 * CaseCount * Analysis.BProperties.Weight
                    /
                    (Analysis.ConstraintSet.MaximumPalletWeight - Analysis.PalletProperties.Weight);
            }
        }
        /// <summary>
        /// Pallet weight
        /// </summary>
        public double PalletWeight
        {
            get
            {
                return Analysis.PalletProperties.Weight
                    + CaseCount * Analysis.BProperties.Weight
                    + (Analysis.HasInterlayer ? InterlayerCount * Analysis.InterlayerProperties.Weight : 0.0)
                    + (Analysis.HasInterlayerAntiSlip ? Analysis.InterlayerPropertiesAntiSlip.Weight : 0.0)
                    + (Analysis.HasPalletCorners ? Analysis.PalletCornerProperties.Weight * 4.0 : 0.0)
                    + (Analysis.HasPalletCap ? Analysis.PalletCapProperties.Weight : 0.0);
            }
        }
        public BBox3D LoadBoundingBox
        {
            get
            {
                if (!_bbox.IsValid)
                    _bbox = ComputeLoadBBox3D();
                return _bbox;
            }
        }

        public BBox3D LoadBoundingBoxWDeco
        {
            get
            {
                BBox3D bbox = new BBox3D(LoadBoundingBox);
                double zMax = bbox.PtMax.Z;
                // extend ?
                if (Analysis.HasPalletCorners)
                {
                    double thickness = Analysis.PalletCornerProperties.Thickness;
                    Vector3D ptMin = bbox.PtMin;
                    ptMin.X -= thickness;
                    ptMin.Y -= thickness;
                    Vector3D ptMax = bbox.PtMax;
                    ptMax.X += thickness;
                    ptMax.Y += thickness;
                    bbox.Extend(ptMin);
                    bbox.Extend(ptMax);
                }
                // extend ?
                if (Analysis.HasPalletCap)
                {
                    Vector3D v0 = new Vector3D(
                        0.5 * (Analysis.PalletProperties.Length - Analysis.PalletCapProperties.Length),
                        0.5 * (Analysis.PalletProperties.Width - Analysis.PalletCapProperties.Width),
                        zMax + Analysis.PalletCapProperties.Height - Analysis.PalletCapProperties.InsideHeight);
                    bbox.Extend(v0);
                    Vector3D v1 = new Vector3D(
                        0.5 * (Analysis.PalletProperties.Length + Analysis.PalletCapProperties.Length),
                        0.5 * (Analysis.PalletProperties.Width + Analysis.PalletCapProperties.Width),
                        zMax + Analysis.PalletCapProperties.Height - Analysis.PalletCapProperties.InsideHeight);
                    bbox.Extend(v1);
                }
                return bbox;
            }
        }

        public BBox3D BoundingBox
        {
            get
            {
                BBox3D bbox = new BBox3D();
                // --- extend
                // pallet
                bbox.Extend(Vector3D.Zero);
                bbox.Extend(new Vector3D(Analysis.PalletProperties.Length, Analysis.PalletProperties.Width, Analysis.PalletProperties.Height));
                // load
                bbox.Extend(LoadBoundingBox);
                // --- extend
                return bbox;
            }
        }

        public BBox3D BoundingBoxWDeco
        {
            get
            {
                BBox3D bbox = new BBox3D();
                // --- extend
                // pallet
                bbox.Extend(Vector3D.Zero);
                bbox.Extend(new Vector3D(Analysis.PalletProperties.Length, Analysis.PalletProperties.Width, Analysis.PalletProperties.Height));
                // load
                bbox.Extend(LoadBoundingBoxWDeco);
                // --- extend
                return bbox;
            }
        }

        public double PalletLength
        {
            get
            {
                return BoundingBox.Length;
            }
        }
        public double PalletWidth
        {
            get
            {
                return BoundingBox.Width;
            }
        }
        public double PalletHeight
        {
            get
            {
                BoxLayer bLayer = this[Count - 1] as BoxLayer;
                return this[Count - 1].ZLow + (null != bLayer ? bLayer.Thickness(Analysis.BProperties) : 0.0);
            }
        }

        private BBox3D ComputeLoadBBox3D()
        {
            BBox3D bbox = new BBox3D();
            int iLayer = 0;
            while (iLayer < Count)
            {
                ILayer layer = this[iLayer];
                BoxLayer blayer = layer as BoxLayer;
                if (null != blayer)
                    bbox.Extend(blayer.BoundingBox(Analysis.BProperties));
                ++iLayer;
            }
            return bbox;
        }

        public bool HasHomogeneousLayers
        {
            get { return _homogeneousLayer; }
            set { _homogeneousLayer = value; }
        }

        public string CaseOrientation
        {
            get { return "Z"; }
        }

        public Orientation FirstCaseOrientation
        {
            get
            {
                if (Count > 0)
                {
                    BoxLayer boxLayer = this[0] as BoxLayer;
                    if (null != boxLayer && boxLayer.Count > 0)
                        return new Orientation(boxLayer[0].DirectionLength, boxLayer[0].DirectionWidth);
                }
                return new Orientation();
            }
        }

        public double AverageLoadOnFirstLayerCase
        {
            get
            {
                // first box layer
                if (0 == this.CaseCount)
                    return 0.0;
                // all above first layer(s) weight
                double totalWeight = 0.0;
                for (int i = 1; i < this.Count; ++i)
                {
                    BoxLayer thisLayer = this[i] as BoxLayer;
                    if (null != thisLayer) // do not count interlayers
                        totalWeight += thisLayer.Count * Analysis.BProperties.Weight;
                }
                BoxLayer boxlayer = this[0] as BoxLayer;
                if (null != boxlayer) // we never know
                    return totalWeight / boxlayer.Count;
                else
                    return 0.0;
            }
        }
        #endregion

        #region Limit reached
        public Limit LimitReached
        {
            get { return _limitReached; }
            set { _limitReached = value; }
        }
        #endregion

        #region Adding layer / interlayer
        public BoxLayer CreateNewLayer(double zLow, string patternName)
        {
            BoxLayer layer = new BoxLayer(zLow, patternName);
            Add(layer);
            return layer;
        }
        public InterlayerPos CreateNewInterlayer(double zLow, int typeId)
        {
            InterlayerPos layer = new InterlayerPos(zLow, typeId);
            Add(layer);
            return layer;
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            CasePalletSolution sol = (CasePalletSolution)obj;
            if (this.CaseCount > sol.CaseCount)
                return -1;
            else if (this.CaseCount == sol.CaseCount)
            {
                if ((sol.Count > 0 && sol[0] is BoxLayer)
                    && (this.Count > 0 && this[0] is BoxLayer))
                {
                    BoxLayer layerSol = (BoxLayer)sol[0];
                    int iPatternSol = PatternNameToIndex(layerSol.PatternName);
                    BoxLayer layerThis = (BoxLayer)this[0];
                    int iPatternThis = PatternNameToIndex(layerThis.PatternName);

                    if (iPatternSol > iPatternThis)
                        return -1;
                    else if (iPatternSol == iPatternThis)
                        return 0;
                    else
                        return 1;
                }
                return 0;
            }
            else
                return 1;
        }
        private int PatternNameToIndex(string patternName)
        {
            if (string.Equals(patternName, "Column")) return 0;
            else if (string.Equals(patternName, "Interlocked")) return 1;
            else if (string.Equals(patternName, "Trilock")) return 2;
            else if (string.Equals(patternName, "Diagonale")) return 3;
            else if (string.Equals(patternName, "Spirale")) return 4;
            else if (string.Equals(patternName, "Enlarged spiral")) return 5;
            else return 6;
        }
        #endregion

        #region Object method overrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("=== Solution ===> {0} layers -> {1} boxes", this.Count, this.CaseCount));
            int index = 0;
            foreach (BoxLayer layer in this)
                foreach (BoxPosition boxPosition in layer)
                    sb.AppendLine(string.Format("{0} : {1}", index++, boxPosition.ToString()));
            return sb.ToString();
        }
        #endregion
    }
    #endregion
}