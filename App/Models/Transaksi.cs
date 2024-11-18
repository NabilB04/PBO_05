using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Transaksi
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public string Id_User { get; set; }
        [Required(ErrorMessage = "Tanggal Transaksi harus diisi.")]
        public DateTime Tanggal_Transaksi { get; set; }
    }
}
