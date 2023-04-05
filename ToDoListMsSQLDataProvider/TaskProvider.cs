using ToDoList.Business.Models;
using ToDoList.Business.Providers;

namespace ToDoListMsSQLDataProvider
{
    public class TaskProvider : ITaskProvider
    {
        public List<TaskEntity> GetTaskById()
        {
            throw new NotImplementedException();
        }

        public List<TaskEntity> GetTasks()
        {
            throw new NotImplementedException();
        }
    }
}