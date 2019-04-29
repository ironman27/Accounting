using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Accounting.Interfaces;

namespace Accounting.BusinessObjects
{
    public abstract class EmployeeBase: IEquatable<EmployeeBase>, IEmployeeBase
    {
        protected EmployeeBase()
        {
        }
        protected EmployeeBase(decimal salaryPerHour)
        {
            SalaryPerHour = salaryPerHour;
            TimeLogList = new List<ITimeLog>();
        }

        public string Name { get; set; }
        public decimal SalaryPerHour { get; set; }
        public List<ITimeLog> TimeLogList { get; }
        
        
        
        public bool Equals(EmployeeBase other)
        {
            if (other == null || this.Name != other.Name || this.SalaryPerHour != other.SalaryPerHour || this.TimeLogList.Count != other.TimeLogList.Count)
            {
                return false;
            }

            for (int i = 0; i < this.TimeLogList.Count; i++)
            {
                if (!this.TimeLogList[i].Equals(other.TimeLogList[i]))
                {
                    return false;
                }
            }
            
            return  true;
        }
    }
}
