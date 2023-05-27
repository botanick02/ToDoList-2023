
using ToDoList.DAL.DTO_s;
using ToDoList.DAL.SourceChanger.Enums;

namespace ToDoList.BLL.Services.IServices
{
    public interface ITaskService
    {
        public TaskDto AddTask(NewTaskDto newTask, StorageSources source);
        public IEnumerable<TaskDto> GetTasks(StorageSources source);
        public TaskDto ToggleIsDone(int id, StorageSources source);
        public void DeleteTask(int id, StorageSources source);
    }
}
