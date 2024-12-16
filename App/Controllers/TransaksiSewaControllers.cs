using System;
using System.Collections.Generic;
using System.Linq;
using TaniAttire.App.Models;
using TaniAttire.App.Core;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using static TaniAttire.Login;
using static TaniAttire.Views.Kasir.DataPelanggan;

namespace TaniAttire.App.Controllers
{
    public class TransaksiSewaControllers : DataWrapper
    {
        public List<TransaksiSewaDetail> GetAllTransaksiSewa()
        {
            List<TransaksiSewaDetail> transaksiSewaList = new List<TransaksiSewaDetail>();
            using (var conn = openConnection())
            {
                string query = @"
                    SELECT 
        dt.Id_Detail_Transaksi,
        p.Nama_Pelanggan,
        usr.Nama AS Nama_Karyawan,
        pr.Nama_Produk,
        u.Nilai_Ukuran,
        ds.Harga_Sewa,
        ts.Tanggal_Transaksi,
        ts.Tanggal_Kembali,
        ts.Tanggal_Pengembalian,
        ts.Status_Pengembalian,
        p.Id_Pelanggan,
        usr.Id_Users,
        pr.Denda_Perhari,
        
        CASE 
            WHEN ts.Tanggal_Pengembalian > ts.Tanggal_Kembali THEN 
                (CAST(ts.Tanggal_Pengembalian AS DATE) - CAST(ts.Tanggal_Kembali AS DATE)) * pr.Denda_Perhari
            ELSE 
                0
        END AS Denda_Total,
   
        (CAST(ts.Tanggal_Kembali AS DATE) - CAST(ts.Tanggal_Transaksi AS DATE)) * ds.Harga_Sewa AS Jumlah_HargaSewa,
   
        CASE 
            WHEN ts.Tanggal_Pengembalian > ts.Tanggal_Kembali THEN 
                ((CAST(ts.Tanggal_Kembali AS DATE) - CAST(ts.Tanggal_Transaksi AS DATE)) * ds.Harga_Sewa) + 
                ((CAST(ts.Tanggal_Pengembalian AS DATE) - CAST(ts.Tanggal_Kembali AS DATE)) * pr.Denda_Perhari)
            ELSE 
                (CAST(ts.Tanggal_Kembali AS DATE) - CAST(ts.Tanggal_Transaksi AS DATE)) * ds.Harga_Sewa
        END AS Total_Harga
    FROM 
        Detail_Transaksi dt
    INNER JOIN 
        TransaksiSewa ts ON dt.Id_Transaksi_Sewa = ts.Id_TransaksiSewa
    INNER JOIN 
        Pelanggan p ON ts.Id_Pelanggan = p.Id_Pelanggan
    INNER JOIN 
        Detail_Stok ds ON dt.Id_Detail_Stok = ds.Id_Detail_Stok
    INNER JOIN 
        Detail_Produk dp ON ds.Id_Detail_Produk = dp.Id_Detail_Produk
    INNER JOIN 
        Produk pr ON dp.Id_Produk = pr.Id_Produk
    INNER JOIN 
        Ukuran u ON dp.Id_Ukuran = u.Id_Ukuran
    LEFT JOIN 
        Users usr ON ts.Id_Users = usr.Id_Users
    ORDER BY 
        dt.Id_Detail_Transaksi;
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transaksiSewaList.Add(new TransaksiSewaDetail
                        {
                            Id_Detail_Transaksi = reader.GetInt32(0),
                            Nama_Pelanggan = reader.GetString(1),
                            Nama = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Nama_Produk = reader.GetString(3),
                            Nilai_Ukuran = reader.GetString(4),
                            Harga_Sewa = reader.GetDecimal(5),
                            Tanggal_Transaksi = reader.GetDateTime(6),
                            Tanggal_Kembali = reader.GetDateTime(7),
                            Tanggal_Pengembalian = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                            Status_Pengembalian = reader.GetBoolean(9),
                            Id_Pelanggan = reader.GetInt32(10),
                            Id_Users = reader.GetInt32(11),
                            Denda_Perhari = reader.GetDecimal(12),
                            Denda_Total = reader.GetDecimal(13),
                            Jumlah_Hargasewa = reader.GetDecimal(14),           
                            Total_Harga = reader.GetDecimal(15)
                        });

                    }
                }
            }
            return transaksiSewaList;
        }

        public List<TransaksiSewaDetail> GetSewaBelum()
        {
            List<TransaksiSewaDetail> transaksiSewaList = new List<TransaksiSewaDetail>();
            using (var conn = DataWrapper.openConnection())
            {
                string query = @"
            SELECT 
                dt.Id_Detail_Transaksi,
                p.Nama_Pelanggan,
                usr.Nama AS Nama_Karyawan,
                pr.Nama_Produk,
                u.Nilai_Ukuran,
                ds.Harga_Sewa,
                ts.Tanggal_Transaksi,
                ts.Tanggal_Kembali,
                ts.Tanggal_Pengembalian,
                ts.Status_Pengembalian,
                ts.Denda_Total,
                CASE 
                    WHEN ts.Tanggal_Pengembalian > ts.Tanggal_Kembali THEN 
                        ((DATE_PART('day', ts.Tanggal_Pengembalian - ts.Tanggal_Kembali) * ts.Denda_Total) + ds.Harga_Sewa)
                    ELSE 
                        ds.Harga_Sewa
                END AS Total_Harga
            FROM 
                DetailTransaksi dt
            INNER JOIN 
                TransaksiSewa ts ON dt.Id_Transaksi_Sewa = ts.Id_TransaksiSewa
            INNER JOIN 
                Pelanggan p ON ts.Id_Pelanggan = p.Id_Pelanggan
            INNER JOIN 
                DetailStok ds ON dt.Id_Detail_Stok = ds.Id_Detail_Stok
            INNER JOIN 
                DetailProduk dp ON ds.Id_Detail_Produk = dp.Id_Detail_Produk
            INNER JOIN 
                Produk pr ON dp.Id_Produk = pr.Id_Produk
            INNER JOIN 
                Ukuran u ON dp.Id_Ukuran = u.Id_Ukuran
            LEFT JOIN 
                Users usr ON ts.Id_Users = usr.Id_Users
            WHERE 
                ts.Status_Pengembalian = false
            ORDER BY 
                dt.Id_Detail_Transaksi;
        ";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transaksiSewaList.Add(new TransaksiSewaDetail
                        {
                            Id_Detail_Transaksi = reader.GetInt32(0),
                            Nama_Pelanggan = reader.GetString(1),
                            Nama = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Nama_Produk = reader.GetString(3),
                            Nilai_Ukuran = reader.GetString(4),
                            Harga_Sewa = reader.GetDecimal(5),
                            Tanggal_Transaksi = reader.GetDateTime(6),
                            Tanggal_Kembali = reader.GetDateTime(7),
                            Tanggal_Pengembalian = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                            Status_Pengembalian = reader.GetBoolean(9),
                            Denda_Total = reader.GetDecimal(10),
                            Total_Harga = reader.GetDecimal(11)
                        });
                    }
                }
            }
            return transaksiSewaList;
        }

        public void AddTransaksiSewa(TransaksiSewaDetail transaksiSewaDetail)
        {
            using (var conn = DataWrapper.openConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Insert into TransaksiSewa table
                    string queryInsertTransaksiSewa = @"
            INSERT INTO TransaksiSewa (Id_Users, Id_Pelanggan, Tanggal_Transaksi, Tanggal_Kembali, Tanggal_Pengembalian, Status_Pengembalian)
            VALUES (@Id_Users, @Id_Pelanggan, @Tanggal_Transaksi, @Tanggal_Kembali, NULL, FALSE)
            RETURNING Id_TransaksiSewa;";

                    int idTransaksiSewa;

                    using (var cmd = new NpgsqlCommand(queryInsertTransaksiSewa, conn))
                    {
                        cmd.Parameters.AddWithValue("Id_Users", SessionData.LoggedInUserId);
                        cmd.Parameters.AddWithValue("Id_Pelanggan", PelangganSession.SelectedPelangganId); // Use session ID
                        cmd.Parameters.AddWithValue("Tanggal_Transaksi", transaksiSewaDetail.Tanggal_Transaksi);
                        cmd.Parameters.AddWithValue("Tanggal_Kembali", transaksiSewaDetail.Tanggal_Kembali);

                        idTransaksiSewa = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insert into DetailTransaksi table
                    string queryInsertDetailTransaksi = @"
            INSERT INTO Detail_Transaksi (Id_Transaksi_Sewa, Id_Detail_Stok, Jumlah, Id_TransaksiJual)
            VALUES (@Id_Transaksi_Sewa, @Id_Detail_Stok, 1, NULL);";

                    using (var cmd = new NpgsqlCommand(queryInsertDetailTransaksi, conn))
                    {
                        cmd.Parameters.AddWithValue("Id_Transaksi_Sewa", idTransaksiSewa);
                        cmd.Parameters.AddWithValue("Id_Detail_Stok", transaksiSewaDetail.Id_Detail_Transaksi);

                        cmd.ExecuteNonQuery();
                    }

                    // Update DetailStok table to decrement stock
                    string queryUpdateStok = @"
            UPDATE Detail_Stok
            SET Stok_Sewa = Stok_Sewa - 1
            WHERE Id_Detail_Stok = @Id_Detail_Stok
              AND Stok_Sewa >= 1;";

                    using (var cmd = new NpgsqlCommand(queryUpdateStok, conn))
                    {
                        cmd.Parameters.AddWithValue("Id_Detail_Stok", transaksiSewaDetail.Id_Detail_Transaksi);

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



        public int GetTotalSewa()
        {
            int totalSewa = 0;
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT COUNT(*) FROM TransaksiSewa WHERE Status_Pengembalian = TRUE";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalSewa = reader.GetInt32(0);
                        }
                    }
                }
            }
            return totalSewa;
        }
        public TransaksiSewaDetail GetTransaksiById(int idTransaksi)
        {
            TransaksiSewaDetail transaksi = null;

            using (var conn = DataWrapper.openConnection())
            {
                string query = @"
            SELECT 
                dt.Id_Detail_Transaksi,
                p.Nama_Pelanggan,
                usr.Nama AS Nama_Karyawan,
                pr.Nama_Produk,
                u.Nilai_Ukuran,
                ds.Harga_Sewa,
                ts.Tanggal_Transaksi,
                ts.Tanggal_Kembali,
                ts.Tanggal_Pengembalian,
                ts.Status_Pengembalian,
                p.Id_Pelanggan,
                usr.Id_Users,
                pr.Denda_Perhari,
                CASE 
                    WHEN ts.Tanggal_Pengembalian > ts.Tanggal_Kembali THEN 
                        (CAST(ts.Tanggal_Pengembalian AS DATE) - CAST(ts.Tanggal_Kembali AS DATE)) * pr.Denda_Perhari
                    ELSE 
                        0
                END AS Denda_Total,
                (CAST(ts.Tanggal_Kembali AS DATE) - CAST(ts.Tanggal_Transaksi AS DATE)) * ds.Harga_Sewa AS Jumlah_HargaSewa,
                CASE 
                    WHEN ts.Tanggal_Pengembalian > ts.Tanggal_Kembali THEN 
                        ((CAST(ts.Tanggal_Kembali AS DATE) - CAST(ts.Tanggal_Transaksi AS DATE)) * ds.Harga_Sewa) + 
                        ((CAST(ts.Tanggal_Pengembalian AS DATE) - CAST(ts.Tanggal_Kembali AS DATE)) * pr.Denda_Perhari)
                    ELSE 
                        (CAST(ts.Tanggal_Kembali AS DATE) - CAST(ts.Tanggal_Transaksi AS DATE)) * ds.Harga_Sewa
                END AS Total_Harga
            FROM 
                Detail_Transaksi dt
            INNER JOIN 
                TransaksiSewa ts ON dt.Id_Transaksi_Sewa = ts.Id_TransaksiSewa
            INNER JOIN 
                Pelanggan p ON ts.Id_Pelanggan = p.Id_Pelanggan
            INNER JOIN 
                Detail_Stok ds ON dt.Id_Detail_Stok = ds.Id_Detail_Stok
            INNER JOIN 
                Detail_Produk dp ON ds.Id_Detail_Produk = dp.Id_Detail_Produk
            INNER JOIN 
                Produk pr ON dp.Id_Produk = pr.Id_Produk
            INNER JOIN 
                Ukuran u ON dp.Id_Ukuran = u.Id_Ukuran
            LEFT JOIN 
                Users usr ON ts.Id_Users = usr.Id_Users
            WHERE 
                ts.Id_TransaksiSewa = @Id_TransaksiSewa";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id_TransaksiSewa", idTransaksi);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            transaksi = new TransaksiSewaDetail
                            {
                                Id_Detail_Transaksi = reader.GetInt32(0),
                                Nama_Pelanggan = reader.GetString(1),
                                Nama = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Nama_Produk = reader.GetString(3),
                                Nilai_Ukuran = reader.GetString(4),
                                Harga_Sewa = reader.GetDecimal(5),
                                Tanggal_Transaksi = reader.GetDateTime(6),
                                Tanggal_Kembali = reader.GetDateTime(7),
                                Tanggal_Pengembalian = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                                Status_Pengembalian = reader.GetBoolean(9),
                                Id_Pelanggan = reader.GetInt32(10),
                                Id_Users = reader.GetInt32(11),
                                Denda_Perhari = reader.GetDecimal(12),
                                Denda_Total = reader.GetDecimal(13),
                                Jumlah_Hargasewa = reader.GetDecimal(14),
                                Total_Harga = reader.GetDecimal(15)
                            };
                        }
                    }
                }
            }

            return transaksi;
        }
        public void UpdateStatusPengembalian(int idTransaksi, DateTime tanggalPengembalian)
        {
            using (var conn = DataWrapper.openConnection())
            {
                string query = @"
            UPDATE TransaksiSewa
            SET Tanggal_Pengembalian = @TanggalPengembalian,
                Status_Pengembalian = TRUE
            WHERE Id_TransaksiSewa = @Id_TransaksiSewa";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TanggalPengembalian", tanggalPengembalian);
                    cmd.Parameters.AddWithValue("@Id_TransaksiSewa", idTransaksi);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Gagal memperbarui data. Pastikan ID transaksi valid.");
                    }
                }
            }
        }

    }
}
