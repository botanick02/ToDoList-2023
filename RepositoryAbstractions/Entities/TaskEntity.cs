namespace ToDoList.RepositoryAbstractions.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int CategoryId { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
