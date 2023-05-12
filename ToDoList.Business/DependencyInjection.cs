using ToDoList.BLL.Services.IServices;
using ToDoList.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.BLL.Utilities.AutoMapperProfiles;

namespace ToDoList.BLL
{
    public static class DependencyInjection
    {
        public static void RegisterBLLDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}
