using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Detail_Produk
    {
        [Key]
        public int Id_Detail_Produk { get; set; }
        [ForeignKey("Produk")]
        public int Id_Produk { get; set; }
        [ForeignKey("Ukuran")]
        public int Id_Ukuran { get; set; }

        public string Nama_Produk { get; set; }

        public decimal Harga_Jual { get; set; }

        public string Nilai_Ukuran { get; set; }
    }
}
