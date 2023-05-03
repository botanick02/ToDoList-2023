using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ToDoList.Business.Entities;
using ToDoList.Business.Providers;
using Dapper;
using System.Threading.Tasks;
using ToDoList.Business.Repositories;

namespace ToDoListMsSQLDataProvider
{
    public class MsSQLCategoryRepository : ICategoryRepository
    {
        private readonly string connectionString;
        public MsSQLCategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CategoryEntity? AddCategory(CategoryEntity category)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        Name = category.Name,
                    };

                    string sqlQuery = $"INSERT INTO Categories ([Name])" +
                        $" VALUES(@Name); SELECT SCOPE_IDENTITY() AS [Id];";
                    var addedCat = conn.QueryFirst<CategoryEntity>(sqlQuery, parameters);
                    return addedCat;
                    if (addedCat != null)
                    {
                        return GetCategoryById(addedCat.Id);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }

        public CategoryEntity? GetCategoryById(int id)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        Id = id
                    };
                    string sqlQuery = $"SELECT [Name] FROM Categories WHERE Categories.Id = @Id";
                    var category = conn.QueryFirst<CategoryEntity>(sqlQuery, parameters);
                    return category;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }

        public List<CategoryEntity> GetCategories()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT * FROM Categories";
                    var category = conn.Query<CategoryEntity>(sqlQuery).ToList();
                    return category;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return new List<CategoryEntity>();
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var parameters = new
                {
                    Id = id,
                };
                var sqlQuery = "DELETE FROM Categories WHERE Id = @Id";

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Execute(sqlQuery, parameters);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}