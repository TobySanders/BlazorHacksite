using HackSite.Shared;
using UserManagement.Abstractions.Models;

namespace HackSite.Server.Mappers
{
    //Made this class as a quick fix before an actual way to build responses has been implemented

    public static class Mappers
    {
        public static UserViewModel Map(this User user)
        {
            return new UserViewModel
            {
                Username = user.Username
            };
        }

        public static TeamViewModel Map(this Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name,
                Members = team.Members,
                Project = team.project.Map()
            };
        }

        public static ProjectViewModel Map(this Project project)
        {
            return new ProjectViewModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                GithubUrl = project.GithubUrl
            };
        }
    }
}

