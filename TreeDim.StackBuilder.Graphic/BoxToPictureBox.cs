#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using TreeDim.StackBuilder.Basics;
using Sharp3D.Math.Core;

using log4net;
#endregion

namespace TreeDim.StackBuilder.Graphics
{
    public class BoxToPictureBox
    {
        public static void Draw(BProperties boxProperties, HalfAxis.HAxis axis, PictureBox pictureBox)
        {
            // get horizontal angle
            double angle = 45;
            // instantiate graphics
            Graphics3DImage graphics = new Graphics3DImage(pictureBox.Size);
            graphics.CameraPosition = new Vector3D(
                Math.Cos(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , Math.Sin(angle * Math.PI / 180.0) * Math.Sqrt(2.0) * 10000.0
                , 10000.0);
            graphics.Target = Vector3D.Zero;
            graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
            // draw
            Box box = new Box(0, boxProperties);
            // set axes
            HalfAxis.HAxis lengthAxis = HalfAxis.HAxis.AXIS_X_P;
            HalfAxis.HAxis widthAxis = HalfAxis.HAxis.AXIS_Y_P;
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_P: lengthAxis = HalfAxis.HAxis.AXIS_Z_P; widthAxis = HalfAxis.HAxis.AXIS_X_P; break;
                case HalfAxis.HAxis.AXIS_Y_P: lengthAxis = HalfAxis.HAxis.AXIS_X_P; widthAxis = HalfAxis.HAxis.AXIS_Z_N; break;
                case HalfAxis.HAxis.AXIS_Z_P: lengthAxis = HalfAxis.HAxis.AXIS_X_P; widthAxis = HalfAxis.HAxis.AXIS_Y_P; break;
                default: break;
            }
            box.LengthAxis = TreeDim.StackBuilder.Basics.HalfAxis.ToVector3D(lengthAxis);
            box.WidthAxis = TreeDim.StackBuilder.Basics.HalfAxis.ToVector3D(widthAxis);
            // draw box
            graphics.AddBox(box);
            graphics.Flush();
            // set to picture box
            pictureBox.Image = graphics.Bitmap;
        }
    }
}
