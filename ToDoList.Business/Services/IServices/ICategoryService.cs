using ToDoList.DAL.DTO_s.Category;
using ToDoList.DAL.SourceChanger.Enums;

namespace ToDoList.BLL.Services.IServices
{
    public interface ICategoryService
    { 
        public CategoryDto AddCategory(NewCategoryDto newCategory, StorageSources source);

        public GetCategoriesDto GetCategories(StorageSources source, int pageNumber, int pageSize);

        public int DeleteCategory(int id, StorageSources source);
    }
}
