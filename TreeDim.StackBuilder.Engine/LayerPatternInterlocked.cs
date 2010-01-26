#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class LayerPatternInterlocked : LayerPattern
    {
        #region Implementation of LayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Interlocked"; }
        }

        public override void GetLayerDimensions(Layer layer, double palletLength, double palletWidth, out double actualLength, out double actualWidth)
        {
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;

            int maxSizeXLength = 0, maxSizeXWidth = 0, maxSizeYLength = 0, maxSizeYWidth = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out maxSizeXLength, out maxSizeXWidth, out maxSizeYLength, out maxSizeYWidth);

            actualLength = maxSizeXLength * boxLength + maxSizeXWidth * boxWidth;
            actualWidth = Math.Max(maxSizeYLength * boxWidth, maxSizeYWidth * boxLength);
        }

        public override void GenerateLayer(Layer layer, double palletLength, double palletWidth, double actualLength, double actualWidth)
        {
            layer.Clear();

            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;

            int maxSizeXLength = 0, maxSizeXWidth = 0, maxSizeYLength = 0, maxSizeYWidth = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out maxSizeXLength, out maxSizeXWidth, out maxSizeYLength, out maxSizeYWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            double spaceX = maxSizeXLength + maxSizeXWidth > 1 ? (actualLength - (maxSizeXLength * boxLength + maxSizeXWidth * boxWidth)) / (maxSizeXLength + maxSizeXWidth - 1) : 0.0;
            double spaceYLength = maxSizeYLength  > 1 ? (actualWidth - maxSizeYLength * boxWidth ) / (maxSizeYLength - 1) : 0.0;
            double spaceYWidth = maxSizeYWidth > 1 ? (actualWidth - maxSizeYWidth * boxLength) / (maxSizeYWidth - 1) : 0.0;

            for (int i=0; i<maxSizeXLength; ++i)
                for (int j = 0; j < maxSizeYLength; ++j)
                {
                    layer.AddPosition(
                        new Vector2D(
                            offsetX + i * (boxLength + spaceX)
                            , offsetY + j * (boxWidth + spaceYLength))
                        , HalfAxis.AXIS_X_P, HalfAxis.AXIS_Y_P);
                }
            for (int i = 0; i < maxSizeXWidth; ++i)
                for (int j = 0; j < maxSizeYWidth; ++j)
                    layer.AddPosition(
                        new Vector2D(
                            offsetX + maxSizeXLength * (boxLength + spaceX) + i * (boxWidth + spaceX) + boxWidth
                            , offsetY + j * (boxLength + spaceYWidth))
                        , HalfAxis.AXIS_Y_P, HalfAxis.AXIS_X_N);
        }

        private void GetSizeXY(double boxLength, double boxWidth, double palletLength, double palletWidth,
            out int maxSizeXLength, out int maxSizeXWidth, out int maxSizeYLength, out int maxSizeYWidth)
        {
            // get maximum number of box in length
            maxSizeXLength = (int)Math.Floor(palletLength / boxLength);
            // make sure that we can actually add one column of turned boxes
            while (boxWidth > palletLength - maxSizeXLength * boxLength)
                --maxSizeXLength;
            // get number of column of turned boxes
            maxSizeXWidth = (int)Math.Floor((palletLength - maxSizeXLength * boxLength) / boxWidth);
            // get maximum number in width
            // for boxes with length aligned with pallet length
            maxSizeYLength = (int)Math.Floor(palletWidth / boxWidth);
            // for turned boxes
            maxSizeYWidth = (int)Math.Floor(palletWidth / boxLength);
        }
        #endregion
    }
}
