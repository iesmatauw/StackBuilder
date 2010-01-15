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
                Graphics3DImage graphics = new Graphics3DImage(new Size(1000, 1000));
                graphics.AngleX = 5.0;
                graphics.AngleY = 5.0;
                graphics.ViewPoint = new Vector3D(1000.0, 1000.0, 1000.0);
                graphics.Target = new Vector3D(0.0, 0.0, 0.0);
                graphics.LightDirection = new Vector3D(-1.0, -1.0, -1.0);
                graphics.SetViewport(-0.0f, -0.0f, 2000.0f, 2000.0f);
                // instantiate box and draw
                List<Box> boxList = new List<Box>();
                Box box00 = new Box(0, 100.0, 75.0, 50.0);
                boxList.Add(box00);
                Box box10 = new Box(0, 100.0, 75.0, 50.0);
                box10.Position = new Vector3D(100.0, 0.0,0.0);
                boxList.Add(box10);
                Box box01 = new Box(0, 100.0, 75.0, 50.0);
                box01.Position = new Vector3D(0.0, 75.0, 0.0);
                boxList.Add(box01);
                Box box11 = new Box(0, 100.0, 75.0, 50.0);
                box11.Position = new Vector3D(0.0, 0.0, 50.0);
                boxList.Add(box11);
                // draw
                foreach (Box box in boxList)
                    foreach (Face face in box.Faces)
                        graphics.AddFace(face);
                graphics.Draw();
                // Save as %TEMP%\Pallet.jpg
                string filePath = Path.Combine(Path.GetTempPath(), "Pallet.bmp");
                graphics.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
