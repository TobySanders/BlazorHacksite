using HackSite.Mappers;
using HackSite.Views;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace HackSite.Controllers
{
    public class ProjectsController
    {
        private readonly IProjectsRepository _projectsRepository;

        public ProjectsController(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<ProjectView> AddProjectAsync(string title, string description)
        {
            var project = new Project
            {
                Title = title,
                Description = description
            };

            var result = await _projectsRepository.CreateAsync(project);
            return result.Map();
        }

        public async Task<ProjectView> GetProjectAsync(Guid id)
        {
            var result = await _projectsRepository.ReadAsync(id);
            return result.Map();
        }

        public async Task<ProjectView[]> GetProjectsAsync()
        {
            var result = await _projectsRepository.ReadAllAsync();
            return result.Select(project => project.Map()).ToArray();
        }

        public async Task<ProjectView> UpdateProjectAsync(ProjectView projectView)
        {
            var project = projectView.Map();
            var result = await _projectsRepository.UpdateAsync(project);
            return result.Map();
        }

        public async Task DeleteProjectAsync(Guid projectId)
        {
            await _projectsRepository.DeleteAsync(projectId);
        }

    }
}
