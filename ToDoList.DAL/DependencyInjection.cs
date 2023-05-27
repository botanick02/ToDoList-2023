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

            if (connectionString == null || connectionString == string.Empty)
            {
                throw new InvalidOperationException("Connection string was not found or empty");
            }

            services.AddTransient(provider => new MsSqlTaskRepository(connectionString));
            services.AddTransient(provider => new MsSqlCategoryRepository(connectionString));
            services.AddTransient<XmlTaskRepository>();
            services.AddTransient<XmlCategoryRepository>();
            services.AddTransient<StorageSourcesProvider>();

            services.AddTransient<CategoryRepositoryResolver>(CategoryRepositoryProvider => key =>
            {
                return key switch
                {
                    StorageSources.MsSQL => CategoryRepositoryProvider.GetService<MsSqlCategoryRepository>()!,
                    StorageSources.XML => CategoryRepositoryProvider.GetService<XmlCategoryRepository>()!,
                    _ => throw new KeyNotFoundException(),
                };
            });

            services.AddTransient<TaskRepositoryResolver>(ToDoTaskRepositoryProvider => key =>
            {
                return key switch
                {
                    StorageSources.MsSQL => ToDoTaskRepositoryProvider.GetService<MsSqlTaskRepository>()!,
                    StorageSources.XML => ToDoTaskRepositoryProvider.GetService<XmlTaskRepository>()!,
                    _ => throw new NotImplementedException(),
                };
            });
        }
    }
}