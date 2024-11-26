using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class TransaksiJual
    {
        [Key]
        public int Id_TransaksiJual { get; set; } 

        [ForeignKey("Users")]
        [Required(ErrorMessage = "Id Users harus diisi.")]
        public int Id_Users { get; set; } 

        [ForeignKey("Pelanggan")]
        [Required(ErrorMessage = "Id Pelanggan harus diisi.")]
        public int Id_Pelanggan { get; set; }

        [Required(ErrorMessage = "Tanggal Transaksi harus diisi.")]
        public DateTime Tanggal_Transaksi { get; set; } = DateTime.Now;
    }
}
