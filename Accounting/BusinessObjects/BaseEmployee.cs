using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounting.BusinessObjects
{
    public abstract class BaseEmployee
    {
        private List<TimeLog> TimeLogList;

        protected BaseEmployee(decimal salaryPerHour)
        {
            SalaryPerHour = salaryPerHour;
            TimeLogList = new List<TimeLog>();
        }

        private decimal _salaryPerHour;

        public decimal SalaryPerHour
        {
            get => _salaryPerHour;
            set => _salaryPerHour = value;
        }

        public void AddTimeLog(TimeLog timeLog)
        {
            if (!TimeLogList.Exists(t => t.DateTime == timeLog.DateTime))
            {
                TimeLogList.Add(timeLog);
            }
        }

        public virtual decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            decimal sum = 0;
            foreach (var timeLog in TimeLogList.Where(t => t.DateTime >= startDateTime && t.DateTime <= endDateTime))
            {
                sum += timeLog.Hours * _salaryPerHour;
            }
            return sum;
        }
    }
}
