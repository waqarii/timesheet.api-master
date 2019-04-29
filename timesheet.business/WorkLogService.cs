using System;
using System.Collections.Generic;
using timesheet.data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using timsheet.ContractModel;
using timesheet.model;

namespace timesheet.business
{
    public class WorkLogService : IWorkLogService
    {
        private TimesheetDb _db { get; }

        public WorkLogService(TimesheetDb dbContext)
        {
            this._db = dbContext;
        }

        public List<EmployeeTaskModel> GetEmployeeWorkLogs(int empId, DateTime startDate)
        {
            var result = new List<EmployeeTaskModel>();
            try
            {
                var workLogmodel = this._db.WorkLogs.Where(w => w.EmployeeId == empId
                                    && w.WorkLogDateTime >= startDate.Date && w.WorkLogDateTime <= startDate.Date.AddDays(6))
                                   ?.Include(e => e.Employee).Include(t => t.Task);
                var tasks = workLogmodel.Select(x => x.Task).Distinct();

                foreach (var task in tasks)
                {
                    result.Add(new EmployeeTaskModel
                    {
                        TaskId = task.Id,
                        TaskName = task.Name,
                        Day1Hours = workLogmodel.Where(w => w.TaskId == task.Id && w.WorkLogDateTime == startDate.Date).Sum(w => w.TotalLogHours),
                        Day2Hours = workLogmodel.Where(w => w.TaskId == task.Id && w.WorkLogDateTime == startDate.Date.AddDays(1)).Sum(w => w.TotalLogHours),
                        Day3Hours = workLogmodel.Where(w => w.TaskId == task.Id && w.WorkLogDateTime == startDate.Date.AddDays(2)).Sum(w => w.TotalLogHours),
                        Day4Hours = workLogmodel.Where(w => w.TaskId == task.Id && w.WorkLogDateTime == startDate.Date.AddDays(3)).Sum(w => w.TotalLogHours),
                        Day5Hours = workLogmodel.Where(w => w.TaskId == task.Id && w.WorkLogDateTime == startDate.Date.AddDays(4)).Sum(w => w.TotalLogHours),
                        Day6Hours = workLogmodel.Where(w => w.TaskId == task.Id && w.WorkLogDateTime == startDate.Date.AddDays(5)).Sum(w => w.TotalLogHours),
                        Day7Hours = workLogmodel.Where(w => w.TaskId == task.Id && w.WorkLogDateTime == startDate.Date.AddDays(6)).Sum(w => w.TotalLogHours)
                    });
                }
            }
            catch
            {
                //TODO:logging
                throw;
            }
            return result;
        }

        public List<WorkLogModel> GetWorklogList(int empId, DateTime startDate)
        {
            try
            {
                return this._db.WorkLogs.Where(w => w.EmployeeId == empId &&
                                    (startDate == null || w.WorkLogDateTime >= startDate)
                                    && w.WorkLogDateTime <= startDate.Date.AddDays(6))
                                    .Select(w => new WorkLogModel
                                    {
                                        EmployeeId = w.EmployeeId,
                                        TotalLogHours = w.TotalLogHours,
                                        WorkLogDate = w.WorkLogDateTime,
                                        TaskId = w.TaskId
                                    }).ToList();
            }
            catch
            {
                //TODO:logging
                throw;
            }
        }

        public void SaveEmployeeWorkLogs(List<WorkLogReqModel> reqworklog)
        {
            try
            {
                var modelreq = reqworklog.Select(w => new WorkLog
                {
                    EmployeeId= w.EmployeeId,
                    TaskId=w.TaskId,
                    TotalLogHours=w.LogHours,
                    WorkLogDateTime=w.LogDate,
                    UpdatedDate= DateTime.UtcNow,
                    IsActive=true                    
                });

                this._db.WorkLogs.AddRange(modelreq);
                this._db.SaveChanges();
            }
            catch
            {
                //TODO:logging
                throw;
            }
        }
    }
}
