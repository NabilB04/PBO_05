using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Detail_Stok
    {
        [Key]
        public int Id_Detail_Stok { get; set; } 

        [ForeignKey("Detail_Produk")]
        public int Id_Detail_Produk { get; set; } 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok Sewa harus diisi")]
        public int Stok_Sewa { get; set; } = 0; 

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok Jual harus diisi")]
        public int Stok_Jual { get; set; } = 0; 

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Harga Sewa harus diisi")]
        public decimal Harga_Sewa { get; set; } 

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Harga Jual harus diisi")]
        public decimal Harga_Jual { get; set; } 
    }
}
