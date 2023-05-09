using GraphQL.Types;
using ToDoList.Business.DTO_s;

namespace ToDoList.Server.GraphQL.Tasks.Types.Inputs
{
    public class NewTaskInputType : InputObjectGraphType<NewTaskDTO>
    {
        public NewTaskInputType()
        {
            Field(d => d.Title, nullable: false);
            Field(d => d.CategoryId, nullable: false);
            Field(d => d.DueDate, nullable: true);
        }
    }
}
