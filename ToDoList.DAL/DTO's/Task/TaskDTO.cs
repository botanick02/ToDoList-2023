namespace ToDoList.DAL.DTO_s.Tasks
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime? DueDate { get; set; }

        public int CategoryId { get; set; }

        public bool IsDone { get; set; }
    }
}
