using System;
using Accounting.BusinessObjects;
using Accounting.Interfaces;
using Accounting.Services;

namespace Accounting.Logic
{
    public class ManagerLogic : ISalary
    {
        private Manager _manager;
        public ManagerLogic(Manager manager)
        {
            _manager = manager;
        }

        public decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            decimal employeesSalarySum = 0;
            foreach (var employee in _manager.Employees)
            {
                employeesSalarySum += SalaryService.CalculateSalaryBase(employee, startDateTime, endDateTime);
            }

            return SalaryService.CalculateSalaryBase(_manager, startDateTime, endDateTime) + employeesSalarySum * Manager.Percent;
        }

    }
}
