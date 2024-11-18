using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Jenis kategori harus diisi.")]
        public string Jenis_kategori { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
