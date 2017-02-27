using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpustakaan.ViewModel
{
    public class MstKelurahanViewModel
    {
        public int ID { get; set; }
        public int IDKecamatan { get; set; }
        public string NamaKelurahan { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
