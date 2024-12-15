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
        public int Id_Detail_Stok { get; set; }
        [ForeignKey("Detail_Produk")]
        public int Id_Detail_Produk { get; set; }
        [ForeignKey("Produk")]
        public int Id_Produk { get; set; }

        public string Nilai_Ukuran { get; set; }

        public int Stok_Jual { get; set; }
        public int Stok_Sewa { get; set; }
    }
}
