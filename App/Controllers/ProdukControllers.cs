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
        public int GetTotalProduk()
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
        public void AddProduk(Produk produk, string filePath)
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
                string query = @"INSERT INTO Produk (Nama_Produk, Foto_Produk, Denda_Perhari) 
                                 VALUES (@nama_produk, @foto_produk, @denda_perhari)";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama_produk", produk.Nama_Produk);
                    cmd.Parameters.AddWithValue("foto_produk", fileName); 
                    cmd.Parameters.AddWithValue("denda_perhari", produk.Denda_Perhari);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
