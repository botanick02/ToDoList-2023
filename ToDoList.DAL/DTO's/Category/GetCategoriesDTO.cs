namespace ToDoList.DAL.DTO_s.Category
{
    public class GetCategoriesDto
    {
        public IEnumerable<CategoryDto>? Categories { get; set; }

        public int TotalCount { get; set; }
    }
}
