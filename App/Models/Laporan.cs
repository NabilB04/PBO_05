using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Models
{
    public class Laporan
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Detail_Transaksi")]
        public string Id_Detail_Transaksi { get; set; }

        public int Total_Penjualan { get; set; }
        public decimal Total_Pendapatan { get; set; }
    }
}
