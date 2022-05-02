﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DBContext
{
    public class BaseRepository
    {
        private string sqlSchema = "";

        public static IConfigurationRoot Configuration { get; set; }

        public SqlConnection GetSqlConnection(bool open = true)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string cs = Configuration["Logging:AppSettings:SqlConnectionString"];

            var csb = new SqlConnectionStringBuilder(cs) { };

            var conn = new SqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }

        public string GetSqlSchema()
        {
            if (sqlSchema == "")
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

                Configuration = builder.Build();

                sqlSchema = Configuration["Logging:AppSettings:SqlConnectionString"];

                if (sqlSchema == null || sqlSchema == "")
                {
                    sqlSchema = "dbo";
                }
            }
            

            return sqlSchema;
        }

    }
}
