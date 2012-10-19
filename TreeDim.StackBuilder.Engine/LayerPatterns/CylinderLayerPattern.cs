#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    internal abstract class CylinderLayerPattern
    {
        #region Abstract methods
        abstract public string Name { get; }
        abstract public void GetLayerDimensions(CylinderLayer layer, out double length, out double width); 
        abstract public void GenerateLayer(CylinderLayer layer, double actualLength, double actualWidth);
        #endregion

        #region Public properties
        #endregion
    }
}
