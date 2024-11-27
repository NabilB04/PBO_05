using System;
using System.Collections.Generic;
using System.Linq;
using TaniAttire.App.Models;
using TaniAttire.App.Core;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TaniAttire.App.Controllers
{
    public class TransaksiJualController
    {
        public List<TransaksiJualDetail> GetAllTransaksiJual()
        {
            List<TransaksiJualDetail> transaksiList = new List<TransaksiJualDetail>();
            using (var conn = DataWrapper.openConnection())
            {
                string query = @"
                    SELECT 
                        dt.Id_Detail_Transaksi,
                        p.Nama_Pelanggan,
                        usr.Nama AS Nama_Karyawan
                        pr.Nama_Produk,
                        tj.Tanggal_Transaksi
                        u.Nilai_Ukuran,
                        dt.Jumlah,
                        ds.Harga_jual AS Harga_Satuan
                        (dt.Jumlah * ds.Harga_Jual) AS Total_Harga
                    FROM 
                        Detail_Transaksi dt
                    INNER JOIN 
                        TransaksiJual tj ON dt.Id_TransaksiJual = tj.Id_TransaksiJual
                    INNER JOIN 
                        Pelanggan p ON tj.Id_Pelanggan = p.Id_Pelanggan
                    INNER JOIN 
                        DetailStok ds ON dt.Id_Detail_Stok = ds.Id_Detail_Stok
                    INNER JOIN 
                        DetailProduk dp ON ds.Id_Detail_Produk = dp.Id_Detail_Produk
                    INNER JOIN 
                        Produk pr ON dp.Id_Produk = pr.Id_Produk
                    INNER JOIN 
                        Ukuran u ON dp.Id_Ukuran = u.Id_Ukuran
                    LEFT JOIN 
                        Users usr ON tj.Id_Users = usr.Id_Users
                    ORDER BY 
                        dt.Id_Detail_Transaksi;
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transaksiList.Add(new TransaksiJualDetail
                        {

                            Nama_Pelanggan = reader.GetString(1),
                            Nama_Produk = reader.GetString(2),
                            Nama = reader.GetString(3),
                            Tanggal_Transaksi =reader.GetDateTime(4),
                            Nilai_Ukuran = reader.GetString(5),
                            Jumlah = reader.GetInt32(6),
                            Harga_Jual = reader.GetDecimal(7),
                            Total_Harga = reader.GetInt32(6) * reader.GetDecimal(7)
                        });
                    }
                }
            }
            return transaksiList;
        }
    }
}
