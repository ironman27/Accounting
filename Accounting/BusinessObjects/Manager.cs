using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.BusinessObjects
{
    public class Manager:Employee
    {
        public const decimal Percent = 0.03m;

        public Manager(int salary) : base(salary)
        {
        }

        List<Employee> _employees = new List<Employee>();

        public override decimal CalculateSalary()
        {
            decimal employeesSalarySum = 0;
            foreach (var employee in _employees)
            {
                foreach (var tl in employee._timeLog)
                {
                    employeesSalarySum += employee.Salary * tl.Hours;
                }
            }

            return base.CalculateSalary() + employeesSalarySum * Percent * Percent;
        }
    }
}
