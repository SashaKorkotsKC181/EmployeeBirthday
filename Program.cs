using System;
using System.Collections.Generic;

namespace EmployeeBirthdays
{
    class Program
    {
        static void OutputList(List<Employee> listOfEmployee)
        {
            listOfEmployee.Sort();
            foreach(Employee person in listOfEmployee)
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
        static void Main(string[] args)
        {
            Dictionary<int, List<Employee>> listOfEmployeeInMonth = new Dictionary<int, List<Employee>>();

            List<Employee> test5Month = new List<Employee>();
            test5Month.Add(new Employee(new DateTime(1998,5,20),"Ваня", "Иванов"));
            test5Month.Add(new Employee(new DateTime(1988,5,24),"Аня", "Січ"));
            List<Employee> test4Month = new List<Employee>();
            test4Month.Add(new Employee(new DateTime(2000,4,1),"Коля", "Новогодний"));
            test4Month.Add(new Employee(new DateTime(1991,4,7),"Стас", "Рождественский"));
        
            listOfEmployeeInMonth.Add(5, test5Month);
            listOfEmployeeInMonth.Add(4,test5Month);



            int howManyMonthNext = 5;

            OutputListOfEmployeeInMonth(howManyMonthNext, listOfEmployeeInMonth);


            
        }
    }
}
