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
using NpgsqlTypes;
using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;

namespace TaniAttire.App.Controllers
{
    public class ProdukControllers : DataWrapper
    {
        public List<Produk> GetAllProduk()
        {
            List<Produk> produkList = new List<Produk>();

            using (var conn = openConnection())
            {
                string query = "SELECT * FROM produk";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produkList.Add(new Produk
                        {
                            Id_Produk = reader.GetInt32(0),
                            Nama_Produk = reader.GetString(1),
                            Status = reader.GetBoolean(2),
                            Foto_Produk = reader.IsDBNull(3) ? null : reader.GetString(3)
                        });
                    }
                }
            }
            return produkList;
        }
        public List<GetProduk> GetTotalProduk()
        {
            List<GetProduk> produkList = new List<GetProduk>();
            using (var conn = openConnection())
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
            using (var conn = openConnection())
            {
                string query = "SELECT COUNT(*) FROM Produk WHERE Status = TRUE";
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
            var validationContext = new ValidationContext(produk, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(produk, validationContext, validationResults, true))
            {
                throw new ValidationException(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }
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

            using (var conn = openConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string checkQuery = "SELECT COUNT(*) FROM Produk WHERE Nama_produk = @nama_produk  AND Status = @Status";
                        using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("Nama_produk", produk.Nama_Produk);
                            checkCmd.Parameters.AddWithValue("Status", true);


                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (count > 0)
                            {
                                throw new Exception("Produk sudah ada.");
                            }
                        }

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
        public Produk GetProdukById(int idProduk)
        {
            Produk produk = null;
            using (var conn = openConnection())
            {
                string query = @"
            SELECT 
                Id_Produk, 
                Nama_Produk, 
                Foto_Produk, 
                Denda_Perhari
            FROM Produk
            WHERE Id_Produk = @Id_Produk AND Status = TRUE";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id_Produk", idProduk);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produk = new Produk
                            {
                                Id_Produk = reader.GetInt32(0),
                                Nama_Produk = reader.GetString(1),
                                Foto_Produk = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Denda_Perhari = reader.GetDecimal(3)
                            };
                        }
                    }
                }
            }
            return produk;
        }

        public Detail_Stok GetDetailStokByProdukId(int idProduk)
        {
            Detail_Stok detailStok = null;
            using (var conn = openConnection())
            {
                string query = @"
            SELECT 
                ds.Stok_Jual, 
                ds.Stok_Sewa, 
                ds.Harga_Jual, 
                ds.Harga_Sewa
            FROM Detail_Stok ds
            INNER JOIN Detail_Produk dp ON ds.Id_Detail_Produk = dp.Id_Detail_Produk
            WHERE dp.Id_Produk = @Id_Produk";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id_Produk", idProduk);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            detailStok = new Detail_Stok
                            {
                                Stok_Jual = reader.GetInt32(0),
                                Stok_Sewa = reader.GetInt32(1),
                                Harga_Jual = reader.GetDecimal(2),
                                Harga_Sewa = reader.GetDecimal(3)
                            };
                        }
                    }
                }
            }
            return detailStok;
        }

        public void UpdateProduk(Produk produk, string fotoProduk, int idUkuran, Detail_Stok detailStok)
        {
            var validationContext = new ValidationContext(produk, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(produk, validationContext, validationResults, true))
            {
                throw new ValidationException(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }
            using (var conn = openConnection())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string checkQuery = "SELECT COUNT(*) FROM Produk WHERE Nama_produk = @nama_produk  AND Status = @Status";
                    using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("Nama_produk", produk.Nama_Produk);
                        checkCmd.Parameters.AddWithValue("Status", true);


                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            throw new Exception("Produk sudah ada.");
                        }
                    }

                    string queryProduk = @"
                UPDATE Produk 
                SET Nama_Produk = @Nama_Produk, 
                    Foto_Produk = @Foto_Produk, 
                    Denda_Perhari = @Denda_Perhari 
                WHERE Id_Produk = @Id_Produk";

                    using (var cmd = new NpgsqlCommand(queryProduk, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nama_Produk", produk.Nama_Produk);
                        cmd.Parameters.AddWithValue("@Foto_Produk", fotoProduk);
                        cmd.Parameters.AddWithValue("@Denda_Perhari", produk.Denda_Perhari);
                        cmd.Parameters.AddWithValue("@Id_Produk", produk.Id_Produk);
                        cmd.ExecuteNonQuery();
                    }

                    // Update Detail Stok
                    string queryDetailStok = @"
                UPDATE Detail_Stok 
                SET Stok_Sewa = @Stok_Sewa, 
                    Stok_Jual = @Stok_Jual, 
                    Harga_Sewa = @Harga_Sewa, 
                    Harga_Jual = @Harga_Jual 
                WHERE Id_Detail_Produk = (
                    SELECT Id_Detail_Produk 
                    FROM Detail_Produk 
                    WHERE Id_Produk = @Id_Produk AND Id_Ukuran = @Id_Ukuran
                )";

                    using (var cmd = new NpgsqlCommand(queryDetailStok, conn))
                    {
                        cmd.Parameters.AddWithValue("@Stok_Sewa", detailStok.Stok_Sewa);
                        cmd.Parameters.AddWithValue("@Stok_Jual", detailStok.Stok_Jual);
                        cmd.Parameters.AddWithValue("@Harga_Sewa", detailStok.Harga_Sewa);
                        cmd.Parameters.AddWithValue("@Harga_Jual", detailStok.Harga_Jual);
                        cmd.Parameters.AddWithValue("@Id_Produk", produk.Id_Produk);
                        cmd.Parameters.AddWithValue("@Id_Ukuran", idUkuran);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Terjadi kesalahan saat memperbarui produk: " + ex.Message);
                }
            }
        }

        public void SoftDeleteProduk(int idProduk)
        {
            using (var conn = openConnection())
            {
                string query = @"
            UPDATE Produk
            SET Status = FALSE
            WHERE Id_Produk = @Id_Produk";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id_Produk", idProduk);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
