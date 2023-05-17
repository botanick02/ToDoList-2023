using GraphQL.Types;
using System;
using ToDoList.DAL.DTO_s.Category;

namespace ToDoList.Server.GraphQL.Categories.Types.Input
{
    public class NewCategoryInputType : InputObjectGraphType<NewCategoryDTO>
    {
        public NewCategoryInputType()
        {
            Field(c => c.Name, nullable: false);
        }
    }
}
