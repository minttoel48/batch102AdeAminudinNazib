using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class TrxPinjamanHeaderDAO
    {
        public static List<TrxPinjamanHeaderViewModel> GetData()
        {
            List<TrxPinjamanHeaderViewModel> result = new List<TrxPinjamanHeaderViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.TrxPinjamanHeaders.Select(x => new TrxPinjamanHeaderViewModel()
                {
                    ID = x.ID,
                    NoRegistrasi = x.NoRegistrasi,
                    NoReferensi = x.NoReferensi,
                    IDAnggota = x.IDAnggota,
                    TanggalPinjam = x.TanggalPinjam,
                    TanggalKembali = x.TanggalKembali,
                    CreateedOn = x.CreateedOn,
                    CreateBy = x.CreateBy,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy,
                    Status = x.Status
                }).ToList();
            }
            return result;
        }
        public static bool Add(TrxPinjamanHeaderViewModel model)
        {
            TrxPinjamanHeader pinjamanHeader = new TrxPinjamanHeader();
            pinjamanHeader.ID = model.ID;
            pinjamanHeader.NoRegistrasi = model.NoRegistrasi;
            pinjamanHeader.NoReferensi = model.NoReferensi;
            pinjamanHeader.IDAnggota = model.IDAnggota;
            pinjamanHeader.TanggalPinjam = model.TanggalPinjam;
            pinjamanHeader.TanggalKembali = model.TanggalKembali;


            pinjamanHeader.CreateedOn = DateTime.Now;
            pinjamanHeader.CreateBy = 1;
            pinjamanHeader.Status = model.Status;

            using (PerpusContext context = new PerpusContext())
            {
                context.TrxPinjamanHeaders.Add(pinjamanHeader);
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
        public static bool Update(TrxPinjamanHeaderViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {
                TrxPinjamanHeader pinjamanHeader = context.TrxPinjamanHeaders.Where(s => s.ID == model.ID).FirstOrDefault();
                pinjamanHeader.ID = model.ID;
                pinjamanHeader.NoRegistrasi = model.NoRegistrasi;
                pinjamanHeader.NoReferensi = model.NoReferensi;
                pinjamanHeader.IDAnggota = model.IDAnggota;
                pinjamanHeader.TanggalPinjam = model.TanggalPinjam;
                pinjamanHeader.TanggalKembali = model.TanggalKembali;


                pinjamanHeader.CreateedOn = DateTime.Now;
                pinjamanHeader.CreateBy = 1;
                pinjamanHeader.Status = model.Status;
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
        public static TrxPinjamanHeaderViewModel CariBerdasarkanId(int id)
        {
            TrxPinjamanHeaderViewModel Objecthasilnya = new TrxPinjamanHeaderViewModel();
            using (PerpusContext _perpusContext = new PerpusContext())
            {
                Objecthasilnya = (from mstA in _perpusContext.TrxPinjamanHeaders
                                  where mstA.ID == id
                                  select new TrxPinjamanHeaderViewModel
                                  {
                                      ID = mstA.ID,
                                      NoRegistrasi = mstA.NoRegistrasi,
                                      NoReferensi = mstA.NoReferensi,
                                      IDAnggota = mstA.IDAnggota,
                                      TanggalPinjam= mstA.TanggalPinjam,
                                      TanggalKembali = mstA.TanggalKembali,
                                      Status= mstA.Status,
                                  }

                    ).FirstOrDefault();
            }
            return Objecthasilnya;
        }
        public static bool Delete(TrxPinjamanHeaderViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {
                TrxPinjamanHeader pinjamanHeader = context.TrxPinjamanHeaders.Where(s => s.ID == model.ID).FirstOrDefault();
                context.TrxPinjamanHeaders.Remove(pinjamanHeader);

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
