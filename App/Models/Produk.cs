using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Produk
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nama produk harus diisi.")]
        public string Nama_Produk { get; set; }
        [Required(ErrorMessage = "Harga produk harus diisi.")]
        public decimal Harga_Produk { get; set; }
        [Required(ErrorMessage = "Deskripsi produk harus diisi.")]
        public string Deskripsi { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
