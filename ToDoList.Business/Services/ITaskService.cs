using ToDoList.Business.DTO_s;
using ToDoList.Business.Entities;

namespace ToDoList.Business.Services
{
    public interface ITaskService
    {
        public TaskDTO AddTask(NewTaskDTO newTask);
        public List<TaskDTO> GetTasks();
        public TaskDTO ToggleIsDone(int Id);
    }
}
