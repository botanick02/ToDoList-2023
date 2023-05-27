using AutoMapper;
using ToDoList.BLL.Services.IServices;
using ToDoList.DAL.DTO_s;
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

        public void DeleteTask(int id, StorageSources source)
        {
            taskRepository(source).Delete(id);
        }

        public IEnumerable<TaskDto> GetTasks(StorageSources source)
        {
            var tasks = mapper.Map<IEnumerable<TaskDto>>(taskRepository(source).GetTasks());
            tasks = tasks.OrderBy(task => task.DueDate == null ? DateTime.MaxValue : task.DueDate);
            tasks = tasks.OrderBy(task => task.IsDone);
            return tasks;
        }

        public TaskDto ToggleIsDone(int id, StorageSources source)
        {
            var task = taskRepository(source).GetTaskById(id) ?? throw new InvalidOperationException($"Task with Id {id} was not found");
            task.IsDone = !task.IsDone;
            return mapper.Map<TaskDto>(taskRepository(source).Update(task));
        }
    }
}
