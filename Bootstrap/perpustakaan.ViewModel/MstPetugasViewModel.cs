using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perpustakaan.ViewModel
{
    public class MstPetugasViewModel
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(10)]
        public string Kode { get; set; }
        [MaxLength(50)]
        public string Nama { get; set; }
        [MaxLength(50)]
        public string Alamat { get; set; }
        [MaxLength(20)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string NoTelepon { get; set; }
    }
}
