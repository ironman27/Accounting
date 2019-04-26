using System;
using System.Collections.Generic;

namespace Accounting.BusinessObjects
{
    public class Manager:BaseEmployee
    {
        public const decimal Percent = 0.03m;
        private readonly List<BaseEmployee> _employeeList = new List<BaseEmployee>();

        public Manager(int salaryPerHour) : base(salaryPerHour)
        {
        }

        public Manager(int salaryPerHour, IEnumerable<BaseEmployee> employees) : base(salaryPerHour)
        {
            foreach (var employee in employees)
                AddEmployee(employee);
        }

        public override decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            decimal employeesSalarySum = 0;
            foreach (var employee in _employeeList)
            {
                employeesSalarySum += employee.CalculateSalary(startDateTime, endDateTime);
            }

            return base.CalculateSalary(startDateTime, endDateTime) + employeesSalarySum * Percent;
        }

        public void AddEmployee(BaseEmployee baseEmployee)
        {
            if (!_employeeList.Contains(baseEmployee) && baseEmployee != this)
            {
                _employeeList.Add(baseEmployee);
            }
        }
    }
}
