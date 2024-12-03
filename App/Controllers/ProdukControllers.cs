using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaniAttire.App.Models;
using System.IO;
using TaniAttire.App.Core;
using Npgsql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniAttire.App.Controllers
{
    public class ProdukControllers
    {
        public List<GetProduk> GetTotalProduk()
        {
            List<GetProduk> produkList = new List<GetProduk>();
            using (var conn = DataWrapper.openConnection())
            {
                string query = @"
            SELECT 
                p.Id_Produk,
                p.Nama_Produk,
                p.Foto_Produk,
                u.Nilai_Ukuran,
                ds.Stok_Jual,
                ds.Stok_Sewa,
                ds.Harga_Sewa,
                ds.Harga_Jual,
                p.Denda_Perhari
            FROM 
                Produk p
            INNER JOIN 
                Detail_Produk dp ON p.Id_Produk = dp.Id_Produk
            INNER JOIN 
                Ukuran u ON dp.Id_Ukuran = u.Id_Ukuran
            INNER JOIN 
                Detail_Stok ds ON dp.Id_Detail_Produk = ds.Id_Detail_Produk
            WHERE 
                p.Status = TRUE AND u.Status = TRUE
            ORDER BY 
                p.Id_Produk;
        ";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produkList.Add(new GetProduk
                        {
                            Id_Produk = reader.GetInt32(0),
                            Nama_Produk = reader.GetString(1),
                            Foto_Produk = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Nilai_Ukuran = reader.GetString(3),
                            Stok_Jual = reader.GetInt32(4),
                            Stok_Sewa = reader.GetInt32(5),
                            Harga_Sewa = reader.GetDecimal(6),
                            Harga_Jual = reader.GetDecimal(7),
                            Denda_Perhari = reader.GetDecimal(8)
                        });
                    }
                }
            }
            return produkList;
        }

        public int GetJumlahProduk()
        {
            int totalProduk = 0;
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT COUNT(*) FROM Produk";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalProduk = reader.GetInt32(0);
                        }
                    }
                }
            }
            return totalProduk;
        }

        public void AddProduk(Produk produk, string filePath, int idUkuran, Detail_Stok detailStok)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File tidak ditemukan pada path yang diberikan.");
            }

            string uploadsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(filePath)}";
            string destinationPath = Path.Combine(uploadsFolder, fileName);

            File.Copy(filePath, destinationPath);

            using (var conn = DataWrapper.openConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        
                        string queryProduk = @"INSERT INTO Produk (Nama_Produk, Foto_Produk, Denda_Perhari) 
                               VALUES (@nama_produk, @foto_produk, @denda_perhari)
                               RETURNING Id_Produk";
                        int idProduk;

                        using (var cmd = new NpgsqlCommand(queryProduk, conn))
                        {
                            cmd.Parameters.AddWithValue("nama_produk", produk.Nama_Produk);
                            cmd.Parameters.AddWithValue("foto_produk", fileName);
                            cmd.Parameters.AddWithValue("denda_perhari", produk.Denda_Perhari);

                            idProduk = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        
                        string queryDetailProduk = @"INSERT INTO Detail_Produk (Id_Produk, Id_Ukuran)
                                     VALUES (@id_produk, @id_ukuran)
                                     RETURNING Id_Detail_Produk";
                        int idDetailProduk;

                        using (var cmd = new NpgsqlCommand(queryDetailProduk, conn))
                        {
                            cmd.Parameters.AddWithValue("id_produk", idProduk);
                            cmd.Parameters.AddWithValue("id_ukuran", idUkuran);

                            idDetailProduk = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        
                        string queryDetailStok = @"INSERT INTO Detail_Stok (Id_Detail_Produk, Stok_Sewa, Stok_Jual, Harga_Sewa, Harga_Jual)
                                   VALUES (@id_detail_produk, @stok_sewa, @stok_jual, @harga_sewa, @harga_jual)";
                        using (var cmd = new NpgsqlCommand(queryDetailStok, conn))
                        {
                            cmd.Parameters.AddWithValue("id_detail_produk", idDetailProduk);
                            cmd.Parameters.AddWithValue("stok_sewa", detailStok.Stok_Sewa);
                            cmd.Parameters.AddWithValue("stok_jual", detailStok.Stok_Jual);
                            cmd.Parameters.AddWithValue("harga_sewa", detailStok.Harga_Sewa);
                            cmd.Parameters.AddWithValue("harga_jual", detailStok.Harga_Jual);

                            cmd.ExecuteNonQuery();
                        }

                       
                        transaction.Commit();
                    }
                    catch
                    {
                       
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}
