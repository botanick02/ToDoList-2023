using ToDoList.DAL.DTO_s.Tasks;
using ToDoList.DAL.SourceChanger.Enums;

namespace ToDoList.BLL.Services.IServices
{
    public interface ITaskService
    {
        public TaskDto AddTask(NewTaskDto newTask, StorageSources source);
        public GetTasksDto GetTasks(StorageSources source, int pageNumber, int pageSize);
        public TaskDto ToggleIsDone(int id, StorageSources source);
        public int DeleteTask(int id, StorageSources source);
    }
}
