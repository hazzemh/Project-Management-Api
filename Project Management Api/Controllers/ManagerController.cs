using Business_Logic.Services;
using Data_Access.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Management_Api.DTOs;

namespace Project_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService _managerService)
        {
           this._managerService = _managerService;
        }

        [HttpGet("Get-Employees")]
        public IActionResult GetEmployees(int pageNo , int pageSize)
        {
            if (pageNo < 1)
            {
                return BadRequest("The page number must be greater than or equal to 1.");
            }
            List<Employee> employees = _managerService.GetEmployees(pageNo,pageSize);
            if (employees.Count == 0)
            {
                return BadRequest("There is no Employees.");
            }
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            foreach (Employee employee in employees)
            {
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.Name = employee.UserName;
                employeeDto.JobTitle = employee.JobTitle;

                employeeDtos.Add(employeeDto);
            }
            return Ok(employeeDtos);
        }

        [HttpPost("Create-Project")]
        public IActionResult CreateNewProject(ProjectDto projectDto)
        {
            try
            {
                var project = new Project
                {
                    Name = projectDto.Name,
                    StartDate = projectDto.StartDate,
                    EndDate = projectDto.EndDate,
                    Budget = projectDto.Budget,
                };
                _managerService.CreateProject(project);

                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create project: " + ex.Message);
            }
        }

        [HttpDelete("Delete-Project")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                _managerService.DeleteProject(projectId);
                return Ok("The Project is deleted Successfully. ");
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            } 
        }

        [HttpPost("Add-Sponsor")]
        public IActionResult AddSponsor([FromBody]Sponsor sponsor)
        {
            try
            {
                _managerService.AddSponsor(sponsor);
                return Ok(sponsor);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("Add-Sponsor-to-project")]
        public IActionResult AddSponsorToProject([FromBody] Sponsor sponsor,int projectId)
        {
            try
            {
                _managerService.AddSponsorToProject(sponsor,projectId);
                return Ok("Sponsor successfully added to the project.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Get-Sponsores")]
        public IActionResult GetSponsores() {
            List<Sponsor> sponsors = _managerService.getAllSponsores();
            if(sponsors.Count == 0)
            {
                return BadRequest("no sponsores.");
            }
            else
            {
                return Ok(sponsors);
            }
        
        }

        [HttpPost("{projectId}/Add-Task-To-Project")]
        public IActionResult AddTaskToProject(int projectId, [FromBody] Data_Access.Models.Task task)
        {
            try
            {
                _managerService.AddTaskToProject(task, projectId);
                return Ok("Task added to project successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred.");
            }
        }

        [HttpPost("{projectId}/{taskName}/assign/{employeeId}")]
        public IActionResult AssignTaskToEmployee(int projectId, string taskName, string employeeId)
        {
            try
            {
                _managerService.AssignTaskToEmployee(projectId, taskName, employeeId);
                return Ok("Task assigned to employee successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

    }
}
