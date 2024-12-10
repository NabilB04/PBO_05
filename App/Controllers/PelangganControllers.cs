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

        public void Addpelanggan(Pelanggan pelanggan1)
        {

            var validationContext = new ValidationContext(pelanggan1, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(pelanggan1, validationContext, validationResults, true))
            {
                throw new ValidationException(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }

            using (var conn = openConnection())
            {

                string checkQuery = "SELECT COUNT(*) FROM Pelanggan WHERE Nama_Pelanggan = @Nama_Pelanggan AND No_Telpon = @No_Telpon AND Alamat  = @Alamat ";
                using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("Nama_Pelanggan",pelanggan1.Nama_Pelanggan );
                    checkCmd.Parameters.AddWithValue("No_Telpon", pelanggan1.No_Telpon);
                    checkCmd.Parameters.AddWithValue("Alamat", pelanggan1.Alamat);


                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        throw new Exception("Pelanggan sudah ada.");
                    }
                }


                string query = "INSERT INTO Pelanggan (Nama_Pelanggan, No_Telpon, Alamat) VALUES(@Nama_Pelanggan, @No_Telpon, @Alamat)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Nama_Pelanggan", pelanggan1.Nama_Pelanggan);
                    cmd.Parameters.AddWithValue("No_Telpon", pelanggan1.No_Telpon);
                    cmd.Parameters.AddWithValue("Alamat", pelanggan1.Alamat);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
