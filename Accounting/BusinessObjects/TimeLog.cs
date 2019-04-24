using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.BusinessObjects
{
    public class TimeLog
    {
        public TimeLog(DateTime dateTime, int hours)
        {
            DateTime = dateTime;
            Hours = hours;
        }

        public DateTime DateTime { get; set; }
        public int Hours { get; set; }
    }
}
