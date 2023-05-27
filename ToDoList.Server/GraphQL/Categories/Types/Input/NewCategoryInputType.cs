using GraphQL.Types;
using ToDoList.DAL.DTO_s.Category;

namespace ToDoList.Server.GraphQL.Categories.Types.Input
{
    public class NewCategoryInputType : InputObjectGraphType<NewCategoryDto>
    {
        public NewCategoryInputType()
        {
            Field(c => c.Name, nullable: false);
        }
    }
}
