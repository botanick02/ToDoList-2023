using ToDoList.Business.Providers;
using ToDoList.Business.SourceChanger.Enums;

public delegate ITaskRepository TaskRepositoryResolver(StorageSources key);