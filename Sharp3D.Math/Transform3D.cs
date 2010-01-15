#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace Sharp3D.Math.Core
{
    /// <summary>
    /// Represents a 3D transformation
    /// </summary>
    [Serializable]
    public class Transform3D : ICloneable
    {
        #region Private fields
        /// <summary>
        /// The <see cref="Matrix4D"/> 3D transformation matrix
        /// </summary>
        Matrix4D _mat = Matrix4D.Identity;
        #endregion

        #region Enums
        public enum Axis
        { 
            X
            , Y
            , Z
        }
        #endregion

        #region Constructors
        public Transform3D()
        { 
        }
        public Transform3D(Matrix4D mat)
        {
            _mat = mat.Clone();
        }
        public Transform3D(Transform3D transf)
        {
            _mat = transf._mat.Clone();
        }
        #endregion

        #region Transform3D members
        public Vector3D transform(Vector3D vec)
        {
            Vector4D vecTransf = _mat * (new Vector4D(vec.X, vec.Y, vec.Z, 1.0));
            return new Vector3D(vecTransf.X, vecTransf.Y, vecTransf.Z);
        }
        #endregion

        #region ICloneable members
        /// <summary>
        /// Creates an exact copy of this <see cref="MatrixTransform3D"/> object.
        /// </summary>
        /// <returns>The <see cref="Transform3D"/> object this method creates, cast as an object.</returns>
        object ICloneable.Clone()
        {
            return new Transform3D(this);
        }
        /// <summary>
        /// Creates an exact copy of this <see cref="MatrixTransform3D"/> object.
        /// </summary>
        /// <returns>The <see cref="MatrixTransform3D"/> object this method creates.</returns>
        public Transform3D Clone()
        {
            return new Transform3D(this);
        }
        #endregion

        #region Public properties
        public Matrix4D Matrix
        {
            get { return _mat; }
            set { _mat = value; }
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Creates a translation transformation from a given <see cref="Vector3D"/>.
        /// </summary>
        /// <param name="vecTrans">A translation <see cref="Vector3D"/>.</param>
        /// <returns>A <see cref="Transform3D"/> object.</returns>
        public static Transform3D Translation(Vector3D v)
        {
            return new Transform3D(
                new Matrix4D(
                            1.0, 0.0, 0.0, v.X,
                            0.0, 1.0, 0.0, v.Y,
                            0.0, 0.0, 1.0, v.Z,
                            0.0, 0.0, 0.0, 1.0
                )
            );
        }
        /// <summary>
        /// Creates a rotation a rotation around X, Y or Z axis transformation 
        /// </summary>
        /// <param name="axis">Axis to rotate about</param>
        /// <param name="angle">A double angle value</param>
        /// <returns>A <see cref="Transform3D"/> object</returns>
        public static Transform3D Rotation(Axis axis, double angle)
        {
            double angleRad = angle * System.Math.PI / 180.0;
            double cosAngle = System.Math.Cos(angleRad);
            double sinAngle = System.Math.Sin(angleRad);

            Matrix4D matrix = Matrix4D.Identity;

            switch (axis)
            {
                case Axis.X:
                    matrix.M22 = matrix.M33 = cosAngle;
                    matrix.M32 = sinAngle;
                    matrix.M23 = -sinAngle;
                    break;
                case Axis.Y:
                    matrix.M11 = matrix.M33 = cosAngle;
                    matrix.M31 = sinAngle;
                    matrix.M13 = -sinAngle;
                    break;
                case Axis.Z:
                    matrix.M11 = matrix.M22 = cosAngle;
                    matrix.M21 = sinAngle;
                    matrix.M12 = -sinAngle;
                    break;
                default:
                    break;
            }
            return new Transform3D(matrix);
        }

        public static Transform3D RotationX(double angle)
        {
            double a = angle * System.Math.PI / 180.0;
            return new Transform3D(
                new Matrix4D(
                    1.0, 0.0, 0.0, 0.0,
                    0.0, System.Math.Cos(a), -System.Math.Sin(a), 0.0,
                    0.0, System.Math.Sin(a), System.Math.Cos(a), 0.0,
                    0.0, 0.0, 0.0, 1.0
                )
            );
        }

        public static Transform3D RotationY(double angle)
        {
            double a = angle * System.Math.PI / 180.0;
            return new Transform3D(
                new Matrix4D(
                     System.Math.Cos(a), 0.0, System.Math.Sin(a), 0.0,
                     0.0, 1.0, 0.0, 0.0,
                     -System.Math.Sin(a), 0.0, System.Math.Cos(a), 0.0,
                     0.0, 0.0, 0.0, 1.0
                )
            );
        }

        public static Transform3D RotationZ(double angle)
        {
            double a = angle * System.Math.PI / 180.0;
            return new Transform3D(
                new Matrix4D(
                     System.Math.Cos(a), -System.Math.Sin(a), 0.0, 0.0,
                     System.Math.Sin(a), System.Math.Cos(a), 0.0, 0.0,
                     0.0, 0.0, 1.0, 0.0,
                     0.0, 0.0, 0.0, 1.0
                )
            );
        }
        /// <summary>
        /// Creates a rotation around a given axis
        /// </summary>
        /// <param name="u">A <see cref="Vector3D"/> that defines the rotation axis direction</param>
        /// <param name="angle">A double angle value in degree</param>
        /// <returns>A <see cref="Transform3D"/> object</returns>
        public static Transform3D Rotation(Vector3D u, double angle)
        {
            u.Normalize();
            double angleRad = angle * System.Math.PI;
            double c = System.Math.Cos(angleRad);
            double s = System.Math.Sin(angleRad);

            Matrix4D m = Matrix4D.Identity;

            m.M11 = u.X * u.X + (1.0 - u.X * u.X) * c;
            m.M12 = u.X * u.Y * (1.0 - c) - u.Z * s;
            m.M13 = u.X * u.Z * (1.0 - c) + u.Y * s;

            m.M21 = u.Y * u.X * (1.0 - c) + u.Z * s;
            m.M22 = u.Y * u.Y * (1.0 - u.Y * u.Y) * c;
            m.M21 = u.Y * u.Z * (1.0 - c) - u.X * s;

            m.M31 = u.Z * u.X * (1.0 - c) + u.Y * s;
            m.M32 = u.Z * u.Y * (1.0 - c) + u.X * s;
            m.M33 = u.Z * u.Z * (1.0 - u.Z * u.Z) * c;

            return new Transform3D(m);
        }

        public static Transform3D Perspective(double d)
        {
            Matrix4D m = Matrix4D.Identity;
            m.M43 = 1.0 / d;
            return new Transform3D(m);
        }
        #endregion

        #region Binary operators
        public static Transform3D operator *(Transform3D transf1, Transform3D transf2)
        {
            return new Transform3D(transf1._mat * transf2._mat);
        }
        #endregion

        #region Constants
        public static readonly Transform3D Identity = new Transform3D(Matrix4D.Identity);

        #endregion

    }
}
