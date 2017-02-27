using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class MstKelurahanDAO
    {
        public static List<MstKelurahanViewModel> GetData()
        {
            List<MstKelurahanViewModel> result = new List<MstKelurahanViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.MstKelurahans.Select(x => new MstKelurahanViewModel()
                    {
                        ID = x.ID,                        
                        IDKecamatan = x.IDKecamatan,
                        NamaKelurahan = x.NamaKelurahan,
                        CreatedOn = x.CreatedOn,
                        CreatedBy = x.CreatedBy,
                        ModifiedOn = x.ModifiedOn,
                        ModifiedBy = x.ModifiedBy

                    }).ToList();
            }
            return result;
        }

        public static bool Add(MstKelurahanViewModel IsiData)
        {
            MstKelurahan Kelurahan = new MstKelurahan();
            Kelurahan.ID = IsiData.ID;
            Kelurahan.IDKecamatan = IsiData.IDKecamatan;
            Kelurahan.NamaKelurahan = IsiData.NamaKelurahan;
            Kelurahan.CreatedOn = DateTime.Now;
            Kelurahan.CreatedBy = IsiData.CreatedBy;

            using (PerpusContext context = new PerpusContext())
            {
                context.MstKelurahans.Add(Kelurahan);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return true;

        }

        public static MstKelurahanViewModel CariID(int id)
        {
            MstKelurahanViewModel hasilID = new MstKelurahanViewModel();
            using(PerpusContext context = new PerpusContext())
            {
                hasilID = (from mstA in context.MstKelurahans 
                           where mstA.ID == id
                           select new MstKelurahanViewModel
                           {
                            ID = mstA.ID,
                            IDKecamatan = mstA.IDKecamatan,
                            NamaKelurahan = mstA.NamaKelurahan
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(MstKelurahanViewModel IsiData)
        { 
            using(PerpusContext context = new PerpusContext())
            {
                MstKelurahan Kelurahan = context.MstKelurahans.Where(s => s.ID == IsiData.ID).FirstOrDefault();

                Kelurahan.NamaKelurahan = IsiData.NamaKelurahan;
                    Kelurahan.ModifiedOn = DateTime.Now;
                    Kelurahan.ModifiedBy = IsiData.ModifiedBy;  
                
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return true;
        }


        public static bool Delete(MstKelurahanViewModel IsiData)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstKelurahan Kelurahan = context.MstKelurahans.Where(s => s.ID == IsiData.ID).FirstOrDefault();
                context.MstKelurahans.Remove(Kelurahan);
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return true;
        }
    }
}
