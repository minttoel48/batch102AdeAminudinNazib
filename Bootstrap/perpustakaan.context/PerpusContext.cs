using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpustakaan.context
{
    public class PerpusContext:DbContext
    {
        public PerpusContext()
            : base("name=PerpusConn")
        {
            //Database.SetInitializer<PerpusContext>(null);
        }

        public DbSet<MstAnggota> MstAnggotas { get; set; }
        public DbSet<MstProvinsi> MstProvinsis { get; set; }
        public DbSet<MstKota> MstKotas { get; set; }
        public DbSet<MstKecamatan> MstKecamatans { get; set; }
        public DbSet<MstKelurahan> MstKelurahans { get; set; }
        public DbSet<TrxPinjamanDetail> TrxPinjamanDetails { get; set; }
        public DbSet<TrxPinjamanHeader> TrxPinjamanHeaders { get; set; }
        public DbSet<MstBuku> MstBuku { get; set; }
        public DbSet<MstPetugas> MstPetugas { get; set; }
    }
}
