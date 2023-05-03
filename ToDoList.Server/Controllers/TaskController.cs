using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Buisness.SourceChanger;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Services;
using ToDoList.Server.Models;
using ToDoList.Server.Models.Inputs;

namespace ToDoList.Server.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly StorageSourcesProvider storageSourcesProvider;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService, ICategoryService categoryService, IMapper mapper)
        {
            this.taskService = taskService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.storageSourcesProvider = storageSourcesProvider;
        }

        public IActionResult Index()
        {
            return View(GetIndexPageViewModel());
        }

        [HttpPost]
        public IActionResult AddTask(TaskInputViewModel newTask)
        {
            if (ModelState.IsValid)
            {
                var newTaskDTO = mapper.Map<NewTaskDTO>(newTask);
                taskService.AddTask(newTaskDTO);
            }

            return View("Index", GetIndexPageViewModel());
        }

        [HttpPost]
        public IActionResult ToggleTask(int Id)
        {
            taskService.ToggleIsDone(Id);

            return View("Index", GetIndexPageViewModel());
        }

        [HttpPost]
        public IActionResult DeleteTask(int Id)
        {
            taskService.DeleteTask(Id);

            return View("Index", GetIndexPageViewModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private TaskIndexPageViewModel GetIndexPageViewModel()
        {
            var model = new TaskIndexPageViewModel();
            model.TasksList = taskService.GetTasks();
            model.Categories = categoryService.GetCategories();
            return model;
        }
    }
}