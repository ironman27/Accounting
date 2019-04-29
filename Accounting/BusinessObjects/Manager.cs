using System;
using System.Collections.Generic;
using Accounting.Interfaces;

namespace Accounting.BusinessObjects
{
    public class Manager : EmployeeBase, IManager
    {
        public List<IEmployee> EmployeeList { get; }

        public Manager() : base()
        {
            EmployeeList = new List<IEmployee>();
        }

        public Manager(int salaryPerHour) : base(salaryPerHour)
        {
            EmployeeList = new List<IEmployee>();
        }
    }
}
