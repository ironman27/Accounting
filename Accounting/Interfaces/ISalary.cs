using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Interfaces
{
    public interface ISalary
    {
        decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime);
    }
}
