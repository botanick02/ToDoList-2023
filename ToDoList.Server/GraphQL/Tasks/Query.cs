using GraphQL;
using GraphQL.Types;
using System.Runtime.CompilerServices;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Providers;
using ToDoList.Business.Services;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class Query
    {
        public static IEnumerable<TaskDTO> GetTasks([FromServices] ITaskService taskService)
            => taskService.GetTasks();

        public static string Name()
            => "namefwefd";
    }
}
