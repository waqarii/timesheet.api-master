using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using timesheet.business;
using timsheet.ContractModel;

namespace timesheet.api.controllers
{
    [Route("api/v1/worklog")]
    [ApiController]
    public class WorkLogController : ControllerBase
    {
        private readonly IWorkLogService _workLogService;

        public WorkLogController(IWorkLogService workLogService)
        {
            _workLogService = workLogService;
        }

        [HttpGet]
        [Route("GetWorkLog")]
        public IActionResult GetWorkLog(int employeeId, DateTime startDate)
        {
            var items = this._workLogService.GetEmployeeWorkLogs(employeeId, startDate);
            return new ObjectResult(items);
        }

        [HttpPost("SaveWorkLog")]
        public IActionResult Save([FromBody] List<WorkLogReqModel> empWorklogs)
        {
            this._workLogService.SaveEmployeeWorkLogs(empWorklogs);
            return new ObjectResult(true);
        }
    }
}