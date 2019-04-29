using Accounting.Interfaces;

namespace Accounting.BusinessObjects
{
    public class Employee : EmployeeBase, IEmployee
    {
        public Employee() : base()
        {
        }
        public Employee(decimal salaryPerHour) : base(salaryPerHour)
        {
        }
    }
}