using GraphQL.Types;
using ToDoList.DAL.DTO_s;

namespace ToDoList.Server.GraphQL.Tasks.Types.Inputs
{
    public class NewTaskInputType : InputObjectGraphType<NewTaskDTO>
    {
        public NewTaskInputType()
        {
            Field(t => t.Title, nullable: false);

            Field(t => t.CategoryId, nullable: false);

            Field(t => t.DueDate, nullable: true);
        }
    }
}
