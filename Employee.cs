using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denton_CourseProject_Part2
{
    [Serializable]
    internal class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string ssn { get; set; }
        public DateTime hireDate { get; set; }
        public Benefits benefits { get; set; }


        public Employee(string cFirstName, string cLastName, string cSSN, DateTime cHireDate, Benefits cBenefits)
        {
            firstName = cFirstName;
            lastName = cLastName;
            ssn = cSSN;
            hireDate = cHireDate;
            benefits = cBenefits;
        }
        public override string ToString()
        {
            return firstName + "," + lastName + "," + ssn + "," + hireDate.ToString() + "," + benefits.ToString();
        }

        //private string firstname;
        //private string lastname;
        //private string m_ssn;
        //private DateTime hiredate;

        //public string firstName
        // {
        //    get { return firstname; }
        //   set { firstname = value; }
        //}

        //public string lastName
        //{
        //    get { return lastname; }
        //    set { lastname = value; }
        //}

        //public string ssn
        //{
        //    get { return m_ssn; }
        //    set { m_ssn = value; }
        //}

        //public DateTime hireDate
        //{
        //    get { return hiredate; }
        //    set { hiredate = value; }
        //}
    }
}
