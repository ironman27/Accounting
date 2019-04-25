using System;
using System.Collections.Generic;

namespace Accounting.BusinessObjects
{
    public class Manager:BaseEmployee
    {
        public const decimal Percent = 0.03m;
        private List<BaseEmployee> EmployeeList;

        public Manager(int salaryPerHour) : base(salaryPerHour)
        {
            EmployeeList = new List<BaseEmployee>();
        }

        public override decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            decimal employeesSalarySum = 0;
            foreach (var employee in EmployeeList)
            {
                employeesSalarySum += employee.CalculateSalary(startDateTime, endDateTime);
            }

            return base.CalculateSalary(startDateTime, endDateTime) + employeesSalarySum * Percent;
        }

        public void AddEmployee(BaseEmployee baseEmployee)
        {
            if (!EmployeeList.Contains(baseEmployee) && baseEmployee != this)
            {
                EmployeeList.Add(baseEmployee);
            }
        }
    }
}
