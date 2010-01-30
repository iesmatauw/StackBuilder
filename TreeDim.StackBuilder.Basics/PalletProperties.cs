#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
#endregion

namespace TreeDim.StackBuilder.Basics
{
    public class PalletProperties
    {
        #region Enums
        public enum PalletType
        { 
            BLOCK
        }
        public static string[] PalletTypeNames = { "Block" };
        #endregion

        #region Data members
        string _name, _description;
        double _length, _width, _height;
        double _weight;
        double _admissibleLoadWeight, _admissibleLoadHeight;
        private List<Analysis> _dependingAnalyses = new List<Analysis>();
        private Color _color = Color.Yellow;
        private PalletType _type = PalletType.BLOCK;
        #endregion

        #region Constructor
        public PalletProperties(PalletType type, double length, double width, double height)
        {
            _type = type;
            _length = length;
            _width = width;
            _height = height;
        }
        #endregion

        #region Public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
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
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public double AdmissibleLoadWeight
        {
            get { return _admissibleLoadWeight; }
            set { _admissibleLoadWeight = value; }
        }
        public double AdmissibleLoadHeight
        {
            get { return _admissibleLoadHeight; }
            set { _admissibleLoadHeight = value; }
        }
        public PalletType Type
        {
            get { return _type; }
        }
        public Color Color
        {
            set { _color = value; }
            get { return _color; }
        }
        #endregion

        #region Depending analysis
        public void AddDependingAnalysis(Analysis analysis)
        {
            _dependingAnalyses.Add(analysis);
        }
        public bool HasDependingAnalyses
        {
            get { return _dependingAnalyses.Count > 0; }
        }
        public void RemoveDependingAnalysis(Analysis analysis)
        {
            _dependingAnalyses.Remove(analysis);
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
