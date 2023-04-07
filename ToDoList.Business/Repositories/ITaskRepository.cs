using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Business.Models;

namespace ToDoList.Business.Providers
{
    public interface ITaskRepository
    {
        public TaskModel? AddTask(TaskModel task);
        public List<TaskModel> GetTasks();
        public TaskModel? GetTaskById(int Id);
    }
}
