using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Entities;
using ToDoList.Business.Services;
using ToDoList.Server.Models;

namespace ToDoList.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService taskService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, ITaskService taskService, ICategoryService categoryService, IMapper mapper)
        {
            this.taskService = taskService;
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new IndexPageViewModel();
            model.TasksList = taskService.GetTasks();
            model.CategoriesList = categoryService.GetCategories();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTask(TaskInputViewModel newTask)
        {
            Debug.WriteLine("task " + newTask.Title + " " + newTask.DueDate);
            var newTaskDTO = mapper.Map<NewTaskDTO>(newTask);
            taskService.AddTask(newTaskDTO);
             
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ToggleTask(int taskId)
        {
            taskService.ToggleIsDone(taskId);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}