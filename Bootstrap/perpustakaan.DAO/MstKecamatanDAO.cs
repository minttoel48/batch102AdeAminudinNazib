using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class MstKecamatanDAO
    {
        public static List<MstKecamatanViewModel> GetData()
        {
            List<MstKecamatanViewModel> result = new List<MstKecamatanViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.MstKecamatans.Select(x => new MstKecamatanViewModel()
                    {
                        ID = x.ID,                        
                        IDKota = x.IDKota,
                        NamaKecamatan = x.NamaKecamatan,
                        CreatedOn = x.CreatedOn,
                        CreatedBy = x.CreatedBy,
                        ModifiedOn = x.ModifiedOn,
                        ModifiedBy = x.ModifiedBy

                    }).ToList();
            }
            return result;
        }

        public static bool Add(MstKecamatanViewModel IsiData)
        {
            MstKecamatan Kecamatan = new MstKecamatan();
            Kecamatan.ID = IsiData.ID;
            Kecamatan.IDKota = IsiData.IDKota;
            Kecamatan.NamaKecamatan = IsiData.NamaKecamatan;
            Kecamatan.CreatedOn = DateTime.Now;
            Kecamatan.CreatedBy = IsiData.CreatedBy;

            using (PerpusContext context = new PerpusContext())
            {
                context.MstKecamatans.Add(Kecamatan);

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

        public static MstKecamatanViewModel CariID(int id)
        {
            MstKecamatanViewModel hasilID = new MstKecamatanViewModel();
            using(PerpusContext context = new PerpusContext())
            {
                hasilID = (from mstA in context.MstKecamatans 
                           where mstA.ID == id
                           select new MstKecamatanViewModel
                           {
                            ID = mstA.ID,
                            IDKota = mstA.IDKota,
                            NamaKecamatan = mstA.NamaKecamatan
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(MstKecamatanViewModel IsiData)
        { 
            using(PerpusContext context = new PerpusContext())
            {
                MstKecamatan Kecamatan = context.MstKecamatans.Where(s => s.ID == IsiData.ID).FirstOrDefault();

                Kecamatan.NamaKecamatan = IsiData.NamaKecamatan;
                    Kecamatan.ModifiedOn = DateTime.Now;
                    Kecamatan.ModifiedBy = IsiData.ModifiedBy;  
                
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


        public static bool Delete(MstKecamatanViewModel IsiData)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstKecamatan Kecamatan = context.MstKecamatans.Where(s => s.ID == IsiData.ID).FirstOrDefault();
                context.MstKecamatans.Remove(Kecamatan);
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

        public static List<MstKecamatanViewModel> DataKotaKec(int id)
        {
            List<MstKecamatanViewModel> result = new List<MstKecamatanViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = (from mstKc in context.MstKecamatans
                          join mstK in context.MstKotas
                          on mstKc.IDKota equals mstK.ID
                          where mstK.ID == id
                          select new MstKecamatanViewModel
                          {
                              ID = mstKc.ID,
                              NamaKecamatan = mstKc.NamaKecamatan,
                              IDKota= mstKc.IDKota,
                              NamaKota = mstK.NamaKota
                          }
                    ).ToList();
            }
            return result;
        }
    }
}
