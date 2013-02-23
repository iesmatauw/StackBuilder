using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeDim.StackBuilder.SQLite;
using TreeDim.StackBuilder.Basics;

namespace TreeDim.StackBuilder.SQLite.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemStore store = new ItemStore();
            List<PalletProperties> palletProps = store.GetAllPallets();
            foreach (PalletProperties p in palletProps)
                Console.WriteLine(p.Name + " -> " + p.Description); 
        }
    }
}
