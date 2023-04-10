using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Business.DTO_s.Category;
using ToDoList.Business.Entities;
using ToDoList.Business.Providers;
using ToDoList.Business.Repositories;

namespace ToDoList.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public CategoryDTO AddCategory(NewCategoryDTO newCategory)
        {
            var category = mapper.Map<CategoryEntity>(newCategory);

            return mapper.Map<CategoryDTO>(categoryRepository.AddCategory(category));
        }
        public List<CategoryDTO> GetCategories()
        {
            return mapper.Map<List<CategoryDTO>>(categoryRepository.GetCategories());
        }
    }
}
