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
        public int id_users { get; set; }
        [Required(ErrorMessage = "Username harus diisi.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password harus diisi.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role harus diisi.")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Nama harus diisi.")]
        public string Nama { get; set; }
        [Required(ErrorMessage = "No Telepon harus diisi.")]
        public string No_Telpon { get; set; }
    }
}
