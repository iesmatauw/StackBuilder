#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class TruckSolution : IComparable
    {
        #region Data members
        private string _title;
        private BoxLayer _layer;
        private TruckAnalysis _parentTruckAnalysis;
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
                    return (int)Math.Floor(_parentTruckAnalysis.TruckProperties.Height / _parentTruckAnalysis.ParentSolution.PalletHeight(_parentTruckAnalysis.ParentAnalysis));
            }
        }
        #endregion

        #region Public properties

        public int PalletCount
        {
            get { return NoLayers * _layer.BoxCount; }
        }
        public int BoxCount
        {
            get { return PalletCount * _parentTruckAnalysis.ParentSolution.BoxCount; }
        }
        public double Efficiency
        {
            get
            {
                return 100.0 * BoxCount * _parentTruckAnalysis.ParentAnalysis.BProperties.Volume
                    /_parentTruckAnalysis.TruckProperties.Volume;
            }
        }
        public double LoadWeight
        {
            get { return PalletCount * _parentTruckAnalysis.ParentSolution.PalletWeight(_parentTruckAnalysis.ParentAnalysis); }
        }
        public double LoadHeight
        {
            get { return NoLayers * _parentTruckAnalysis.ParentSolution.PalletHeight(_parentTruckAnalysis.ParentAnalysis); }
        }
        public TruckAnalysis ParentTruckAnalysis
        {
            get { return _parentTruckAnalysis;  }
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
