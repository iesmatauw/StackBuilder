#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public abstract class BProperties : ItemBase
    {
        #region Data members
        protected double _length, _width;
        private double _weight;
        #endregion

        #region Constructor
        public BProperties(Document document)
            : base(document)
        { 
        }
        public BProperties(Document document, string name, string description)
            : base(document, name, description)
        { 
        }
        #endregion

        #region Public properties
        public double Length
        {
            get { return _length; }
            set { _length = value; Modify(); }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; Modify(); }
        }
        abstract public double Height {get; set;}
        public double Volume
        {
            get { return _length * _width * Height; }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; Modify(); }
        }
        #endregion

        #region Public methods
        abstract public Color[] Colors { get; }
        abstract public void SetColor(Color color);
        abstract public Color GetColor(HalfAxis.HAxis axis);

        public double Dimension(HalfAxis.HAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                case HalfAxis.HAxis.AXIS_X_P:
                    return _length;
                case HalfAxis.HAxis.AXIS_Y_N:
                case HalfAxis.HAxis.AXIS_Y_P:
                    return _width;
                case HalfAxis.HAxis.AXIS_Z_N:
                case HalfAxis.HAxis.AXIS_Z_P:
                    return Height;
                default:
                    return 0.0;
            }
        }
        abstract public bool IsBundle { get; }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("BProperties => Length = {0}      Width = {1}     Height = {2}", _length, _width, Height) );
            return sBuilder.ToString();
        }
        #endregion
    }
}
