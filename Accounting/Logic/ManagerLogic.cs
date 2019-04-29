using System;
using Accounting.Interfaces;

namespace Accounting.Logic
{
    public class ManagerLogic : EmployeeBaseLogic
    {
        public const decimal Percent = 0.03m;

        public ManagerLogic(IManager manager):base(manager)
        {
            Manager = manager;
        }

        private IManager Manager { get; set; }

        public override decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            decimal employeesSalarySum = 0;

            EmployeeLogic employeeLogic = new EmployeeLogic();
            foreach (var employee in Manager.EmployeeList)
            {
                employeeLogic.Employee = employee;
                employeesSalarySum += employeeLogic.CalculateSalary(startDateTime, endDateTime);
            }

            employeeLogic.Employee = Manager;
            return employeeLogic.CalculateSalary(startDateTime, endDateTime) + employeesSalarySum * Percent;
        }
    }
}
