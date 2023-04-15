using System.ComponentModel.DataAnnotations;

namespace ToDoList.Server.Models
{
    public class CategoryInputViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
