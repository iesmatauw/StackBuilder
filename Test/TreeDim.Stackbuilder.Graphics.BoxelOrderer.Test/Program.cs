using System;
using System.Collections.Generic;
using System.Text;
using Sharp3D.Math.Core;

namespace TreeDim.StackBuilder.Graphics
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate
            BoxelOrderer orderer0 = new BoxelOrderer();


            // fill BoxelOrderer class
            Box b0 = new Box(0, 400.0, 300.0, 200.0);
            b0.Position = new Vector3D(300.0, 0.0, 0.0);
            b0.LengthAxis = Vector3D.YAxis;
            b0.WidthAxis = -Vector3D.XAxis;
            orderer0.Add(b0);
            Box b1 = new Box(1, 400.0, 300.0, 200.0);
            b1.Position = new Vector3D(600.0, 0.0, 0.0);
            b1.LengthAxis = Vector3D.YAxis;
            b1.WidthAxis = -Vector3D.XAxis;
            orderer0.Add(b1);
            Box b2 = new Box(2, 400.0, 300.0, 200.0);
            b2.Position = new Vector3D(300.0, 400.0, 0.0);
            b2.LengthAxis = Vector3D.YAxis;
            b2.WidthAxis = -Vector3D.XAxis;
            orderer0.Add(b2);
            Box b3 = new Box(3, 400.0, 300.0, 200.0);
            b3.Position = new Vector3D(600.0, 400.0, 0.0);
            b3.LengthAxis = Vector3D.YAxis;
            b3.WidthAxis = -Vector3D.XAxis;
            orderer0.Add(b3);
            Box b4 = new Box(4, 400.0, 300.0, 200.0);
            b4.Position = new Vector3D(300.0, 800.0, 0.0);
            b4.LengthAxis = Vector3D.YAxis;
            b4.WidthAxis = -Vector3D.XAxis;
            orderer0.Add(b4);
            Box b5 = new Box(5, 400.0, 300.0, 200.0);
            b5.Position = new Vector3D(600.0, 800.0, 0.0);
            b5.LengthAxis = Vector3D.YAxis;
            b5.WidthAxis = -Vector3D.XAxis;
            orderer0.Add(b5);

            Box b6 = new Box(6, 400.0, 300.0, 200.0);
            b6.Position = new Vector3D(600.0, 0.0, 0.0);
            b6.LengthAxis = Vector3D.XAxis;
            b6.WidthAxis = Vector3D.YAxis;
            orderer0.Add(b6);
            Box b7 = new Box(7, 400.0, 300.0, 200.0);
            b7.Position = new Vector3D(600.0, 300.0, 0.0);
            b7.LengthAxis = Vector3D.XAxis;
            b7.WidthAxis = Vector3D.YAxis;
            orderer0.Add(b7);
            Box b8 = new Box(8, 400.0, 300.0, 200.0);
            b8.Position = new Vector3D(600.0, 600.0, 0.0);
            b8.LengthAxis = Vector3D.XAxis;
            b8.WidthAxis = Vector3D.YAxis;
            orderer0.Add(b8);
            Box b9 = new Box(9, 400.0, 300.0, 200.0);
            b9.Position = new Vector3D(600.0, 900.0, 0.0);
            b9.LengthAxis = Vector3D.XAxis;
            b9.WidthAxis = Vector3D.YAxis;
            orderer0.Add(b9);

