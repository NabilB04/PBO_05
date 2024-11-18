using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Detail_Transaksi
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Transaksi")]
        public string Id_Transaksi { get; set; }
        [ForeignKey("Detail_Produk")]
        public string Id_Detail_Produk { get; set; }
        [Required(ErrorMessage = "Jumlah harus diisi.")]
        public int jumlah { get; set; }

        public decimal Total_Harga { get; set; }
    }
}
