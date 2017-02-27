using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class MstPetugasDAO
    {
        public static List<MstPetugasViewModel> GetData()
        {
            List<MstPetugasViewModel> result = new List<MstPetugasViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.MstPetugas.Select(x => new MstPetugasViewModel()
                {
                    ID = x.ID,
                    Kode = x.Kode,
                    Nama = x.Nama,
                    Alamat = x.Alamat,
                    Email = x.Email,
                    Password = x.Password,
                    NoTelepon = x.NoTelepon,             

                }).ToList();
                return result;
            }
        }

        public static bool Add(MstPetugasViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstPetugas petugas = new MstPetugas();
                petugas.ID = model.ID;
                petugas.Kode = model.Kode;
                petugas.Nama = model.Nama;
                petugas.Alamat = model.Alamat;
                petugas.Email = model.Email;
                petugas.Password = model.Password;
                petugas.NoTelepon = model.NoTelepon;  

                context.MstPetugas.Add(petugas);

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
        }

        public static bool Update(MstPetugasViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstPetugas petugas = context.MstPetugas.Where(s => s.ID == model.ID).FirstOrDefault();

                petugas.ID = model.ID;
                petugas.Kode = model.Kode;
                petugas.Nama = model.Nama;
                petugas.Alamat = model.Alamat;
                petugas.Email = model.Email;
                petugas.Password = model.Password;
                petugas.NoTelepon = model.NoTelepon;

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
        }

        public static MstPetugasViewModel CariBerdasarkanID(int id)
        {
            MstPetugasViewModel Objecthasilnya = new MstPetugasViewModel();
            using (PerpusContext _perpusContext = new PerpusContext())
            {
                Objecthasilnya = (from mstA in _perpusContext.MstPetugas
                                  where mstA.ID == id
                                  select new MstPetugasViewModel
                                  {
                                      ID = mstA.ID,
                                      Kode = mstA.Kode,
                                      Nama = mstA.Nama,
                                      Alamat = mstA.Alamat,
                                      Email = mstA.Email,
                                      Password = mstA.Password,
                                      NoTelepon = mstA.NoTelepon,  
                                  }

                            ).FirstOrDefault();
            }
            return Objecthasilnya;
        }

        public static bool Delete(MstPetugasViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {
                MstPetugas petugas = context.MstPetugas.Where(s => s.ID == model.ID).FirstOrDefault();
                context.MstPetugas.Remove(petugas);

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
        }
    }
}
