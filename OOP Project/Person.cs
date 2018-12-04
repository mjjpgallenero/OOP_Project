using System;
using System.Globalization;

namespace LabActivity4
{
    public class Person
    {
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string BirthDate; 
        public string Address;
        public string Description;

        public Person(string firstName, string lastName, string middleName = null)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public string GetFullName()
        {
            string fullName;
            if (MiddleName != null)
            {
                fullName = $"{FirstName[0].ToString().ToUpper()} {MiddleName[0].ToString().ToUpper()}. {LastName[0].ToString().ToUpper()}";
            }
            else
            {
                fullName = $"{FirstName[0].ToString().ToUpper()} {LastName[0].ToString().ToUpper()}";
            }

            return fullName;
        }
        public int GetAge()
        {
            return Calculations.CalculateAge(BirthDate); // DD/MM/YYYY
        }
    }
}