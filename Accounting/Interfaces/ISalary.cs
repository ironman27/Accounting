using System;

namespace Accounting.Interfaces
{
    public interface ISalary
    {
        decimal CalculateSalary(DateTime startDateTime, DateTime endDateTime);
    }
}
