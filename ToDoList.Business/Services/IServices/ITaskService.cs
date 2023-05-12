
using ToDoList.DAL.DTO_s;
using ToDoList.DAL.SourceChanger.Enums;

namespace ToDoList.BLL.Services.IServices
{
    public interface ITaskService
    {
        public TaskDTO AddTask(NewTaskDTO newTask, StorageSources source);
        public IEnumerable<TaskDTO> GetTasks(StorageSources source);
        public TaskDTO ToggleIsDone(int Id, StorageSources source);
        public void DeleteTask(int Id, StorageSources source);
    }
}
