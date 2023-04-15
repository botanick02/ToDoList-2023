using ToDoList.Business.DTO_s;
using ToDoList.Business.DTO_s.Category;

namespace ToDoList.Server.Models
{
    public class TaskIndexPageViewModel
    {
        public List<TaskDTO> TasksList { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public TaskInputViewModel NewTask { get; set; }
    }
}
