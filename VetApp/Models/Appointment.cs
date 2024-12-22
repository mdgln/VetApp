using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models
{
    internal class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Animal { get; set; }
        public int Age { get; set; }
        public string Problem { get; set; }
        public DateTime Date { get; set; }

        public Appointment(int id, string patientName, string animal, int age, string problem, DateTime date)
        {
            Id = id;
            PatientName = patientName;
            Animal = animal;
            Age = age;
            Problem = problem;
            Date = date;
        }

        public Appointment(string patientName, string animal, int age, string problem, DateTime date)
        {
            PatientName = patientName;
            Animal = animal;
            Age = age;
            Problem = problem;
            Date = date;
        }
    }
}
