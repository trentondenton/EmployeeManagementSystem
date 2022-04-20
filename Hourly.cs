using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denton_CourseProject_Part2
{
    [Serializable]
    internal class Hourly : Employee
    {
        public double hourlyRate { get; set; }
        public double hoursWorked { get; set; }

        public Hourly(string cFirstName,
            string cLastName,
            string cSSN,
            DateTime cHireDate,
            Benefits cBenefits,
            double cHourlyRate,
            double cHoursWorked) : base(cFirstName, cLastName, cSSN, cHireDate, cBenefits)
        {
            hourlyRate = cHoursWorked;
            hoursWorked = cHoursWorked;

        }

        public override string ToString()
        {
            return firstName + "," + lastName + "," + ssn + "," + hireDate.ToString() + "," + benefits.ToString() + "," + hourlyRate.ToString() + "," +hoursWorked.ToString();
        }

        public double CalculatePay()
        {
            return hoursWorked * hourlyRate;
        }
    }
}
