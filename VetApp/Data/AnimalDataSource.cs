using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models;
using Microsoft.Data.SqlClient;

namespace VetApp.Data
{
    class AnimalDataSource
    {
        public readonly string connectionString = "Data Source = DESKTOP-0A6BRHF\\SQLEXPRESS; Initial Catalog = ExpensesManagment; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

        public IEnumerable<Animal> GetAll()
        {
            IList<Animal> animals = [];
            using (SqlConnection connection = new())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                string query = "SELECT * FROM ExpensesManagment.dbo.Users";

                using SqlCommand cmd = new(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Animal animal = new()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1)
                    };
                    animals.Add(animal);
                }
            }

            return animals;
        }
        
    }
}
