using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using ToDoList.RepositoryAbstractions.IRepositories;
using ToDoList.RepositoryAbstractions.Entities;
using System.Threading.Tasks;

namespace ToDoListMsSQLDataProvider
{
    public class MsSqlTaskRepository : ITaskRepository
    {
        private readonly string connectionString;
        public MsSqlTaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TaskEntity? AddTask(TaskEntity task)
        {
            try
            {
                var parameters = new
                {
                    task.Title,
                    task.CategoryId,
                    task.DueDate
                };
                string sqlQuery = $"INSERT INTO Tasks (Title, CategoryId, DueDate)" +
                    $" VALUES(@Title, @CategoryId, @DueDate); SELECT SCOPE_IDENTITY() AS [Id];";

                using (var conn = new SqlConnection(connectionString))
                {
                    var addedTaskId = conn.QueryFirst<int>(sqlQuery, parameters);
                    return GetTaskById(addedTaskId);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }

        public TaskEntity? GetTaskById(int id)
        {
            try
            {
                var parameters = new
                {
                    Id = id
                };
                string sqlQuery = $"SELECT * FROM Tasks WHERE Id = @Id";

                using (var conn = new SqlConnection(connectionString))
                {
                    var task = conn.QueryFirst<TaskEntity>(sqlQuery, parameters);
                    if (task != null && task.DueDate != null)
                    {
                        DateTime dueDate = (DateTime)task.DueDate;
                        task.DueDate = DateTime.SpecifyKind(dueDate, DateTimeKind.Utc);
                    }
                    return task;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }

        public List<TaskEntity> GetTasks(int pageNumber, int pageSize)
        {
            try
            {
                var parameters = new
                {
                    Offset = pageNumber * pageSize - pageSize,
                    PageSize = pageSize
                };
                string sqlQuery = $"SELECT * FROM Tasks " +
                    $"ORDER BY CASE WHEN DueDate IS NULL THEN '9999-12-31' ELSE DueDate END, IsDone " +
                    $"OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                using (var conn = new SqlConnection(connectionString))
                {
                    var tasks = conn.Query<TaskEntity>(sqlQuery, parameters).ToList();
                    foreach (var task in tasks)
                    {
                        if (task != null && task.DueDate != null)
                        {
                            DateTime dueDate = (DateTime)task.DueDate;
                            task.DueDate = DateTime.SpecifyKind(dueDate, DateTimeKind.Utc);
                        }
                    }
                    return tasks;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return new List<TaskEntity>();
        }

        public TaskEntity? Update(TaskEntity task)
        {
            
            var parameters = new
            {
                task.Id,
                task.Title,
                task.DueDate,
                task.CategoryId,
                task.IsDone
            };
            var sqlQuery = "UPDATE Tasks SET Title = @Title, CategoryId = @CategoryId," +
                " DueDate = @DueDate, IsDone = @IsDone WHERE Id = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                var affectedRows = conn.Execute(sqlQuery, parameters);
                if (affectedRows > 0)
                {
                    return GetTaskById(task.Id);
                }
                return null;
            }
        }
        public int Delete(int id)
        {
            try
            {
                var parameters = new
                {
                    Id = id,
                };
                var sqlQuery = "DELETE FROM tasks WHERE Id = @Id";

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

        public int GetTasksCount()
        {
            try
            {
                var sqlQuery = "SELECT COUNT(*) AS Count FROM tasks;";

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