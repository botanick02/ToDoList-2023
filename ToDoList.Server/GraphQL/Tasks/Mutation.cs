using GraphQL;
using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
using ToDoList.DAL.DTO_s;
using ToDoList.Server.GraphQL.Tasks.Types;
using ToDoList.Server.GraphQL.Tasks.Types.Inputs;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(ITaskService taskService)
        {
            Field<TaskType>("Create")
               .Argument<NewTaskInputType>("NewTaskInputType", "Arguments for task's creation")
               .Resolve(context =>
               {
                   var source = HeaderSourceProviderParser.ParseContextHeaderSource(context);
                   var toDoTaskCreateInput = context.GetArgument<NewTaskDTO>("NewTaskInputType");
                   var res = taskService.AddTask(toDoTaskCreateInput, source);
                   return res;
               });

            Field<TaskType>("ToggleIsDone")
               .Argument<IntGraphType>("TaskId", "Task id to be toggled")
               .Resolve(context =>
               {
                   var source = HeaderSourceProviderParser.ParseContextHeaderSource(context);

                   var taskId = context.GetArgument<int>("TaskId");
                   var res = taskService.ToggleIsDone(taskId, source);
                   return res;
               });

            Field<bool>("DeleteTask")
               .Argument<IntGraphType>("TaskId", "Task id to be deleted")
               .Resolve(context =>
               {
                   var source = HeaderSourceProviderParser.ParseContextHeaderSource(context);

                   var taskId = context.GetArgument<int>("TaskId");
                   taskService.DeleteTask(taskId, source);
                   return true;
               });
        }
    }
}
