using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denton_CourseProject_Part2
{
    [Serializable]
    internal class Salary : Employee
    {
        public double annualSalary { get; set; }

        public Salary(string cFirstName,
            string cLastName,
            string cSSN,
            DateTime cHireDate,
            Benefits cBenefits,
            double cAnnualSalary) : base(cFirstName, cLastName, cSSN, cHireDate, cBenefits)
            {
            annualSalary = cAnnualSalary;

            }

        public override string ToString()
        {
            return firstName + "," + lastName + "," + ssn + "," + hireDate.ToString() + "," + benefits.ToString() + "," + annualSalary.ToString();
        }

        public double CalculatePay()
        {
            return annualSalary / 12;
        }
    }
}
