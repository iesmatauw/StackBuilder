#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class CylinderLayerPatternStaggered : CylinderLayerPattern
    {
        #region Implementation of CylinderLayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Staggered"; }
        }

        public override void GetLayerDimensions(CylinderLayer layer, out double actualLength, out double actualWidth)
        {
            double palletLength = layer.PalletLength;
            double palletWidth = layer.PalletWidth;
            double radius = layer.CylinderRadius;
            actualLength = 0.0;
            actualWidth = 0.0;
        }

        public override void GenerateLayer(CylinderLayer layer, double actualLength, double actualWidth)
        {
            layer.Clear();


        }
        #endregion
    }
}
