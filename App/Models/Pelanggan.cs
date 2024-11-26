using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Pelanggan
    {
        [Key]
        public int Id_Pelanggan { get; set; }

        [Required(ErrorMessage = "Nama pelanggan harus diisi.")]
        [StringLength(100, ErrorMessage = "Nama pelanggan tidak boleh lebih dari 100 karakter.")]
        public string Nama_Pelanggan { get; set; }

        [StringLength(15, ErrorMessage = "No Telepon tidak boleh lebih dari 15 karakter.")]
        public string No_Telpon { get; set; }

        public string Alamat { get; set; } 
    }

}
