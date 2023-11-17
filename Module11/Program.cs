using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < 100; i++)
            {
                employees.Add(new Employee(RandomFN(),
                    RandomLN(),
                    (EmployeeType)random.Next(Enum.GetValues(typeof(EmployeeType)).Length),
                    random.Next(500, 10000)));
            }

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }

        }

        private static string[] EnglishFirstNames = { "Alex", "Jordan", "Taylor", "Morgan", "Avery", "Casey", "Riley", "Jamie", "Cameron", "Jordan" };
        private static string[] EnglishLastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };

        private static Random random = new Random();

        public static string RandomFN()
        {
            return EnglishFirstNames[random.Next(EnglishFirstNames.Length)];
        }

        public static string RandomLN()
        {
            return EnglishLastNames[random.Next(EnglishLastNames.Length)];
        }
    }

    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        EmployeeType Type { get; set; }
        int Salary { get; set; }
        int ID { get; set; }

        void Print();

    }

    public class Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType Type { get; set; }
        public int Salary { get; set; }
        public int ID { get; set; }

        public static int NewID = 1;

        public Employee(string firstname, string lastname, EmployeeType type, int salary)
        {
            this.ID = NewID;
            NewID++;
            FirstName = firstname;
            LastName = lastname;
            Type = type;
            Salary = salary;
        }

        public void Print()
        {
            Console.Write(
                $"First name: {FirstName}\n" +
                $"Last name: {LastName}\n" +
                $"ID: {ID}\n" +
                $"Job title: {Type}" +
                $"Salary: {Salary}\n");
        }

        public override string ToString()
        {
            return $"{ID} {FirstName} {LastName} {Type} ${Salary}";
        }

    }

    public enum EmployeeType
    {
        Beginner,
        Junior,
        Middle,
        Senior,
        Director
    }
}
