using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class TrxPinjamanDetailDAO
    {
        public static List<TrxPinjamanDetailViewModel> GetData()
        {
            List<TrxPinjamanDetailViewModel> result = new List<TrxPinjamanDetailViewModel>();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.TrxPinjamanDetails.Select(x => new TrxPinjamanDetailViewModel()
                {
                    ID = x.ID,
                    HeaderID = x.HeaderID,
                    IDBuku = x.IDBuku,                  
                    CreateBy = x.CreateBy,
                    CreateedOn = x.CreateedOn,
                    ModifiedOn = x.ModifiedOn,
                    ModifiedBy = x.ModifiedBy
                }).ToList();
            }
            return result;
        }
        public static bool Add(TrxPinjamanDetailViewModel model)
        {
            TrxPinjamanDetail pinjamanDetail = new TrxPinjamanDetail();
            pinjamanDetail.ID = model.ID;
            pinjamanDetail.HeaderID = model.HeaderID;
            pinjamanDetail.IDBuku = model.IDBuku;

            pinjamanDetail.CreateedOn = DateTime.Now;
            pinjamanDetail.CreateBy = 1;

            using (PerpusContext context = new PerpusContext())
            {
                context.TrxPinjamanDetails.Add(pinjamanDetail);
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
        public static bool Update(TrxPinjamanDetailViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {
                TrxPinjamanDetail pinjamanDetail = context.TrxPinjamanDetails.Where(s => s.ID == model.ID).FirstOrDefault();
                pinjamanDetail.ID = model.ID;
                pinjamanDetail.HeaderID = model.HeaderID;
                pinjamanDetail.IDBuku = model.IDBuku;

                pinjamanDetail.CreateedOn = DateTime.Now;
                pinjamanDetail.CreateBy = 1;

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
        public static TrxPinjamanDetailViewModel CariBerdasarkanId(int id)
        {
            TrxPinjamanDetailViewModel Objecthasilnya = new TrxPinjamanDetailViewModel();
            using (PerpusContext _perpusContext = new PerpusContext())
            {
                Objecthasilnya = (from mstA in _perpusContext.TrxPinjamanDetails
                                  where mstA.ID == id
                                  select new TrxPinjamanDetailViewModel
                                  {
                                      ID = mstA.ID,
                                      HeaderID = mstA.HeaderID,
                                      IDBuku = mstA.IDBuku,
                                  }

                    ).FirstOrDefault();
            }
            return Objecthasilnya;
        }
        public static bool Delete(TrxPinjamanDetailViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {
                TrxPinjamanDetail pinjamanDetail = context.TrxPinjamanDetails.Where(s => s.ID == model.ID).FirstOrDefault();
                context.TrxPinjamanDetails.Remove(pinjamanDetail);

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
