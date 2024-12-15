using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class TransaksiSewaDetail
    {
        [ForeignKey("Detail_Transaksi")]
        public int Id_Detail_Transaksi { get; set; } //0
        [Required(ErrorMessage = "Nama pelanggan harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama pelanggan tidak boleh lebih dari 100 karakter.")]
        public string Nama_Pelanggan { get; set; } //1
        [Required(ErrorMessage = "Nama harus diisi.")]
        public string Nama { get; set; } //2
        [Required(ErrorMessage = "Nama produk harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama produk tidak boleh lebih dari 100 karakter.")]
        public string Nama_Produk { get; set; } //3
        [Required(ErrorMessage = "Nilai ukuran harus diisi.")]
        [RegularExpression(@"^(3[5-9]|[4][0-9]|50)$|^(s|m|l|xl)$|^(x{1,4}l)$",
        ErrorMessage = "Nilai ukuran harus antara 35-50, atau salah satu dari s, m, l, xl, atau xxl, xxxl, xxxxl.")]
        public string Nilai_Ukuran { get; set; } //4
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Harga Sewa harus diisi")]
        public decimal Harga_Sewa { get; set; } //5
        [Required(ErrorMessage = "Tanggal Transaksi harus diisi.")]
        public DateTime Tanggal_Transaksi { get; set; } = DateTime.Now; //6

        [Required(ErrorMessage = "Tanggal Kembali harus diisi.")]
        public DateTime Tanggal_Kembali { get; set; } //7

        public DateTime? Tanggal_Pengembalian { get; set; } //8

        [Required]
        public bool Status_Pengembalian { get; set; } = false; //9
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Denda_Perhari { get; set; } = 0; //10
        public decimal Denda_Total { get; set; } = 0; //11
        public decimal Total_Harga { get; set; } //11

        public decimal Jumlah_Hargasewa { get; set; }
        [ForeignKey("Users")]
        public int Id_Users { get; set; } //0
    }
}
