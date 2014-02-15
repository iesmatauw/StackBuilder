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
            try
            {
                ItemStore store = new ItemStore();
                List<PalletProperties> palletProps = store.GetAllPallets();
                foreach (PalletProperties p in palletProps)
                    Console.WriteLine(p.Name + " -> " + p.Description);
/*
                McKeeFormula.QualityData cqd = store.CreateNew(1, "B_125 Grade-459 g/m2", "B", 2.87f, 6.77f, 4.53f, 2.38f);
 */ 
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
