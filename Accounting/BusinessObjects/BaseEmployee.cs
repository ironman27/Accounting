using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounting.BusinessObjects
{
    public abstract class BaseEmployee
    {
        private readonly List<TimeLog> _timeLogList;

        protected BaseEmployee(decimal salaryPerHour)
        {
            SalaryPerHour = salaryPerHour;
            _timeLogList = new List<TimeLog>();
        }

        private decimal _salaryPerHour;

        public decimal SalaryPerHour
        {
            get => _salaryPerHour;
            set => _salaryPerHour = value;
        }

        public void AddTimeLog(TimeLog timeLog)
        {
            if (!_timeLogList.Exists(t => t.DateTime == timeLog.DateTime))
            {
                _timeLogList.Add(timeLog);
            }
        }

        public virtual decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime)
        {
            decimal sum = 0;
            foreach (var timeLog in _timeLogList.Where(t => t.DateTime >= startDateTime && t.DateTime <= endDateTime))
            {
                sum += timeLog.Hours * _salaryPerHour;
            }
            return sum;
        }
    }
}
