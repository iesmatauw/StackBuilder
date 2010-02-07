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

        public override void GetLayerDimensions(Layer layer, out double actualLength, out double actualWidth)
        {
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int maxSizeXLength = 0, maxSizeXWidth = 0, maxSizeYLength = 0, maxSizeYWidth = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out maxSizeXLength, out maxSizeXWidth, out maxSizeYLength, out maxSizeYWidth);

            actualLength = maxSizeXLength * boxLength + maxSizeXWidth * boxWidth;
            actualWidth = maxSizeYWidth * boxWidth +  maxSizeYLength * boxLength;
        }

        public override void GenerateLayer(Layer layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int maxSizeXLength = 0, maxSizeXWidth = 0, maxSizeYLength = 0, maxSizeYWidth = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out maxSizeXLength, out maxSizeXWidth, out maxSizeYLength, out maxSizeYWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);


            for (int i = 0; i < Math.Min(maxSizeXLength + maxSizeXWidth, maxSizeYWidth + maxSizeYLength); ++i)
            {
                double spaceX = maxSizeXLength + maxSizeXWidth > 1
                    ? (actualLength - maxSizeXLength * boxLength - maxSizeXWidth * boxWidth) / (maxSizeXLength + maxSizeXWidth - 1)
                    : 0.0;
                double spaceY = maxSizeYLength + maxSizeYWidth > 1
                    ? (actualWidth - maxSizeYWidth * boxWidth - maxSizeYLength * boxLength) / (maxSizeYLength + maxSizeYWidth - 1)
                    : 0.0;
                System.Diagnostics.Debug.Assert(spaceX >= 0.0);
                System.Diagnostics.Debug.Assert(spaceY >= 0.0);

                double xBase = offsetX + i * (boxLength + spaceX);
                double yBase = offsetY + i * (boxWidth + spaceY);
                // first box
                AddPosition(
                    layer
                    , new Vector2D(xBase + boxWidth, yBase)
                    , HalfAxis.AXIS_Y_P, HalfAxis.AXIS_X_N);

                // along X
                for (int ix = 0; ix < maxSizeXLength - i; ++ix)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase + boxWidth + spaceX + ix * (boxLength + spaceX)
                        , yBase)
                        , HalfAxis.AXIS_X_P, HalfAxis.AXIS_Y_P);

                // along Y
                for (int iy = 0; iy < maxSizeYWidth - i; ++iy)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase
                        , yBase + boxLength + spaceY + iy * (boxWidth + spaceY))
                        , HalfAxis.AXIS_X_P, HalfAxis.AXIS_Y_P);
            }
        }

        public override int GetNumberOfVariants(Layer layer)
        {
            return 1;
        }
        public override bool CanBeSwaped
        {
            get { return true; }
        }
        #endregion

        #region Helpers
        private void GetSizeXY(double boxLength, double boxWidth, double palletLength, double palletWidth,
            out int maxSizeXLength, out int maxSizeXWidth, out int maxSizeYLength, out int maxSizeYWidth)
        {
            maxSizeXWidth = boxWidth < palletLength ? 1 : 0;
            maxSizeXLength = (int)Math.Floor((palletLength - boxWidth) / boxLength);

            maxSizeYLength = boxLength < palletWidth ? 1 : 0;
            maxSizeYWidth = (int)Math.Floor((palletWidth - boxLength) / boxWidth);
        }
        #endregion
    }
}
