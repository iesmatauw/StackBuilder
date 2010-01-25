#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class LayerPatternColumn : LayerPattern
    {
        #region Implementation of LayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Column"; }
        }

        public override void GenerateLayer(Layer layer, double palletLength, double palletWidth)
        {
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;

            int sizeX = (int)Math.Floor(palletLength / boxLength);
            int sizeY = (int)Math.Floor(palletWidth / boxWidth);

            double offsetX = 0.5 * (palletLength - sizeX * boxLength);
            double offsetY = 0.5 * (palletLength - sizeY * boxWidth);

            for (int i = 0; i < sizeX; ++i)
                for (int j = 0; j < sizeY; ++j)
                    layer.AddPosition(
                        new Vector2D(
                            offsetX + i * boxLength
                            , offsetY + j * boxWidth)
                        , HalfAxis.AXIS_X_P, HalfAxis.AXIS_Y_P);
        }
        #endregion
    }
}
