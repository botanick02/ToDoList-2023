using GraphQL.Types;
using ToDoList.DAL.DTO_s.Tasks;

namespace ToDoList.Server.GraphQL.Tasks.Types
{
    public class GetTasksResponseType : ObjectGraphType<GetTasksDto>
    {
        public GetTasksResponseType()
        {
            Field(r => r.Tasks, nullable: false);

            Field(r => r.TotalCount, nullable: false);
        }
    }
}
