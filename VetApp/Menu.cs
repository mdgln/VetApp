using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Data;
using VetApp.Models;
using VetApp.Repositories;

namespace VetApp
{
    public class Menu
    {

        public Menu()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
            string option;
            bool isValid;

            do
            {

                Console.WriteLine("Welcome to VetApp\n");

                Console.WriteLine("1. Add an appointment");
                Console.WriteLine("2. Check appointments");
                Console.WriteLine("3. Delete an appointment");
                Console.WriteLine("4. Patients");
                Console.WriteLine("5. Leave\n");

                Console.Write("Select a valid option, please: ");
                option = Console.ReadLine();
                isValid = int.TryParse(option, out int _);

                if (!isValid)
                {
                    Console.WriteLine("\nChoose a valid option, please.");
                    Console.WriteLine("Type any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (!isValid);

            Console.Clear();

            switch (option)
            {
                case "1":
                    AddAppointment();
                    break;
                case "2":
                    CheckAppointments();
                    break;
                case "3":
                    DeleteAppointment();
                    break;
                case "4":
                    Patients();
                    break;
                case "5":
                    Leave();
                    break;
                default:
                    Console.WriteLine("This is not a valid option.");
                    break;
            }

        }

        private void AddAppointment()
        {
            Console.WriteLine("Add an appointment\n");

            Console.Write("Patient Name: ");
            string patientName = Console.ReadLine();
            Console.Write("Animal: ");
            string animal = Console.ReadLine();
            Console.Write("Age: ");
            string age = Console.ReadLine();
            Console.Write("Problem: ");
            string problem = Console.ReadLine();
            Console.Write("Date: ");
            string date = Console.ReadLine();

            AppointmentRepository appointmentRepository = new();
            int result = appointmentRepository.Add(new Appointment(patientName, animal, int.Parse(age), problem, DateTime.Parse(date)));

            if (result == 0)
            {
                Console.WriteLine("\nThere was a problem. The appointment could not be booked.");
            } else
            {
                Console.WriteLine("\nAppointment booked succesfully.");
            }

            Console.Write("Please click any key to continue...");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }

        private void CheckAppointments()
        {
            Console.WriteLine("Check appointments\n");

            AppointmentRepository appointmentRepository = new();
            IEnumerable<Appointment> appointments = appointmentRepository.GetAll();

            if (appointments.Any())
            {
                Console.WriteLine("|{0,0}|{1,-15}|{2,-15}|{3,-5}|{4,-25}|{5,-25}|", "ID", "Patient Name", "Animal", "Age", "Problem", "Date");
                foreach (Appointment appointment in appointments)
                { 
                    Console.WriteLine("|{0,-2}|{1,-15}|{2,-15}|{3,-5}|{4,-25}|{5,-25}|", appointment.Id, appointment.PatientName.Trim(), appointment.Animal.Trim(), appointment.Age.ToString().Trim(), appointment.Problem.Trim(), appointment.Date.ToString().Trim());
                }
            }
            
            Console.Write("\nClick any key to go back to the menu...");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }

        private void Patients()
        {
            Console.WriteLine("Patients\n");

            AppointmentRepository appointmentRepository = new();
            IEnumerable<Appointment> appointments = appointmentRepository.GetAll();

            if (appointments.Any())
            {
                Console.WriteLine("|{0,-15}|{1,-10}|", "Patient Name", "Animal");
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine("|{0,-15}|{1,-10}|", appointment.PatientName.Trim(), appointment.Animal.Trim());
                }
            }

            Console.Write("\nClick any key to go back to the menu...");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }

        private void DeleteAppointment()
        {
            Console.WriteLine("Delete an appointment\n");

            AppointmentRepository appointmentRepository = new();
            IEnumerable<Appointment> appointments = appointmentRepository.GetAll();

            if (appointments.Any())
            {


                Console.WriteLine("|{0,0}|{1,-15}|{2,-15}|{3,-5}|{4,-25}|{5,-25}|", "ID", "Patient Name", "Animal", "Age", "Problem", "Date");
                foreach (Appointment appointment in appointments)
                {
                    Console.WriteLine("|{0,-2}|{1,-15}|{2,-15}|{3,-5}|{4,-25}|{5,-25}|", appointment.Id, appointment.PatientName.Trim(), appointment.Animal.Trim(), appointment.Age.ToString().Trim(), appointment.Problem.Trim(), appointment.Date.ToString().Trim());
                }
            }

            Console.Write("\nSelect the ID of the appointent you want to delete: ");
            string appointmentId = Console.ReadLine();

            int result = appointmentRepository.Delete(int.Parse(appointmentId));

            if (result == 0)
            {
                Console.WriteLine("\nThere was a problem. The appointment could not be deleted.");
            }
            else
            {
                Console.WriteLine("\nAppointment deleted succesfully.");
            }

            Console.Write("Please click any key to continue...");
            Console.ReadLine();
            Console.Clear();
            ShowMenu();
        }

        private void Leave()
        {
            Console.WriteLine("Are you sure you want to leave the VetApp? (y/n)");
            string result = Console.ReadLine();

            if (result != "y")
            {
                Console.Clear();
                ShowMenu();
            }
        }

    }
}
