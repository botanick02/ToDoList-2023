using ToDoList.DAL.DTO_s;
using ToDoList.DAL.DTO_s.Category;
using ToDoList.Server.Models.Inputs;

namespace ToDoList.Server.Models
{
    public class TaskIndexPageViewModel
    {
        public List<TaskDTO> TasksList { get; set; }

        public List<CategoryDTO> Categories { get; set; }

        public TaskInputViewModel NewTask { get; set; }
    }
}
