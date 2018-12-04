using System;

namespace LabActivity4
{
    public class Calculations
    {
        public static int CalculateAge(string birthDate)
        {
            DateTime now = DateTime.UtcNow;
            DateTime past = Convert.ToDateTime(birthDate);

            var ageInMonths = 12 * (now.Year - past.Year) + (now.Month - past.Month);
            var age = ageInMonths / 12;

            return age;
        }

        public decimal CalculateInterest(int principalAmount, decimal monthlyRate, int months)
        {
            return principalAmount * (monthlyRate / 100) * months;
        }

        public decimal CalculateAccruedAmount(string startDate, int principalAmount, decimal monthlyRate)
        {
            DateTime now = DateTime.UtcNow;
            DateTime past = Convert.ToDateTime(startDate);

            var numberOfMonths = 12 * (now.Year - past.Year) + (now.Month - past.Month);

            decimal I = CalculateInterest(principalAmount, monthlyRate, numberOfMonths);

            return principalAmount + (I * numberOfMonths);
        }
    }
}