namespace ToDoList.DAL.DTO_s.Tasks
{
    public class NewTaskDto
    {
        public string? Title { get; set; }

        public DateTime? DueDate { get; set; }

        public int CategoryId { get; set; }
    }
}
