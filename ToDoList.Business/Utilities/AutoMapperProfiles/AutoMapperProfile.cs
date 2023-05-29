using AutoMapper;
using ToDoList.DAL.DTO_s.Category;
using ToDoList.DAL.DTO_s.Tasks;
using ToDoList.RepositoryAbstractions.Entities;

namespace ToDoList.BLL.Utilities.AutoMapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<TaskEntity, NewTaskDto>().ReverseMap();
                CreateMap<TaskDto, TaskEntity>().ReverseMap();
                CreateMap<CategoryEntity, NewCategoryDto>().ReverseMap();
                CreateMap<CategoryDto, CategoryEntity>().ReverseMap();
            }
        }
    }
}
