using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpustakaan.context
{
     [Table("T_MST_ANGGOTA")]
    public class MstAnggota
    {
         [Key]
        public int ID { get; set; }
         [Column(TypeName="Varchar")]
         [StringLength(20)]
        public string KodeAnggota { get; set; }
         [Column(TypeName = "Varchar")]
         [StringLength(50)]
        public string Nama { get; set; }
         [Column(TypeName = "Varchar")]
         [StringLength(255)]
        public string Alamat { get; set; }
        public Nullable<int> IDProvinsi { get; set; }
        public Nullable<int> IDKota { get; set; }
        public Nullable<int> IDKecamatan { get; set; }
        public Nullable<int> IDKelurahan { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string NoTelepon { get; set; }
        public System.DateTime MasaBerlakuKartu { get; set; }
        public System.DateTime MasaBerlakuAnggota { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> LoginID { get; set; }
        public virtual ICollection<TrxPinjamanHeader> Pinjamans { get; set; }
    }
}
