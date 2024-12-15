using System;
using System.Collections.Generic;
using System.Linq;
using TaniAttire.App.Models;
using TaniAttire.App.Core;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using static TaniAttire.Login;

namespace TaniAttire.App.Controllers
{
    public class TransaksiJualControllers : DataWrapper
    {
        public List<TransaksiJualDetail> GetAllTransaksiJual()
        {
            List<TransaksiJualDetail> transaksiList = new List<TransaksiJualDetail>();
            using (var conn = openConnection())
            {
                string query = @"
                    SELECT 
                        dt.Id_Detail_Transaksi,
                        usr.Nama AS Nama_Karyawan,
                        pr.Nama_Produk,
                        tj.Tanggal_Transaksi,
                        u.Nilai_Ukuran,
                        dt.Jumlah,
                        ds.Harga_jual AS Harga_Satuan,
                        (dt.Jumlah * ds.Harga_Jual) AS Total_Harga,
                        tj.Id_Users
                    FROM 
                        Detail_Transaksi dt
                    INNER JOIN 
                        TransaksiJual tj ON dt.Id_TransaksiJual = tj.Id_TransaksiJual
                    INNER JOIN 
                        Detail_Stok ds ON dt.Id_Detail_Stok = ds.Id_Detail_Stok
                    INNER JOIN 
                        Detail_Produk dp ON ds.Id_Detail_Produk = dp.Id_Detail_Produk
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
                            Id_Detail_Transaksi = reader.GetInt32(0),
                            Nama_Karyawan = reader.GetString(1),
                            Nama_Produk = reader.GetString(2),
                            Tanggal_Transaksi =reader.GetDateTime(3),
                            Nilai_Ukuran = reader.GetString(4),
                            Jumlah = reader.GetInt32(5),
                            Harga_Jual = reader.GetDecimal(6),
                            Total_Harga = reader.GetInt32(7),
                            Id_Users = reader.GetInt32(8),

                        });
                    }
                }
            }
            return transaksiList;
        }
        public int GetTotalJual()
        {
            int totalJual = 0;
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT COUNT(*) FROM TransaksiJual";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalJual = reader.GetInt32(0);
                        }
                    }
                }
            }
            return totalJual;
        }

        public void AddTransaksiJual(TransaksiJualDetail transaksiJualDetail)
        {
            using (var conn = openConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                   
                    string queryInsertTransaksiJual = @"
                    INSERT INTO TransaksiJual ( Tanggal_Transaksi, Id_Users)
                    VALUES (@Tanggal_Transaksi, @Id_Users)
                    RETURNING Id_TransaksiJual;";

                    int idTransaksiJual;

                    using (var cmd = new NpgsqlCommand(queryInsertTransaksiJual, conn))
                    {
                        cmd.Parameters.AddWithValue("Tanggal_Transaksi", transaksiJualDetail.Tanggal_Transaksi);
                        cmd.Parameters.AddWithValue("Id_Users", SessionData.LoggedInUserId); 
                        idTransaksiJual = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string queryInsertDetailTransaksi = @"
                INSERT INTO Detail_Transaksi (Id_TransaksiJual, Id_Detail_Stok, Jumlah , Id_Transaksi_Sewa)
                VALUES (@Id_TransaksiJual, @Id_Detail_Stok, @Jumlah , NULL);";

                    using (var cmd = new NpgsqlCommand(queryInsertDetailTransaksi, conn))
                    {
                        cmd.Parameters.AddWithValue("Id_TransaksiJual", idTransaksiJual);
                        cmd.Parameters.AddWithValue("Id_Detail_Stok", transaksiJualDetail.Id_Detail_Transaksi); 
                        cmd.Parameters.AddWithValue("Jumlah", transaksiJualDetail.Jumlah);
                        cmd.ExecuteNonQuery();
                    }

                    string queryUpdateStok = @"
                UPDATE Detail_Stok
                SET Stok_Jual = Stok_Jual - @Jumlah
                WHERE Id_Detail_Stok = @Id_Detail_Stok
                  AND Stok_Jual >= @Jumlah;";

                    using (var cmd = new NpgsqlCommand(queryUpdateStok, conn))
                    {
                        cmd.Parameters.AddWithValue("Jumlah", transaksiJualDetail.Jumlah);
                        cmd.Parameters.AddWithValue("Id_Detail_Stok", transaksiJualDetail.Id_Detail_Transaksi);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("Stok tidak mencukupi untuk transaksi ini.");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }
    }
}
