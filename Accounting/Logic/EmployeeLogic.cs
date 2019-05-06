using Accounting.Interfaces;

namespace Accounting.Logic
{
    public class EmployeeLogic:EmployeeBaseLogic
    {
		public EmployeeLogic() : base()
		{
		}
		public EmployeeLogic(IEmployeeBase employee) :base(employee)
        {
        }        
    }
}
