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

    public  class ManagerService : IManagerService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Project> _projectRepository;
        private readonly IRepository<Sponsor> _sponsorRepository;
        private readonly IRepository<ProjectSponsors> _projectSponsorsRepository;
        private readonly IRepository<TaskProgress> _taskProgressRepository;
        private readonly IRepository<Data_Access.Models.Task> _taskRepository;

        public ManagerService(IRepository<Employee> _employeeRepository , IRepository<Project> _projectRepository,
            IRepository<Sponsor> _sponsorRepository, IRepository<ProjectSponsors> _projectSponsorsRepository
            , IRepository<TaskProgress> _taskProgressRepository, IRepository<Data_Access.Models.Task> _taskRepository)
        {
            this._employeeRepository = _employeeRepository;
            this._projectRepository = _projectRepository;
            this._sponsorRepository = _sponsorRepository;
            this._projectSponsorsRepository = _projectSponsorsRepository;
            this._taskProgressRepository = _taskProgressRepository;
            this._taskRepository = _taskRepository;
        }

        public List<Employee> GetEmployees(int pageNo , int pageSize)
        {
            return _employeeRepository.GetAllWithPagination(pageNo,pageSize, e => e.Role == "Employee");
        }

        public void CreateProject(Project project)
        {
            _projectRepository.Add(project);
        }

        public void DeleteProject(int projectId)
        {
           _projectRepository.Remove(projectId);
        }

        public void AddSponsor(Sponsor sponsor)
        {
            _sponsorRepository.Add(sponsor);
        }

        public void AddSponsorToProject(Sponsor sponsor,int projectId)
        {
            var projectSponsor = new ProjectSponsors
            {
                ProjectId = projectId,
                SponsorId = sponsor.Id
            };
            _projectSponsorsRepository.Add(projectSponsor);
        }

        public void AddTaskToProject(Data_Access.Models.Task task, int ProjectId) 
        {
            var project =_projectRepository.GetById(ProjectId);

            if (project == null)
            {
                throw new ArgumentException("Project not found.");
            }

            var newTask = new Data_Access.Models.Task
            {
                ProjectId = ProjectId,
                Name = task.Name,
                Duration = task.Duration,
                Progress = task.Progress
            };

            _taskRepository.Add(newTask);
        }

        public void AssignTaskToEmployee(int projectId, string taskName, string employeeId)
        {
                var task = _taskRepository.GetOne(t => t.ProjectId == projectId && t.Name == taskName);

                if (task == null)
                {
                    throw new ArgumentException("Task not found.");
                }

                var employee =_employeeRepository.GetOne(e => e.Id == employeeId);

                if (employee == null)
                {
                    throw new ArgumentException("Employee not found.");
                }

                var taskProgress = new TaskProgress
                {
                    EmployeeId = employeeId,
                    ProjectId = projectId,
                    Name = taskName,
                    Hours = 0 // Assuming initial progress is 0 hours
                };

               _taskProgressRepository.Add(taskProgress);
            
        }

        public List<Sponsor> getAllSponsores()
        {
            return _sponsorRepository.GetAll();
        }

    }
}
