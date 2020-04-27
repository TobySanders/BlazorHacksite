using HackSite.Data;
using HackSite.Mappers;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectsRepository projectsRepository, ILogger<ProjectsController> logger)
        {
            _projectsRepository = projectsRepository;
            _logger = logger;
        }

        public async Task<ProjectView> AddProjectAsync(string title, string description)
        {
            var project = new Project
            {
                Title = title,
                Description = description
            };

            try
            {
                var result = await _projectsRepository.CreateAsync(project);
                return result.Map();
            }
            catch(Exception e) //TODO:need to figure out what to do with these
            {
                _logger.LogError("Error Adding Project to repository", e);

                return new ProjectView(); //TODO:Probably want to call some error handler instead
            }
        }

        public async Task<ProjectView> GetProjectAsync(Guid id)
        {
            try
            {
                var result = await _projectsRepository.ReadAsync(id);
                return result.Map();
            }
            catch (Exception e)
            {
                _logger.LogError("Error retrieving Project from repository", e);

                return new ProjectView();
            }
        }

        public async Task<ProjectView[]> GetProjectsAsync()
        {
            try
            {
                var result = await _projectsRepository.ReadAllAsync();
                return result.Select(project=>project.Map()).ToArray();
            }
            catch (Exception e)
            {
                _logger.LogError("Error retrieving Projects from repository", e);

                return new ProjectView[0];
            }
        }

        public async Task<ProjectView[]> GetProjectsByTeamAsync(Guid teamId)
        {
            try
            {
                var result = await _projectsRepository.GetProjectsByTeamAsync(teamId);
                return result.Select(project => project.Map()).ToArray();
            }
            catch (Exception e)
            {
                _logger.LogError("Error retrieving Projects from repository", e);

                return new ProjectView[0];
            }
        }

        public async Task<ProjectView[]> GetProjectsByUserAsync(Guid userId)
        {
            try
            {
                var result = await _projectsRepository.GetProjectsByUserAsync(userId);
                return result.Select(project => project.Map()).ToArray();
            }
            catch (Exception e)
            {
                _logger.LogError("Error retrieving Projects from repository", e);

                return new ProjectView[0];
            }
        }

        public async Task<ProjectView> UpdateProjectAsync(ProjectView projectView)
        {
            var project = projectView.Map();

            try
            {
                var result = await _projectsRepository.UpdateAsync(project);
                return result.Map();
            }
            catch (Exception e)
            {
                _logger.LogError("Error Adding Project to repository", e);

                throw new Exception("Failed to Update project");
            }
        }

        public async Task DeleteProjectAsync(Guid projectId)
        {
            try
            {
                await _projectsRepository.DeleteAsync(projectId);
            }
            catch (Exception e)
            {
                _logger.LogError("Error Adding Project to repository", e);

                throw new Exception("Failed to Delete project");
            }
        }

    }
}
