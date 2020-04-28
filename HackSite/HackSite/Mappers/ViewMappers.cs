using HackSite.Data;
using UserManagement.Abstractions.Models;

namespace HackSite.Mappers
{
    public static class ViewMappers
    {
        public static TeamView Map(this Team team)
        {
            return new TeamView
            {
                Id = team.Id,
                Name = team.Name,
                project = team.project.Map()
            };
        }

        public static ProjectView Map(this Project project)
        {
            return new ProjectView
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                RepositoryUrl = project.GithubUrl
            };
        }
        
        public static Project Map(this ProjectView projectView)
        {
            return new Project
            {
                Id = projectView.Id,
                Title = projectView.Title,
                Description = projectView.Description,
                GithubUrl = projectView.RepositoryUrl
            };
        }
    }
}
