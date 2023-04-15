using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Business.DTO_s;
using ToDoList.Business.DTO_s.Category;
using ToDoList.Business.Services;
using ToDoList.Server.Models;

namespace ToDoList.Server.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoryController(ILogger<TaskController> logger, ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(GetIndexPageViewModel());
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryInputViewModel newCategory)
        {
            if (ModelState.IsValid)
            {
                var newCategoryDTO = mapper.Map<NewCategoryDTO>(newCategory);
                categoryService.AddCategory(newCategoryDTO);
            }

            return View("Index", GetIndexPageViewModel());
        }


        [HttpPost]
        public IActionResult DeleteCategory(int Id)
        {
            categoryService.DeleteCategory(Id);

            return View("Index", GetIndexPageViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private CategoryIndexPageViewModel GetIndexPageViewModel()
        {
            var model = new CategoryIndexPageViewModel();
            model.Categories = categoryService.GetCategories();
            return model;
        }
    }
}