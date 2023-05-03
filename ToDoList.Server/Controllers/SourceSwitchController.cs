using Microsoft.AspNetCore.Mvc;
using ToDoList.Buisness.SourceChanger;

namespace ToDoList.Server.Controllers
{
    public class SourceSwitchController  : Controller
    {
        

        [HttpPost]
        public IActionResult ChangeCurrentSource(string source, string controller, string action)
        {
            SourceStorage.SetCurrentSource(source);
            return RedirectToAction(action, controller);
        }
    }
}