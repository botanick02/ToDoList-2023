using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ToDoList.Business.Models;
using ToDoList.Business.Providers;
using Dapper;
using System.Threading.Tasks;


namespace ToDoListMsSQLDataProvider
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string connectionString;
        public TaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TaskModel? AddTask(TaskModel task)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        Title = task.Title,
                        CategoryId = task.CategoryId,
                        DueDate = task.DueDate
                    };
                    string sqlQuery = $"INSERT INTO Tasks (Title, CategoryId, DueDate)" +
                        $" VALUES(@Title, @CategoryId, @DueDate); SELECT SCOPE_IDENTITY() AS [Id];";
                    var addedTask = conn.QueryFirst<TaskModel>(sqlQuery, parameters);
                    return addedTask;
                    if (addedTask != null)
                    {
                        return GetTaskById(addedTask.Id);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }

        public TaskModel? GetTaskById(int id)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        Id = id
                    };
                    string sqlQuery = $"SELECT Tasks.*, Categories.[Name] AS CategoryName FROM Tasks INNER JOIN Categories ON " +
                        $"Tasks.CategoryId = Categories.Id WHERE Tasks.Id = @Id";
                    var task = conn.QueryFirst<TaskModel>(sqlQuery, parameters);
                    return task;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return null;
        }

        public List<TaskModel> GetTasks()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string sqlQuery = $"SELECT Tasks.*, Categories.[Name] AS CategoryName FROM Tasks INNER JOIN Categories ON " +
                        $"Tasks.CategoryId = Categories.Id";
                    var task = conn.Query<TaskModel>(sqlQuery).ToList();
                    return task;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return new List<TaskModel>();
        }
    }
}