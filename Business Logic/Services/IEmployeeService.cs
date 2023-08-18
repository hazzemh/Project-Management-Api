using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public interface IEmployeeService
    {
        List<Project> GetEmployeeProjects(string employeeId);
        List<Data_Access.Models.Task> GetEmployeeTasks(string employeeId,int projectId);
    }
}
