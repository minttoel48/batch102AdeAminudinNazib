using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class MstProvinsiDAO
    {
        public static List<MstProvinsiViewModel> GetData()
        {
            List<MstProvinsiViewModel> result = new List<MstProvinsiViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.MstProvinsis.Select(x => new MstProvinsiViewModel()
                    {
                        ID = x.ID,
                        NamaProvinsi = x.NamaProvinsi,
                        CreatedOn = x.CreatedOn,
                        CreatedBy = x.CreatedBy,
                        ModifiedOn = x.ModifiedOn,
                        ModifiedBy = x.ModifiedBy

                    }).ToList();
            }
            return result;
        }

        public static bool Add(MstProvinsiViewModel IsiData)
        {
            MstProvinsi anggota = new MstProvinsi();
            anggota.ID = IsiData.ID;
            anggota.NamaProvinsi = IsiData.NamaProvinsi;
            anggota.CreatedOn = DateTime.Now;
            anggota.CreatedBy = IsiData.CreatedBy;

            using (PerpusContext context = new PerpusContext())
            {
                context.MstProvinsis.Add(anggota);

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

        public static MstProvinsiViewModel CariID(int id)
        {
            MstProvinsiViewModel hasilID = new MstProvinsiViewModel();
            using(PerpusContext context = new PerpusContext())
            {
                hasilID = (from mstA in context.MstProvinsis 
                           where mstA.ID == id
                           select new MstProvinsiViewModel
                           {
                            ID = mstA.ID,
                            NamaProvinsi = mstA.NamaProvinsi
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update(MstProvinsiViewModel IsiData)
        { 
            using(PerpusContext context = new PerpusContext())
            {
                MstProvinsi Provinsi = context.MstProvinsis.Where(s => s.ID == IsiData.ID).FirstOrDefault();
                //if (anggota != null)
                //{
                    Provinsi.ID = IsiData.ID;
                    Provinsi.NamaProvinsi = IsiData.NamaProvinsi;
                    Provinsi.ModifiedOn = DateTime.Now;
                    Provinsi.ModifiedBy = IsiData.ModifiedBy;  
               // }
                
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


        public static bool Delete(MstProvinsiViewModel IsiData)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstProvinsi Provinsi = context.MstProvinsis.Where(s => s.ID == IsiData.ID).FirstOrDefault();
                context.MstProvinsis.Remove(Provinsi);
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
