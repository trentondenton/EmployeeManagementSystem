using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denton_CourseProject_Part2
{
    [Serializable]
    internal class Benefits
    {
        public string healthInsurance { get; set; }
        public double lifeInsurance { get; set; }
        public int vacation { get; set; }

        public Benefits(string cHealthInsurance, double cLifeInsurance, int cVacation)
        {
            healthInsurance = cHealthInsurance;
            lifeInsurance = cLifeInsurance;
            vacation = cVacation;
        }
        public override string ToString()
        {
            return healthInsurance + "," + lifeInsurance + "," + vacation.ToString();
        }
    }
}
