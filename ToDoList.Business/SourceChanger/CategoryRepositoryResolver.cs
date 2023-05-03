using ToDoList.Business.Repositories;
using ToDoList.Business.SourceChanger.Enums;

public delegate ICategoryRepository CategoryRepositoryResolver(StorageSources key);