using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StorageProviders.Abstractions.Models;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;
using UserManagement.EntityResolvers;

namespace UserManagement
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectsRepository(this IServiceCollection services)
        {
            services.TryAddSingleton<IEntityResolver<ProjectTableEntity, Project>, ProjectEntityResolver>();
            services.TryAddSingleton<IProjectsRepository, ProjectsRepository>();

            return services;
        }

        public static IServiceCollection AddTeamsRepository(this IServiceCollection services)
        {
            services.TryAddSingleton<IEntityResolver<TeamTableEntity, Team>, TeamEntityResolver>();
            services.TryAddSingleton<ITeamsRepository, TeamsRepository>();

            return services;
        }

        public static IServiceCollection AddUserRepository(this IServiceCollection services)
        {
            services.TryAddSingleton<IEntityResolver<UserTableEntity, User>, UserEntityResolver>();
            services.TryAddSingleton<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
