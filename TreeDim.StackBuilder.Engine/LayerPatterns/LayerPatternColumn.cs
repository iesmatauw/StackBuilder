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

        public override void GetLayerDimensions(Layer layer, out double actualLength, out double actualWidth)
        {
            double palletLength = layer.PalletLength;
            double palletWidth = layer.PalletWidth;
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            actualLength = Math.Floor(palletLength / boxLength) * boxLength;
            actualWidth = Math.Floor(palletWidth / boxWidth) * boxWidth;
        }

        public override void GenerateLayer(Layer layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int sizeX = (int)Math.Floor(palletLength / boxLength);
            int sizeY = (int)Math.Floor(palletWidth / boxWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            double spaceX = sizeX > 1 ? (actualLength - sizeX * boxLength) / (sizeX - 1) : 0.0;
            double spaceY = sizeY > 1 ? (actualWidth - sizeY * boxWidth) / (sizeY - 1) : 0.0;

            for (int i = 0; i < sizeX; ++i)
                for (int j = 0; j < sizeY; ++j)
                    AddPosition(layer
                        , new Vector2D(
                            offsetX + i * (boxLength + spaceX)
                            , offsetY + j * (boxWidth + spaceY)
                            )
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
        }

        public override int GetNumberOfVariants(Layer layer)
        {
            return 1;
        }
        public override bool CanBeSwapped { get { return false; } }
        public override bool CanBeInverted { get { return false; } }
        #endregion
    }
}
