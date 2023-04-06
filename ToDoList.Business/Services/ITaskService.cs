using ToDoList.Business.DTO_s;
using ToDoList.Business.Models;

namespace ToDoList.Business.Services
{
    public interface ITaskService
    {
        public TaskDTO AddTask(NewTaskDTO task);
        public List<TaskDTO> GetTasks();
    }
}
