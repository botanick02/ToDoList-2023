using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;
using System.Security.Claims;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Services;
using ToDoList.Business.SourceChanger.Enums;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class Query : ObjectGraphType
    {
        public Query(ITaskService taskService)
        {
            Field<ListGraphType<TaskType>>("GetTasks")
                .Resolve(context =>
                {
                    var httpContext = context.RequestServices.GetService<IHttpContextAccessor>().HttpContext;
                    var sourceString = httpContext.Request.Headers["Source"];
                    StorageSources source;
                    Enum.TryParse(sourceString, out source);

                    return taskService.GetTasks(source);
                });
        }
    }
}
