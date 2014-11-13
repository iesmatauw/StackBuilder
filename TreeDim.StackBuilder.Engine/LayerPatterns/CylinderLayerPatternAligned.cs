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
        public override bool CanBeSwapped
        {
            get { return false; }
        }
        public override void GetLayerDimensions(LayerCyl layer, out double actualLength, out double actualWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double diameter = 2.0 * layer.CylinderRadius;

            actualLength = Math.Floor(palletLength / diameter) * diameter; ;
            actualWidth = Math.Floor(palletWidth / diameter) * diameter;
        }
        public override void GenerateLayer(LayerCyl layer, double actualLength, double actualWidth)
        {
            layer.Clear();

            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = layer.CylinderRadius;
            double diameter = 2.0 * layer.CylinderRadius;

            int sizeX = (int)Math.Floor(palletLength / diameter);
            int sizeY = (int)Math.Floor(palletWidth / diameter);

            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            double spaceX = sizeX > 1 ? (actualLength - sizeX * diameter) / (sizeX - 1) : 0.0;
            double spaceY = sizeY > 1 ? (actualWidth - sizeY * diameter) / (sizeY - 1) : 0.0;

            for (int j=0; j<sizeY; ++j)
                for (int i=0; i<sizeX; ++i)
                    AddPosition( layer, new Vector2D(
                        radius + offsetX + i * (diameter + spaceX)
                        , radius + offsetY + j * (diameter + spaceY)
                        ));
                     
        }
        #endregion
    }
}
