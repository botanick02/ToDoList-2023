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

        public List<TaskEntity> GetTasks()
        {
            try
            {
                string sqlQuery = $"SELECT * FROM Tasks";

                using (var conn = new SqlConnection(connectionString))
                {
                    var tasks = conn.Query<TaskEntity>(sqlQuery).ToList();
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
        public void Delete(int id)
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
        }
    }
}