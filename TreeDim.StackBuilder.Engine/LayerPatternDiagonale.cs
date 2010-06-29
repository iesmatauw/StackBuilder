#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class LayerPatternDiagonale : LayerPattern
    {
        #region Implementation of LayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Diagonale"; }
        }

        public override void GetLayerDimensions(Layer layer, out double actualLength, out double actualWidth)
        {
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int iStep = 0, maxSizeXLength = 0, maxSizeXWidth = 0, maxSizeYLength = 0, maxSizeYWidth = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out iStep, out maxSizeXLength, out maxSizeXWidth, out maxSizeYLength, out maxSizeYWidth);

            actualLength = maxSizeXLength * boxLength + maxSizeXWidth * boxWidth;
            if (maxSizeYWidth >= iStep)
                actualLength = Math.Max(actualLength, iStep * boxLength);
            actualWidth = maxSizeYWidth * boxWidth + maxSizeYLength * boxLength;
            if (maxSizeXLength >= iStep)
                actualWidth = Math.Max(actualWidth, iStep * boxWidth);

        }
        public override void GenerateLayer(Layer layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int maxSizeXLength = 0, maxSizeXWidth = 0, maxSizeYLength = 0, maxSizeYWidth = 0, iStep = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out iStep, out maxSizeXLength, out maxSizeXWidth, out maxSizeYLength, out maxSizeYWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            for (int i = 0; i < iStep; ++i)
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
                    , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);

                // along X
                for (int ix = 0; ix < iStep-1-i; ++ix)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase + boxWidth + spaceX + ix * (boxLength + spaceX)
                        , yBase)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);

                int maxY = (int)Math.Floor(actualWidth / boxWidth); 
                double ySpaceNew = (actualWidth - boxWidth * maxY) / (maxY-1);
                for (int ix = iStep-1-i; ix < maxSizeXLength-i; ++ix)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase + boxWidth + spaceX + ix * (boxLength + spaceX)
                        , offsetY + i * (boxWidth + ySpaceNew))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);

                // along Y
                for (int iy = 0; iy < iStep-1-i; ++iy)
                    AddPosition(
                        layer
                        , new Vector2D(
                        xBase
                        , yBase + boxLength + spaceY + iy * (boxWidth + spaceY))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);

                int maxX = (int)Math.Floor(actualLength / boxLength);
                double xSpaceNew = (actualLength - boxLength * maxX) / (maxX-1);
                for (int iy = iStep-1-i; iy < maxSizeYWidth-i; ++iy)
                    AddPosition(
                        layer
                        , new Vector2D(
                        offsetX + i * (boxLength + xSpaceNew)
                        , yBase + boxLength + spaceY + iy * (boxWidth + spaceY))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
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
            out int iStep, out int maxSizeXLength, out int maxSizeXWidth, out int maxSizeYLength, out int maxSizeYWidth)
        {
            iStep = Math.Min(
                (int)Math.Floor( (palletLength - boxWidth) / boxLength )
                , (int)Math.Floor((palletWidth - boxLength) / boxWidth)
                ) + 1;

            maxSizeXWidth = boxWidth < palletLength ? 1 : 0;
            maxSizeXLength = (int)Math.Floor((palletLength - boxWidth) / boxLength);

            maxSizeYLength = boxLength < palletWidth ? 1 : 0;
            maxSizeYWidth = (int)Math.Floor((palletWidth - boxLength) / boxWidth);
        }
        #endregion
    }
}
