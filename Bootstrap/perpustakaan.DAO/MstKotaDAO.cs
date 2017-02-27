using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class MstKotaDAO
    {
        public static List<MstKotaViewModel> GetData()
        {
            List<MstKotaViewModel> result = new List<MstKotaViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.MstKotas.Select(x => new MstKotaViewModel()
                    {
                        ID = x.ID,                        
                        IDProvinsi = x.IDProvinsi,
                        NamaKota = x.NamaKota,
                        CreatedOn = x.CreatedOn,
                        CreatedBy = x.CreatedBy,
                        ModifiedOn = x.ModifiedOn,
                        ModifiedBy = x.ModifiedBy

                    }).ToList();
            }
            return result;
        }

        public static bool Add(MstKotaViewModel IsiData)
        {
            MstKota Kota = new MstKota();
            Kota.ID = IsiData.ID;
            Kota.IDProvinsi = IsiData.IDProvinsi;
            Kota.NamaKota = IsiData.NamaKota;
            Kota.CreatedOn = DateTime.Now;
            Kota.CreatedBy = IsiData.CreatedBy;

            using (PerpusContext context = new PerpusContext())
            {
                context.MstKotas.Add(Kota);

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

        public static MstKotaViewModel CariID(int id)
        {
            MstKotaViewModel hasilID = new MstKotaViewModel();
            using(PerpusContext context = new PerpusContext())
            {
                hasilID = (from mstA in context.MstKotas 
                           where mstA.ID == id
                           select new MstKotaViewModel
                           {
                            ID = mstA.ID,
                            IDProvinsi = mstA.IDProvinsi,
                            NamaKota = mstA.NamaKota
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(MstKotaViewModel IsiData)
        { 
            using(PerpusContext context = new PerpusContext())
            {
                MstKota Kota = context.MstKotas.Where(s => s.ID == IsiData.ID).FirstOrDefault();

                    Kota.NamaKota = IsiData.NamaKota;
                    Kota.ModifiedOn = DateTime.Now;
                    Kota.ModifiedBy = IsiData.ModifiedBy;  
                
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


        public static bool Delete(MstKotaViewModel IsiData)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstKota Kota = context.MstKotas.Where(s => s.ID == IsiData.ID).FirstOrDefault();
                context.MstKotas.Remove(Kota);
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

        public static List<MstKotaViewModel> DataProvKota(int id)
        {
            List<MstKotaViewModel> result = new List<MstKotaViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = (from mstK in context.MstKotas
                          join mstP in context.MstProvinsis
                          on mstK.IDProvinsi equals mstP.ID
                          where mstP.ID == id
                          select new MstKotaViewModel 
                          { 
                            ID = mstK.ID,
                            NamaKota = mstK.NamaKota,
                            IDProvinsi = mstK.IDProvinsi,
                            NamaProvinsi = mstP.NamaProvinsi
                          }
                    ).ToList();
            }
            return result;
        }
    }
}
