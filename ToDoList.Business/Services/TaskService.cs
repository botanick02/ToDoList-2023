using AutoMapper;
using System.Threading.Tasks;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Entities;
using ToDoList.Business.Providers;

namespace ToDoList.Business.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper) 
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        public TaskDTO AddTask(NewTaskDTO newTask)
        {
            var task = mapper.Map<TaskEntity>(newTask);

            return mapper.Map<TaskDTO>(taskRepository.AddTask(task));
        }

        public List<TaskDTO> GetTasks()
        {
            return mapper.Map<List<TaskDTO>>(taskRepository.GetTasks());
        }

        public TaskDTO ToggleIsDone(int Id)
        {
            var task = taskRepository.GetTaskById(Id);

            task.IsDone = !task.IsDone;

            return mapper.Map<TaskDTO>(taskRepository.Update(task));
        }
    }
}
