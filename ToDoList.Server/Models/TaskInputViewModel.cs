using System.ComponentModel.DataAnnotations;
using ToDoList.Server.Models.Attributes;

namespace ToDoList.Server.Models
{
    public class TaskInputViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Future(ErrorMessage = "Due date cannot be in the past.")]
        public DateTime? DueDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
    }
}
