using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.BusinessObjects;

namespace Accounting.Interfaces
{
    public interface IEmployeeBase
    {
        string Name { get; set; }
        decimal SalaryPerHour { get; set; }

        List<ITimeLog> TimeLogList { get; }
    }
}
