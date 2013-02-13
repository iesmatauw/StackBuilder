
#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using TreeDim.StackBuilder.Basics;
#endregion

namespace TreeDim.StackBuilder.SQLite
{
    public class ItemStore : IDisposable
    {
        #region Public methods
        public List<PalletProperties> GetAllPallets(Users user)
        {
            List<PalletProperties> palletProperties = new List<PalletProperties>();
            StackBuilderEntities db = new StackBuilderEntities();
            var pallets = db.Pallets.Where(p => p.UserID_PalletID.Any(up => up.UserID == user.ID));
            foreach (Pallets p in pallets)
            {
                PalletProperties pp = new PalletProperties(null, p.Type, p.Length, p.Width, p.Height);
                pp.Name = p.Name;
                pp.Description = p.Description;
                pp.Guid = p.GUID;
                pp.Weight = p.Weight;
                pp.AdmissibleLoadWeight = p.MaxLoad;
                pp.Color = Color.FromArgb(p.Color);
                palletProperties.Add(pp);
            }
            return palletProperties;
        }

        public List<PalletProperties> GetAllPallets()
        { 
            StackBuilderEntities db = new StackBuilderEntities();
            var user = db.Users.SingleOrDefault(u => u.ID == 1);

            return GetAllPallets(user);
        }
        #endregion

        #region IDisposable implementation
        public void Dispose()
        {        
        }
        private void Dispose(bool disposing)
        {
        }
        #endregion
    }
}
