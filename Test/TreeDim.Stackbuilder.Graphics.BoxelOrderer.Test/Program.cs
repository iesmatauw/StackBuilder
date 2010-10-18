using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDim.StackBuilder.Graphics
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate
            BoxelOrderer orderer = new BoxelOrderer();
            // fill BoxelOrderer class
            uint pickId = 0;

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

            List<Box> orderedList = orderer.GetSortedList();
            Console.WriteLine("******************************");
            foreach (Box b in orderedList)
                Console.Write("{0} ", b.PickId);
            Console.WriteLine();
        }
    }
}
