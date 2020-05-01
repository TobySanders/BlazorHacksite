using HackSite.Views;
using System.Linq;
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
                Projects = team.Projects.Select(proj => proj.Map()).ToList(),
                Members = team.Members.Select(member => member.Map()).ToList()
            };
        }

        public static Team Map(this TeamView teamView)
        {
            return new Team
            {
                Id = teamView.Id,
                Name = teamView.Name,
                Projects = teamView.Projects.Select(proj=>proj.Map()).ToList(),
                Members = teamView.Members.Select(member => member.Map()).ToList()
            };
        }

        public static ProjectView Map(this Project project)
        {
            return new ProjectView
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                RepositoryUrl = project.RepositoryUrl
            };
        }

        public static Project Map(this ProjectView projectView)
        {
            return new Project
            {
                Id = projectView.Id,
                Title = projectView.Title,
                Description = projectView.Description,
                RepositoryUrl = projectView.RepositoryUrl
            };
        }

        public static UserView Map(this User user)
        {
            return new UserView
            {
                Id = user.Id,
                Username = user.Username
            };
        }

        public static User Map(this UserView userView)
        {
            return new User
            {
                Id = userView.Id,
                Username = userView.Username
            };
        }
    }
}
