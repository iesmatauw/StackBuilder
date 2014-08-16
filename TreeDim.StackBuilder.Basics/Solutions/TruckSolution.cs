#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class TruckSolution : IComparable
    {
        #region Data members
        private string _title;
        private BoxLayer _layer;
        private TruckAnalysis _parentTruckAnalysis;
        private BBox3D _bbox = new BBox3D();
         #endregion

        #region Constructor
        public TruckSolution(string title, TruckAnalysis truckAnalysis)
        {
            _title = title;
            _parentTruckAnalysis = truckAnalysis;
        }
        #endregion

        #region Layers
        public BoxLayer Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }
        public int NoLayers
        {
            get
            {
                if (!_parentTruckAnalysis.ConstraintSet.MultilayerAllowed)
                    return 1;
                else
                    return (int)Math.Floor(
                        (_parentTruckAnalysis.TruckProperties.Height - _parentTruckAnalysis.ConstraintSet.MinDistancePalletTruckRoof)
                        / _parentTruckAnalysis.ParentSolution.PalletHeight
                        );
            }
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Pallet count
        /// </summary>
        public int PalletCount
        { get { return NoLayers * _layer.BoxCount; } }
        /// <summary>
        /// Total case count in truck
        /// </summary>
        public int BoxCount
        {
            get { return PalletCount * _parentTruckAnalysis.ParentSolution.CaseCount; }
        }
        /// <summary>
        /// Volume efficiency of pallet layout
        /// </summary>
        public double Efficiency
        {
            get
            {
                return 100.0 * BoxCount * _parentTruckAnalysis.ParentAnalysis.BProperties.Volume
                    /_parentTruckAnalysis.TruckProperties.Volume;
            }
        }
        /// <summary>
        /// Total load weight of truck
        /// </summary>
        public double LoadWeight
        {
            get { return PalletCount * _parentTruckAnalysis.ParentSolution.PalletWeight; }
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
        private BBox3D ComputeLoadBBox3D()
        {
            double palletLength = ParentTruckAnalysis.ParentSolution.PalletLength;
            double palletWidth = ParentTruckAnalysis.ParentSolution.PalletWidth;
            double palletHeight = ParentTruckAnalysis.ParentSolution.PalletHeight;

            BBox3D bbox = new BBox3D();
            int iLayer = 0;
            while (iLayer < NoLayers)
            {
                foreach (BoxPosition bPositionLayer in Layer)
                {
                    // actual position in load
                    BoxPosition bpos = new BoxPosition(
                        new Vector3D(
                            bPositionLayer.Position.X
                            , bPositionLayer.Position.Y
                            , bPositionLayer.Position.Z + palletHeight * iLayer)
                        , bPositionLayer.DirectionLength
                        , bPositionLayer.DirectionWidth);

                    Vector3D[] pts = new Vector3D[8];
                    Vector3D vI = HalfAxis.ToVector3D(bpos.DirectionLength);
                    Vector3D vJ = HalfAxis.ToVector3D(bpos.DirectionWidth);
                    Vector3D vK = Vector3D.CrossProduct(vI, vJ);
                    pts[0] = bpos.Position;
                    pts[1] = bpos.Position + palletLength * vI;
                    pts[2] = bpos.Position + palletWidth * vJ;
                    pts[3] = bpos.Position + palletLength * vI + palletWidth * vJ;
                    pts[4] = bpos.Position + palletHeight * vK;
                    pts[5] = bpos.Position + palletWidth * vJ + palletHeight * vK; ;
                    pts[6] = bpos.Position + HalfAxis.ToVector3D(bpos.DirectionWidth) * palletWidth;
                    pts[7] = bpos.Position + HalfAxis.ToVector3D(bpos.DirectionLength) * palletLength + HalfAxis.ToVector3D(bpos.DirectionWidth) * palletWidth;

                    foreach (Vector3D pt in pts)
                        bbox.Extend(pt);

                }
                ++iLayer;
            }
            return bbox;
        }

        /// <summary>
        /// Load height (pallet height * number of layers
        /// </summary>
        public double LoadHeight
        {
            get { return NoLayers * _parentTruckAnalysis.ParentSolution.PalletHeight; }
        }
        /// <summary>
        /// Parent truck analysis
        /// </summary>
        public TruckAnalysis ParentTruckAnalysis
        {
            get { return _parentTruckAnalysis;  }
            set { _parentTruckAnalysis = value; }
        }
        /// <summary>
        /// Title given to solution as it was generated
        /// </summary>
        public string Title
        {
            get { return _title; }
        }
        #endregion

        #region Public methods
        public void SetLayer(BoxLayer layer)
        {
            _layer = layer;
        }
        #endregion

        #region IComparable
        public int CompareTo(object obj)
        {
            TruckSolution sol = (TruckSolution)obj;
            if (this.PalletCount > sol.PalletCount)
                return -1;
            else if (this.PalletCount == sol.PalletCount)
                return 0;
            else
                return 1;
        }
        #endregion
    }
}
