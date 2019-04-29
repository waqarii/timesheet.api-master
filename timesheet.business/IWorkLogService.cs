using System;
using System.Collections.Generic;
using timsheet.ContractModel;

namespace timesheet.business
{
    public interface IWorkLogService
    {
        List<EmployeeTaskModel> GetEmployeeWorkLogs(int empId, DateTime startDate);
        List<WorkLogModel> GetWorklogList(int empId, DateTime startDate);
        void SaveEmployeeWorkLogs(List<WorkLogReqModel> reqworklog);
    }
}