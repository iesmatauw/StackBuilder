#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class LayerPatternSpirale: LayerPattern
    {
        #region Implementation of LayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Spirale"; }
        }

        public override void GenerateLayer(Layer layer, double palletLength, double palletWidth)
        {
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
        }
        #endregion
    }
}
