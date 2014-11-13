#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class CylinderLayerPatternMixed212 : CylinderLayerPattern
    {
        #region Implementation of CylinderLayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Mixed212"; }
        }
        public override bool CanBeSwapped
        {
            get { return true; }
        }
        public override void GetLayerDimensions(LayerCyl layer, out double actualLength, out double actualWidth)
        {
            double palletLength = layer.PalletLength;
            double palletWidth = layer.PalletWidth;
            double radius = layer.CylinderRadius;
            actualLength = 0.0;
            actualWidth = 0.0;
        }

        public override void GenerateLayer(LayerCyl layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            throw new NotImplementedException();
        }
        #endregion
    }
}
