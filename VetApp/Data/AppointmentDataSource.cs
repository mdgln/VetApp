using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models;

namespace VetApp.Data
{
    internal class AppointmentDataSource
    {
        public readonly string connectionString = new DataBaseHelper().GetConnectionString();
        public int Add(Appointment appointment)
        {
            try
            {
                using (SqlConnection connection = new())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    string query = "INSERT INTO Appointment " +
                        $"VALUES ('{appointment.PatientName}', '{appointment.Animal}', {appointment.Age}, '{appointment.Problem}', '{appointment.Date}')";

                    using SqlCommand command = new(query, connection);
                    int recordAffected = command.ExecuteNonQuery();

                    if (recordAffected > 0)
                    {
                        return 1; // Console.WriteLine("Appointment booked succesfully.");
                    } else
                    {
                        return 0; // Console.WriteLine("There was a problem.");
                    }
                }
            }
            catch (Exception ex)
            {
                return 0; // Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            try
            {
                using (SqlConnection connection = new()) 
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    string query = "SELECT * FROM Appointment";

                    SqlCommand command = new(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    IList<Appointment> appointments = new List<Appointment>();

                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment
                        (
                            id: reader.GetInt32(0),
                            patientName: reader.GetString(1),
                            animal: reader.GetString(2),
                            age: reader.GetInt32(3),
                            problem: reader.GetString(4),
                            date: reader.GetDateTime(5)
                        );

                        appointments.Add(appointment);
                    }

                    return appointments;
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<Appointment>();
            }
        }

        public int Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    string query = "DELETE FROM Appointment " +
                                    $"WHERE Id = {id}";

                    using SqlCommand command = new(query, connection);
                    int recordAffected = command.ExecuteNonQuery();

                    if (recordAffected > 0)
                    {
                        return 1; // Console.WriteLine("Appointment booked succesfully.");
                    }
                    else
                    {
                        return 0; // Console.WriteLine("There was a problem.");
                    }
                }
            }
            catch (Exception ex)
            {
                return 0; // Console.WriteLine(ex.Message);
            }
        }

    }
}
