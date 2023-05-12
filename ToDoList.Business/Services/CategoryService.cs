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
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(CategoryRepositoryResolver categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository(StorageSources.MsSQL);
            this.mapper = mapper;
        }
        public CategoryDTO AddCategory(NewCategoryDTO newCategory)
        {
            var category = mapper.Map<CategoryEntity>(newCategory);

            return mapper.Map<CategoryDTO>(categoryRepository.AddCategory(category));
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return mapper.Map<IEnumerable<CategoryDTO>>(categoryRepository.GetCategories());
        }
    }
}
