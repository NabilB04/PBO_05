using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class GetProduk
    {
        public int Id_Produk { get; set; }
        [Required(ErrorMessage = "Nama produk harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama produk tidak boleh lebih dari 100 karakter.")]
        public string Nama_Produk { get; set; }

        [StringLength(255, ErrorMessage = "Foto produk tidak boleh lebih dari 255 karakter.")]
        public string Foto_Produk { get; set; }
        [Required(ErrorMessage = "Nilai ukuran harus diisi.")]
        [RegularExpression(@"^(3[5-9]|[4][0-9]|50)$|^(s|m|l|xl)$|^(x{1,4}l)$",
        ErrorMessage = "Nilai ukuran harus antara 35-50, atau salah satu dari s, m, l, xl, atau xxl, xxxl, xxxxl.")]
        public string Nilai_Ukuran { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok Jual harus diisi")]
        public int Stok_Jual { get; set; } = 0;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok Sewa harus diisi")]
        public int Stok_Sewa { get; set; } = 0;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Harga Sewa harus diisi")]
        public decimal Harga_Sewa { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Harga Jual harus diisi")]
        public decimal Harga_Jual { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Denda Per hari harus diisi")]
        public decimal Denda_Perhari { get; set; }
    }
}
