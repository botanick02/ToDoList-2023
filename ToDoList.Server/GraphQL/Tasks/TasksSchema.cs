using GraphQL.Types;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class TasksSchema : Schema
    {
        public TasksSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<Query>();
            //Mutation = new AutoRegisteringObjectGraphType<Mutation>();
        }
    }
}