#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class HCylinderLoadPatternPyramid : HCylinderLoadPattern
    {
        #region Implementation of HCylinderLoadPattern abstract properties
        public override string Name
        {
            get { return "Pyramid"; }
        }
        public override bool CanBeSwapped
        {
            get { return true; }
        }
        public override void Generate(CylLoad load, int maxCount, double actualLength, double actualWidth, double maxHeight)
        {
            load.Clear();

            double palletLength = GetPalletLength(load);
            double palletWidth = GetPalletWidth(load);
            double radius = load.CylinderRadius;
            double diameter = 2.0 * load.CylinderRadius;
            double length = load.CylinderLength;

            int sizeX = Convert.ToInt32(Math.Floor(GetPalletLength(load) / load.CylinderLength));
            int sizeY = Convert.ToInt32(Math.Floor(GetPalletWidth(load) / (2.0 * load.CylinderRadius)));

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            for (int iLayer = 0; iLayer < sizeX; ++iLayer)
            {
                if ((iLayer+1) * diameter > maxHeight)
                    return;

                for (int j = 0; j < sizeY-iLayer; ++j)
                {
                    for (int i = 0; i < sizeX; ++i)
                    {
                        AddPosition(
                            load
                            , new CylPosition(
                                new Vector3D(
                                    offsetX + i * length
                                    , offsetY + (1 + iLayer) * radius + j * diameter
                                    , radius + iLayer * diameter)
                                , HalfAxis.HAxis.AXIS_X_P)
                            );
                        if (maxCount > 0 && load.Count >= maxCount)
                            return;
                    }
                }
                ++iLayer;
            }
        }
        #endregion
    }
}
