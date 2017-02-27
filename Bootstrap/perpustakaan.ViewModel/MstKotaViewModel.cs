using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace perpustakaan.ViewModel
{
    public class MstKotaViewModel
    {
        [Key]
        public int ID { get; set; }
        public int IDProvinsi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string NamaProvinsi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string NamaKota { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
