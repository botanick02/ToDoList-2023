using ToDoList.Business.DTO_s;
using ToDoList.Business.SourceChanger.Enums;

namespace ToDoList.Business.Services
{
    public interface ITaskService
    {
        public TaskDTO AddTask(NewTaskDTO newTask, StorageSources source);
        public IEnumerable<TaskDTO> GetTasks(StorageSources source);
        public TaskDTO ToggleIsDone(int Id, StorageSources source);
        public void DeleteTask(int Id, StorageSources source);
    }
}
