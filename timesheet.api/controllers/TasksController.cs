using Microsoft.AspNetCore.Mvc;
using timesheet.business;

namespace timesheet.api.controllers
{
    [Route("api/v1/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _taskService;

        public TasksController(ITasksService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("getAllTask")]
        public IActionResult GetAllTask()
        {
            var items = _taskService.GetAllTask();
            return new ObjectResult(items);
        }
    }
}