﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema; //utk script table

namespace perpustakaan.context
{
    [Table("T_MST_BUKU")]
    public class MstBuku
    {
        public int ID { get; set; }
        public int IDKategori { get; set; }
        public int IDPenerbit { get; set; }
        public string Kode { get; set; }
        public string JudulBuku { get; set; }
        public string ISBN { get; set; }
        public string Pengarang { get; set; }
        public Nullable<int> Lokasi { get; set; }
        public Nullable<int> Aktif { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<int> IDSumberBuku { get; set; }
    }
}
