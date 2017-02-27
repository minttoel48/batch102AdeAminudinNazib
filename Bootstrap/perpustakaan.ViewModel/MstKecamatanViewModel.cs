using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpustakaan.ViewModel
{
    public class MstKecamatanViewModel
    {
        public int ID { get; set; }
        public int IDKota { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string NamaKota { get; set; }
        public string NamaKecamatan { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
