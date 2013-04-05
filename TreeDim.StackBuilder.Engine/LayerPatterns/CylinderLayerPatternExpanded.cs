using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeDim.StackBuilder.Engine
{
    class CylinderLayerPatternExpanded : CylinderLayerPattern
    {
        #region Implementation of CylinderLayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Expanded"; }
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
