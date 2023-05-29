namespace ToDoList.DAL.DTO_s.Tasks
{
    public class GetTasksDto
    {
        public IEnumerable<TaskDto>? Tasks { get; set; }

        public int TotalCount { get; set; }
    }
}
