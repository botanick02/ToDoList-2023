using GraphQL.Types;
using System;
using ToDoList.Business.DTO_s;

namespace ToDoList.Server.GraphQL.Tasks
{
    public class TaskType : ObjectGraphType<TaskDTO>
    {
        public TaskType()
        {
            Field(d => d.Title, nullable: false);
            Field(d => d.Id, nullable: false);
            Field(d => d.IsDone, nullable: false);
            Field(d => d.CategoryId, nullable: false);
            Field(d => d.DueDate, nullable: true);
        }
    }
}
