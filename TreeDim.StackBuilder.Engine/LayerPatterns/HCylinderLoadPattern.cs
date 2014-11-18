#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using TreeDim.StackBuilder.Basics;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Engine
{
    #region HCylinderLoadPattern
    internal abstract class HCylinderLoadPattern
    {
        #region Data members
        private bool _swapped = false;
        protected static readonly ILog _log = LogManager.GetLogger(typeof(HCylinderLoadPattern));
        #endregion

        #region Constructor
        public HCylinderLoadPattern() { }
        #endregion

        #region Abstract methods
        abstract public string Name { get; }
        abstract public bool CanBeSwapped { get; }
        abstract public void Generate(CylLoad layer, int maxCount, double actualLength, double actualWidth, double maxHeight);
        #endregion

        #region Public properties
        public bool Swapped
        {
            get { return _swapped; }
            set { _swapped = value; }
        }
        #endregion

        #region Public methods
        public virtual void GetDimensions(CylLoad load, int maxCount, out double length, out double width)
        {
            length = 0.0; width = 0.0;
            // using XP direction
            int noX = Convert.ToInt32(Math.Floor(GetPalletLength(load) / load.CylinderLength));
            int noY = Convert.ToInt32(Math.Floor(GetPalletWidth(load) / (2.0 * load.CylinderRadius)));

            if (-1 != maxCount && maxCount < noX * (noY-1))
            {
                if (maxCount < noX)
                {
                    noX = maxCount;
                    noY = 1;
                }
                else
                    noY = maxCount / noX + 1;
            }
            length = noX * load.CylinderLength;
            width = 2.0 * noY * load.CylinderRadius;
        }
        #endregion

        #region Private methods
        protected double GetPalletLength(CylLoad load)
        {
            if (!_swapped)
                return load.PalletLength;
            else
                return load.PalletWidth;
        }
        protected double GetPalletWidth(CylLoad load)
        {
            if (!_swapped)
                return load.PalletWidth;
            else
                return load.PalletLength;
        }
        public void AddPosition(CylLoad load, CylPosition pos)
        {
            Matrix4D matRot = Matrix4D.Identity;
            Vector3D vTranslation = Vector3D.Zero;

            if (_swapped)
            {
                matRot = new Matrix4D(
                    0.0, -1.0, 0.0, 0.0
                    , 1.0, 0.0, 0.0, 0.0
                    , 0.0, 0.0, 1.0, 0.0
                    , 0.0, 0.0, 0.0, 1.0
                    );
                vTranslation = new Vector3D(load.PalletLength, 0.0, 0.0);

                matRot.M14 = vTranslation[0];
                matRot.M24 = vTranslation[1];
                matRot.M34 = vTranslation[2];
            }

            load.Add(pos.Transform(new Transform3D(matRot)));


            /*
            Transform3D transfRot = new Transform3D(matRot);
            Transform3D transfRotTranslation = new Transform3D(matRot);
            Vector3D vPositionSwapped = transfRotTranslation.transform(pos.XYZ);
            Vector3D vDirSwapped = transfRotTranslation.transformRot(HalfAxis.ToVector3D(pos.Direction));
            load.Add(new CylPosition(vPositionSwapped, HalfAxis.ToHalfAxis(vDirSwapped)));
            */ 
        }
        #endregion
    }
    #endregion
}
