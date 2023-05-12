namespace ToDoList.DAL.DTO_s
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public int CategoryId { get; set; }

        public bool IsDone { get; set; }
    }
}
