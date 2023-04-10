using ToDoList.Business.DTO_s;
using ToDoList.Business.DTO_s.Category;
using ToDoList.Business.Entities;

namespace ToDoList.Business.Services
{
    public interface ICategoryService
    {
        public CategoryDTO AddCategory(NewCategoryDTO newTask);
        public List<CategoryDTO> GetCategories();
    }
}
