using AutoMapper;
using ToDoList.Buisness.SourceChanger;
using ToDoList.Business.DTO_s.Category;
using ToDoList.Business.Entities;
using ToDoList.Business.Repositories;
using ToDoList.Business.SourceChanger.Enums;

namespace ToDoList.Business.Services
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

        public List<CategoryDTO> GetCategories()
        {
            return mapper.Map<List<CategoryDTO>>(categoryRepository.GetCategories());
        }
    }
}
