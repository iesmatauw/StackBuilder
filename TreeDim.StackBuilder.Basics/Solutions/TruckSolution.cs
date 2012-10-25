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
                    return (int)Math.Floor(_parentTruckAnalysis.TruckProperties.Height / _parentTruckAnalysis.ParentSolution.PalletHeight);
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
