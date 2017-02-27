using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace perpustakaan.context
{
    [Table("T_R_BRW_HEADER")]
    public class TrxPinjamanHeader
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        public string NoRegistrasi { get; set; }
        [MaxLength(20)]
        public string NoReferensi { get; set; }
        public Nullable<int> IDAnggota { get; set; }
        public Nullable<System.DateTime> TanggalPinjam { get; set; }
        public Nullable<System.DateTime> TanggalKembali { get; set; }
        public Nullable<System.DateTime> CreateedOn { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> Status { get; set; }
        public virtual ICollection<MstAnggota> Anggotas { get; set; }
    }
}
