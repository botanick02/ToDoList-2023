using ToDoList.DAL.SourceChanger.Enums;
using ToDoList.RepositoryAbstractions.IRepositories;

public delegate ITaskRepository TaskRepositoryResolver(StorageSources key);