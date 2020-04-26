using HackSite.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StorageProviders;
using StorageProviders.Abstractions;
using StorageProviders.Abstractions.Models;
using StorageProviders.Abstractions.Settings;
using StorageProviders.Mocks;
using System;
using UserManagement;
using UserManagement.Abstractions;
using UserManagement.Abstractions.Models;

namespace HackSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();


            if (Configuration.GetValue<bool>("UseLocalStorage"))
            {
                services.AddSingleton<ITableStorageProvider<UserTableEntity, Guid>, UserTableStorageMock>().
                    AddSingleton<ITableStorageProvider<TeamTableEntity, Guid>, TeamTableStroageMock>().
                    AddSingleton<ITableStorageProvider<ProjectTableEntity, Guid>, ProjectTableStorageMock>();
            }
            else
            {
                services.Configure<TableSettings>(Configuration);
                services.AddSingleton<ITableStorageProvider<ProjectTableEntity, Guid>, ProjectTableStorageProvider>()
                   .AddSingleton<ITableStorageProvider<TeamTableEntity, Guid>, TeamTableStorageProvider>();
            }

            services.AddProjectsRepository()
                .AddTeamsRepository();

            services.AddSingleton<TeamsController>(); //no idea if this should be singleton or not but the visual studio template used singleton
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
