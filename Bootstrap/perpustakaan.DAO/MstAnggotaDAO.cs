using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class MstAnggotaDAO
    {
        public static List<MstAnggotaViewModel> GetData()
        {
            List<MstAnggotaViewModel> result = new List<MstAnggotaViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = (from mstA in context.MstAnggotas
                          join mstP in context.MstProvinsis
                          on mstA.IDProvinsi equals mstP.ID

                          into j1
                          from j10 in j1.DefaultIfEmpty()
                          join mstK in context.MstKotas
                          on mstA.IDKota equals mstK.ID

                          into j2
                          from j20 in j2.DefaultIfEmpty()
                          select new MstAnggotaViewModel
                          {
                              ID = mstA.ID,
                              KodeAnggota = mstA.KodeAnggota,
                              Nama = mstA.Nama,
                              Alamat = mstA.Alamat,
                              IDProvinsi = mstA.IDProvinsi,
                              NamaProvinsi = j10.NamaProvinsi,
                              IDKota = mstA.IDKota,
                              NamaKota = j20.NamaKota,
                              IDKecamatan = mstA.IDKecamatan,
                              IDKelurahan = mstA.IDKelurahan,
                              Email = mstA.Email,
                              NoTelepon = mstA.NoTelepon,
                              MasaBerlakuKartu = mstA.MasaBerlakuKartu,
                              MasaBerlakuAnggota = mstA.MasaBerlakuAnggota,
                              CreatedOn = mstA.CreatedOn,
                              CreatedBy = mstA.CreatedBy,
                              ModifiedOn = mstA.ModifiedOn,
                              ModifiedBy = mstA.ModifiedBy,
                              LoginID = mstA.LoginID

                          }
                         ).ToList();
                    
            }
            return result;
        }

        public static bool Add(MstAnggotaViewModel IsiData)
        {
            MstAnggota anggota = new MstAnggota();
            anggota.ID = IsiData.ID;
            anggota.KodeAnggota = IsiData.KodeAnggota;
            anggota.Nama = IsiData.Nama;
            anggota.Alamat = IsiData.Alamat;
            anggota.IDProvinsi = IsiData.IDProvinsi;
            anggota.IDKota = IsiData.IDKota;
            anggota.IDKecamatan = IsiData.IDKecamatan;
            anggota.IDKelurahan = IsiData.IDKelurahan;
            anggota.Email = IsiData.Email;
            anggota.NoTelepon = IsiData.NoTelepon;
            anggota.MasaBerlakuKartu = IsiData.MasaBerlakuKartu;
            anggota.MasaBerlakuAnggota = IsiData.MasaBerlakuAnggota;
            anggota.CreatedOn = DateTime.Now;
            anggota.CreatedBy = IsiData.CreatedBy;
            anggota.LoginID = IsiData.LoginID;

            using (PerpusContext context = new PerpusContext())
            {
                context.MstAnggotas.Add(anggota);

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

        public static MstAnggotaViewModel CariID(int id)
        {
            MstAnggotaViewModel hasilID = new MstAnggotaViewModel();
            using(PerpusContext context = new PerpusContext())
            {
                hasilID = (from mstA in context.MstAnggotas 
                           where mstA.ID == id 
                           select new MstAnggotaViewModel
                           {
                            ID = mstA.ID,
                            KodeAnggota = mstA.KodeAnggota,
                            Nama = mstA.Nama,
                            Alamat = mstA.Alamat,
                            IDProvinsi = mstA.IDProvinsi,
                            IDKota = mstA.IDKota,
                            IDKecamatan = mstA.IDKecamatan,
                            IDKelurahan = mstA.IDKelurahan,
                            Email = mstA.Email,
                            NoTelepon = mstA.NoTelepon,
                            MasaBerlakuKartu = mstA.MasaBerlakuKartu,
                            MasaBerlakuAnggota = mstA.MasaBerlakuAnggota
                           }
                           ).FirstOrDefault();
            }
            return hasilID;
        }
        public static bool Update (MstAnggotaViewModel IsiData)
        { 
            using(PerpusContext context = new PerpusContext())
            {
                MstAnggota anggota = context.MstAnggotas.Where(s => s.ID == IsiData.ID).FirstOrDefault();
                //if (anggota != null)
                //{
                    anggota.ID = IsiData.ID;
                    anggota.KodeAnggota = IsiData.KodeAnggota;
                    anggota.Nama = IsiData.Nama;
                    anggota.Alamat = IsiData.Alamat;
                    anggota.IDProvinsi = IsiData.IDProvinsi;
                    anggota.IDKota = IsiData.IDKota;
                    anggota.IDKecamatan = IsiData.IDKecamatan;
                    anggota.IDKelurahan = IsiData.IDKelurahan;
                    anggota.Email = IsiData.Email;
                    anggota.NoTelepon = IsiData.NoTelepon;
                    anggota.MasaBerlakuKartu = IsiData.MasaBerlakuKartu;
                    anggota.MasaBerlakuAnggota = IsiData.MasaBerlakuAnggota;
                    anggota.ModifiedOn = DateTime.Now;
                    anggota.ModifiedBy = IsiData.ModifiedBy;  
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


        public static bool Delete(MstAnggotaViewModel IsiData)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstAnggota anggota = context.MstAnggotas.Where(s => s.ID == IsiData.ID).FirstOrDefault();
                context.MstAnggotas.Remove(anggota);
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
