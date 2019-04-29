using System.Collections.Generic;
using timsheet.ContractModel;

namespace timesheet.business
{
    public interface IEmployeeService
    {
        IList<EmployeeModel> GetEmployees();
    }
}
