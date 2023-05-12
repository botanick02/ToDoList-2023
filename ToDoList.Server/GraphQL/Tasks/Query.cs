using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
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
