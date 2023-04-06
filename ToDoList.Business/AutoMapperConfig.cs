using AutoMapper;
using ToDoList.Business.DTO_s;
using ToDoList.Business.Models;

namespace ToDoList
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskModel, NewTaskDTO>().ReverseMap();
                cfg.CreateMap<TaskDTO, TaskModel>().ReverseMap();

            });

            mapperConfiguration.CreateMapper();
            return mapperConfiguration;
        }
    }
}
