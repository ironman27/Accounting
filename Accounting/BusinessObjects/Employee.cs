using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.BusinessObjects
{
    public class Employee : BaseEmployee
    {
        public Employee(decimal salaryPerHour) : base(salaryPerHour)
        {
        }
        
        public override decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            return CalculateBaseSalary(startDateTime, endDateTime);
        }
    }
}
