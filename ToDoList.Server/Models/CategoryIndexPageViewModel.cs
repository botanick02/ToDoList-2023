using ToDoList.Business.DTO_s.Category;
using ToDoList.Business.DTO_s;

namespace ToDoList.Server.Models
{
    public class CategoryIndexPageViewModel
    {
        public List<CategoryDTO> Categories { get; set; }
        public CategoryInputViewModel NewCategory { get; set; }
    }
}
