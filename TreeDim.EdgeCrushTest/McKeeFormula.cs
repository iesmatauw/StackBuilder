#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace TreeDim.EdgeCrushTest
{
    public class McKeeFormula
    {
        #region Formula implementation
        public void FormulaOption1(double L, double B, double H, double T, double ECT, double kHumid, double kJStock, ref double k)
        {
            Formula(L / 1000.0, B / 1000.0, H / 1000.0, T / 1000.0, ECT, kHumid, kJStock, ref k);
            k = k * 1000 / 9.81;    //kN -> kg
        }

        public void Formula(double L, double B, double H, double T, double ECT, double kHumid, double kJStock, ref double k)
        { 
            double denom = 0.0;

            k = 5.87 * ECT * Math.Pow(2.0 * (L + B) , 0.4924) * Math.Pow(T, 0.5076);
            k = k * kHumid * kJStock;
        }
        #endregion
    }
}
