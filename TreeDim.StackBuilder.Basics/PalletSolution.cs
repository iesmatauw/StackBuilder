#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using System.Drawing;
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
        int InterlayerCount { get; }
    }

    public class InterlayerPos : ILayer
    {
        #region Data members
        private double _zLower = 0.0;
        #endregion

        #region Constructor
        public InterlayerPos(double zLow)
        {
            _zLower = zLow;
        }
        #endregion

        #region ILayer implementation
        public double ZLow
        {
            get { return _zLower; }
        }
        public int BoxCount
        {
            get { return 0; }
        }
        public int InterlayerCount
        {
            get { return 1; }
        }
        #endregion
    }

    /// <summary>
    /// A layer of box
    /// </summary>
    public class BoxLayer : List<BoxPosition>, ILayer
    {
        #region Data members
        double _zLower = 0.0;
        #endregion

        #region Constructor
        public BoxLayer(double zLow)
        {
            _zLower = zLow;
        }
        #endregion

        #region Public properties
        public double ZLow
        {
            get { return _zLower; }
        }
        public int BoxCount
        {
            get { return Count; }
        }

        public int InterlayerCount
        {
            get { return 0; }
        }
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
    #endregion

    #region PalletSolution
    /// <summary>
    /// A set of box position and orientation that represent a valid solution
    /// </summary>
    public class PalletSolution : List<ILayer>, IComparable
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
        private PalletAnalysis _parentAnalysis = null;
        private Limit _limitReached = Limit.LIMIT_UNKNOWN;
        private BBox3D _bbox = new BBox3D();
        #endregion

        #region Constructor
        public PalletSolution(PalletAnalysis analysis, string title, bool homogenousLayer)
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
        public PalletAnalysis Analysis
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
                        (Analysis.PalletProperties.Length - Analysis.ConstraintSet.OverhangX)
                        * (Analysis.PalletProperties.Width - Analysis.ConstraintSet.OverhangY)
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
                        (Analysis.PalletProperties.Length - Analysis.ConstraintSet.OverhangX)
                        * (Analysis.PalletProperties.Width - Analysis.ConstraintSet.OverhangY)
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
                return Analysis.PalletProperties.Weight + CaseCount * Analysis.BProperties.Weight;
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
                    totalWeight += thisLayer.Count * Analysis.BProperties.Weight;
                }
                BoxLayer boxlayer = this[0] as BoxLayer;
                return totalWeight / boxlayer.Count;
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
        public BoxLayer CreateNewLayer(double zLow)
        {
            BoxLayer layer = new BoxLayer(zLow);
            Add(layer);
            return layer;
        }
        public InterlayerPos CreateNewInterlayer(double zLow)
        {
            InterlayerPos layer = new InterlayerPos(zLow);
            Add(layer);
            return layer;
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            PalletSolution sol = (PalletSolution)obj;
            if (this.CaseCount > sol.CaseCount)
                return -1;
            else if (this.CaseCount == sol.CaseCount)
                return 0;
            else
                return 1;
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