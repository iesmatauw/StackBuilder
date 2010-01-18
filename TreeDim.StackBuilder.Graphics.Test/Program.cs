#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using TreeDim.StackBuilder.Graphics;

using System.Drawing;
using System.IO;
using Sharp3D.Math.Core;
#endregion

namespace TreeDim.StackBuilder.Graphics.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // instantiate graphics
                Graphics3DImage graphics = new Graphics3DImage(new Size(1024, 1024));
                graphics.CameraPosition = new Vector3D(1000.0, 1000.0, 1000.0);
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                graphics.LightDirection = new Vector3D(-0.75, -0.5, 1.0);
                graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                // load Bitmap
                string imageFilePath = @".\treeDim.bmp";
                Bitmap bmp = new Bitmap(imageFilePath);
                Texture texture = new Texture(bmp, new Vector2D(10.0, 10.0), new Vector2D(80.0 * bmp.Size.Width / bmp.Size.Height, 80.0));
                List<Texture> listTexture= new List<Texture>();
                listTexture.Add(texture);
                // instantiate box and draw
                List<Box> boxList = new List<Box>();
                for (int k=0; k<8; ++k)
                    for (int j= 0; j<5; ++j)
                        for (int i = 0; i < 4; ++i)
                        {
                            Box box = new Box(0, 200.0, 160.0, 100.0);
                            box.Position = new Vector3D((double)i * 200.0, (double)j * 160.0, (double)k * 100.0);
                            box.SetAllFacesColor(Color.Chocolate);
                            box.SetFaceTextures(Box.FaceEnum.AXIS_Y_P, listTexture);
                            boxList.Add(box);
                        }

                // draw
                foreach (Box box in boxList)
                    foreach (Face face in box.Faces)
                        graphics.AddFace(face);
                graphics.Draw();
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
