using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
using ToDoList.Server.GraphQL.Tasks.Types;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class TasksQuery : ObjectGraphType
    {
        public TasksQuery(ITaskService taskService, HeaderSourceProviderParser headerAccessor)
        {
            Field<ListGraphType<TaskType>>("AllTasks")
                .Resolve(context =>
                {
                    var source = headerAccessor.ParseContextHeaderSource(context);
                    return taskService.GetTasks(source);
                });
        }
    }
}
