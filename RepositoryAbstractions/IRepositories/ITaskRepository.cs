using ToDoList.RepositoryAbstractions.Entities;

namespace ToDoList.RepositoryAbstractions.IRepositories
{
    public interface ITaskRepository
    {
        public TaskEntity? AddTask(TaskEntity task);

        public List<TaskEntity> GetTasks(int pageNumber, int pageSize);

        public int GetTasksCount();

        public TaskEntity? GetTaskById(int id);

        public TaskEntity? Update(TaskEntity task);

        public int Delete(int id);

    }
}
