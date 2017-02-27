using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace perpustakaan.context
{
    [Table("T_R_BRW_DETAIL")]
    public class TrxPinjamanDetail
    {
        [Key]
        public int ID { get; set; }
        public Nullable<int> HeaderID { get; set; }
        public Nullable<int> IDBuku { get; set; }
        public Nullable<System.DateTime> CreateedOn { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
