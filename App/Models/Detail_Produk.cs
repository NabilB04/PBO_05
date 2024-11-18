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
        public int Id { get; set; }
        [ForeignKey("Produk")]
        public string id_Produk { get; set; }
        [ForeignKey("Ukuran")]
        public string id_Ukuran { get; set; }
        [Required(ErrorMessage = "Stok_produk harus diisi .")]
        public int Stok_produk { get; set; }
    }
}
