using Microsoft.AspNetCore.Mvc;
using timesheet.business;

namespace timesheet.api.controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;            
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var items = _employeeService.GetEmployees();
            return new ObjectResult(items);
        }
    }
}