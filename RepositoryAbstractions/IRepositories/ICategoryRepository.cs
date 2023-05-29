using ToDoList.RepositoryAbstractions.Entities;

namespace ToDoList.RepositoryAbstractions.IRepositories
{
    public interface ICategoryRepository
    {
        public CategoryEntity? AddCategory(CategoryEntity category);

        public List<CategoryEntity> GetCategories();
        
        public CategoryEntity? GetCategoryById(int id);
        
        public int DeleteCategory(int id);
    }
}
