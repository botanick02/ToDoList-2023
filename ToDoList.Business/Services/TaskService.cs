using AutoMapper;
using ToDoList.Buisness.SourceChanger;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Entities;
using ToDoList.Business.Providers;
using ToDoList.Business.SourceChanger.Enums;

namespace ToDoList.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;
        public TaskService(TaskRepositoryResolver taskRepository, IMapper mapper, StorageSources source) 
        {
            this.taskRepository = taskRepository(source);
            this.mapper = mapper;
        }

        public TaskDTO AddTask(NewTaskDTO newTask)
        {
            var task = mapper.Map<TaskEntity>(newTask);

            return mapper.Map<TaskDTO>(taskRepository.AddTask(task));
        }

        public void DeleteTask(int id)
        {
            taskRepository.Delete(id);
        }

        public IEnumerable<TaskDTO> GetTasks()
        {
            var tasks = mapper.Map<IEnumerable<TaskDTO>>(taskRepository.GetTasks());
            tasks = tasks.OrderBy(task => task.DueDate == null ? DateTime.MaxValue : task.DueDate);
            return tasks;
        }

        public TaskDTO ToggleIsDone(int id)
        {
            var task = taskRepository.GetTaskById(id);

            task.IsDone = !task.IsDone;

            return mapper.Map<TaskDTO>(taskRepository.Update(task));
        }
    }
}
