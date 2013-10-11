#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using TreeDim.EdgeCrushTest.Properties;

using log4net;
#endregion

namespace TreeDim.EdgeCrushTest
{
    public partial class McKeeFormula
    {
        #region Enums
        public enum FormulaType
        {
            MCKEE_CLASSIC
            , MCKEE_IMPROVED
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(McKeeFormula));
        static private Dictionary<string, QualityData> _cardboardQualityDictionary;
        #endregion

        #region Formula implementation
        private static double ComputeBCT_ECT(double length, double width, double thickness, double ect)
        { 
        	double L1 = length / 25.4;
			double B1 = width / 25.4;
			double e1 = thickness / 25.4;
            double ect1 = ect / 0.1751;
			double rcv = 5.87 * ect1 * Math.Pow(2 * (L1 + B1), 0.4924) * Math.Pow(e1, 0.5076);
            return rcv * 0.45359;
        }
        private static double ComputeBCT_Stiffness(
            double length, double width, double height
            , double thickness
            , double stiffnessX, double stiffnessY
            , double ect)
        {
            double L1 = length / 25.4;
			double B1 = width / 25.4;
			double H1 = height / 25.4;
			double e1 = thickness / 25.4;
			double ECT1 = ect / 0.1751;
			double Dx1 = stiffnessX / 0.113;
			double Dy1 = stiffnessY / 0.113;
			
			double D = 1.593 / Math.Pow(H1, 0.236);
			double k = 1.014 * Math.Pow(ECT1, 0.746) * Math.Pow((Dx1 * Dy1), 0.127) * (2 * (Math.Pow(L1, 0.492) + Math.Pow(B1, 0.492)));
			double rcv = k * D;
            return rcv * 0.45359;
        }
        /// <summary>
        /// Compute static BCT
        /// </summary>
        public static double ComputeStaticBCT(
            double length, double width, double height
            , string cardboardId, string caseType
            , FormulaType mcKeeFormulaType)
        {
            if (!McKeeFormula.CardboardQualityDictionary.ContainsKey(cardboardId))
                throw new Exception(Exception.ErrorType.ERROR_INVALIDCARDBOARD, cardboardId);
            QualityData qualityData = McKeeFormula.CardboardQualityDictionary[cardboardId];

            if (!McKeeFormula.CaseTypeDictionary.ContainsKey(caseType))
                throw new Exception(Exception.ErrorType.ERROR_INVALIDCASETYPE, caseType);
            double caseTypeCoef = McKeeFormula.CaseTypeDictionary[caseType];

            switch (mcKeeFormulaType)
            { 
                case FormulaType.MCKEE_CLASSIC:
                    return McKeeFormula.ComputeBCT_ECT(length, width, qualityData.Thickness, qualityData.ECT) * caseTypeCoef;
                case FormulaType.MCKEE_IMPROVED:
                    return McKeeFormula.ComputeBCT_Stiffness(length, width, height,
                        qualityData.Thickness, qualityData.RigidityDX, qualityData.RigidityDY,
                        qualityData.ECT) * caseTypeCoef;
                default:
                    throw new TreeDim.EdgeCrushTest.Exception(Exception.ErrorType.ERROR_INVALIDFORMULATYPE, string.Empty); 
            }
        }
        #endregion

        #region Dynamic BCT
        public static Dictionary<KeyValuePair<string, string>, double> EvaluateEdgeCrushTestMatrix(
            double L, double B, double H
            , string cardboardId, string caseType, string printType
            , McKeeFormula.FormulaType mcKeeFormulaType)
        {
            // get dictionnaries
            Dictionary<string, double> humidityCoefDictionary = HumidityCoefDictionary;
            Dictionary<string, double> stockCoefDictionary = StockCoefDictionary;
            double printCoef = PrintCoefDictionary[printType];
            // get cardboard quality data
            double bct_static = ComputeStaticBCT(L, B, H, cardboardId, caseType, mcKeeFormulaType);
 
            Dictionary<KeyValuePair<string, string>, double> edgeCrushTestMatrix = new Dictionary<KeyValuePair<string, string>, double>();
            foreach (string humidityRange in HumidityCoefDictionary.Keys)
                foreach (string stockDuration in StockCoefDictionary.Keys)
                {
                    edgeCrushTestMatrix.Add(new KeyValuePair<string, string>(stockDuration, humidityRange)
                        , bct_static * printCoef * stockCoefDictionary[stockDuration] * humidityCoefDictionary[humidityRange]);
                }
            return edgeCrushTestMatrix;
        }
        #endregion

