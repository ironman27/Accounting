using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.BusinessObjects
{
    public class Employee
    {
        public Employee(decimal salary)
        {
            Salary = salary;
        }

        public decimal Salary { get; set; }
        public List<TimeLog> _timeLog = new List<TimeLog>();

        public virtual decimal CalculateSalary()
        {
            decimal sum = 0;
            foreach (var timeLog in _timeLog)
            {
                sum += timeLog.Hours * Salary;
            }
            return sum;
        }
    }
}
