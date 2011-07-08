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
    #region Position
    public struct Position
    {
        #region Data members
        private int _index;
        private Vector3D _xyz;
        private HalfAxis.HAxis _axis1, _axis2;
        #endregion

        #region Constructor
        public Position(int index, Vector3D xyz, HalfAxis.HAxis axis1, HalfAxis.HAxis axis2)
        {
            _index = index; _xyz = xyz; _axis1 = axis1; _axis2 = axis2;
        }
        #endregion

        #region Public properties
        public Vector3D XYZ {   get {return _xyz;}  }
        public HalfAxis.HAxis Axis1 { get { return _axis1; } }
        public HalfAxis.HAxis Axis2 { get { return _axis2; } }
        public int Index { get { return _index; } }
        #endregion
    }
    #endregion

    #region PalletData
    public class PalletData
    {
        #region Data members
        private string _name;
        private string _description;
        private List<Vector3D> _lumbers;
        private List<Position> _positions;
        private Vector3D _defaultDimensions;
        private static List<PalletData> _pool;
        #endregion

        #region Constructor
        private PalletData(string name, string description, Vector3D[] lumbers, Position[] positions, Vector3D dimensions)
        {
            _name = name;
            _description = description;
            _lumbers = new List<Vector3D>(lumbers);
            _positions = new List<Position>(positions);
            _defaultDimensions = dimensions;
        }
        #endregion

        #region Static pool methods
        private static void Initialize()
        {
            if (null == _pool)
            {
                _pool = new List<PalletData>();
                
            }
        }

        public static PalletData GetByName(string name)
        {
            return _pool.Find(delegate(PalletData type) { return string.Compare(type._name, name, true) == 0; });
        }
        #endregion

        #region Drawing
        public void Draw(Graphics3D graphics, Vector3D dimensions, Color color, Transform3D t)
        {
            double coefX = dimensions.X / _defaultDimensions.X;
            double coefY = dimensions.Y / _defaultDimensions.Y;
            double coefZ = dimensions.Z / _defaultDimensions.Z;
            uint pickId = 0;
            foreach (Position pos in _positions)
            {
                double coef0 = coefX, coef1 = coefY, coef2 = coefZ;
                if (pos.Axis1 == HalfAxis.HAxis.AXIS_X_P && pos.Axis2 == HalfAxis.HAxis.AXIS_Y_P)
                { coef0 = coefX; coef1 = coefY; }
                else if (pos.Axis1 == HalfAxis.HAxis.AXIS_Y_P && pos.Axis2 == HalfAxis.HAxis.AXIS_X_N)
                { coef0 = coefY; coef1 = coefX; }
                Vector3D dim = _lumbers[pos.Index];
                Box box = new Box(pickId++, dim.X * coef0, dim.Y * coef1, dim.Z * coef2);
                box.SetAllFacesColor(color);
                box.Position = t.transform(new Vector3D(pos.XYZ.X * coefX, pos.XYZ.Y * coefY, pos.XYZ.Z * coefZ));
                box.LengthAxis = Basics.HalfAxis.ToVector3D(HalfAxis.Transform(pos.Axis1, t)); ;
                box.WidthAxis = Basics.HalfAxis.ToVector3D(HalfAxis.Transform(pos.Axis2, t)); ;
                graphics.AddBox(box);
            }
        }
        #endregion
    }
    #endregion

    #region Pallet
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

        #region Overrides
        public void Draw(Graphics3D graphics, Transform3D t)
        {
            if (_length == 0.0 || _width == 0.0 || _height == 0.0)
                return;

            switch (_type)
            {
                case PalletProperties.PalletType.BLOCK:
                    {
                        Box box = new Box(0, _length, _width, _height);
                        box.SetAllFacesColor(_color);
                        box.Position = t.transform(Vector3D.Zero);
                        box.LengthAxis  = Basics.HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_P, t));
                        box.WidthAxis   = Basics.HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P, t));
                        graphics.AddBox(box);
                    }
                    break;
                case PalletProperties.PalletType.UK_STANDARD:
                    {
                        double coefLength = _length / 1200.0;
                        double coefWidth = _width / 1000.0;
                        double coefHeight = _height / 150.0;
                        uint pickId = 0;

                        // planks
                        Box plank1 = new Box(++pickId, 1000.0 * coefWidth, 98.0 * coefLength, 18.0 * coefHeight); plank1.SetAllFacesColor(_color);
                        Box plank2 = new Box(++pickId, 138.0 * coefWidth, 98.0 * coefLength, 95.0 * coefHeight); plank2.SetAllFacesColor(_color);
                        Box plank4 = new Box(++pickId, 1200.0 * coefLength, 95.0 * coefWidth, 18.0 * coefHeight); plank4.SetAllFacesColor(_color);
                        Box plank5 = new Box(++pickId, 1000.0 * coefWidth, 120.0 * coefLength, 19.0 * coefHeight); plank5.SetAllFacesColor(_color);

                        // first layer
                        double z = 0.0;
                        double xStep = (1200.0* coefLength - plank1.Width) / 2.0;
                        for (int i = 0; i < 3; ++i)
                        {
                            plank1 = new Box(++pickId, 1000.0 * coefWidth, 98.0 * coefLength, 18.0 * coefHeight); plank1.SetAllFacesColor(_color);
                            plank1.LengthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P, t));
                            plank1.WidthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_N, t));
                            plank1.Position = t.transform(new Vector3D(plank1.Width + i * xStep, 0.0, z));
                            graphics.AddBox(plank1);
                        }
                        
                        // second layer
                        z = plank1.Height;
                        double yStep = (1000.0* coefWidth - plank2.Length) / 2.0;
                        for (int i = 0; i < 3; ++i)
                            for (int j = 0; j < 3; ++j)
                            {
                                plank2 = new Box(++pickId, 138.0 * coefWidth, 98.0 * coefLength, 95.0 * coefHeight); plank2.SetAllFacesColor(_color);
                                plank2.LengthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P, t));
                                plank2.WidthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_N, t));
                                plank2.Position = t.transform(new Vector3D(plank2.Width + i * xStep, j*yStep, z));
                                graphics.AddBox(plank2);
                            }

                        // third layer
                        z = plank1.Height + plank2.Height;
                        yStep = plank4.Width + (1000.0* coefWidth - 3.0 * plank4.Width) / 2.0;
                        for (int j = 0; j < 3; ++j)
                        {
                            plank4 = new Box(++pickId, 1200.0 * coefLength, 95.0 * coefWidth, 18.0 * coefHeight); plank4.SetAllFacesColor(_color);
                            plank4.LengthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_P, t));
                            plank4.WidthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P, t));
                            plank4.Position = t.transform(new Vector3D(0.0, j * yStep, z));
                            graphics.AddBox(plank4);
                        }

                        // fourth layer
                        z = plank1.Height + plank2.Height + plank4.Height;
                        xStep = plank5.Width + (1200.0* coefLength-7.0*plank5.Width) / 6.0;
                        for (int i = 0; i < 7; ++i)
                        {
                            plank5 = new Box(++pickId, 1000.0 * coefWidth, 120.0 * coefLength, 19.0 * coefHeight); plank5.SetAllFacesColor(_color);
                            plank5.LengthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_Y_P,t));
                            plank5.WidthAxis = HalfAxis.ToVector3D(HalfAxis.Transform(HalfAxis.HAxis.AXIS_X_N, t));
                            plank5.Position = t.transform(new Vector3D(plank5.Width + i * xStep, 0.0, z));
                            graphics.AddBox(plank5);
                        }
                    }
                    break;
                case PalletProperties.PalletType.EUR:
                    break;
                case PalletProperties.PalletType.EUR2:
                    break;
                case PalletProperties.PalletType.EUR3:
                    break;
                case PalletProperties.PalletType.EUR6:
                    break;
                case PalletProperties.PalletType.US_48_40:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Public properties
        public Face[] Faces
        {
            get
            {
                Face[] faces = new Face[6];
                // points
                Vector3D[] points = new Vector3D[8];
                points[0] = Vector3D.Zero;
                points[1] = _length * Vector3D.XAxis;
                points[2] = _length * Vector3D.XAxis + _width * Vector3D.YAxis;
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

                return faces;            
            }
        }
        #endregion
    }
    #endregion
}
