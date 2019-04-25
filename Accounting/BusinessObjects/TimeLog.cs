using System;

namespace Accounting.BusinessObjects
{
    public class TimeLog
    {
        public TimeLog(DateTime dateTime, int hours)
        {
            DateTime = dateTime;
            Hours = hours;
        }

        private DateTime _dateTime;

        public DateTime DateTime
        {
            get => _dateTime;
            set => _dateTime = value;
        }

        private int _hours;
        public int Hours
        {
            get => _hours;
            set
            {
                if (value >= 0 && value <= 24)
                    _hours = value;
            }
        }
    }
}
