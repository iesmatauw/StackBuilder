#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class CylinderLayerPatternAligned : CylinderLayerPattern
    {
        #region Implementation of CylinderLayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Aligned"; }
        }
        public override void GetLayerDimensions(CylinderLayer layer, out double actualLength, out double actualWidth)
        {
            double palletLength = layer.PalletLength;
            double palletWidth = layer.PalletWidth;
            double radius = layer.CylinderRadius;

            actualLength = Math.Floor(palletLength / radius) * radius; ;
            actualWidth = Math.Floor(palletWidth / radius) * radius;
        }
        public override void GenerateLayer(CylinderLayer layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double palletLength = layer.PalletLength;
            double palletWidth = layer.PalletWidth;
            double radius = layer.CylinderRadius;

            int sizeX = (int)Math.Floor(palletLength / radius);
            int sizeY = (int)Math.Floor(palletWidth / radius);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            double spaceX = sizeX > 1 ? (actualLength - sizeX * radius) / (sizeX - 1) : 0.0;
            double spaceY = sizeY > 1 ? (actualWidth - sizeY * radius) / (sizeY - 1) : 0.0;

            for (int i=0; i<sizeX; ++i)
                for (int j=0; j<sizeY; ++j)
                    layer.Add( new Vector2D(
                        offsetX + i * (radius + spaceX)
                        , offsetY + j * (radius + spaceY)
                        ));
                     
        }
        #endregion
    }
}
