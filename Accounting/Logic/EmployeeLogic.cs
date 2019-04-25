using System;
using System.Linq;
using Accounting.BusinessObjects;
using Accounting.Interfaces;
using Accounting.Services;

namespace Accounting.Logic
{
    public class EmployeeLogic:ISalary
    {
        private Employee _employee;
        public EmployeeLogic(Employee employee)
        {
            _employee = employee;
        }

        public decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            return SalaryService.CalculateSalaryBase(_employee, startDateTime, endDateTime);
        }
    }
}
