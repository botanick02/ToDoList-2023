using GraphQL.Types;
using ToDoList.Server.GraphQL.Categories;
using ToDoList.Server.GraphQL.Tasks;

namespace ToDoList.Server.GraphQL
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation() {
            Field<TasksMutation>("Tasks")
                .Resolve(_ => new { });

            Field<CategoriesMutation>("Categories")
               .Resolve(_ => new { });
        }
    }
}
