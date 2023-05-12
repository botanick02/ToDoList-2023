using ToDoList.RepositoryAbstractions.Entities;

namespace ToDoList.RepositoryAbstractions.IRepositories
{
    public interface ITaskRepository
    {
        public TaskEntity? AddTask(TaskEntity task);

        public List<TaskEntity> GetTasks();

        public TaskEntity? GetTaskById(int id);

        public TaskEntity? Update(TaskEntity task);

        public void Delete(int id);

    }
}
