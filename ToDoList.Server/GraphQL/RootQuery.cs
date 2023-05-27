using GraphQL.Types;
using ToDoList.Server.GraphQL.Categories;
using ToDoList.Server.GraphQL.StorageSources;
using ToDoList.Server.GraphQL.Tasks;

namespace ToDoList.Server.GraphQL
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery() {

            Field<TasksQuery>("Tasks")
                .Resolve(_ => new { });

            Field<CategoriesQuery>("Categories")
               .Resolve(_ => new { });
            
            Field<StorageSourcesQueries>("StorageSources")
               .Resolve(_ => new { });
        }
    }
}
