﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Models;
using ToDoList.Business.Services;
using ToDoList.Server.Models;

namespace ToDoList.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService taskSerivce;
        public HomeController(ILogger<HomeController> logger, ITaskService taskService)
        {
            _logger = logger;
            this.taskSerivce = taskService;
        }

        public IActionResult Index()
        {
            var model = new IndexPageViewModel();
            model.TasksList = taskSerivce.GetTasks();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTask(NewTaskDTO newTask)
        {
            Debug.WriteLine("task " + newTask.Title + " " + newTask.DueDate);
            taskSerivce.AddTask(newTask);
            return Index();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}