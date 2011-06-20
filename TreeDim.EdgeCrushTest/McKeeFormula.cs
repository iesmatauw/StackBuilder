#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.EdgeCrushTest
{
    public class McKeeFormula
    {
        #region Formula implementation
        public static void FormulaOption1(double L, double B, double H, double T, double ECT, double kHumid, double kJStock, ref double k)
        {
            Formula(L / 1000.0, B / 1000.0, H / 1000.0, T / 1000.0, ECT, kHumid, kJStock, ref k);
            k = k * 1000 / 9.81;    //kN -> kg
        }

        public static void Formula(double L, double B, double H, double T, double ECT, double kHumid, double kJStock, ref double k)
        { 
            k = 5.87 * ECT * Math.Pow(2.0 * (L + B) , 0.4924) * Math.Pow(T, 0.5076);
            k = k * kHumid * kJStock;
        }

        public static Dictionary<string, double> HumidityCoefDictionnary
        {
            get
            {
                Dictionary<string, double> humidityCoefs = new Dictionary<string, double>()
                {
                    {"0-35%", 1.1}
                    , {"36-45%", 1.1}
                    , {"46-55%", 1.0}
                    , {"56-65%", 0.9}
                    , {"66-75%", 0.8}
                    , {"76-85%", 0.7}
                    , {"86-100%", 0.5}
                };
                return humidityCoefs;
            }
        }

        public static Dictionary<string, double> JStockCoefDictionnary
        {
            get
            {
                Dictionary<string, double> jStockCoef = new Dictionary<string, double>()
                {
                    {"0 day", 1.0}
                    , {"1-3 days", 0.7}
                    , {"4-10 days", 0.65}
                    , {"11-30 days", 0.6}
                    , {"1-2 monthes", 0.55}
                    , {"2-3 monthes", 0.55}
                    , {"3-4 monthes", 0.5}
                    , {"more than 4 monthes", 0.45}
                };
                return jStockCoef;
            }
        }
        #endregion
    }
}
