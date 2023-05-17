using GraphQL;
using GraphQL.Types;
using ToDoList.BLL.Services.IServices;
using ToDoList.DAL.DTO_s.Category;
using ToDoList.Server.GraphQL.Categories.Types;
using ToDoList.Server.GraphQL.Categories.Types.Input;
using ToDoList.Server.HttpContextHelpers;

namespace ToDoList.Server.GraphQL.Categories
{
    public class CategoriesMutation : ObjectGraphType
    {
        public CategoriesMutation(ICategoryService categoryService, HeaderSourceProviderParser headerAccessor)
        {
            Field<CategoryType>("CreateCategory")
               .Argument<NewCategoryInputType>("NewCategoryInputType", "Arguments for category's creation")
               .Resolve(context =>
               {
                   var source = headerAccessor.ParseContextHeaderSource(context);
                   var categoryCreateInput = context.GetArgument<NewCategoryDTO>("NewCategoryInputType");
                   var res = categoryService.AddCategory(categoryCreateInput, source);
                   return res;
               });


            Field<bool>("DeleteCategory")
               .Argument<IntGraphType>("CategoryId", "Category id to be deleted")
               .Resolve(context =>
               {
                   var source = headerAccessor.ParseContextHeaderSource(context);

                   var categoryId = context.GetArgument<int>("CategoryId");
                   categoryService.DeleteCategory(categoryId, source);
                   return true;
               });
        }
    }
}
