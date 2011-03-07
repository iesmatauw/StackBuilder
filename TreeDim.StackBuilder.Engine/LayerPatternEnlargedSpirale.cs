#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class LayerPatternEnlargedSpirale : LayerPattern
    {
       #region Implementation of LayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Enlarged spirale"; }
        }

        public override void GetLayerDimensions(Layer layer, out double actualLength, out double actualWidth)
        {
            actualLength = 0.0;
            actualWidth = 0.0;
        }

        public override void GenerateLayer(Layer layer, double actualLength, double actualWidth)
        {
            throw new NotImplementedException();
        }
        public override int GetNumberOfVariants(Layer layer)
        {
            return 1;
        }
        public override bool CanBeSwaped { get { return true; } }
        public override bool CanBeInverted { get { return true; } }
        #endregion
    }
}
