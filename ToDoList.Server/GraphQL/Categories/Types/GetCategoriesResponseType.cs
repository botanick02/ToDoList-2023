
using GraphQL.Types;
using ToDoList.DAL.DTO_s.Category;

namespace ToDoList.Server.GraphQL.Categories.Types
{
    public class GetCategoriesResponseType : ObjectGraphType<GetCategoriesDto>
    {
        public GetCategoriesResponseType()
        {
            Field(r => r.Categories, nullable: false);

            Field(r => r.TotalCount, nullable: false);
        }
    }
}
