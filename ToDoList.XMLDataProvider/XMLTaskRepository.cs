using Microsoft.VisualBasic;
using System.Xml;
using System.Xml.Linq;
using ToDoList.RepositoryAbstractions.Entities;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoList.XMLDataProvider
{
    public class XMLTaskRepository : ITaskRepository
    {
        private readonly string xmlFilePath;
        private readonly XDocument xmlDocument;
        public XMLTaskRepository()
        {
            xmlFilePath = @"..\ToDoList.XMLDataProvider\ToDoList.xml";
            xmlDocument = XDocument.Load(xmlFilePath);
        }

        public TaskEntity? AddTask(TaskEntity task)
        {
            var tasks = xmlDocument.Descendants("Task").OrderByDescending(t => int.Parse(t.Attribute("Id")!.Value));
            var newId = 0;
            foreach (var t in tasks)
            {
                if (int.Parse(t.Attribute("Id")!.Value) >= newId)
                {
                    newId = int.Parse(t.Attribute("Id")!.Value) + 1;
                }
            }

            var newTask = new XElement("Task",
                new XAttribute("Id", newId),
                new XAttribute("Title", task.Title),
                new XAttribute("CategoryId", task.CategoryId),
                new XAttribute("IsDone", "False"),
                new XAttribute("DueDate", task.DueDate.ToString() ?? "")
                );

            xmlDocument.Root!.Element("Tasks")!.Add(newTask);
            xmlDocument.Save(xmlFilePath);
            return GetTaskById(newId);
        }

        public void Delete(int id)
        {
            xmlDocument.Descendants("Task").Where(c => c.Attribute("Id")!.Value.Equals(id.ToString())).Remove();
            xmlDocument.Save(xmlFilePath);
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

        public List<TaskEntity> GetTasks()
        {
            var tasks = xmlDocument.Root!.Descendants("Task").Select(t => new TaskEntity()
            {
                Id = XmlConvert.ToInt32(t.Attribute("Id")!.Value),
                Title = t.Attribute("Title")!.Value,
                CategoryId = XmlConvert.ToInt32(t.Attribute("CategoryId")!.Value),
                IsDone = bool.Parse(t.Attribute("IsDone")!.Value),
                DueDate = t.Attribute("DueDate")!.Value != "" ? DateTime.SpecifyKind(DateTime.Parse(t.Attribute("DueDate")!.Value), DateTimeKind.Utc) : null,
            }).ToList();

            return tasks;
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
