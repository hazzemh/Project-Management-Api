using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public interface IManagerService
    {
        List<Employee> GetEmployees(int pageNo, int pageSize);
        void CreateProject(Project project);
        void DeleteProject(int projectId);
        void AddSponsor(Sponsor sponsor);
        void AddSponsorToProject(Sponsor sponsor, int projectId);
        List<Sponsor> getAllSponsores();
        void AddTaskToProject(Data_Access.Models.Task task, int ProjectId);
        void AssignTaskToEmployee(int projectId, string taskName, string employeeId);
    }
}
