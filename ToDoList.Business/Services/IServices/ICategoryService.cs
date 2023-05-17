using ToDoList.DAL.DTO_s.Category;
using ToDoList.DAL.SourceChanger.Enums;

namespace ToDoList.BLL.Services.IServices
{
    public interface ICategoryService
    { 
        public CategoryDTO AddCategory(NewCategoryDTO newTask, StorageSources source);

        public IEnumerable<CategoryDTO> GetCategories(StorageSources source);

        public void DeleteCategory(int id, StorageSources source);
    }
}
