using System;
using System.Linq;
using Accounting.Interfaces;

namespace Accounting.Logic
{
    public abstract class EmployeeBaseLogic
    {
        public EmployeeBaseLogic()
        {
        }

        public EmployeeBaseLogic(IEmployeeBase employeeBase)
        {
            Employee = employeeBase;
        }

        public IEmployeeBase Employee { get; set; }

        public virtual decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            return Employee.TimeLogList.Where(t => t.DateTime >= startDateTime && t.DateTime <= endDateTime).Sum(timeLog => timeLog.Hours * Employee.SalaryPerHour);
        }
    }
}
