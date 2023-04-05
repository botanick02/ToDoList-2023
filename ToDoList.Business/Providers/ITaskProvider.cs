using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Business.Models;

namespace ToDoList.Business.Providers
{
    public interface ITaskProvider
    {
        public List<TaskEntity> AddTask(TaskEntity task);
        public List<TaskEntity> GetTasks();
        public List<TaskEntity> GetTaskById();
    }
}
