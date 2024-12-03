using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;


namespace TaniAttire.App.Core
{
    public static class DataWrapper
    {
        private static readonly string DB_HOST = "localhost";
        private static readonly string DB_DATABASE = "TaniAttire1";
        private static readonly string DB_USERNAME = "postgres";
        private static readonly string DB_PASSWORD = "Triplef33";
        private static readonly string DB_PORT = "5432";

        private static NpgsqlConnection connection;
        private static NpgsqlCommand command;


        public static NpgsqlConnection openConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}");
                connection.Open();
                command = new NpgsqlCommand();
                command.Connection = connection;
            }
            return connection;
        }

        public static void closeConnection()
        {
            connection.Close();
            command.Parameters.Clear();
        }

        public static DataTable queryExecutor(string query, NpgsqlParameter[] parameters = null)
        {
            try
            {
                openConnection();
                DataTable dataTable = new DataTable();
                command.CommandText = query;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                    command.Prepare();
                }
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                closeConnection();
                return dataTable;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void commandExecutor(string query, NpgsqlParameter[] parameters = null)
        {
            try
            {
                openConnection();
                command.CommandText = query;
                command.Parameters.AddRange(parameters);
                command.Prepare();
                command.Parameters.Clear();
                command.ExecuteNonQuery();
                closeConnection();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

