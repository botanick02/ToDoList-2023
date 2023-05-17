using GraphQL.Types;
using ToDoList.Server.GraphQL.Tasks;

namespace ToDoList.Server.GraphQL
{
    public class ToDoListSchema : Schema
    {
        public ToDoListSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}