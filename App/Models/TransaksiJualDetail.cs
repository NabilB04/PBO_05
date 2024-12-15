using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class TransaksiJualDetail
    {
        [ForeignKey("Detail_Transaksi")]
        public int Id_Detail_Transaksi { get; set; }

        [ForeignKey("Users")]
        [Required(ErrorMessage = "Id Users harus diisi.")]
        public int Id_Users { get; set; }

        [Required(ErrorMessage = "Nama pelanggan harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama pelanggan tidak boleh lebih dari 100 karakter.")]
        public string Nama_Karyawan { get; set; }
        [Required(ErrorMessage = "Nama produk harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama produk tidak boleh lebih dari 100 karakter.")]
        public string Nama_Produk { get; set; }
        [Required(ErrorMessage = "Tanggal Transaksi harus diisi.")]
        public DateTime Tanggal_Transaksi { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Nilai ukuran harus diisi.")]
        [RegularExpression(@"^(3[5-9]|[4][0-9]|50)$|^(s|m|l|xl)$|^(x{1,4}l)$",
        ErrorMessage = "Nilai ukuran harus antara 35-50, atau salah satu dari s, m, l, xl, atau xxl, xxxl, xxxxl.")]
        public string Nilai_Ukuran { get; set; }

        [Required(ErrorMessage = "Jumlah harus diisi.")]
        [Range(1, int.MaxValue, ErrorMessage = "Jumlah harus lebih besar dari 0.")]
        public int Jumlah { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Harga Jual harus diisi")]
        public decimal Harga_Jual { get; set; }
        public decimal Total_Harga { get; set; }

       
    }
}
