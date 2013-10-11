#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace TreeDim.EdgeCrushTest
{
    public partial class McKeeFormula
    {
        #region QualityData class
        public class QualityData : ICloneable
        {
            #region Data members
            private string _name, _profile;
            private double _thickness, _ECT, _rigidityDX, _rigidityDY;
            #endregion

            #region Constructor
            public QualityData(QualityData data)
            {
                _name = data._name;
                _thickness = data._thickness;
                _ECT = data._ECT;
                _rigidityDX = data._rigidityDX;
                _rigidityDY = data._rigidityDY;
            }
            public QualityData(string name, string profile, double thickness, double ect, double rigidityDX, double rigidityDY)
            {
                _name = name;
                _profile = profile;
                _thickness = thickness;
                _ECT = ect;
                _rigidityDX = rigidityDX;
                _rigidityDY = rigidityDY;
            }
            #endregion

            #region ICloneable Members
            /// <summary>
            /// Creates an exact copy of this <see cref="QualityData"/> object.
            /// </summary>
            /// <returns>The <see cref="QualityData"/> object this method creates, cast as an object.</returns>
            object ICloneable.Clone()
            {
                return new QualityData(this);
            }
            /// <summary>
            /// Creates an exact copy of this <see cref="QualityData"/> object.
            /// </summary>
            /// <returns>The <see cref="QualityData"/> object this method creates.</returns>
            public QualityData Clone()
            {
                return new QualityData(this);
            }
            #endregion

            #region Object overrides
            public override string ToString()
            {
                return _name + " - " + _thickness.ToString() + " mm";
            }
            #endregion

            #region Public properties
            public string Id { get { return _name + " - " + _thickness.ToString() + " mm"; } }
            public string Name { get { return _name; } }
            public double Thickness { get { return _thickness; } }
            public double ECT { get { return _ECT; } }
            public double RigidityDX { get { return _rigidityDX; } }
            public double RigidityDY { get { return _rigidityDY; } }
            public string Profile { get { return _profile; } }
            #endregion
        }
        #endregion
    }
}
