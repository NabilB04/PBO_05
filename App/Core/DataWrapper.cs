﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Configuration;


namespace TaniAttire.App.Core
{
    public class DataWrapper
    {
        private static string connectionString = "Host=localhost;Username=postgres;Password=Triplef33;Database=latihan_uts";
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

    }
}