/*
            orderer.Add(new Box(++pickId, 6.0, 2.0, 5.0, 4.0, 22.0, 0.0));
            orderer.Add(new Box(++pickId, 14.0, 4.0, 5.0, 4.0, 16.0, 0.0));
            orderer.Add(new Box(++pickId, 4.0, 6.0, 5.0, 6.0, 4.0, 0.0));
            orderer.Add(new Box(++pickId, 4.0, 4.0, 5.0, 12.0, 21.0, 0.0));
            orderer.Add(new Box(++pickId, 8.0, 2.0, 5.0, 14.0, 8.0, 0.0));
            orderer.Add(new Box(++pickId, 4.0, 4.0, 5.0, 12.0, 2.0, 0.0));
            orderer.Add(new Box(++pickId, 2.0, 2.0, 5.0, 18.0, 2.0, 0.0));
            orderer.Add(new Box(++pickId, 4.0, 6.0, 5.0, 20.0, 18.0, 0.0));
            orderer.Add(new Box(++pickId, 2.0, 2.0, 5.0, 24.0, 12.0, 0.0));
            orderer.Add(new Box(++pickId, 2.0, 4.0, 5.0, 26.0, 18.0, 0.0));
            orderer.Add(new Box(++pickId, 4.0, 4.0, 5.0, 30.0, 16.0, 0.0));
            orderer.Add(new Box(++pickId, 4.0, 2.0, 5.0, 32.0, 4.0, 0.0));

            orderer.Add(new Box(++pickId, 6.0, 2.0, 5.0, 4.0, 22.0, 5.0));
            orderer.Add(new Box(++pickId, 14.0, 4.0, 5.0, 4.0, 16.0, 5.0));
            orderer.Add(new Box(++pickId, 4.0, 6.0, 5.0, 6.0, 4.0, 5.0));
            orderer.Add(new Box(++pickId, 4.0, 4.0, 5.0, 12.0, 21.0, 5.0));
            orderer.Add(new Box(++pickId, 8.0, 2.0, 5.0, 14.0, 8.0, 5.0));
            orderer.Add(new Box(++pickId, 4.0, 4.0, 5.0, 12.0, 2.0, 5.0));
            orderer.Add(new Box(++pickId, 2.0, 2.0, 5.0, 18.0, 2.0, 5.0));
            orderer.Add(new Box(++pickId, 4.0, 6.0, 5.0, 20.0, 18.0, 5.0));
            orderer.Add(new Box(++pickId, 2.0, 2.0, 5.0, 24.0, 12.0, 5.0));
            orderer.Add(new Box(++pickId, 2.0, 4.0, 5.0, 26.0, 18.0, 5.0));
            orderer.Add(new Box(++pickId, 4.0, 4.0, 5.0, 30.0, 16.0, 5.0));
            orderer.Add(new Box(++pickId, 4.0, 2.0, 5.0, 32.0, 4.0, 5.0));
*/
            Vector3D target = Vector3D.Zero;

            // set direction 0
            Vector3D camera = new Vector3D(-1000.0, -1000.0, 1000.0);
            orderer0.Direction = target - camera;
            List<Box> orderedList = orderer0.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();

            // set direction 1
            camera = new Vector3D(1000.0, -1000.0, 1000.0);
            orderer0.Direction = target - camera;
            orderedList = orderer0.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();

            // set direction 2
            camera = new Vector3D(1000.0, 1000.0, 1000.0);
            orderer0.Direction = target - camera;
            orderedList = orderer0.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();

            // set direction 3
            camera = new Vector3D(-1000.0, 1000.0, 1000.0);
            orderer0.Direction = target - camera;
            orderedList = orderer0.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();


            // instantiate
            BoxelOrderer orderer1 = new BoxelOrderer();


            // fill BoxelOrderer class
 
            Box b16 = new Box(0, 400.0, 300.0, 200.0);
            b16.Position = new Vector3D(0.0, 0.0, 0.0);
            b16.LengthAxis = Vector3D.XAxis;
            b16.WidthAxis = Vector3D.YAxis;
            orderer1.Add(b16);
            Box b17 = new Box(1, 400.0, 300.0, 200.0);
            b17.Position = new Vector3D(0.0, 300.0, 0.0);
            b17.LengthAxis = Vector3D.XAxis;
            b17.WidthAxis = Vector3D.YAxis;
            orderer1.Add(b17);
            Box b18 = new Box(2, 400.0, 300.0, 200.0);
            b18.Position = new Vector3D(0.0, 600.0, 0.0);
            b18.LengthAxis = Vector3D.XAxis;
            b18.WidthAxis = Vector3D.YAxis;
            orderer1.Add(b18);
            Box b19 = new Box(3, 400.0, 300.0, 200.0);
            b19.Position = new Vector3D(0.0, 900.0, 0.0);
            b19.LengthAxis = Vector3D.XAxis;
            b19.WidthAxis = Vector3D.YAxis;
            orderer1.Add(b19);

            Box b10 = new Box(4, 400.0, 300.0, 200.0);
            b10.Position = new Vector3D(700.0, 0.0, 0.0);
            b10.LengthAxis = Vector3D.YAxis;
            b10.WidthAxis = -Vector3D.XAxis;
            orderer1.Add(b10);
            Box b11 = new Box(5, 400.0, 300.0, 200.0);
            b11.Position = new Vector3D(1000.0, 0.0, 0.0);
            b11.LengthAxis = Vector3D.YAxis;
            b11.WidthAxis = -Vector3D.XAxis;
            orderer1.Add(b11);
            Box b12 = new Box(6, 400.0, 300.0, 200.0);
            b12.Position = new Vector3D(700.0, 400.0, 0.0);
            b12.LengthAxis = Vector3D.YAxis;
            b12.WidthAxis = -Vector3D.XAxis;
            orderer1.Add(b12);
            Box b13 = new Box(7, 400.0, 300.0, 200.0);
            b13.Position = new Vector3D(1000.0, 400.0, 0.0);
            b13.LengthAxis = Vector3D.YAxis;
            b13.WidthAxis = -Vector3D.XAxis;
            orderer1.Add(b13);
            Box b14 = new Box(8, 400.0, 300.0, 200.0);
            b14.Position = new Vector3D(700.0, 800.0, 0.0);
            b14.LengthAxis = Vector3D.YAxis;
            b14.WidthAxis = -Vector3D.XAxis;
            orderer1.Add(b14);
            Box b15 = new Box(9, 400.0, 300.0, 200.0);
            b15.Position = new Vector3D(1000.0, 800.0, 0.0);
            b15.LengthAxis = Vector3D.YAxis;
            b15.WidthAxis = -Vector3D.XAxis;
            orderer1.Add(b15);


            // set direction 0
            camera = new Vector3D(-1000.0, -1000.0, 1000.0);
            orderer1.Direction = target - camera;
            orderedList = orderer1.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();

            // set direction 1
            camera = new Vector3D(1000.0, -1000.0, 1000.0);
            orderer1.Direction = target - camera;
            orderedList = orderer1.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();

            // set direction 2
            camera = new Vector3D(1000.0, 1000.0, 1000.0);
            orderer1.Direction = target - camera;
            orderedList = orderer1.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();

            // set direction 3
            camera = new Vector3D(-1000.0, 1000.0, 1000.0);
            orderer1.Direction = target - camera;
            orderedList = orderer1.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();

        }
    }
}