        #region Coefficient dictionary
        /// <summary>
        /// Convert to McKeeFormula to string
        /// </summary>
        public static string ModeText(McKeeFormula.FormulaType type)
        {
            switch (type)
            {
                case McKeeFormula.FormulaType.MCKEE_CLASSIC: return TreeDim.EdgeCrushTest.Properties.Resource.MCKEEFORMULA_CLASSIC;
                case McKeeFormula.FormulaType.MCKEE_IMPROVED: return TreeDim.EdgeCrushTest.Properties.Resource.MCKEEFORMULA_IMPROVED;
                default: return "";
            }
        }
        /// <summary>
        /// Convert string to McKeeFormula
        /// </summary>
        public static McKeeFormula.FormulaType TextToMode(string sMode)
        {
            if (string.Equals(sMode, TreeDim.EdgeCrushTest.Properties.Resource.MCKEEFORMULA_CLASSIC))
                return McKeeFormula.FormulaType.MCKEE_CLASSIC;
            else if (string.Equals(sMode, TreeDim.EdgeCrushTest.Properties.Resource.MCKEEFORMULA_IMPROVED))
                return McKeeFormula.FormulaType.MCKEE_IMPROVED;
            else
                return McKeeFormula.FormulaType.MCKEE_CLASSIC;
        }
        /// <summary>
        /// Case type dictionary
        /// </summary>
        public static Dictionary<string, double> CaseTypeDictionary
        {
            get
            {
                Dictionary<string, double> caseTypeDictionary = new Dictionary<string,double>()
                {
                    { TreeDim.EdgeCrushTest.Properties.Resource.CASETYPE_AMERICANCASE, 1.0 }
                };
                return caseTypeDictionary;
            }
        }
        /// <summary>
        /// Humidity coefficient dictionary
        /// </summary>
        public static Dictionary<string, double> HumidityCoefDictionary
        {
            get
            {
                Dictionary<string, double> humidityCoefs = new Dictionary<string, double>()
                {
                    {"0-45%", 1.1}
                    , {"46-55%", 1.0}
                    , {"56-65%", 0.9}
                    , {"66-75%", 0.8}
                    , {"76-85%", 0.7}
                    , {"86-100%", 0.5}
                };
                return humidityCoefs;
            }
        }
        /// <summary>
        /// Stock coefficient dictionary
        /// </summary>
        public static Dictionary<string, double> StockCoefDictionary
        {
            get
            {
                Dictionary<string, double> jStockCoef = new Dictionary<string, double>()
                {
                    {TreeDim.EdgeCrushTest.Properties.Resource.STORAGEDURATION_0DAY, 1.0}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.STORAGEDURATION_1_3DAYS, 0.7}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.STORAGEDURATION_4_10DAYS, 0.65}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.STORAGEDURATION_11_30DAYS, 0.6}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.STORAGEDURATION_1_3MONTHES, 0.55}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.STORAGEDURATION_3_4MONTHES, 0.5}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.STORAGEDURATION_4_MONTHES, 0.45}
                };
                return jStockCoef;
            }
        }
        /// <summary>
        /// Print surface dictionary
        /// </summary>
        public static Dictionary<string, double> PrintCoefDictionary
        {
            get
            {
                Dictionary<string, double> printCoefDictionary = new Dictionary<string,double>()
                {
                    {TreeDim.EdgeCrushTest.Properties.Resource.PRINTEDSURFACE_SIMPLE, 1.0}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.PRINTEDSURFACE_DISTRIBUTED, 0.9}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.PRINTEDSURFACE_COMPLEX, 0.8}
                    , {TreeDim.EdgeCrushTest.Properties.Resource.PRINTEDSURFACE_COVERED, 0.7}
                };
                return printCoefDictionary;
            }
        }
        /// <summary>
        /// Cardboard quality dictionary
        /// </summary>
        public static Dictionary<string, QualityData> CardboardQualityDictionary
        {
            get
            {
                if (null == _cardboardQualityDictionary)
                {
                    // instantiate
                    _cardboardQualityDictionary = new Dictionary<string, QualityData>();
                    // get db file path
                    string dbFilePath = Settings.Default.CardboardQualityDBFile;
                    // check existence
                    if (!File.Exists(dbFilePath))
                        throw new FileNotFoundException(Resource.MESSAGE_CARDBOARDQUALITYDBNOTFOUND, dbFilePath);
                    // load file
                    CardboardQualityList cardboardQualityList = CardboardQualityList.LoadFromFile(dbFilePath);
                    // load dictionary
                    foreach (CardboardQualityListCardboardQuality quality in cardboardQualityList.CardboardQuality)
                    {
                        try
                        {
                            _cardboardQualityDictionary.Add(quality.Name + " - " + quality.Thickness.ToString() + " mm"
                                , new QualityData(quality.Name, quality.Profile, quality.Thickness, quality.ECT, quality.RigidityDX, quality.RigidityDY));
                        }
                        catch (Exception ex)
                        {   _log.Error(quality.Name + " -> " + ex.Message); }
                    }
                    // log info -> cardboard quality db successfully loaded
                    _log.DebugFormat("Successfully loaded cardboard quality db: {0}", dbFilePath);
                }
                return _cardboardQualityDictionary;
            }
        }
        #endregion
    }
}
