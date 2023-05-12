using ToDoList.Server.Models.Inputs;
using ToDoList.DAL.DTO_s.Category;

namespace ToDoList.Server.Models
{
    public class CategoryIndexPageViewModel
    {
        public List<CategoryDTO> Categories { get; set; }
        public CategoryInputViewModel NewCategory { get; set; }
    }
}
