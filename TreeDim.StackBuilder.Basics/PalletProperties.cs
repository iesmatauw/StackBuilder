using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Basics
{
    public class PalletProperties
    {
        #region Data members
        string _name;
        double _length, _width, _height;
        #endregion

        #region Public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            return string.Format("PalletProperties => Length {0} Width {0} Height {0}", _length, _width, _height) ;
        }
        #endregion
    }
}
