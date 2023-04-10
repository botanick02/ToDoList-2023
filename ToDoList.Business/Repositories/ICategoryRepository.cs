using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Business.Entities;

namespace ToDoList.Business.Repositories
{
    public interface ICategoryRepository
    {
        public CategoryEntity? AddCategory(CategoryEntity category);
        public List<CategoryEntity> GetCategories();
        public CategoryEntity? GetCategoryById(int id);
    }
}
