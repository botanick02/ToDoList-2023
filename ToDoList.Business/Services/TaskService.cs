using AutoMapper;
using ToDoList.BLL.Services.IServices;
using ToDoList.DAL.DTO_s.Tasks;
using ToDoList.DAL.SourceChanger;
using ToDoList.DAL.SourceChanger.Enums;
using ToDoList.RepositoryAbstractions.Entities;

namespace ToDoList.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskRepositoryResolver taskRepository;
        private readonly IMapper mapper;
        public TaskService(TaskRepositoryResolver taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        public TaskDto AddTask(NewTaskDto newTask, StorageSources source)
        {
            var task = mapper.Map<TaskEntity>(newTask);
            var addedTask = mapper.Map<TaskDto>(taskRepository(source).AddTask(task));
            return addedTask;
        }

        public int DeleteTask(int id, StorageSources source)
        {
            return taskRepository(source).Delete(id);
        }

        public GetTasksDto GetTasks(StorageSources source, int pageNumber, int pageSize)
        {
            var res = new GetTasksDto();
            res.Tasks = mapper.Map<IEnumerable<TaskDto>>(taskRepository(source).GetTasks(pageNumber, pageSize));
            res.TotalCount = taskRepository(source).GetTasksCount();
            return res;
        }

        public TaskDto ToggleIsDone(int id, StorageSources source)
        {
            var task = taskRepository(source).GetTaskById(id) ?? throw new InvalidOperationException($"Task with Id {id} was not found");
            task.IsDone = !task.IsDone;
            return mapper.Map<TaskDto>(taskRepository(source).Update(task));
        }
    }
}
