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

            //заполняем лист случайными 50 работниками
            for (int i = 0; i < 50; i++)
            {
                employees.Add(new Employee(RandomFN(),
                    RandomLN(),
                    (EmployeeType)random.Next(Enum.GetValues(typeof(EmployeeType)).Length),
                    random.Next(500, 10000),
                    (Gender)random.Next(Enum.GetValues(typeof(Gender)).Length),
                    RandomHireDate()));
            }

            //вывод всех работников
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.ToString());
            }

            // Вывод сотрудников по выбранному типу
            bool validTypeInput = false;
            EmployeeType selectedType = EmployeeType.Beginner;

            while (!validTypeInput)
            {
                Console.WriteLine("Введите номер типа сотрудника (1 - Beginner, 2 - Junior, 3 - Middle, 4 - Senior, 5 - Director):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int employeeTypeIndex) && employeeTypeIndex >= 1 && employeeTypeIndex <= Enum.GetValues(typeof(EmployeeType)).Length)
                {
                    selectedType = (EmployeeType)employeeTypeIndex - 1;
                    validTypeInput = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите корректное значение.");
                }
            }

            Console.WriteLine($"Сотрудники типа {selectedType}:");
            DisplayEmployeesByType(employees, selectedType);

            // Вывод сотрудников по выбранному гендеру
            bool validGenderInput = false;
            Gender selectedGender = Gender.Male;

            while (!validGenderInput)
            {
                Console.WriteLine("Введите номер гендера сотрудника (1 - Male, 2 - Female):");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int genderIndex) && genderIndex >= 1 && genderIndex <= Enum.GetValues(typeof(Gender)).Length)
                {
                    selectedGender = (Gender)genderIndex - 1;
                    validGenderInput = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите корректное значение.");
                }
            }

            Console.WriteLine($"Сотрудники гендера {selectedGender}:");
            DisplayEmployeesByGender(employees, selectedGender);

            // Вывод сотрудников трудоустроенных после введенного года
            bool validYearInput = false;
            int selectedYear = 2000;

            while (!validYearInput)
            {
                Console.WriteLine("Введите год трудоустройства:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out selectedYear) && selectedYear >= 2000 && selectedYear <= DateTime.Now.Year)
                {
                    validYearInput = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите корректное значение.");
                }
            }

            Console.WriteLine($"Сотрудники, трудоустроенные после {selectedYear} года:");
            DisplayEmployeesAfterYear(employees, selectedYear);

            Console.ReadKey();
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
        public static DateTime RandomHireDate()
        {
            DateTime startDate = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - startDate).Days;

            return startDate.AddDays(random.Next(range));
        }

        // Метод для вывода сотрудников по выбранному типу
        private static void DisplayEmployeesByType(List<Employee> employees, EmployeeType selectedType)
        {
            var selectedTypeEmployees = employees.Where(e => e.Type == selectedType).ToList();
            selectedTypeEmployees.Sort((e1, e2) => e1.LastName.CompareTo(e2.LastName));

            foreach (Employee employee in selectedTypeEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        // Метод для вывода сотрудников по выбранному гендеру
        private static void DisplayEmployeesByGender(List<Employee> employees, Gender selectedGender)
        {
            var selectedGenderEmployees = employees.Where(e => e.Gender == selectedGender).ToList();
            selectedGenderEmployees.Sort((e1, e2) => e1.LastName.CompareTo(e2.LastName));

            foreach (Employee employee in selectedGenderEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        // Метод для вывода сотрудников трудоустроенных после введенного года
        private static void DisplayEmployeesAfterYear(List<Employee> employees, int selectedYear)
        {
            var selectedYearEmployees = employees.Where(e => e.HireDate.Year > selectedYear).ToList();
            selectedYearEmployees.Sort((e1, e2) => e1.LastName.CompareTo(e2.LastName));

            foreach (Employee employee in selectedYearEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }

    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        DateTime HireDate { get; set; }
        EmployeeType Type { get; set; }
        Gender Gender { get; set; }
        int Salary { get; set; }
        int ID { get; set; }

        void Print();

    }

    public class Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeType Type { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public int ID { get; set; }

        public static int NewID = 1;

        public Employee(string firstname, string lastname, EmployeeType type, int salary, Gender gender, DateTime hiredate)
        {
            this.ID = NewID;
            NewID++;
            FirstName = firstname;
            LastName = lastname;
            Type = type;
            Salary = salary;
            Gender = gender;
            HireDate = hiredate;
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
            return $"{ID} {LastName} {FirstName} {Type} ${Salary}";
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

    public enum Gender
    {
        Male,
        Female
    }
}
