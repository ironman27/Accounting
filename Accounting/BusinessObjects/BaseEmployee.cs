using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.BusinessObjects
{
    public abstract class BaseEmployee
    {
        private decimal _salaryPerHour;
        private List<TimeLog> _timeLog = new List<TimeLog>();

        protected BaseEmployee(decimal salaryPerHour)
        {
            _salaryPerHour = salaryPerHour;
        }

        public abstract decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime);

        protected decimal CalculateBaseSalary(DateTime startDateTime, DateTime enDateTime)
        {
            decimal sum = 0;
            foreach (var timeLog in _timeLog.Where(t => t.DateTime >= startDateTime && t.DateTime <= enDateTime))
            {
                sum += timeLog.Hours * _salaryPerHour;
            }
            return sum;
        }

        public void AddTimeLog(TimeLog timeLog)
        {
            _timeLog.Add(timeLog);
        }
    }
}
