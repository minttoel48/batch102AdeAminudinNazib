using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpustakaan.context
{
     [Table("T_MST_PROVINSI")]
    public class MstProvinsi
    {
         [Key]
        public int ID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string NamaProvinsi { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual ICollection<MstAnggota> Anggotas { get; set; }
        public virtual ICollection<MstKota> Kotas { get; set; }
    }
}
