namespace ToDoList.DAL.DTO_s
{
    public class NewTaskDTO
    {
        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public int CategoryId { get; set; }
    }
}
