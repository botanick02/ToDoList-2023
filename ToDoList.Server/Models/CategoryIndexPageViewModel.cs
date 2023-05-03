using ToDoList.Business.DTO_s.Category;
using ToDoList.Business.DTO_s;
using ToDoList.Server.Models.Inputs;

namespace ToDoList.Server.Models
{
    public class CategoryIndexPageViewModel
    {
        public List<CategoryDTO> Categories { get; set; }
        public CategoryInputViewModel NewCategory { get; set; }
    }
}
