using System;
using System.Collections.Generic;

namespace Accounting.BusinessObjects
{
    public class Manager:BaseEmployee
    {
        public const decimal Percent = 0.03m;

        public Manager(int salaryPerHour) : base(salaryPerHour)
        {
        }

        private List<BaseEmployee> employees = new List<BaseEmployee>();

        public override decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            decimal employeesSalarySum = 0;
            foreach (var employee in employees)
            {
                employeesSalarySum += employee.CalculateSalary(startDateTime, endDateTime);
            }

            return CalculateBaseSalary(startDateTime, endDateTime) + employeesSalarySum * Percent;
        }

        public void AddEmployee(BaseEmployee baseEmployee)
        {
            if(!employees.Contains(baseEmployee) && baseEmployee != this)
                employees.Add(baseEmployee);
        }
    }
}
