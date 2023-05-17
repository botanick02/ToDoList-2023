using AutoMapper;
using ToDoList.BLL.Services.IServices;
using ToDoList.DAL.DTO_s.Category;
using ToDoList.DAL.SourceChanger.Enums;
using ToDoList.RepositoryAbstractions.Entities;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoList.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepositoryResolver categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(CategoryRepositoryResolver categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public CategoryDTO AddCategory(NewCategoryDTO newCategory, StorageSources source)
        {
            var category = mapper.Map<CategoryEntity>(newCategory);

            return mapper.Map<CategoryDTO>(categoryRepository(source).AddCategory(category));
        }

        public void DeleteCategory(int id, StorageSources source)
        {
            categoryRepository(source).DeleteCategory(id);
        }

        public IEnumerable<CategoryDTO> GetCategories(StorageSources source)
        {
            return mapper.Map<IEnumerable<CategoryDTO>>(categoryRepository(source).GetCategories());
        }
    }
}
