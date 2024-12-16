using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniAttire.App.Core;
using TaniAttire.App.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaniAttire.App.Controllers
{
    internal class PelangganControllers : DataWrapper
    {
        public List<Pelanggan> GetAllpelanggan ()
        {
            List<Pelanggan> pelangganList = new List<Pelanggan>();
            using (var conn = openConnection())
            {
                string query = "SELECT * FROM Pelanggan";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pelangganList.Add(new Pelanggan
                        {
                            Id_Pelanggan = reader.GetInt32(0),
                            Nama_Pelanggan = reader.GetString(1),
                            No_Telpon = reader.GetString(2),
                            Alamat = reader.GetString(3),
                        });
                    }
                }
            }
            return pelangganList;
        }

        public Pelanggan Getpelangganbyid(int Id_Pelanggan)
        {
            Pelanggan pelanggan1 = null;
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT Id_Pelanggan  FROM Pelanggan WHERE Id_Pelanggan = @Id_Pelanggan";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id_Pelanggan", Id_Pelanggan);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pelanggan1 = new Pelanggan
                            {
                                Id_Pelanggan = reader.GetInt32(0),
                              
                            };
                        }
                    }
                }
            }
            return pelanggan1;
        }

        public List<Pelanggan> SearchPelanggan(string keyword)
        {
            List<Pelanggan> pelangganList = new List<Pelanggan>();

            using (var conn = DataWrapper.openConnection())
            {
                string query = @"
            SELECT * 
            FROM pelanggan 
            WHERE LOWER(nama_pelanggan) LIKE @keyword 
               OR LOWER(no_telpon) LIKE @keyword 
               OR LOWER(alamat) LIKE @keyword";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("keyword", $"%{keyword.ToLower()}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pelangganList.Add(new Pelanggan
                            {
                                Id_Pelanggan = reader.GetInt32(0),
                                Nama_Pelanggan = reader.GetString(1),
                                No_Telpon = reader.GetString(2),
                                Alamat = reader.GetString(3),
                            });
                        }
                    }
                }
            }

            return pelangganList;
        }

        public int Addpelanggan(Pelanggan pelanggan1)
        {
            // Validasi data
            var validationContext = new ValidationContext(pelanggan1, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(pelanggan1, validationContext, validationResults, true))
            {
                throw new ValidationException(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }

            using (var conn = openConnection())
            {
                // Periksa apakah pelanggan sudah ada
                string checkQuery = "SELECT COUNT(*) FROM Pelanggan WHERE Nama_Pelanggan = @Nama_Pelanggan AND No_Telpon = @No_Telpon AND Alamat = @Alamat";
                using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("Nama_Pelanggan", pelanggan1.Nama_Pelanggan);
                    checkCmd.Parameters.AddWithValue("No_Telpon", pelanggan1.No_Telpon);
                    checkCmd.Parameters.AddWithValue("Alamat", pelanggan1.Alamat);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        throw new Exception("Pelanggan sudah ada.");
                    }
                }

                // Tambahkan pelanggan baru dan kembalikan ID
                string query = @"
            INSERT INTO Pelanggan (Nama_Pelanggan, No_Telpon, Alamat)
            VALUES (@Nama_Pelanggan, @No_Telpon, @Alamat)
            RETURNING Id_Pelanggan;";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Nama_Pelanggan", pelanggan1.Nama_Pelanggan);
                    cmd.Parameters.AddWithValue("No_Telpon", pelanggan1.No_Telpon);
                    cmd.Parameters.AddWithValue("Alamat", pelanggan1.Alamat);

                    // Mengembalikan ID pelanggan yang baru saja ditambahkan
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

    }
}
