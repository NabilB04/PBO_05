using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniAttire.App.Core;
using TaniAttire.App.Models;

namespace TaniAttire.App.Controllers
{
    public class ukuranControllers
    {
        public List<Ukuran> GetAllukuran()
        {
            List<Ukuran> ukuranList = new List<Ukuran>();
            using (var conn = DataWrapper.openConnection())
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
        public void AddUkuran(Ukuran ukuran1)
        {
            using (var conn = DataWrapper.openConnection())
            {
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