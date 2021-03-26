using System;

namespace EmployeeBirthdays
{
    class Employee : IComparable<Employee>
    {
        public DateTime DateOfBirth { get; private set; }
        string name;
        string surname;
        public Employee(DateTime dateOfBirth_, string name_, string surname_)
        {
            DateOfBirth = dateOfBirth_;
            name = name_;
            surname = surname_;
        }
        public override string ToString()
        {
            int age = (DateTime.Today.Year - DateOfBirth.Year - 1) +(((DateTime.Today.Month > DateOfBirth.Month) || ((DateTime.Today.Month == DateOfBirth.Month) && (DateTime.Today.Day >= DateOfBirth.Day))) ? 1 : 0);
            return $"({DateOfBirth.ToString("dd")}) - {name} {surname} ({age} {Plural(age,"год","года","лет")})";
        }

        public string String(DateTime date)
        {
            int age = (date.Year - DateOfBirth.Year - 1) +(((date.Month > DateOfBirth.Month) || ((date.Month == DateOfBirth.Month) && (date.Day >= DateOfBirth.Day))) ? 1 : 0);
            return $"({DateOfBirth.ToString("dd")}) - {name} {surname} ({age} {Plural(age,"год","года","лет")})";
        }
        public int CompareTo(Employee p)
        {
            int i = this.DateOfBirth.Month.CompareTo(p.DateOfBirth.Month);
            if (i == 0)
            {
                return this.DateOfBirth.Day.CompareTo(p.DateOfBirth.Day);                
            }
            else
            {
                return i;
            }
        }

        string Plural(int number, string formNominativeSingl, string formNominativePlural, string formGenitivePlural)
        {
            int lastDigit = number % 10;
            if (lastDigit == 0 || lastDigit >= 5 || number % 100 == 11)
            {
                return formGenitivePlural;
            } 
            else if (lastDigit == 1)
            {
                return formNominativeSingl;
            }                        
            else
            {
                return formNominativePlural;
            }
        }
    }
}