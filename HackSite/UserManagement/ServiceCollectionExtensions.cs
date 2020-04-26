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
            services.TryAddScoped<IEntityResolver<ProjectTableEntity, Project>, ProjectEntityResolver>();
            services.TryAddScoped<IProjectsRepository, ProjectsRepository>();

            return services;
        }

        public static IServiceCollection AddTeamsRepository(this IServiceCollection services)
        {
            services.TryAddScoped<IEntityResolver<TeamTableEntity, Team>, TeamEntityResolver>();
            services.TryAddScoped<ITeamsRepository, TeamsRepository>();

            return services;
        }

        public static IServiceCollection AddUserRepository(this IServiceCollection services)
        {
            services.TryAddScoped<IEntityResolver<UserTableEntity, User>, UserEntityResolver>();

            return services;
        }
    }
}
