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

        public override void GetLayerDimensions(Layer layer, double palletLength, double palletWidth, out double actualLength, out double actualWidth)
        {
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            actualLength = Math.Floor(palletLength / boxLength) * boxLength;
            actualWidth = Math.Floor(palletWidth / boxWidth) * boxWidth;
        }

        public override void GenerateLayer(Layer layer, double palletLength, double palletWidth, double actualLength, double actualWidth)
        {
            layer.Clear();

            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;

            int sizeX = (int)Math.Floor(palletLength / boxLength);
            int sizeY = (int)Math.Floor(palletWidth / boxWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletLength - actualWidth);

            double spaceX = sizeX > 1 ? (actualLength - sizeX * boxLength) / (sizeX - 1) : 0.0;
            double spaceY = sizeY > 1 ? (actualWidth - sizeY * boxWidth) / (sizeY - 1) : 0.0;

            for (int i = 0; i < sizeX; ++i)
                for (int j = 0; j < sizeY; ++j)
                    layer.AddPosition(
                        new Vector2D(
                            offsetX + i * (boxLength + spaceX)
                            , offsetY + j * (boxWidth + spaceY)
                            )
                        , HalfAxis.AXIS_X_P, HalfAxis.AXIS_Y_P);
        }
        #endregion
    }
}
