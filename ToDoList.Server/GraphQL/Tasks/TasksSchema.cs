using GraphQL.Types;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class TasksSchema : Schema
    {
        public TasksSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = new AutoRegisteringObjectGraphType<Query>();
            //Mutation = new AutoRegisteringObjectGraphType<Mutation>();
        }
    }
}