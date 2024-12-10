using Npgsql;
using System;
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
    public class ukuranControllers : DataWrapper
    {
        public List<Ukuran> GetAllukuran()
        {
            List<Ukuran> ukuranList = new List<Ukuran>();
            using (var conn = openConnection())
            {
                string query = "SELECT * FROM Ukuran WHERE Status = @Status";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", true);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ukuranList.Add(new Ukuran
                            {
                                Id_Ukuran = reader.GetInt32(0),
                                Kategori = reader.GetString(1),
                                Nilai_Ukuran = reader.GetString(2),
                                Status = reader.GetBoolean(3),
                            });
                        }
                    }
                }
            }
            return ukuranList;
        }

        public List<string> GetNilaiUkuran()
        {
            List<string> nilaiUkuranList = new List<string>();
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT Nilai_Ukuran FROM Ukuran WHERE Status = @Status";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", true);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nilaiUkuranList.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return nilaiUkuranList;
        }
        public void AddUkuran(Ukuran ukuran1)
        {
            if (ukuran1.Kategori.Equals("Pakaian", StringComparison.OrdinalIgnoreCase))
            {
                var validSizes = new List<string> { "S", "M", "L", "XL", "XXL", "XXXL", "XXXXL" };
                if (!validSizes.Contains(ukuran1.Nilai_Ukuran))
                {
                    throw new ValidationException("Nilai ukuran untuk kategori 'Pakaian' hanya dapat berupa S, M, L, XL, XXL, XXXL, atau XXXXL.");
                }
            }
            else if (ukuran1.Kategori.Equals("Sepatu", StringComparison.OrdinalIgnoreCase))
            {
                if (!int.TryParse(ukuran1.Nilai_Ukuran, out int size) || size < 35 || size > 50)
                {
                    throw new ValidationException("Nilai ukuran untuk kategori 'Sepatu' hanya dapat berupa angka antara 35 dan 50.");
                }
            }
            else
            {
                throw new ValidationException("Kategori tidak valid. Harus berupa 'Pakaian' atau 'Sepatu'.");
            }

            var validationContext = new ValidationContext(ukuran1, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(ukuran1, validationContext, validationResults, true))
            {
                throw new ValidationException(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }

            using (var conn = DataWrapper.openConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM Ukuran WHERE Kategori = @Kategori AND Nilai_Ukuran = @Nilai_Ukuran AND Status = @Status";
                using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("Kategori", ukuran1.Kategori);
                    checkCmd.Parameters.AddWithValue("Nilai_Ukuran", ukuran1.Nilai_Ukuran);
                    checkCmd.Parameters.AddWithValue("Status", true);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        throw new Exception("Ukuran sudah ada.");
                    }
                }

                string query = "INSERT INTO Ukuran (Kategori, Nilai_Ukuran, Status) VALUES(@Kategori, @Nilai_Ukuran, @Status)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Kategori", ukuran1.Kategori);
                    cmd.Parameters.AddWithValue("Nilai_Ukuran", ukuran1.Nilai_Ukuran);
                    cmd.Parameters.AddWithValue("Status", ukuran1.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void DeleteUkuran(int Id_Ukuran)
        {
            string query = "UPDATE Ukuran SET Status = @Status WHERE Id_Ukuran = @Id_Ukuran";

            NpgsqlParameter[] parameters = {
            new NpgsqlParameter("@Status", false), 
            new NpgsqlParameter("@Id_Ukuran", Id_Ukuran)};

            DataWrapper.commandExecutor(query, parameters);
        }
    }
}