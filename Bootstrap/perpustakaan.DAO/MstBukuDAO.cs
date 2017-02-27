using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//tambahkan
using perpustakaan.ViewModel;
using perpustakaan.context;

namespace perpustakaan.DAO
{
    public class MstBukuDAO
    {
        public static List<MstBukuViewModel> Getdata()
        {
            List<MstBukuViewModel> result = new List<MstBukuViewModel>();
            PerpusContext context = new PerpusContext();

            result = context.MstBuku.Select(x => new MstBukuViewModel()
            {
                ID = x.ID,
                IDKategori = x.IDKategori,
                IDPenerbit = x.IDPenerbit,
                Kode = x.Kode,
                JudulBuku = x.JudulBuku,
                ISBN = x.ISBN,
                Pengarang = x.Pengarang,
                Lokasi = x.Lokasi,
                Aktif = x.Aktif,
                Value = x.Value,
                IDSumberBuku = x.IDSumberBuku
            }
            ).ToList();

            return result;
        }


        public static MstBukuViewModel GetDataByID (int id)
        {
            MstBukuViewModel result = new MstBukuViewModel();
            using (PerpusContext context = new PerpusContext())
            {
                result = context.MstBuku.Where(x => x.ID == id)
                    .Select(x => new MstBukuViewModel()
                    {
                        ID = x.ID,
                        IDKategori = x.IDKategori,
                        IDPenerbit = x.IDPenerbit,
                        IDSumberBuku = x.IDSumberBuku,
                        JudulBuku = x.JudulBuku,
                        Kode = x.Kode,
                        ISBN = x.ISBN,
                        Pengarang = x.Pengarang,
                        Lokasi = x.Lokasi,
                        Aktif = x.Aktif,
                        Value = x.Value,
                    }).FirstOrDefault();
            }
            return result;
        }



        public static bool Add(MstBukuViewModel model)
        {
            MstBuku buku = new MstBuku();
            buku.ID = model.ID;
            buku.IDKategori = model.IDKategori;
            buku.IDPenerbit = model.IDPenerbit;
            buku.Kode = model.Kode;
            buku.JudulBuku = model.JudulBuku;
            buku.ISBN = model.ISBN;
            buku.Pengarang = model.Pengarang;
            buku.Lokasi = model.Lokasi;
            buku.Aktif = model.Aktif;
            buku.Value = model.Value;
            buku.IDSumberBuku = model.IDSumberBuku;

            using (PerpusContext context = new PerpusContext())
            {
                context.MstBuku.Add(buku);
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


        public static bool Update(MstBukuViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {

                MstBuku buku = context.MstBuku.Where(s => s.ID == model.ID).FirstOrDefault();

                buku.ID = model.ID;
                buku.IDKategori = model.IDKategori;
                buku.IDPenerbit = model.IDPenerbit;
                buku.Kode = model.Kode;
                buku.JudulBuku = model.JudulBuku;
                buku.ISBN = model.ISBN;
                buku.Pengarang = model.Pengarang;
                buku.Lokasi = model.Lokasi;
                buku.Aktif = model.Aktif;
                buku.Value = model.Value;
                buku.IDSumberBuku = model.IDSumberBuku;

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


        public static MstBukuViewModel CariIDBuku(int id)
        {
            MstBukuViewModel HasilCari = new MstBukuViewModel();
            using (PerpusContext _context = new PerpusContext())
            {
                HasilCari = (from mstB in _context.MstBuku
                             where mstB.ID == id
                             select new MstBukuViewModel
                             {
                                 ID = mstB.ID,
                                 IDKategori = mstB.IDKategori,
                                 IDPenerbit = mstB.IDPenerbit,
                                 Kode = mstB.Kode,
                                 JudulBuku = mstB.JudulBuku,
                                 ISBN = mstB.ISBN,
                                 Pengarang = mstB.Pengarang,
                                 Lokasi = mstB.Lokasi,
                                 Aktif = mstB.Aktif,
                                 Value = mstB.Value,
                                 IDSumberBuku = mstB.IDSumberBuku
                             }

                                 ).FirstOrDefault();

            }
            return HasilCari;
        }



        public static bool Hapus(MstBukuViewModel model)
        {
            using (PerpusContext context = new PerpusContext())
            {

                MstBuku buku = context.MstBuku.Where(s => s.ID == model.ID).FirstOrDefault();
                context.MstBuku.Remove(buku);

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
