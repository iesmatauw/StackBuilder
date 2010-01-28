#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using TreeDim.StackBuilder.Basics;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    /// <summary>
    /// Layer pattern abstract class
    /// </summary>
    internal abstract class LayerPattern
    {
        #region Abstract methods
        abstract public string Name { get; }
        abstract public void GetLayerDimensions(Layer layer, out double actualLength, out double actualWidth);
        abstract public void GenerateLayer(Layer layer, double actualLength, double actualWidth);
        abstract public int GetNumberOfVariants(Layer layer);
        abstract public bool CanBeSwaped { get; }
        #endregion

        #region Public properties
        public int VariantIndex
        {
            get { return _variantIndex; }
            set { _variantIndex = value; }
        }
        public bool Swaped
        {
            get { return _swaped; }
            set { _swaped = value; }
        }
        #endregion

        #region Private methods
        protected double GetPalletLength(Layer layer)
        {
            if (!_swaped)
                return layer.PalletLength;
            else
                return layer.PalletWidth;
        }

        protected double GetPalletWidth(Layer layer)
        { 
            if (!_swaped)
                return layer.PalletWidth;
            else
                return layer.PalletLength;        
        }

        public void AddPosition(Layer layer, Vector2D vPosition, HalfAxis lengthAxis, HalfAxis widthAxis)
        {
            if (!_swaped)
            {
                layer.AddPosition(vPosition, lengthAxis, widthAxis);
            }
            else
            {
                Matrix4D matRot = new Matrix4D(0.0, -1.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0, 1.0);
                Transform3D transfRot = new Transform3D(matRot);
                HalfAxis lengthAxisSwaped = StackBuilder.Basics.Convert.ToHalfAxis(transfRot.transform(StackBuilder.Basics.Convert.ToVector3D(lengthAxis)));
                HalfAxis widthAxisSwaped = StackBuilder.Basics.Convert.ToHalfAxis(transfRot.transform(StackBuilder.Basics.Convert.ToVector3D(widthAxis)));

                matRot.M14 = layer.PalletLength;
                Transform3D transfRotTranslation = new Transform3D(matRot);
                Vector3D vPositionSwapped = transfRotTranslation.transform(new Vector3D(vPosition.X, vPosition.Y, 0.0));

                layer.AddPosition(new Vector2D(vPositionSwapped.X, vPositionSwapped.Y), lengthAxisSwaped, widthAxisSwaped);
            }
        }
        #endregion

        #region Data members
        private int _variantIndex = 0;
        bool _swaped = false;
        #endregion
    }
}
