using Data_Access.Models;
using Data_Access.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<TaskProgress> _taskProgressRepository;
        private readonly IRepository<Data_Access.Models.Task> _taskRepository;

        public EmployeeService(IRepository<Project> _projectRepository, IRepository<Data_Access.Models.Task> _taskRepository,
                               IRepository<TaskProgress> _taskProgressRepository)
        {
            this._projectRepository = _projectRepository;
            this._taskProgressRepository = _taskProgressRepository;
            this._taskRepository = _taskRepository; 
        }

        public List<Project> GetEmployeeProjects(string employeeId)
        {
            var employeeProjectsIds = _taskProgressRepository.GetList(tp => tp.EmployeeId == employeeId)
                                                          .Select(tp => tp.ProjectId).ToList();
            var projects = _projectRepository.GetList(p => employeeProjectsIds.Contains(p.Id)).ToList();

            return projects;
        }

        public List<Data_Access.Models.Task> GetEmployeeTasks(string employeeId, int projectId)
        {
            var employeeTasks = _taskProgressRepository.GetList(tp => tp.EmployeeId == employeeId 
                                && tp.ProjectId == projectId)
                                .Select(tp => tp.Name)
                                .ToList();

            var tasks = _taskRepository.GetList(t => employeeTasks.Contains(t.Name)).ToList();

            return tasks;
        }
    }
}
