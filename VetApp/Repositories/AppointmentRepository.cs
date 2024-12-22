using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Data;
using VetApp.Models;

namespace VetApp.Repositories
{
    internal class AppointmentRepository
    {
        public int Add(Appointment appointment)
        {
            AppointmentDataSource appointmentDataSource = new();
            return appointmentDataSource.Add(appointment);
        }

        public IEnumerable<Appointment> GetAll()
        {
            AppointmentDataSource appointmentDataSource = new();
            return appointmentDataSource.GetAll();
        }

        public int Delete(int id)
        {
            AppointmentDataSource appointmentDataSource = new();
            return appointmentDataSource.Delete(id);
        }
    }
}
