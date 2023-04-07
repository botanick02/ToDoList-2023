using ToDoList.Business.DTO_s;

namespace ToDoList.Server.Models
{
    public class IndexPageViewModel
    {
        public List<TaskDTO> TasksList { get; set; }
        public NewTaskDTO NewTask { get; set; }
    }
}
