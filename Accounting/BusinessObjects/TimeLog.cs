using System;
using Accounting.Interfaces;

namespace Accounting.BusinessObjects
{
    public class TimeLog:IEquatable<ITimeLog>, ITimeLog
    {
        public TimeLog()
        {
        }

        public TimeLog(DateTime dateTime, int hours)
        {
            DateTime = dateTime;
            Hours = hours;
        }

        public DateTime DateTime { get; set; }
        public int Hours { get; set; }

        public bool Equals(ITimeLog other)
        {
            return other != null && this.DateTime == other.DateTime && this.Hours == other.Hours;
        }
    }
}
