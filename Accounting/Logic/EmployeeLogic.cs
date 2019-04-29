using Accounting.Interfaces;

namespace Accounting.Logic
{
    public class EmployeeLogic:EmployeeBaseLogic
    {
        public EmployeeLogic(IEmployeeBase employee) :base(employee)
        {
        }

        public EmployeeLogic() : base()
        {
        }
    }
}
