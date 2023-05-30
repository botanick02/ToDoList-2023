using GraphQL;
using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
using ToDoList.Server.GraphQL.Categories.Types;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Categories
{
    public class CategoriesQuery : ObjectGraphType
    {
        public CategoriesQuery(ICategoryService categoryService, HeaderSourceProviderParser headerAccessor)
        {
            Field<GetCategoriesResponseType>("GetCategories")
                .Argument<IntGraphType>("PageNumber")
                .Argument<IntGraphType>("PageSize")
                .Resolve(context =>
                {
                    var pageNumber = context.GetArgument<int>("PageNumber");
                    var pageSize = context.GetArgument<int>("PageSize");
                    var source = headerAccessor.ParseContextHeaderSource(context);

                    return categoryService.GetCategories(source, pageNumber, pageSize);
                });
        }
    }
}
