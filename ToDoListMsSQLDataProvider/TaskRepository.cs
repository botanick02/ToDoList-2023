using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ToDoList.Business.Models;
using ToDoList.Business.Providers;
using Dapper;


namespace ToDoListMsSQLDataProvider
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string connectionString;
        public TaskRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TaskModel AddTask(TaskModel task)
        {
            try
            {
                TaskModel res = null;
                using (var conn = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        Title = task.Title,
                        CategoryId = task.CategoryId,
                        DueDate = task.DueDate
                    };
                    string sqlQuery = $"INSERT INTO task (Title, CategoryId, DueDate)" +
                        $" VALUES(@Title, @CategoryId, @DueDate); SELECT SCOPE_IDENTITY() AS [Id];";
                    var addedTask = conn.QueryFirst<TaskModel>(sqlQuery, parameters);
                    return addedTask;
                    //if (addedTask != null)
                    //{
                    //    res = GetTask(addedTask.Id);
                    //}
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return task;
        }

        public List<TaskModel> GetTaskById()
        {
            throw new NotImplementedException();
        }

        public List<TaskModel> GetTasks()
        {
            throw new NotImplementedException();
        }
    }
}