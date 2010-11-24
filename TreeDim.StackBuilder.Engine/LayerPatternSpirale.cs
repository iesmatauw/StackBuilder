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

            int sizeXLength = 0, sizeXWidth = 0, sizeYLength = 0, sizeYWidth = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out sizeXLength, out sizeXWidth, out sizeYLength, out sizeYWidth);

            actualLength = sizeXLength * boxLength + sizeXWidth * boxWidth;
            actualWidth = sizeYWidth * boxWidth + sizeYLength * boxLength;
        }

        public override void GenerateLayer(Layer layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            throw new NotImplementedException();
/*
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int maxSizeXLength = 0, maxSizeXWidth = 0, maxSizeYLength = 0, maxSizeYWidth = 0;
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                , out maxSizeXLength, out maxSizeXWidth, out maxSizeYLength, out maxSizeYWidth);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            double spaceX = maxSizeXLength + maxSizeXWidth > 1 ? (actualLength - (maxSizeXLength * boxLength + maxSizeXWidth * boxWidth)) / (maxSizeXLength + maxSizeXWidth - 1) : 0.0;
            double spaceY = maxSizeYLength + maxSizeYWidth > 1 ? (actualWidth - (maxSizeYLength * boxWidth + maxSizeYWidth * boxLength)) / (maxSizeYLength + maxSizeYWidth - 1) : 0.0;

            // length aligned boxes
            for (int i=0; i<maxSizeXLength; ++i)
                for (int j = 0; j < maxSizeYLength; ++j)
                {
                    AddPosition(
                        layer
                        , new Vector2D(
                            offsetX + i * (boxLength + spaceX)
                            , offsetY + j * (boxWidth + spaceY))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                    AddPosition(
                        layer
                        , new Vector2D(
                            palletLength - offsetX - boxLength - i * (boxLength + spaceX)
                            , palletWidth - offsetY - boxWidth - i * (boxWidth + spaceY))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
                }
            // width aligned boxes
            for (int i=0; i<maxSizeXWidth; ++i)
                for (int j = 0; j < maxSizeYWidth; ++j)
                {
                    AddPosition(
                        layer
                        , new Vector2D(
                            offsetX + maxSizeXWidth * (boxLength + spaceX) + boxWidth + i * (boxWidth + spaceX)
                            , offsetY + maxSizeYLength * (boxWidth + spaceY) + j * (boxLength + spaceY))
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                    AddPosition(
                        layer
                        , new Vector2D(
                            palletLength - offsetX - maxSizeXWidth * (boxLength + spaceX) - boxWidth - i * (boxWidth + spaceX)
                            , palletWidth - offsetY - maxSizeYLength * (boxWidth + spaceY) - j * (boxLength + spaceY))
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
                }
*/ 
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
            out int sizeXLength, out int sizeXWidth, out int sizeYLength, out int sizeYWidth)
        {
            // get optimum combination of sizeXLength, sizeYLength
            int sizeXLengthMax = (int)Math.Floor((palletLength - boxWidth) / boxLength);
            int sizeYLengthMax = (int)Math.Floor((palletWidth - boxLength) / boxWidth);
            int iBoxNumberMax = 0;
            int sizeXLengthOpt = 1, sizeYLengthOpt = 1;

            for (int iSizeXLength = 1; iSizeXLength <= sizeXLengthMax; ++iSizeXLength)
                for (int iSizeYLength = 1; iSizeYLength <= sizeYLengthMax; ++iSizeYLength)
                {
                    int iBoxNumber = GetBoxNumber(iSizeXLength, iSizeYLength, boxLength, boxWidth, palletLength, palletWidth);
                    if (iBoxNumber >= iBoxNumberMax)
                    {
                        sizeXLengthOpt = iSizeXLength;
                        sizeYLengthOpt = iSizeYLength;
                        iBoxNumberMax = iBoxNumber;
                    }
                }
            // compute corresponding sizeXLength / sizeXWidth / sizeYLength / sizeYWidth
            sizeXLength = sizeXLengthOpt;
            sizeYLength = sizeYLengthOpt;
            sizeXWidth = (int)Math.Floor((palletLength - sizeXLength * boxLength) / boxWidth);
            sizeYWidth = (int)Math.Floor((palletWidth - sizeYLength * boxWidth) / boxLength);
        }

        private int GetBoxNumber(int sizeXLength, int sizeYLength,
            double boxLength, double boxWidth, double palletLength, double palletWidth)
        {
            // check possibility
            if ( (sizeXLength * boxLength > 0.5 * palletLength) && (sizeYLength * boxWidth > 0.5 * palletWidth) )
                return 0;
            // combination is possible compute number of boxes
            int sizeXWidth = (int)Math.Floor((palletLength - sizeXLength * boxLength) / boxWidth);
            int sizeYWidth = (int)Math.Floor((palletWidth - sizeYLength * boxWidth) / boxLength);
            return 2 * (sizeXLength * sizeYLength + sizeXWidth * sizeYWidth);
        }
        #endregion
    }
}
