﻿using GraphQL.Types;
using ToDoList.DAL.DTO_s.Category;

namespace ToDoList.Server.GraphQL.Categories.Types
{
    public class CategoryType : ObjectGraphType<CategoryDto>
    {
        public CategoryType()
        {
                Field(c => c.Id, nullable: false);

                Field(c => c.Name, nullable: false);
        }
    }
}
