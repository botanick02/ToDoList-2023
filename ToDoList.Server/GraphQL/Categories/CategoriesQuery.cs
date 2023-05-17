using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
using ToDoList.Server.GraphQL.Categories.Types;
using ToDoList.Server.GraphQL.Tasks.Types;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Categories
{
    public class CategoriesQuery : ObjectGraphType
    {
        public CategoriesQuery(ICategoryService categoryService, HeaderSourceProviderParser headerAccessor)
        {
            Field<ListGraphType<CategoryType>>("GetCategories")
                .Resolve(context =>
                {
                    var source = headerAccessor.ParseContextHeaderSource(context);
                    return categoryService.GetCategories(source);
                });
        }
    }
}
