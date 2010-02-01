#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;
using System.Drawing;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class Pallet
    {
        #region Data members
        private double _length, _width, _height;
        private Color _color;
        private PalletProperties.PalletType _type;
        #endregion

        #region Constructor
        public Pallet(PalletProperties palletProperties)
        {
            _length = palletProperties.Length;
            _width = palletProperties.Width;
            _height = palletProperties.Height;
            _color = palletProperties.Color;
            _type = palletProperties.Type;
        }
        #endregion

        #region Public properties
        public Face[] Faces
        {
            get
            {
                Face[] faces= new Face[6];
                switch (_type)
                {
                    case PalletProperties.PalletType.BLOCK:
                        {
                            // points
                            Vector3D[] points = new Vector3D[8];
                            points[0] = Vector3D.Zero;
                            points[1] = _length * Vector3D.XAxis;
                            points[2] = _length * Vector3D.XAxis +_width * Vector3D.YAxis;
                            points[3] = _width * Vector3D.YAxis;
                            points[4] = _height * Vector3D.ZAxis;
                            points[5] = _length * Vector3D.XAxis + _height * Vector3D.ZAxis;
                            points[6] = _length * Vector3D.XAxis + _width * Vector3D.YAxis + _height * Vector3D.ZAxis;
                            points[7] = _width * Vector3D.YAxis + _height * Vector3D.ZAxis;

                            faces[0] = new Face(0, new Vector3D[] { points[3], points[0], points[4], points[7] }); // AXIS_X_N
                            faces[1] = new Face(0, new Vector3D[] { points[1], points[2], points[6], points[5] }); // AXIS_X_P
                            faces[2] = new Face(0, new Vector3D[] { points[0], points[1], points[5], points[4] }); // AXIS_Y_N
                            faces[3] = new Face(0, new Vector3D[] { points[2], points[3], points[7], points[6] }); // AXIS_Y_P
                            faces[4] = new Face(0, new Vector3D[] { points[3], points[2], points[1], points[0] }); // AXIS_Z_N
                            faces[5] = new Face(0, new Vector3D[] { points[4], points[5], points[6], points[7] }); // AXIS_Z_P

                            foreach (Face face in faces)
                                face.ColorFill = _color;
                        }
                        break;
                    default:
                        break;
                }
                return faces;            
            }
        }
        #endregion
    }
}
