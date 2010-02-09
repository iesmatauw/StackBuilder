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
    #region Box
    public class Box : Drawable
    {
        #region Data members
        uint _pickId = 0;
        double[] _dim = new double[3];
        Vector3D _position = Vector3D.Zero;
        Vector3D _lengthAxis = Vector3D.XAxis;
        Vector3D _widthAxis = Vector3D.YAxis;
        Color[] _colors;
        List<Texture>[] _textureLists = new List<Texture>[6];
        /// <summary>
        /// Bundle properties
        /// </summary>
        private bool _isBundle = false;
        private int _noFlats = 0;
        #endregion

        #region Constructor
        public Box(uint pickId, double length, double width, double height)
        {
            _pickId = pickId;
            _dim[0] = length;
            _dim[1] = width;
            _dim[2] = height;

            _colors = new Color[6];
            _colors[0] = Color.Red;
            _colors[1] = Color.Red;
            _colors[2] = Color.Green;
            _colors[3] = Color.Green;
            _colors[4] = Color.Blue;
            _colors[5] = Color.Blue;

            for (int i=0; i<6; ++i)
                _textureLists[i] = null;
        }
        public Box(uint pickId, BoxProperties boxProperties)
        {
            _pickId = pickId;
            _dim[0] = boxProperties.Length;
            _dim[1] = boxProperties.Width;
            _dim[2] = boxProperties.Height;

            _colors = boxProperties.Colors;

            for (int i = 0; i < 6; ++i)
            { 
            
            }
        }
        public Box(uint pickId, InterlayerProperties interlayerProperties)
        {
            _pickId = pickId;
            _dim[0] = interlayerProperties.Length;
            _dim[1] = interlayerProperties.Width;
            _dim[2] = interlayerProperties.Thickness;
            _colors = new Color[6];
            for (int i=0; i<6; ++i)
                _colors[i] = interlayerProperties.Color;
        }

        public Box(uint pickId, BundleProperties bundleProperties)
        {
            _pickId = pickId;
            _isBundle = true;
            _dim[0] = bundleProperties.Length;
            _dim[1] = bundleProperties.Width;
            _dim[2] = bundleProperties.TotalThickness;
            _colors = new Color[6]; 
            for (int i = 0; i < 6; ++i)
                _colors[i] = bundleProperties.Color;
            _noFlats = bundleProperties.NoFlats;
        }
        #endregion

        #region Public properties
        public Vector3D Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public double Length
        {
            get { return _dim[0]; }
        }
        public double Width
        {
            get { return _dim[1]; }
        }
        public double Height
        {
            get { return _dim[2]; }
        }

        public Vector3D LengthAxis
        {
            get { return _lengthAxis; }
            set { _lengthAxis = value; }
        }
        public Vector3D WidthAxis
        {
            get { return _widthAxis; }
            set { _widthAxis = value; }
        }

        public Color[] Colors
        {
            get { return _colors; }
        }

        public bool IsBundle
        {
            get { return _isBundle; }
            set { _isBundle = value; }
        }
        public int BundleFlats
        {
            get { return _noFlats; }
        }


        public Vector3D[] Oriented(Vector3D pt0, Vector3D pt1, Vector3D pt2, Vector3D pt3, Vector3D pt)
        {
            Vector3D crossProduct = Vector3D.CrossProduct(pt1 - pt0, pt2 - pt0);
            if (Vector3D.DotProduct(crossProduct, pt - pt0) < 0)
                return new Vector3D[] { pt0, pt1, pt2, pt3 };
            else
                return new Vector3D[] { pt3, pt2, pt1, pt0 };
        }

        public Vector3D[] Points
        {
            get
            {
                Vector3D heightAxis = Vector3D.CrossProduct(_lengthAxis, _widthAxis);
                Vector3D[] points = new Vector3D[8];
                points[0] = _position;
                points[1] = _position + _dim[0] * _lengthAxis;
                points[2] = _position + _dim[0] * _lengthAxis + _dim[1] * _widthAxis;
                points[3] = _position + _dim[1] * _widthAxis;

                points[4] = _position + _dim[2] * heightAxis;
                points[5] = _position + _dim[2] * heightAxis + _dim[0] * _lengthAxis;
                points[6] = _position + _dim[2] * heightAxis + _dim[0] * _lengthAxis + _dim[1] * _widthAxis;
                points[7] = _position + _dim[2] * heightAxis + _dim[1] * _widthAxis;

                return points;
            }
        }

        public Vector3D Center
        {
            get
            {
                return _position
                    + 0.5 * _dim[0] * _lengthAxis
                    + 0.5 * _dim[1] * _widthAxis
                    + 0.5 * _dim[2] * Vector3D.CrossProduct(_lengthAxis, _widthAxis);
            }
        }

        public Face[] Faces
        {
            get
            {
                Vector3D heightAxis = Vector3D.CrossProduct(_lengthAxis, _widthAxis);
                Vector3D[] points = new Vector3D[8];
                points[0] = _position;
                points[1] = _position + _dim[0] * _lengthAxis;
                points[2] = _position + _dim[0] * _lengthAxis + _dim[1] * _widthAxis;
                points[3] = _position + _dim[1] * _widthAxis;

                points[4] = _position + _dim[2] * heightAxis;
                points[5] = _position + _dim[2] * heightAxis + _dim[0] * _lengthAxis ;
                points[6] = _position + _dim[2] * heightAxis + _dim[0] * _lengthAxis + _dim[1] * _widthAxis ;
                points[7] = _position + _dim[2] * heightAxis + _dim[1] * _widthAxis ;

                Face[] faces = new Face[6];
                faces[0] = new Face(_pickId, new Vector3D[] { points[3], points[0], points[4], points[7] }); // AXIS_X_N
                faces[1] = new Face(_pickId, new Vector3D[] { points[1], points[2], points[6], points[5] }); // AXIS_X_P
                faces[2] = new Face(_pickId, new Vector3D[] { points[0], points[1], points[5], points[4] }); // AXIS_Y_N
                faces[3] = new Face(_pickId, new Vector3D[] { points[2], points[3], points[7], points[6] }); // AXIS_Y_P
                faces[4] = new Face(_pickId, new Vector3D[] { points[3], points[2], points[1], points[0] }); // AXIS_Z_N
                faces[5] = new Face(_pickId, new Vector3D[] { points[4], points[5], points[6], points[7] }); // AXIS_Z_P

                int i = 0;
                foreach (Face face in faces)
                {
                    face.ColorFill = _colors[i];
                    face.Textures = _textureLists[i];
                    ++i;
                }

                return faces;
            }
        }
        #endregion

        #region Public methods
        public override void Draw(Graphics3D graphics)
        {
            foreach (Face face in Faces)
                graphics.AddFace(face);
        }

        public void SetAllFacesColor(Color color)
        {
            for (int i = 0; i < 6; ++i)
                _colors[i] = color;        
        }

        public void SetFaceColor(HalfAxis iFace, Color color)
        {
            _colors[(int)iFace] = color;
        }

        public void SetFaceTextures(HalfAxis iFace, List<Texture> textures)
        {
            _textureLists[(int)iFace] = textures;
        }
        #endregion
    }
    #endregion

    #region Box comparison
    public class BoxComparison : IComparer<Box>
    {
        #region Constructor
        public BoxComparison(Transform3D transform)
        {
            _transform = transform;
        }
        #endregion

        #region Implementation IComparer
        public int Compare(Box b1, Box b2)
        {
            if (b1.Center.Z > b2.Center.Z)
                return 1;
            else if (b1.Center.Z == b2.Center.Z)
            {
                if (_transform.transform(b1.Center).Z < _transform.transform(b2.Center).Z)
                    return 1;
                else if (_transform.transform(b1.Center).Z == _transform.transform(b2.Center).Z)
                    return 0;
                else
                    return -1;
            }
            else
                return -1;
        }
        #endregion

        #region Data members
        Transform3D _transform;
        #endregion
    }
    #endregion
}
