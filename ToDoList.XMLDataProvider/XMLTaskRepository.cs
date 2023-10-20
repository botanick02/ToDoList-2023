using Microsoft.VisualBasic;
using System;
using System.Xml;
using System.Xml.Linq;
using ToDoList.RepositoryAbstractions.Entities;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoList.XMLDataProvider
{
    public class XmlTaskRepository : ITaskRepository
    {
        private readonly string xmlFilePath;
        private readonly XDocument xmlDocument;
        public XmlTaskRepository()
        {
            xmlFilePath = @"..\ToDoList.XMLDataProvider\ToDoList.xml";
            xmlDocument = XDocument.Load(xmlFilePath);
        }

        public TaskEntity? AddTask(TaskEntity task)
        {
            var highestTaskId = int.Parse(xmlDocument.Descendants("Task").OrderByDescending(t => int.Parse(t.Attribute("Id")!.Value)).FirstOrDefault()!.Attribute("Id")!.Value);
            var newId = highestTaskId + 1;

            var newTask = new XElement("Task",
                new XAttribute("Id", newId),
                new XAttribute("Title", task.Title!),
                new XAttribute("CategoryId", task.CategoryId),
                new XAttribute("IsDone", "False"),
                new XAttribute("DueDate", task.DueDate.ToString() ?? "")
                );

            xmlDocument.Root!.Element("Tasks")!.Add(newTask);
            xmlDocument.Save(xmlFilePath);
            return GetTaskById(newId);
        }

        public int Delete(int id)
        {
            xmlDocument.Descendants("Task").Where(c => c.Attribute("Id")!.Value.Equals(id.ToString())).Remove();
            xmlDocument.Save(xmlFilePath);
            return id;
        }

        public TaskEntity? GetTaskById(int id)
        {
            var task = xmlDocument.Root!.Descendants("Task").Where(t => t.Attribute("Id")!.Value.Equals(id.ToString())).Select(t => new TaskEntity()
            {
                Id = XmlConvert.ToInt32(t.Attribute("Id")!.Value),
                Title = t.Attribute("Title")!.Value,
                CategoryId = XmlConvert.ToInt32(t.Attribute("CategoryId")!.Value),
                IsDone = bool.Parse(t.Attribute("IsDone")!.Value),
                DueDate = t.Attribute("DueDate")?.Value != "" ? DateTime.SpecifyKind(DateTime.Parse(t.Attribute("DueDate")!.Value), DateTimeKind.Utc) : null,
            }).First();

            return task;
        }

        public List<TaskEntity> GetTasks(int pageNumber, int pageSize)
        {
            var tasks = xmlDocument.Root!.Descendants("Task").Select(t => new TaskEntity()
            {
                Id = XmlConvert.ToInt32(t.Attribute("Id")!.Value),
                Title = t.Attribute("Title")!.Value,
                CategoryId = XmlConvert.ToInt32(t.Attribute("CategoryId")!.Value),
                IsDone = bool.Parse(t.Attribute("IsDone")!.Value),
                DueDate = t.Attribute("DueDate")!.Value != "" ? DateTime.SpecifyKind(DateTime.Parse(t.Attribute("DueDate")!.Value), DateTimeKind.Utc) : null,
            });

            tasks = tasks.OrderBy(task => task.DueDate == null ? DateTime.MaxValue : task.DueDate);
            var tasksOrdered = tasks.OrderBy(task => task.IsDone).ToList();


            var rangeStart = pageNumber * pageSize - pageSize;

            if (rangeStart > tasksOrdered.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Requested page with requested page size is out of tasks list range.");
            }

            pageSize = (rangeStart + pageSize) > tasksOrdered.Count ? (tasksOrdered.Count - rangeStart) : pageSize;

            var tasksPaged = tasksOrdered.GetRange(rangeStart, pageSize);

            return tasksPaged;
        }

        public int GetTasksCount()
        {
            return xmlDocument.Descendants("Task").Count();
        }

        public TaskEntity? Update(TaskEntity task)
        {
            var taskXml = xmlDocument.Descendants("Task").First(t => t.Attribute("Id")!.Value.Equals(task.Id.ToString()));
            taskXml.SetAttributeValue("Title", task.Title);
            taskXml.SetAttributeValue("CategoryId", task.CategoryId);
            taskXml.SetAttributeValue("DueDate", task.DueDate.ToString());
            taskXml.SetAttributeValue("IsDone", task.IsDone.ToString());
            xmlDocument.Descendants("Task").First(t => t.Attribute("Id")!.Value.Equals(task.Id.ToString())).ReplaceWith(taskXml);
            xmlDocument.Save(xmlFilePath);
            return GetTaskById(task.Id);
        }
    }
}
