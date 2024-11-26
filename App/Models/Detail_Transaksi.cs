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
        public int Id_Detail_Transaksi { get; set; } 

        [ForeignKey("Detail_Stok")]
        [Required(ErrorMessage = "Id Detail Stok harus diisi.")]
        public int Id_Detail_Stok { get; set; } 

        [ForeignKey("TransaksiJual")]
        public int? Id_TransaksiJual { get; set; } 

        [ForeignKey("TransaksiSewa")]
        public int? Id_TransaksiSewa { get; set; } 

        [Required(ErrorMessage = "Jumlah harus diisi.")]
        [Range(1, int.MaxValue, ErrorMessage = "Jumlah harus lebih besar dari 0.")]
        public int Jumlah { get; set; } 

    }
}
