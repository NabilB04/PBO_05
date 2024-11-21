using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniAttire.App.Models;
using TaniAttire.App.Core;
using Microsoft.VisualBasic.ApplicationServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TaniAttire.App.Controllers
{
    public class usersControllers
    {
        public List<Users> GetAllusers()
        {
            List<Users> usersList = new List<Users>();
            using (var conn = DataWrapper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users";
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usersList.Add(new Users
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            Role = reader.GetString(3),
                            Nama = reader.GetString(4),
                            No_Telpon = reader.GetString(5)
                        });
                    }
                }
            }
            return usersList;
        }
        public void AddUsers(Users users1)
        {
            using (var conn = DataWrapper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO users (username,password,role,nama,no_telpon) VALUES(@username, @password, 2,@nama, @no_telpon)";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("username", users1.Username);
                    cmd.Parameters.AddWithValue("password", users1.Password);
                    cmd.Parameters.AddWithValue("nama", users1.Nama);
                    cmd.Parameters.AddWithValue("no_telpon", users1.No_Telpon);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Users GetusersByusernameAndpassword(string username, string password)
        {
            Users users1 = null;
            using (var conn = DataWrapper.GetConnection())
            {
                conn.Open();
                string query = "SELECT username, password, role FROM users WHERE username = @username AND password = @password";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            users1 = new Users
                            {
                                Username = reader.GetString(0), // Kolom pertama: username
                                Password = reader.GetString(1), // Kolom kedua: password
                                Role = reader.GetString(2)      // Kolom ketiga: role
                            };
                        }
                    }
                }
            }
            return users1;
        }
    }
}