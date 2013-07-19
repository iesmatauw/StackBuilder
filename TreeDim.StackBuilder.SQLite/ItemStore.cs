
#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using TreeDim.StackBuilder.Basics;
using TreeDim.EdgeCrushTest;
#endregion

namespace TreeDim.StackBuilder.SQLite
{
    public class ItemStore : IDisposable
    {
        #region Pallets
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
                pp.Color = Color.FromArgb(Convert.ToInt32(p.Color));
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
/*
        #region QualityData
        public List<McKeeFormula.QualityData> GetAllQualityData(Users user)
        {
            List<McKeeFormula.QualityData> cardboardQualities = new List<McKeeFormula.QualityData>();
            StackBuilderEntities db = new StackBuilderEntities();
            var qualities = db.CardboardQualityData.Where(q => q.UserID_CardboardQualityID.Any(uq => uq.UserID == user.ID));
            foreach (CardboardQualityData cqd in qualities)
            {
                McKeeFormula.QualityData qd = new McKeeFormula.QualityData(
                    cqd.Name, cqd.Profile, cqd.Thickness, cqd.ECT
                    , cqd.RigidityDX, cqd.RigidityDY);
                cardboardQualities.Add(qd);
            }
            return cardboardQualities;
        }

        public List<McKeeFormula.QualityData> GetAllQualityData()
        {
            StackBuilderEntities db = new StackBuilderEntities();
            var user = db.Users.SingleOrDefault(u => u.ID == 1);
            return GetAllQualityData(user);        
        }

        public McKeeFormula.QualityData GetQualityDataByName(Int64 userId, string name)
        {
            StackBuilderEntities db = new StackBuilderEntities();
            var quality = db.CardboardQualityData.SingleOrDefault(cqd => cqd.Name == name && cqd.UserID_CardboardQualityID.Any(uq => uq.UserID == userId));
            return new McKeeFormula.QualityData(quality.Name, quality.Profile, quality.Thickness, quality.ECT, quality.RigidityDX, quality.RigidityDY);
        }

        public McKeeFormula.QualityData CreateNew(Int64 userId, string name, string profile, float thickness, float ect, float rigidityX, float rigidityY)
        {
            using (StackBuilderEntities context = new StackBuilderEntities())
            {
                context.CardboardQualityData.AddObject(
                    new CardboardQualityData()
                    {
                        Name = name,
                        Profile = profile,
                        Thickness = thickness,
                        ECT = ect,
                        RigidityDX = rigidityX,
                        RigidityDY = rigidityY,
                        UserID_CardboardQualityID =
                        {
                            new UserID_CardboardQualityID()
                            {
                                UserID = userId
                            }
                        }
                    }
                );
                context.SaveChanges();
            }

            return GetQualityDataByName(userId, name);
        }
        #endregion
*/
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
