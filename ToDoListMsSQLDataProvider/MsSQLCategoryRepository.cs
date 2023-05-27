using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using ToDoList.RepositoryAbstractions.Entities;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoListMsSQLDataProvider
{
    public class MsSqlCategoryRepository : ICategoryRepository
    {
        private readonly string connectionString;
        public MsSqlCategoryRepository(string connectionString)
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
                        category.Name,
                    };

                    string sqlQuery = $"INSERT INTO Categories ([Name])" +
                        $" VALUES(@Name); SELECT SCOPE_IDENTITY() AS [Id];";
                    var addedCatId = conn.QueryFirst<int>(sqlQuery, parameters);
                    return GetCategoryById(addedCatId);
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
                    string sqlQuery = $"SELECT * FROM Categories WHERE Categories.Id = @Id";
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