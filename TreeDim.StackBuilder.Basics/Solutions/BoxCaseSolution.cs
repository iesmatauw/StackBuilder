#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    /// <summary>
    /// A set of box position and orientation that represent a valid box/case analysis solution
    /// </summary>
    public class BoxCaseSolution : List<BoxLayer>, IComparable
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
        private string _patternName;
        private HalfAxis.HAxis _orthoAxis;
        private BoxCaseAnalysis _boxCaseAnalysis;
        private string _title;
        private Limit _limitReached = Limit.LIMIT_UNKNOWN;
        private BBox3D _bbox = new BBox3D();
        #endregion

        #region Constructor
        public BoxCaseSolution(BoxCaseAnalysis boxCaseAnalysis, HalfAxis.HAxis orthoAxis, string patternName)
        {
            _boxCaseAnalysis = boxCaseAnalysis;
            _orthoAxis = orthoAxis;
            _patternName = patternName;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Parent analysis
        /// </summary>
        public BoxCaseAnalysis Analysis
        {
            get { return _boxCaseAnalysis; }
            set { _boxCaseAnalysis = value; }
        }
        /// <summary>
        /// Box count
        /// </summary>
        public int BoxPerCaseCount
        {
            get
            {
                int boxCount = 0;
                foreach (BoxLayer layer in this)
                    boxCount += layer.BoxCount;
                return boxCount;
            }
        }

        public BoxLayer BoxLayerFirst
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
        /// <summary>
        /// Boxes per layer count
        /// </summary>
        public int BoxPerLayerCount
        {
            get
            {
                if (this.Count == 0) return 0;
                return this[0].BoxCount;
            }
        }
        /// <summary>
        /// Layers count
        /// </summary>
        public int BoxLayersCount
        {
            get
            {
                int boxLayerCount = 0;
                foreach (ILayer layer in this)
                    if (layer is BoxLayer)
                        ++boxLayerCount;
                return boxLayerCount;
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
        /// <summary>
        /// 
        /// </summary>
        private BBox3D ComputeLoadBBox3D()
        {
            BBox3D bbox = new BBox3D();
            int iLayer = 0;
            while (iLayer < Count)
            {
                ILayer layer = this[iLayer];
                BoxLayer blayer = layer as BoxLayer;
                if (null != blayer)
                    bbox.Extend(blayer.BoundingBox(_boxCaseAnalysis.BoxProperties));
                ++iLayer;
            }
            return bbox;
        }
        public double VolumeEfficiencyBoxes
        {
            get
            {
                return 100.0 * BoxPerCaseCount * Analysis.BoxProperties.Volume
                    / Analysis.CaseProperties.InsideVolume; 
            }
        }
        public double CaseWeight
        {
            get { return _boxCaseAnalysis.CaseProperties.Weight
                + BoxPerCaseCount * _boxCaseAnalysis.BoxProperties.Weight; }
        }
        public BoxCaseSolution.Limit LimitReached
        {
            get { return _limitReached; }
            set { _limitReached = value; }
        }
        public string Title
        {
            get { return _title; }
        }
        #endregion

        #region Adding layer / interlayer
        public BoxLayer CreateNewLayer(double zLow)
        {
            BoxLayer layer = new BoxLayer(zLow);
            Add(layer);
            return layer;
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            BoxCaseSolution sol = (BoxCaseSolution) obj;
            if (this.BoxPerCaseCount > sol.BoxPerCaseCount)
                return -1;
            else if (this.BoxPerCaseCount == sol.BoxPerCaseCount)
                return 0;
            else
                return 1;
        }
        #endregion
    }
}
