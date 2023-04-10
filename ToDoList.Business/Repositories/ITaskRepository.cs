using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Business.Entities;

namespace ToDoList.Business.Providers
{
    public interface ITaskRepository
    {
        public TaskEntity? AddTask(TaskEntity task);
        public List<TaskEntity> GetTasks();
        public TaskEntity? GetTaskById(int Id);
        public TaskEntity? Update(TaskEntity task);
    }
}
