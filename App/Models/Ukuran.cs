using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Ukuran
    {
        [Key]
        public int Id_Ukuran { get; set; }
        [Required(ErrorMessage = "Kategori harus diisi.")]
        [StringLength(50, ErrorMessage = "Kategori tidak boleh lebih dari 50 karakter.")]
        public string Kategori { get; set; }
        [Required(ErrorMessage = "Nilai ukuran harus diisi.")]
        [RegularExpression(@"^(3[5-9]|[4][0-9]|50)$|^(S|M|L|XL)$|^(X{1,4}L)$",
        ErrorMessage = "Nilai ukuran harus antara 35-50, atau salah satu dari S, M, L, XL, atau XXL, XXXL, XXXXL.")]
        public string Nilai_Ukuran { get; set; }
        [Required(ErrorMessage = "Status Ukuran harus diisi.")]
        public bool Status { get; set; }
    }
}
