using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Business.Providers;
using ToDoList.Business.Services;
using ToDoListMsSQLDataProvider;

namespace ToDoList.DAL
{
    public static class DALConfiguration
    {
        public static IServiceCollection ConfigureDALServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>(provider => new TaskRepository(configuration.GetConnectionString("DefaultConnection")));

           

            return services;
        }
    }
}
