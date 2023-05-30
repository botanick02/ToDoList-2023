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

        public List<CategoryEntity> GetCategories(int pageNumber, int pageSize)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        Offset = pageNumber * pageSize - pageSize,
                        PageSize = pageSize
                    };
                    string sqlQuery = $"SELECT * FROM Categories " +
                        $"ORDER BY Id " +
                        $"OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                    var category = conn.Query<CategoryEntity>(sqlQuery, parameters).ToList();
                    return category;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return new List<CategoryEntity>();
        }

        public int DeleteCategory(int id)
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
            return id;
        }

        public int GetCategoriesCount()
        {
            try
            {
                var sqlQuery = "SELECT COUNT(*) AS Count FROM Categories";

                using (var conn = new SqlConnection(connectionString))
                {
                    return conn.QueryFirst<int>(sqlQuery);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return 0;
        }
    }
}