using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;
using System.Security.Claims;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Services;
using ToDoList.Business.SourceChanger.Enums;
using ToDoList.Server.GraphQL.Tasks.Types;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class Query : ObjectGraphType
    {
        public Query(ITaskService taskService)
        {
            Field<ListGraphType<TaskType>>("GetTasks")
                .Resolve(context =>
                {
                    var source = HeaderSourceProviderParser.ParseContextHeaderSource(context);
                    return taskService.GetTasks(source);
                });
        }
    }
}
