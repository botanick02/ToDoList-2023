using GraphQL;
using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
using ToDoList.Server.GraphQL.Tasks.Types;
using ToDoList.Server.GraphQL.Tasks.Types.Inputs;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class TasksQuery : ObjectGraphType
    {
        public TasksQuery(ITaskService taskService, HeaderSourceProviderParser headerAccessor)
        {
            Field<GetTasksResponseType>("GetTasks")
                .Argument<IntGraphType>("PageNumber")
                .Argument<IntGraphType>("PageSize")
                .Resolve(context =>
                {
                    var pageNumber = context.GetArgument<int>("PageNumber");
                    var pageSize = context.GetArgument<int>("PageSize");
                    var source = headerAccessor.ParseContextHeaderSource(context);

                    return taskService.GetTasks(source, pageNumber, pageSize);
                });
        }
    }
}
