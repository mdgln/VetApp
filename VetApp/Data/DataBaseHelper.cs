using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Data
{
    class DataBaseHelper
    {
        private readonly string connectionString = "Data Source = DESKTOP-0A6BRHF\\SQLEXPRESS; Initial Catalog = VetApp; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        //public void OpenSqlConnection()
        //{
        //    using SqlConnection connection = new();
        //    connection.ConnectionString = connectionString;
        //    connection.Open();
        //    Console.WriteLine("State: {0}", connection.State);
        //    Console.WriteLine("ConnectionString: {0}", connection.ConnectionString);
        //}

        public string GetConnectionString()
        {
            return connectionString;
        }
    }

}
