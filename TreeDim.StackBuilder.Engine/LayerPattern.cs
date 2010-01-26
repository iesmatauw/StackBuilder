#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using TreeDim.StackBuilder.Basics;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    /// <summary>
    /// Layer pattern abstract class
    /// </summary>
    internal abstract class LayerPattern
    {
        #region Abstract methods
        abstract public string Name { get; }
        abstract public void GetLayerDimensions(Layer layer, double palletLength, double palletWidth, out double actualLength, out double actualWidth);
        abstract public void GenerateLayer(Layer layer, double palletLength, double palletWidth, double actualLength, double actualWidth);
        #endregion
    }
}
