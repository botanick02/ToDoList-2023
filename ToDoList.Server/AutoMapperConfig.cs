using AutoMapper;
using ToDoList.Business.DTO_s;
using ToDoList.Business.DTO_s.Category;
using ToDoList.Business.Entities;
using ToDoList.Server.Models;

namespace ToDoList
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskEntity, NewTaskDTO>().ReverseMap();
                cfg.CreateMap<TaskDTO, TaskEntity>().ReverseMap();
                cfg.CreateMap<NewTaskDTO, TaskInputViewModel>().ReverseMap();
                cfg.CreateMap<CategoryEntity, NewCategoryDTO>().ReverseMap();
                cfg.CreateMap<CategoryDTO, CategoryEntity>().ReverseMap();
                cfg.CreateMap<NewCategoryDTO, CategoryInputViewModel>().ReverseMap();
            });

            mapperConfiguration.CreateMapper();
            return mapperConfiguration;
        }
    }
}
