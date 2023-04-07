using AutoMapper;
using System.Threading.Tasks;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Models;
using ToDoList.Business.Providers;

namespace ToDoList.Business.Services
{
    public class TaskService : ITaskService
    {
        private ITaskRepository taskRepository;
        private IMapper mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper) 
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        public TaskDTO AddTask(NewTaskDTO newTask)
        {
            var task = mapper.Map<TaskModel>(newTask);

            return mapper.Map<TaskDTO>(taskRepository.AddTask(task));
        }

        public List<TaskDTO> GetTasks()
        {
            return mapper.Map<List<TaskDTO>>(taskRepository.GetTasks());
        }
    }
}
