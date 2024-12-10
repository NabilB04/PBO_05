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
    internal class produk1Controllers :DataWrapper
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
        public void AddProduk(Produk produk)
        {
            using (var conn = openConnection())
            {
                string query = "INSERT INTO produk (nama_produk, status, foto_produk) VALUES (@nama_produk, @status, @foto_produk)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nama_produk", produk.Nama_Produk);
                    cmd.Parameters.AddWithValue("status", produk.Status);
                    cmd.Parameters.AddWithValue("foto_produk", produk.Foto_Produk ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateProduk(int idProduk, string namaProduk, bool status, string fotoProduk)
        {
            using (var conn = openConnection())
            {
                string query = "UPDATE produk SET nama_produk = @namaProduk, status = @status, foto_produk = @fotoProduk WHERE id_produk = @idProduk";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idProduk", idProduk);
                    cmd.Parameters.AddWithValue("@namaProduk", namaProduk);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@fotoProduk", fotoProduk ?? (object)DBNull.Value); // Null check
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteProduk(int idProduk)
        {
            using (var conn = openConnection())
            {
                string query = "DELETE FROM produk WHERE id_produk = @idProduk";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idProduk", idProduk);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
