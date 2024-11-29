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
        public int Id_Produk { get; set; } 

        [Required(ErrorMessage = "Nama produk harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama produk tidak boleh lebih dari 100 karakter.")]
        public string Nama_Produk { get; set; }

        [Required(ErrorMessage = "Status produk harus diisi.")]
        public bool Status { get; set; } = true; 

        [StringLength(255, ErrorMessage = "Foto produk tidak boleh lebih dari 255 karakter.")]
        public string Foto_Produk { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Denda Per hari harus diisi")]
        public decimal Denda_Perhari { get; set; }
    }
}
