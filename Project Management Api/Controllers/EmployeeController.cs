using Business_Logic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            this._employeeService = _employeeService;
        }

        [HttpGet("{employeeId}/get-employee-projects")]
        public IActionResult GetEmployeeProjects([FromRoute]string employeeId)
        {
            var projects = _employeeService.GetEmployeeProjects(employeeId);
            if(projects.Count == 0)
            {
                return BadRequest("No Projects Found.");
            }
            else
            {
                return Ok(projects);
            }
        }

        [HttpGet("{employeeId}/project-tasks/{projectId}")]
        public IActionResult GetEmployeeTasks([FromRoute]string employeeId, [FromRoute] int projectId)
        { 
            var tasks = _employeeService.GetEmployeeTasks(employeeId, projectId);
            if(tasks.Count == 0)
            {
                return BadRequest("No Tasks assigned yet.");
            }
            else
            {
                return Ok(tasks);
            }
        }
    }
}
