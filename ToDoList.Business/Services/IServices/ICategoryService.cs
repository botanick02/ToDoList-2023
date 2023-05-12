using ToDoList.DAL.DTO_s.Category;

namespace ToDoList.BLL.Services.IServices
{
    public interface ICategoryService
    { 
        public CategoryDTO AddCategory(NewCategoryDTO newTask);

        public IEnumerable<CategoryDTO> GetCategories();

        public void DeleteCategory(int id);
    }
}
