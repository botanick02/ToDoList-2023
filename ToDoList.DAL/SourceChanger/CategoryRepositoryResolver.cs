using ToDoList.DAL.SourceChanger.Enums;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoList.DAL.SourceChanger
{
    public delegate ICategoryRepository CategoryRepositoryResolver(StorageSources key);
}