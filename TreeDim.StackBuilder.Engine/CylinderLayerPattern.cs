using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Engine
{
    internal abstract class CylinderLayerPattern
    {
        #region Abstract methods
        abstract public string Name { get; }
        abstract public void GenerateLayer(CylinderLayer layer, out double actualLength, out double actualWidth);
        #endregion

        #region Public properties
        #endregion
    }
}
