#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

using TreeDim.StackBuilder.Basics;
using TreeDim.StackBuilder.Engine;
using TreeDim.StackBuilder.Graphics;

using Sharp3D.Math.Core;
using log4net;
using log4net.Config;
#endregion

namespace TreeDim.StackBuilder.Engine.Test
{
    class Program
    {
        static int Main(string[] args)
        {
            ILog log = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure();

            try
            {
                bool useSingleColor = false;
                // instantiate document
                Document doc = new Document("Test", "Test", "fga", DateTime.Now, null);

                // define pallet properties
                PalletProperties palletProperties = new PalletProperties(doc, "EUR2", 1200, 1000, 150);
                Console.WriteLine("=== Pallet properties ===");
                Console.WriteLine(palletProperties.ToString());

                bool testCylinder = false;
                if (!testCylinder)
                {
                    // define box properties
                    BoxProperties boxProperties = new BoxProperties(doc, 162, 210, 250);
                    boxProperties.Name = "Box1";
                    boxProperties.Weight = 3.0;
                    if (!useSingleColor)
                    {
                        boxProperties.SetColor(HalfAxis.HAxis.AXIS_X_N, Color.Red);
                        boxProperties.SetColor(HalfAxis.HAxis.AXIS_X_P, Color.Red);
                        boxProperties.SetColor(HalfAxis.HAxis.AXIS_Y_N, Color.Green);
                        boxProperties.SetColor(HalfAxis.HAxis.AXIS_Y_P, Color.Green);
                        boxProperties.SetColor(HalfAxis.HAxis.AXIS_Z_N, Color.Blue);
                        boxProperties.SetColor(HalfAxis.HAxis.AXIS_Z_P, Color.Blue);
                    }
                    else
                        boxProperties.SetColor(Color.Chocolate);

                    Console.WriteLine(boxProperties.ToString());


                    InterlayerProperties interlayerProperties = null;

                    // define constraints
                    CasePalletConstraintSet constraintSet = new CasePalletConstraintSet();
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_N, true);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_X_P, true);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_N, true);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Y_P, true);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_N, true);
                    constraintSet.SetAllowedOrthoAxis(HalfAxis.HAxis.AXIS_Z_P, true);

                    constraintSet.SetAllowedPattern("Trilock");

                    constraintSet.AllowAlignedLayers = true;
                    constraintSet.AllowAlternateLayers = false;

                    constraintSet.MaximumPalletWeight = 2000;
                    constraintSet.MaximumNumberOfItems = 2000;
                    constraintSet.MaximumHeight = 2000.0;
                    constraintSet.UseMaximumHeight = true;
                    constraintSet.UseMaximumPalletWeight = true;
                    constraintSet.UseMaximumWeightOnBox = false;
                    constraintSet.AllowLastLayerOrientationChange = true;
                    Console.WriteLine("=== Constraint set ===");
                    Console.WriteLine(constraintSet.ToString());

                    // initialize analysis
                    CasePalletAnalysis analysis = new CasePalletAnalysis(boxProperties, palletProperties, interlayerProperties, constraintSet);

                    // initialize solver
                    CasePalletSolver solver = new CasePalletSolver();
                    solver.ProcessAnalysis(analysis);

                    Console.WriteLine("=== Solutions ===");
                    int solIndex = 0;
                    foreach (CasePalletSolution sol in analysis.Solutions)
                    {
                        // instantiate graphics
                        Graphics3DImage graphics = new Graphics3DImage(new Size(1000, 1000));
                        graphics.CameraPosition = new Vector3D(10000.0, 10000.0, 10000.0);
                        graphics.Target = Vector3D.Zero;
                        graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                        // instantiate solution viewer
                        CasePalletSolutionViewer sv = new CasePalletSolutionViewer(sol);
                        sv.Draw(graphics);
                        // save
                        string fileName = string.Format("Pallet_{0}.bmp", solIndex++);
                        string filePath = Path.Combine(Path.GetTempPath(), fileName);
                        Console.WriteLine("Saving file " + filePath + "...");
                        graphics.SaveAs(filePath);
                    }
                }
                else
                {
                    // cylinder
                    Console.WriteLine("=== Cylinder properties ===");
                    CylinderProperties cylProperties = new CylinderProperties(doc, "Cylinder", "Default cylinder", 90, 100, 1.5, Color.Gray, Color.SkyBlue);
                    Console.WriteLine(cylProperties.ToString());
                    // constraint set
                    Console.WriteLine("=== Constraint set ===");
                    CylinderPalletConstraintSet constraintSet = new CylinderPalletConstraintSet();
                    constraintSet.UseMaximumPalletHeight = true;
                    constraintSet.MaximumPalletHeight = 1200.0;
                    constraintSet.UseMaximumPalletWeight = true;
                    constraintSet.MaximumPalletWeight = 2000;
                    constraintSet.UseMaximumNumberOfItems = true;
                    constraintSet.MaximumNumberOfItems = 2000;
                    Console.WriteLine(constraintSet.ToString());
                    // cylinder analysis
                    CylinderPalletAnalysis analysis = new CylinderPalletAnalysis(cylProperties, palletProperties, null, constraintSet);
                    // initialize solver
                    CylinderSolver solver = new CylinderSolver();
                    solver.ProcessAnalysis(analysis);
                    Console.WriteLine("=== Solutions ===");
                    int solIndex = 0;
                    foreach (CylinderPalletSolution sol in analysis.Solutions)
                    {
                        // instantiate graphics
                        Graphics3DImage graphics = new Graphics3DImage(new Size(512, 512));
                        graphics.CameraPosition = new Vector3D(10000.0, 10000.0, 10000.0);
                        graphics.Target = Vector3D.Zero;
                        graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
                        // instantiate solution viewer
                        CylinderPalletSolutionViewer sv = new CylinderPalletSolutionViewer(sol);
                        sv.Draw(graphics);
                        string fileName = string.Format("Pallet_{0}.jpg", solIndex++);
                        string filePath = Path.Combine(Path.GetTempPath(), fileName);
                        Console.WriteLine("Saving file " + filePath + "...");
                        graphics.SaveAs(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            return 0;
        }
    }
}
