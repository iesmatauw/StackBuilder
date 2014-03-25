#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cureos.Measures;
using Cureos.Measures.Quantities;

using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class UnitsManager
    {
        #region Enums
        public enum UnitSystem
        {
            UNIT_METRIC
            , UNIT_IMPERIAL
            , UNIT_US
        }
        #endregion

        #region Private constructor
        private UnitsManager()
        {
        }
        #endregion

        #region Instantiation
        public static UnitsManager Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new UnitsManager();
                return _instance;
            }
        }
        #endregion

        #region Current unit system 
        public static UnitSystem CurrentUnitSystem
        {
            get {   return Instance._currentUnitSystem; }
            set { Instance._currentUnitSystem = value; }
        }
        /// <summary>
        /// Length unit string
        /// </summary>
        public static string LengthUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC:    return "mm";
                    case UnitSystem.UNIT_IMPERIAL:  return "in";
                    case UnitSystem.UNIT_US:        return "in";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        /// <summary>
        /// Weight unit string
        /// </summary>
        public static string MassUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC:    return "kg";
                    case UnitSystem.UNIT_IMPERIAL:  return "lb";
                    case UnitSystem.UNIT_US:        return "lb";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        /// <summary>
        /// Volume unit string
        /// </summary>
        public static string VolumeUnitString
        {
            get
            {
                switch (Instance._currentUnitSystem)
                {
                    case UnitSystem.UNIT_METRIC:    return "l";
                    case UnitSystem.UNIT_IMPERIAL:  return "in³";
                    case UnitSystem.UNIT_US:        return "in³";
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }
        #endregion

        #region Data members
        private static UnitsManager _instance;
        private UnitSystem _currentUnitSystem;
        #endregion

        #region UI string transformations
        static public string ReplaceUnitStrings(string s)
        { 
            string sText = s;
            sText = sText.Replace("uLength", LengthUnitString);
            sText = sText.Replace("uMass", MassUnitString);
            sText = sText.Replace("uVolume", VolumeUnitString);
            return sText;
        }

        public static void AdaptUnitLabels(Control c)
        { 
            foreach (Control ctrl in c.Controls)
            {
                Label lb = ctrl as Label;
                if (null != lb)
                {
                    if (lb.Name.Contains("uLength")) lb.Text = LengthUnitString;
                    else if (lb.Name.Contains("uMass")) lb.Text = MassUnitString;
                    else if (lb.Name.Contains("uVolume")) lb.Text = VolumeUnitString;
                }
                GroupBox gb = ctrl as GroupBox;
                if (null != gb)
                {
                    AdaptUnitLabels(gb);
                }
            }
        }
        #endregion

        #region Conversions
        public static double FactorCubeLengthToVolume
        {
            get
            {
                switch (CurrentUnitSystem)
                {
                    case UnitsManager.UnitSystem.UNIT_METRIC: return 10.0E-06; //mm³ to l
                    case UnitsManager.UnitSystem.UNIT_IMPERIAL: return 1.0; // in³ to in³
                    case UnitsManager.UnitSystem.UNIT_US: return 1.0; // in³ to in³
                    default: throw new Exception("Invalid unit system!");
                }
            }
        }

        private static IUnit<Length> LengthUnitFromUnitSystem(UnitsManager.UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitsManager.UnitSystem.UNIT_METRIC: return Cureos.Measures.Quantities.Length.MilliMeter;
                case UnitsManager.UnitSystem.UNIT_IMPERIAL: return Cureos.Measures.Quantities.Length.Inch;
                case UnitsManager.UnitSystem.UNIT_US: return Cureos.Measures.Quantities.Length.Inch;
                default: throw new Exception("Invalid unit system!");
            }
        }
        private static IUnit<Mass> MassUnitFromUnitSystem(UnitsManager.UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitsManager.UnitSystem.UNIT_METRIC: return Cureos.Measures.Quantities.Mass.KiloGram;
                case UnitsManager.UnitSystem.UNIT_IMPERIAL: return Cureos.Measures.Quantities.Mass.Pound;
                case UnitsManager.UnitSystem.UNIT_US: return Cureos.Measures.Quantities.Mass.Pound;
                default: throw new Exception("Invalid unit system!");
            }
        }
        public static double ConvertLengthFrom(double value, UnitsManager.UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Length> measure = new StandardMeasure<Length>(value, LengthUnitFromUnitSystem(unitSystem));
                return measure.GetAmount(LengthUnitFromUnitSystem(CurrentUnitSystem));
            }
        }
        public static Vector2D ConvertLengthFrom(Vector2D value, UnitsManager.UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Length> measureX = new StandardMeasure<Length>(value.X, LengthUnitFromUnitSystem(unitSystem));
                StandardMeasure<Length> measureY = new StandardMeasure<Length>(value.Y, LengthUnitFromUnitSystem(unitSystem));
                return new Vector2D(
                    measureX.GetAmount(LengthUnitFromUnitSystem(CurrentUnitSystem))
                    , measureY.GetAmount(LengthUnitFromUnitSystem(CurrentUnitSystem))
                    );
            }        
        }
        public static Vector3D ConvertLengthFrom(Vector3D value, UnitsManager.UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Length> measureX = new StandardMeasure<Length>(value.X, LengthUnitFromUnitSystem(unitSystem));
                StandardMeasure<Length> measureY = new StandardMeasure<Length>(value.Y, LengthUnitFromUnitSystem(unitSystem));
                StandardMeasure<Length> measureZ = new StandardMeasure<Length>(value.Z, LengthUnitFromUnitSystem(unitSystem));
                return new Vector3D(
                    measureX.GetAmount(LengthUnitFromUnitSystem(CurrentUnitSystem))
                    , measureY.GetAmount(LengthUnitFromUnitSystem(CurrentUnitSystem))
                    , measureZ.GetAmount(LengthUnitFromUnitSystem(CurrentUnitSystem))
                    );
            }
        }
        public static double ConvertMassFrom(double value, UnitsManager.UnitSystem unitSystem)
        {
            if (unitSystem == CurrentUnitSystem)
                return value;
            else
            {
                StandardMeasure<Mass> measure = new StandardMeasure<Mass>(value, MassUnitFromUnitSystem(unitSystem));
                return measure.GetAmount(MassUnitFromUnitSystem(CurrentUnitSystem));
            }       
        }
        #endregion
    }
}
