using GraphQL;
using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
using ToDoList.DAL.DTO_s.Tasks;
using ToDoList.Server.GraphQL.Tasks.Types;
using ToDoList.Server.GraphQL.Tasks.Types.Inputs;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class TasksMutation : ObjectGraphType
    {
        public TasksMutation(ITaskService taskService, HeaderSourceProviderParser headerAccessor)
        {
            Field<TaskType>("CreateTask")
               .Argument<NewTaskInputType>("NewTaskInputType", "Arguments for task's creation")
               .Resolve(context =>
               {
                   var source = headerAccessor.ParseContextHeaderSource(context);
                   var toDoTaskCreateInput = context.GetArgument<NewTaskDto>("NewTaskInputType");
                   var res = taskService.AddTask(toDoTaskCreateInput, source);
                   return res;
               });

            Field<TaskType>("ToggleIsDone")
               .Argument<IntGraphType>("Id", "Task id to be toggled")
               .Resolve(context =>
               {
                   var source = headerAccessor.ParseContextHeaderSource(context);

                   var taskId = context.GetArgument<int>("Id");
                   var res = taskService.ToggleIsDone(taskId, source);
                   return res;
               });

            Field<int>("DeleteTask")
               .Argument<IntGraphType>("Id", "Task id to be deleted")
               .Resolve(context =>
               {
                   var source = headerAccessor.ParseContextHeaderSource(context);

                   var taskId = context.GetArgument<int>("Id");
                   
                   return taskService.DeleteTask(taskId, source);
               });
        }
    }
}
