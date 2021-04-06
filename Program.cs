using System;
using System.Collections.Generic;
using Npgsql;

namespace EmployeeBirthdays
{
    class Program
    {
        static void OutputList(List<Employee> listOfEmployee)
        {
            listOfEmployee.Sort();
            foreach (Employee person in listOfEmployee)
            {
                Console.WriteLine(person);
            }
        }
        static void OutputListOfEmployeeInMonth(int howManyMonthNext, Dictionary<int, List<Employee>> listOfEmployeeInMonth)
        {
            for (int i = 0; i < howManyMonthNext; i++)
            {
                DateTime currentDate = DateTime.Today.AddMonths(i);
                Console.WriteLine($"{currentDate.ToString("yyyy MMMM")} ");
                if (listOfEmployeeInMonth.ContainsKey(currentDate.Month))
                {
                    OutputList(listOfEmployeeInMonth[currentDate.Month]);
                }
            }
        }
        static Dictionary<int, List<Employee>> ReadFromDBAndSaveIntoDictionary()
        {
            Dictionary<int, List<Employee>> listOfEmployeeInMonth = new Dictionary<int, List<Employee>>();

            string connString = "Host=127.0.0.1;Username=employee_birthday_api;Password=secret;Database=employeebirthdays";

            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            // Retrieve all rows
            using (var cmd = new NpgsqlCommand("SELECT name, surname, dateofbrith FROM employee", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string surname = reader.GetString(1);
                        DateTime date = reader.GetDateTime(2);


                        Employee newEmployee = new Employee()
                        {
                            Name = name,
                            Surname = surname,
                            DateOfBirth = date
                        };

                        if (!listOfEmployeeInMonth.ContainsKey(date.Month))
                        {
                            listOfEmployeeInMonth.Add(date.Month, new List<Employee>());
                        }

                        listOfEmployeeInMonth[date.Month].Add(newEmployee);

                    }
                }
            }
            return listOfEmployeeInMonth;
        }
        static void Main(string[] args)
        {
            Dictionary<int, List<Employee>> listOfEmployeeInMonth = ReadFromDBAndSaveIntoDictionary();

            
            int howManyMonthNext = 5;
            OutputListOfEmployeeInMonth(howManyMonthNext, listOfEmployeeInMonth); 

        }
    }
}
