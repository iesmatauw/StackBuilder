#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Sharp3D.Math.Core;
using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    class CylinderLayerPatternStaggered : CylinderLayerPattern
    {
        #region Implementation of CylinderLayerPattern abstract properties and methods
        public override string Name
        {
            get { return "Staggered"; }
        }
        public override bool CanBeSwaped
        {
            get { return true; }
        }
        public override void GetLayerDimensions(LayerCyl layer, out double actualLength, out double actualWidth)
        {
            int firstRowLength = 0; int secondRowLength = 0; int rowNumber = 0;
            ComputeRowNumberAndLength(layer
                , out firstRowLength, out secondRowLength, out rowNumber
                , out actualLength, out actualWidth); 
        }

        public override void GenerateLayer(LayerCyl layer, double actualLength, double actualWidth)
        {
            layer.Clear();
            int firstRowLength = 0; int secondRowLength = 0; int rowNumber = 0;
            if (!ComputeRowNumberAndLength(layer
                , out firstRowLength, out secondRowLength, out rowNumber
                , out actualLength, out actualWidth))
                return;

            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = layer.CylinderRadius;
            double offsetX = 0.5 * (palletLength - actualLength);
            double offsetY = 0.5 * (palletWidth - actualWidth);

            for (int i = 0; i < rowNumber; ++i)
            {
                double y = (offsetY + radius) + i * radius * Math.Sqrt(3.0);
                for (int j = 0; j < (i % 2 == 0 ? firstRowLength : secondRowLength); ++j)
                    AddPosition(layer, new Vector2D(offsetX + ((i % 2 == 0) ? 0.0 : radius) + j * 2.0 * radius + radius, y));
            }
        }
        #endregion

        #region Helpers
        private bool ComputeRowNumberAndLength(LayerCyl layer
            , out int firstRowLength, out int secondRowLength, out int rowNumber
            , out double actualLength, out double actualWidth)
        {
            double palletLength = GetPalletLength(layer);
            double palletWidth = GetPalletWidth(layer);
            double radius = layer.CylinderRadius;
            double diameter = 2.0 * layer.CylinderRadius;

            // initialize out parameters
            firstRowLength = 0; secondRowLength = 0; rowNumber = 0;
            actualLength = 0.0; actualWidth = 0.0;
            // sanity check
            if (diameter > palletLength || diameter > palletWidth)
                return false;
            // first row number
            firstRowLength = (int)Math.Floor(palletLength / diameter);
            // second row
            if ((firstRowLength + 0.5) * diameter < palletLength)
            {
                secondRowLength = firstRowLength;
                actualLength = (firstRowLength + 0.5) * diameter;
            }
            else
            {
                secondRowLength = firstRowLength - 1;
                actualLength = firstRowLength * diameter;
            }
            // numbers of rows
            rowNumber = (int)Math.Floor(1 + (palletWidth / radius - 2.0) / Math.Sqrt(3.0));
            actualWidth = (2.0 + (rowNumber - 1) * Math.Sqrt(3.0)) * radius;
            return true;
        }
        #endregion
    }
}
