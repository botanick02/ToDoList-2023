using AutoMapper;
using ToDoList.DAL.DTO_s;
using ToDoList.DAL.DTO_s.Category;
using ToDoList.RepositoryAbstractions.Entities;

namespace ToDoList.BLL.Utilities.AutoMapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<TaskEntity, NewTaskDTO>().ReverseMap();
                CreateMap<TaskDTO, TaskEntity>().ReverseMap();
                CreateMap<CategoryEntity, NewCategoryDTO>().ReverseMap();
                CreateMap<CategoryDTO, CategoryEntity>().ReverseMap();
            }
        }
    }
}
