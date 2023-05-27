using ToDoList.DAL.SourceChanger.Enums;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoList.DAL.SourceChanger
{
    public delegate ITaskRepository TaskRepositoryResolver(StorageSources key);
}