using AutoMapper;
using ToDoList.DAL.DTO_s;
using ToDoList.DAL.DTO_s.Category;
using ToDoList.Server.Models.Inputs;

namespace ToDoList.Server
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<NewTaskDTO, TaskInputViewModel>().ReverseMap();
                CreateMap<NewCategoryDTO, CategoryInputViewModel>().ReverseMap();
            }
        }
    }
}
