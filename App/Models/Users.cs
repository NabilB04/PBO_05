using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Users
    {
        [Key]
        public int Id_Users { get; set; }

        [Required(ErrorMessage = "Username harus diisi.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password harus diisi.")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password harus antara 6 sampai 12 karakter.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{6,12}$",
            ErrorMessage = "Password harus mengandung minimal satu huruf besar dan satu angka.")]
        public string Password { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Nama harus diisi.")]
        public string Nama { get; set; }

        [StringLength(15, ErrorMessage = "No Telepon tidak boleh lebih dari 15 karakter.")]
        public string No_Telpon { get; set; }

        [Required]
        public bool Status { get; set; } = true;
    }
}
