using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Assignment2
{
    public class Person
    {
        public static List<string> firstName = new List<string>() { "John", "Jane", "Nick", "Mike", "Julia", "Rhythm", "Sofia", "Bert", "Tom", "Lewis" };
        public static List<string> lastName = new List<string>() { "Doe", "Susan", "Peterley", "Haggins", "Myers", "Cameron", "Miles", "Wick", "Bing", "Geller" };
        public static List<string> gender = new List<string>() { "M", "F", "M", "M", "F", "F", "F", "F", "M", "M", "F" };
        public static List<string> birthDate = new List<string>() { "1998-05-20", "1993-06-2", "1988-03-2", "1948-05-27", "2009-03-1", "1975-05-20", "2012-12-9", "1994-04-10", "1950-11-17", "1990-05-26", "1999-08-30" };
        public static List<string> patientNumber = new List<string>() { "1122334401", "1122334402", "1122334403", "1122334404", "1122334405", "1122334406", "1122334407", "1122334408", "1122334409", "1122334410" };

    }

    public class Client : Person
    {
        public void listAllClients()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"First Name: {Person.firstName[i]}");
                Console.WriteLine($"Last Name: {Person.lastName[i]}");
                Console.WriteLine($"Gender: {Person.gender[i]}");
                Console.WriteLine($"Birth date: {Person.birthDate[i]}");
                Console.WriteLine($"Patient Number: XXX{Person.patientNumber[i].Substring(3)}");
                Console.WriteLine("=========================================");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
    public class Service
    {
        public static List<string> services = new List<string>() { "Cleaning", "Cavity Fill", "Check-up", "X-Ray" };
        public static List<string> extraServices = new List<string>() { "Braces", "Veneers", "Dentures" };
    }



    public class AppointmentDetails
    {
        public string first;
        public string last;
        public string age;
        public string number;
        public List<String> service = new List<string> { };

    }

    public class Appointments : Service
    {

        public List<AppointmentDetails> appointmentList = new List<AppointmentDetails>(8);

        public AppointmentDetails this[int index]
        {
            get { return appointmentList[index]; }
            set { appointmentList[index] = value; }
        }

        public void AddAppointment()
        {
            Console.Clear();
            if (appointmentList.Count < 8)
            {
                AppointmentDetails appointment = new AppointmentDetails();
                Console.WriteLine("Appointment details:");
                Console.WriteLine("Enter first Name:");
                appointment.first = Console.ReadLine();
                Console.WriteLine("Enter last Name:");
                appointment.last = Console.ReadLine();
                Console.WriteLine("Enter age:");
                appointment.age = Console.ReadLine();
                int temp = 0;
                try
                {
                    temp = int.Parse(appointment.age);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Enter number:");
                appointment.number = Console.ReadLine();

                Console.Clear();
                int ex = -1;
                string? option = "8";
                while (option != "6")
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Services:");
                    for (int i = 0; i < services.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{services[i]}");
                    }
                    if (temp < 18 && temp > 0)
                    {
                        Console.WriteLine("5." + extraServices[0]);
                        ex = 0;
                    }
                    else if (temp > 18 && temp < 65)
                    {
                        Console.WriteLine("5." + extraServices[1]);
                        ex = 1;
                    }
                    else
                    {
                        Console.WriteLine("5." + extraServices[2]);
                        ex = 2;
                    }
                    Console.WriteLine("6.Done");

                    option = Console.ReadLine();
                    int c = 0;
                    while (option == "6" && appointment.service.Count == 0 && c < 2)
                    {
                        if (c == 1)
                        {
                            Console.WriteLine("Please try later!");
                            Console.ReadLine();
                            return;
                        }
                        Console.WriteLine("Please pick at least one service to continue: ");
                        option = Console.ReadLine();

                        c++;
                    }
                    int op = 0;
                    bool tr = int.TryParse(option, out op);

                    if (op == 5)
                    {
                        string temp1 = extraServices[ex];
                        //Console.WriteLine(temp1);
                        appointment.service.Add(temp1);
                    }
                    else if (op < 5 && op > 0)
                    {
                        //Console.WriteLine(services[op - 1]);
                        appointment.service.Add(services[op - 1]);
                    }
                    else if (op > 6)
                    {
                        Console.WriteLine("Invalid Input!!!");
                    }
                }

                appointmentList.Add(appointment);
            }
            else
            {
                Console.WriteLine("Sorry! We are fully booked for the day!");
                Console.ReadLine();
            }

        }

        public void listAllAppointments()
        {
            Console.Clear();
            Console.WriteLine("Appointments:");
            Console.WriteLine($"Total appointments for the day: {appointmentList.Count}");

            foreach (var appointment in appointmentList)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"Name: {appointment.first} {appointment.last}");
                Console.WriteLine($"Age: {appointment.age}");
                Console.WriteLine($"Number: {appointment.number}");
                Console.WriteLine("Services:" + appointment.service.Count());
                for (int j = 0; j < appointment.service.Count(); j++)
                {
                    Console.WriteLine(appointment.service[j]);
                }
                Console.WriteLine("==============================");

            }
            Console.ReadLine();
        }


    }


    public class Program
    {
        public static void Main(String[] args)
        {
            Client client = new Client();
            Appointments appointments = new Appointments();


            string option = "0";
            do
            {
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("Menu:");
                Console.WriteLine("1.List all people");
                Console.WriteLine("2.Add Appointment");
                Console.WriteLine("3.Display Schedule");
                Console.WriteLine("4.Exit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        client.listAllClients();
                        break;
                    case "2":
                        appointments.AddAppointment();
                        break;
                    case "3":
                        appointments.listAllAppointments();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid Input!!!");
                        break;
                }


            } while (option != "4");
        }
    }
}
