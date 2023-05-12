using ToDoList.DAL.SourceChanger.Enums;
using ToDoList.RepositoryAbstractions.IRepositories;

public delegate ICategoryRepository CategoryRepositoryResolver(StorageSources key);