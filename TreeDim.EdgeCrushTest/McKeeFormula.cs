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
        #endregion

        #region Coefficient dictionnary
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
                    {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_0DAY, 1.0}
                    , {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_1_3DAYS, 0.7}
                    , {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_4_10DAYS, 0.65}
                    , {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_11_30DAYS, 0.6}
                    , {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_1_2MONTHES, 0.55}
                    , {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_2_3MONTHES, 0.55}
                    , {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_3_4MONTHES, 0.5}
                    , {TreeDim.EdgeCrushTest.Resource.STORAGEDURATION_4_MONTHES, 0.45}
                };
                return jStockCoef;
            }
        }
        #endregion
    }
}
