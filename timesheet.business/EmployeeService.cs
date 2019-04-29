using System;
using System.Collections.Generic;
using System.Linq;
using timesheet.data;
using timsheet.ContractModel;

namespace timesheet.business
{
    public class EmployeeService :IEmployeeService
    {
        private TimesheetDb _db { get; }

        private readonly IWorkLogService _worklogService;

        public EmployeeService(TimesheetDb dbContext, IWorkLogService workLogService)
        {
            this._db = dbContext;
            this._worklogService = workLogService;
        }

        public IList<EmployeeModel> GetEmployees()
        {
            var employeeLstModel = new List<EmployeeModel>();
            try
            {
                var startDate = GetCurrentWeekDetails(DateTime.UtcNow);
                var emplpyees = _db.Employees;

                foreach (var item in emplpyees)
                {
                    employeeLstModel.Add(new EmployeeModel
                    {
                        Id = item.Id,
                        Code = item.Code,
                        Name = item.Name,
                        TotalWeeklyHours = GetEmployeeWeeklyHours(item.Id, startDate),
                        AverageWeeklyHours = GetEmployeeAvgWeeklyHours(item.Id, startDate)
                    });
                }
            }
            catch
            {
                //TODO:logging
                throw;
            }
            return employeeLstModel;
        }

        private DateTime GetCurrentWeekDetails(DateTime date)
        {
            return date.AddDays(DayOfWeek.Sunday - date.DayOfWeek);
        }

        private decimal? GetEmployeeWeeklyHours(int empId, DateTime startDate)
        {
            var worklogLst = _worklogService.GetWorklogList(empId, startDate);
            return decimal.Round(
                worklogLst.Sum(t => t.TotalLogHours) / 7, 2,
                MidpointRounding.AwayFromZero);
        }

        private decimal? GetEmployeeAvgWeeklyHours(int empId, DateTime startDate)
        {
            var worklogLst = _worklogService.GetWorklogList(empId, startDate);
            return decimal.Round(
                worklogLst.Sum(t => t.TotalLogHours) / (decimal)(startDate - new DateTime(startDate.Year, 1, 1)).TotalDays, 
                2, MidpointRounding.AwayFromZero);
        }               
    }
}
