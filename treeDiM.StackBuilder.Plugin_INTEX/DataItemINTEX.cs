#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace treeDiM.StackBuilder.Plugin
{
    #region DataItemINTEX
    public class DataItemINTEX
    {
        #region Data members
        public string _ref;
        public string _description;
        public string _UPC;
        public int _PCB;
        public string _gencode;
        public double _length, _width, _height;
        public double _weight;
        #endregion
        #region Public properties
        public double[] OuterDimensions
        {
            get
            {
                double[] dimItem = new double[3];
                dimItem[0] = _length;
                dimItem[1] = _width;
                dimItem[2] = _height;
                return dimItem;
            }
        }
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0} - {1}", _ref.PadRight(8), _description);
        }
        #endregion
    }
    #endregion

    #region DataPalletINTEX
    public class DataPalletINTEX
    {
        #region Data members
        public string _type;
        public double _length, _width, _height;
        public double _weight;
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0}", _type);
        }
        #endregion
    }
    #endregion

    #region DataCaseINTEX
    public class DataCaseINTEX
    {
        #region Data members
        public string _ref;
        public double _lengthExt, _widthExt, _heightExt, _lengthInt, _widthInt, _heightInt;
        public double _weight;
        #endregion
        #region Object override
        public override string ToString()
        {
            return string.Format("{0} - {1}*{2}*{3}", _ref, _lengthExt, _widthExt, _heightExt);
        }
        #endregion
        #region Properties
        public double[] OuterDimensions
        {
            get
            {
                double[] dimItem = new double[3];
                dimItem[0] = _lengthExt;
                dimItem[1] = _widthExt;
                dimItem[2] = _heightExt;
                return dimItem;
            }
        }
        public double[] InnerDimensions(double defThickness)
        {
            double eps = 1.0E-06;
            double[] dimItem = new double[3];
            dimItem[0] = _lengthInt > eps ? _lengthInt : _lengthExt - 2.0 * defThickness;
            dimItem[1] = _widthInt > eps ? _widthInt : _widthExt - 2.0 * defThickness;
            dimItem[2] = _heightInt > eps ? _heightInt : _heightExt - 2.0 * defThickness;
            return dimItem;
        }
        #endregion
        #region Helpers
        public bool CanContain(DataItemINTEX item, double thickness)
        {
            double[] dimItem = item.OuterDimensions;
            Array.Sort(dimItem);
            double[] dimCase = InnerDimensions(thickness);
            Array.Sort(dimCase);
            return dimItem[0] <= dimCase[0]
                && dimItem[1] <= dimCase[1]
                && dimItem[2] <= dimCase[2];
        }
        #endregion
    }
    #endregion
}
