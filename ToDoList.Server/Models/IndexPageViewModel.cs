using ToDoList.Business.DTO_s;
using ToDoList.Business.DTO_s.Category;

namespace ToDoList.Server.Models
{
    public class IndexPageViewModel
    {
        public List<TaskDTO> TasksList { get; set; }
        public List<CategoryDTO> CategoriesList { get; set; }
        public TaskInputViewModel NewTask { get; set; }
    }
}
