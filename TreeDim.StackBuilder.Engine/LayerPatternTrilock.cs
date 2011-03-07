#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class LayerPatternTrilock : LayerPattern
    {
        #region Implementation of LayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Trilock"; }
        }

        public override void GetLayerDimensions(Layer layer, out double actualLength, out double actualWidth)
        {
            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int sizeX_area1 = 0, sizeY_area1 = 0, sizeX_area2 = 0, sizeY_area2 = 0, sizeX_area3 = 0, sizeY_area3 = 0;
            GetOptimalSizeArea1(boxLength, boxWidth, palletLength, palletWidth, out sizeX_area1, out sizeY_area1);
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth, sizeX_area1, sizeY_area1
                , out sizeX_area2, out sizeY_area2, out sizeX_area3, out sizeY_area3);

            actualLength = Math.Max(sizeX_area2 * boxLength, sizeX_area1 * boxWidth + sizeX_area3 * boxLength);
            actualWidth = Math.Max(sizeY_area1 * boxLength, sizeY_area3 * boxWidth) + sizeY_area2 * boxWidth;

            Debug.Assert(actualLength <= palletLength);
            Debug.Assert(actualWidth <= palletWidth);
        }

        public override void GenerateLayer(Layer layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double boxLength = layer.BoxLength;
            double boxWidth = layer.BoxWidth;
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);

            int sizeX_area1 = 0, sizeY_area1 = 0, sizeX_area2 = 0, sizeY_area2 = 0, sizeX_area3 = 0, sizeY_area3 = 0;
            GetOptimalSizeArea1(boxLength, boxWidth, palletLength, palletWidth, out sizeX_area1, out sizeY_area1);
            GetSizeXY(boxLength, boxWidth, palletLength, palletWidth, sizeX_area1, sizeY_area1
                , out sizeX_area2, out sizeY_area2, out sizeX_area3, out sizeY_area3);

            // compute offsets
            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            // compute spaces
            double spaceX_area1 = sizeX_area1 + sizeX_area3 > 1 ? (actualLength - (boxWidth * sizeX_area1 + boxLength * sizeX_area3)) / (sizeX_area1 + sizeX_area3 - 1) : 0.0;
            double spaceX_area2 = sizeX_area2 > 1 ? (actualLength - sizeX_area2 * boxLength) / (sizeX_area2 - 1) : 0.0;
            double spaceX_area3 = spaceX_area1;

            double spaceY_area1 = 0.0, spaceY_area2 = 0.0, spaceY_area3 = 0.0;
            if (sizeY_area1 * boxLength > sizeY_area3 * boxWidth)
            {
                spaceY_area1 = sizeY_area1 + sizeY_area2 > 1 ? (actualWidth - sizeY_area1 * boxLength - sizeY_area2 * boxWidth) / (sizeY_area1 + sizeY_area2 - 1) : 0.0;
                spaceY_area2 = spaceY_area1;
                spaceY_area3 = (sizeY_area1 * (boxLength + spaceY_area1) - sizeY_area3 * boxWidth) / sizeY_area3;
            }
            else
            {
                spaceY_area3 = sizeY_area2 + sizeY_area3 > 1 ? (actualWidth - (sizeY_area2 + sizeY_area3) * boxWidth) / (sizeY_area2 + sizeY_area3 - 1) : 0.0;
                spaceY_area2 = spaceY_area3;
                spaceY_area1 = (sizeY_area3 * (boxWidth + spaceY_area3) - sizeY_area1 * boxLength) / sizeY_area1;
            }
            // area1
            for (int i = 0; i < sizeX_area1; ++i)
                for (int j = 0; j < sizeY_area1; ++j)
                    AddPosition(layer
                        , new Vector2D(
                            offsetX + boxWidth + i * (boxWidth + spaceX_area1)
                            , offsetY + j * (boxLength + spaceY_area1))
                        , HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N);
            // area2
            for (int i = 0; i < sizeX_area2; ++i)
                for (int j = 0; j < sizeY_area2; ++j)
                    AddPosition(layer
                        , new Vector2D(
                            offsetX + i * (boxLength + spaceX_area2)
                            , actualWidth + offsetY - (j + 1) * boxWidth - j * spaceY_area2)
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);
            // area3
            for (int i = 0; i < sizeX_area3; ++i)
                for (int j = 0; j < sizeY_area3; ++j)
                    AddPosition(layer
                        , new Vector2D(
                            offsetX + sizeX_area1 * (boxWidth + spaceX_area1) + i * (boxLength + spaceX_area3)
                            , offsetY + j * (boxWidth + spaceY_area3))
                        , HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P);

        }

        public override int GetNumberOfVariants(Layer layer)
        {
            return 1;
        }

        public override bool CanBeSwaped { get { return true; } }
        public override bool CanBeInverted { get { return true; } }
        #endregion

        #region Helpers
        private int GetOptimalSizeArea1(double boxLength, double boxWidth, double palletLength, double palletWidth
            , out int sizeX_area1Opt, out int sizeY_area1Opt)
        {
            int iMaxSizeX_area1 = (int)Math.Floor((palletLength - boxLength) / boxWidth);
            int iMaxSizeY_area1 = (int)Math.Floor((palletWidth - boxWidth) / boxLength);

            int iMax = 0;
            sizeX_area1Opt = 0; sizeY_area1Opt = 0;
            for (int i = 1; i <= iMaxSizeX_area1; ++i)
                for (int j = 1; j <= iMaxSizeY_area1; ++j)
                {
                    int sizeX_area2, sizeY_area2, sizeX_area3, sizeY_area3;
                    int boxNumber = GetSizeXY(boxLength, boxWidth, palletLength, palletWidth
                        , i, j, out sizeX_area2, out sizeY_area2, out sizeX_area3, out sizeY_area3);

                    if (boxNumber >= iMax)
                    {
                        sizeX_area1Opt = i; sizeY_area1Opt = j;
                        iMax = boxNumber;
                    }
                }
            /*
                        if (0 == sizeX_area1Opt)
                            _log.Debug("sizeX_area1Opt == 0");
                        if (0 == sizeY_area1Opt)
                            _log.Debug("sizeY_area1Opt == 0");
            */
            return iMax;
        }
        private int GetSizeXY(double boxLength, double boxWidth, double palletLength, double palletWidth
            , int sizeX_area1, int sizeY_area1
            , out int sizeX_area2, out int sizeY_area2
            , out int sizeX_area3, out int sizeY_area3)
        {
            sizeX_area2 = (int)Math.Floor(palletLength / boxLength);
            sizeY_area2 = (int)Math.Floor((palletWidth - sizeY_area1 * boxLength) / boxWidth);

            sizeX_area3 = (int)Math.Floor((palletLength - sizeX_area1 * boxWidth) / boxLength);
            sizeY_area3 = (int)Math.Floor((palletWidth - sizeY_area2 * boxWidth) / boxWidth);

            return sizeX_area1 * sizeY_area1 + sizeX_area2 * sizeY_area2 + sizeX_area3 * sizeY_area3;
        }
        #endregion
    }
}
