using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Server.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
