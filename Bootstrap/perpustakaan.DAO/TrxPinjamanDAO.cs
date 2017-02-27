using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class TrxPinjamanDAO
    {
        public static bool add(TrxPinjamanHeaderViewModel IsiData)
        {
            TrxPinjamanHeader pinjamanHeader = new TrxPinjamanHeader();
            pinjamanHeader.ID = IsiData.ID;
            pinjamanHeader.NoRegistrasi = IsiData.NoRegistrasi;
            pinjamanHeader.NoReferensi = IsiData.NoReferensi;
            pinjamanHeader.IDAnggota = IsiData.IDAnggota;
            pinjamanHeader.TanggalPinjam = IsiData.TanggalPinjam;
            pinjamanHeader.TanggalKembali = IsiData.TanggalKembali;
            pinjamanHeader.CreateedOn = DateTime.Now;
            pinjamanHeader.CreateBy = 1;

            List<TrxPinjamanDetailViewModel> listBuku = IsiData.Detail;
            TrxPinjamanDetail pinjamdetail = new TrxPinjamanDetail();
            foreach (var item in listBuku)
            {                
                pinjamdetail.HeaderID = 1;
                pinjamdetail.ID = 1;
            }

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
    }
}
