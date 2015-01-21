#region Using directives
using System.Collections.Generic;
using System.Text;
using TreeDim.StackBuilder.Graphics;

using System.Drawing;
using System.IO;
using Sharp3D.Math.Core;

using TreeDim.StackBuilder.Basics;
using log4net;
using log4net.Config;
#endregion

namespace TreeDim.StackBuilder.Graphics.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure(); 

            try
            {
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(512, 512));
                graphics.CameraPosition = new Vector3D(-10000.0, -10000.0, 10000.0);
                graphics.Target = Vector3D.Zero;
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // load Bitmap
                string imageFilePath = @"..\..\Image16.bmp";
                Bitmap bmp = new Bitmap(imageFilePath);
                Texture texture = new Texture(bmp, new Vector2D(100.0, 20.0), new Vector2D(40.0 * bmp.Size.Width / bmp.Size.Height, 40.0), 10.0);
                List<Texture> listTexture= new List<Texture>();
                listTexture.Add(texture);
                // instantiate box and draw
                List<Box> boxList = new List<Box>();
                Box box0 = new Box(0, 200.0, 160.0, 100.0);
                box0.Position = Vector3D.Zero;
                box0.SetAllFacesColor(Color.Chocolate);
                box0.SetFaceTextures(HalfAxis.HAxis.AXIS_X_P, listTexture);
                box0.SetFaceTextures(HalfAxis.HAxis.AXIS_Y_P, listTexture);
                box0.SetFaceTextures(HalfAxis.HAxis.AXIS_Z_P, listTexture);
                box0.SetFaceTextures(HalfAxis.HAxis.AXIS_X_N, listTexture);
                box0.SetFaceTextures(HalfAxis.HAxis.AXIS_Y_N, listTexture);
                box0.SetFaceTextures(HalfAxis.HAxis.AXIS_Z_N, listTexture);
                boxList.Add(box0);
                Box box1 = new Box(1, 200.0, 160.0, 100.0);
                box1.Position = new Vector3D(210.0, 0.0, 0.0);
                box1.SetAllFacesColor(Color.Chocolate);
                box1.SetFaceTextures(HalfAxis.HAxis.AXIS_Y_P, listTexture);
                boxList.Add(box1);

                Box box2 = new Box(2, 200.0, 160.0, 100.0);
                box2.Position = new Vector3D(0.0, 170.0, 0.0);
                box2.SetAllFacesColor(Color.Chocolate);
                boxList.Add(box2);

                Box box3 = new Box(3, 200.0, 160.0, 100.0);
                box3.Position = new Vector3D(0.0, 0.0, 110.0);
                box3.SetAllFacesColor(Color.Chocolate);
                boxList.Add(box3);

                // draw
                foreach (Box box in boxList)
                    graphics.AddBox(box);
                graphics.Flush();
                // Save as %TEMP%\Pallet.jpg
                string filePath = Path.Combine(Path.GetTempPath(), "Pallet.bmp");
                graphics.SaveAs(filePath);

                bmp.Dispose();

                // open file
                using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
                {
                    proc.StartInfo.FileName = "mspaint.exe";
                    proc.StartInfo.Arguments = filePath;
                    proc.Start();
                }
            }
            catch (System.Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
    }
}
