namespace ToDoList.Server.Models
{
    public class TaskInputViewModel
    {
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
        public int CategoryId { get; set; }
    }
}
