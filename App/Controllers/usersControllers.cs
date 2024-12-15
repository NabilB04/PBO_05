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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaniAttire.App.Controllers
{
    public class usersControllers : DataWrapper
    {
        public List<Users> GetAllusers()
{
    List<Users> usersList = new List<Users>();
    using (var conn = openConnection())
    {
        string query = "SELECT * FROM users WHERE Status = TRUE";

        using (var cmd = new NpgsqlCommand(query, conn))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                usersList.Add(new Users
                {
                    Id_Users = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    Role = reader.GetString(3),
                    Nama = reader.GetString(4),
                    No_Telpon = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Status = reader.GetBoolean(6) // Membaca status
                });
            }
        }
    }
    return usersList;
}
        public void AddUsers(Users users1)
        {
            var validationContext = new ValidationContext(users1, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(users1, validationContext, validationResults, true))
            {
                throw new ValidationException(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }
            using (var conn = DataWrapper.openConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password AND Status = @Status";
                using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("username", users1.Username);
                    checkCmd.Parameters.AddWithValue("password", users1.Password);
                    checkCmd.Parameters.AddWithValue("Status", true);


                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        throw new Exception("Pengguna sudah ada.");
                    }
                }

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
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT Id_Users ,username, password, role FROM users WHERE Id_Users = @Id_Users AND username = @username AND password = @password AND Status = TRUE";
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
                                Id_Users = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2), 
                                Role = reader.GetString(3)      
                            };
                        }
                    }
                }
            }
            return users1;
        }
        public void UpdateKaryawan(int Id_Users, string username, string password, string nama, string no_telpon)
        {
            var Users1 = new Users
            {
                Id_Users = Id_Users,
                Username = username,
                Password = password,
                Nama = nama,
                No_Telpon = no_telpon
            };


            var validationContext = new ValidationContext(Users1, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(Users1, validationContext, validationResults, true))
            {
                throw new ValidationException(string.Join("; ", validationResults.Select(v => v.ErrorMessage)));
            }

            using (var conn = DataWrapper.openConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password AND Status = @Status";
                using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("username", Users1.Username);
                    checkCmd.Parameters.AddWithValue("password", Users1.Password);
                    checkCmd.Parameters.AddWithValue("Status", true);


                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        throw new Exception("Pengguna sudah ada.");
                    }
                }

                string query = "UPDATE users SET username = @username, password = @password, nama = @nama, no_telpon = @no_telpon WHERE Id_Users = @Id_Users";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Id_Users", Id_Users);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.Parameters.AddWithValue("nama", nama);
                    cmd.Parameters.AddWithValue("no_telpon", no_telpon);
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void DeleteKaryawan(int id_users)
        {
            string query = "UPDATE users SET Status = FALSE WHERE id_users = @id_users";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id_users", id_users)
            };

            DataWrapper.commandExecutor(query, parameters);
        }

        public int GetTotalEmployees()
        {
            int totalEmployees = 0;
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Status = TRUE";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalEmployees = reader.GetInt32(0);
                        }
                    }
                }
            }
            return totalEmployees;
        }
        public Users GetUserById(int id)
        {
            Users user = null;
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT * FROM users WHERE id_users = @id";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Users
                            {
                                Id_Users = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                Nama = reader.GetString(4),
                                No_Telpon = reader.GetString(5)
                            };
                        }
                    }
                }
            }
            return user;
        }
        public List<Users> SearchKaryawan(string keyword)
        {
            List<Users> usersList = new List<Users>();

            using (var conn = DataWrapper.openConnection())
            {
                string query = @"
            SELECT * 
            FROM users 
            WHERE LOWER(username) LIKE @keyword 
               OR LOWER(nama) LIKE @keyword 
               OR LOWER(no_telpon) LIKE @keyword";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("keyword", $"%{keyword.ToLower()}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usersList.Add(new Users
                            {
                                Id_Users = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3),
                                Nama = reader.GetString(4),
                                No_Telpon = reader.GetString(5)
                            });
                        }
                    }
                }
            }

            return usersList;
        }

    }
}