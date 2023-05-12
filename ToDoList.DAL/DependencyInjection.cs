using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.DAL.SourceChanger;
using ToDoList.DAL.SourceChanger.Enums;
using ToDoList.XMLDataProvider;
using ToDoListMsSQLDataProvider;

namespace ToDoList.DAL
{
    public static class DependencyInjection
    {
        public static void RegisterDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient(provider => new MsSQLTaskRepository(connectionString));
            services.AddTransient(provider => new MsSQLCategoryRepository(connectionString));
            services.AddTransient<XMLTaskRepository>();
            services.AddTransient<XMLCategoryRepository>();
            services.AddTransient<StorageSourcesProvider>();

            services.AddTransient<CategoryRepositoryResolver>(CategoryRepositoryProvider => key =>
            {
                switch (key)
                {
                    case StorageSources.MsSQL:
                        return CategoryRepositoryProvider.GetService<MsSQLCategoryRepository>();
                    case StorageSources.XML:
                        return CategoryRepositoryProvider.GetService<XMLCategoryRepository>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            services.AddTransient<TaskRepositoryResolver>(ToDoTaskRepositoryProvider => key =>
            {
                switch (key)
                {
                    case StorageSources.MsSQL:
                        return ToDoTaskRepositoryProvider.GetService<MsSQLTaskRepository>();
                    case StorageSources.XML:
                        return ToDoTaskRepositoryProvider.GetService<XMLTaskRepository>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
        }
    }
}