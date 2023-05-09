using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ToDoList.Business.Entities;
using ToDoList.Business.Providers;
using Dapper;
using System.Threading.Tasks;


namespace ToDoListMsSQLDataProvider
{
    public class MsSQLTaskRepository : ITaskRepository
    {
        private readonly string connectionString;
        public MsSQLTaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TaskEntity? AddTask(TaskEntity task)
        {
            try
            {
                var parameters = new
                {
                    Title = task.Title,
                    CategoryId = task.CategoryId,
                    DueDate = task.DueDate
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
                
                string sqlQuery = $"SELECT Tasks.*, Categories.[Name] AS CategoryName FROM Tasks INNER JOIN Categories ON " +
                    $"Tasks.CategoryId = Categories.Id";

                using (var conn = new SqlConnection(connectionString))
                {
                    var task = conn.Query<TaskEntity>(sqlQuery).ToList();
                    return task;
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
                Id = task.Id,
                Title = task.Title,
                DueDate = task.DueDate,
                CategoryId = task.CategoryId,
                IsDone = task.IsDone
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