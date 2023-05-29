using GraphQL.Types;
using ToDoList.DAL.DTO_s.Tasks;

namespace ToDoList.Server.GraphQL.Tasks.Types.Inputs
{
    public class NewTaskInputType : InputObjectGraphType<NewTaskDto>
    {
        public NewTaskInputType()
        {
            Field(t => t.Title, nullable: false);

            Field(t => t.CategoryId, nullable: false);

            Field(t => t.DueDate, nullable: true);
        }
    }
}
