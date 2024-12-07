﻿using System;
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
    public class usersControllers
    {
        public List<Users> GetAllusers()
        {
            List<Users> usersList = new List<Users>();
            using (var conn = DataWrapper.openConnection())
            {
                string query = "SELECT * FROM users";
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
                            No_Telpon = reader.GetString(5)
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
            using (var conn = DataWrapper.openConnection())
            {
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
                                Username = reader.GetString(0),
                                Password = reader.GetString(1), 
                                Role = reader.GetString(2)      
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

            using (var conn = DataWrapper.openConnection())
            {
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
            string query = "DELETE FROM users WHERE id_users = @id_users";

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
                string query = "SELECT COUNT(*) FROM Users";
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