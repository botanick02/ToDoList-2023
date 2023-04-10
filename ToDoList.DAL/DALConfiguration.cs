using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Business.Providers;
using ToDoList.Business.Repositories;
using ToDoList.Business.Services;
using ToDoListMsSQLDataProvider;

namespace ToDoList.DAL
{
    public static class DALConfiguration
    {
        public static IServiceCollection ConfigureDALServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddSingleton(configuration);
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITaskRepository, TaskRepository>(provider => new TaskRepository(connectionString));
            services.AddScoped<ICategoryRepository, CategoryRepository>(provider => new CategoryRepository(connectionString));

            return services;
        }
    }
}
