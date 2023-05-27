using GraphQL.Types;
using ToDoList.DAL.DTO_s;

namespace ToDoList.Server.GraphQL.Tasks.Types
{
    public class TaskType : ObjectGraphType<TaskDto>
    {
        public TaskType()
        {
            Field(t => t.Title, nullable: false);

            Field(t => t.Id, nullable: false);

            Field(t => t.IsDone, nullable: false);

            Field(t => t.CategoryId, nullable: false);

            Field(t => t.DueDate, nullable: true);
        }
    }
}
