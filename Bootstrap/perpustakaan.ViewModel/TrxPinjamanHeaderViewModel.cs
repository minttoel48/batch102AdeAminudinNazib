using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace perpustakaan.ViewModel
{
    public class TrxPinjamanHeaderViewModel
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        public string NoRegistrasi { get; set; }
        [MaxLength(20)]
        public string NoReferensi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Nama { get; set; }
        public Nullable<int> IDAnggota { get; set; }
        public Nullable<System.DateTime> TanggalPinjam { get; set; }
        public Nullable<System.DateTime> TanggalKembali { get; set; }
        public Nullable<System.DateTime> CreateedOn { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> Status { get; set; }

        public List<TrxPinjamanDetailViewModel> Detail { get; set; }
        public List<int> ListIDBuku { get; set; }
    }
}
