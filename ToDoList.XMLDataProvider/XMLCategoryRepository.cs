using System.Xml;
using System.Xml.Linq;
using ToDoList.RepositoryAbstractions.Entities;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoList.XMLDataProvider
{
    public class XmlCategoryRepository : ICategoryRepository
    {
        private readonly string xmlFilePath;
        private readonly XDocument xmlDocument;
        public XmlCategoryRepository()
        {
            xmlFilePath = @"..\ToDoList.XMLDataProvider\ToDoList.xml";
            xmlDocument = XDocument.Load(xmlFilePath);
        }

        public CategoryEntity? AddCategory(CategoryEntity category)
        {
            var categories = xmlDocument.Descendants("Category").OrderByDescending(c => int.Parse(c.Attribute("Id")!.Value));
            var newId = 1;
            foreach (var c in categories)
            {
                if (int.Parse(c.Attribute("Id")!.Value) >= newId)
                {
                    newId = int.Parse(c.Attribute("Id")!.Value) + 1;
                }
            }

            var newCategory = new XElement("Category",
            new XAttribute("Id", newId),
                new XAttribute("Name", category.Name!)
                );

            xmlDocument.Root!.Element("Categories")!.Add(newCategory);
            xmlDocument.Save(xmlFilePath);
            return GetCategoryById(newId);
        }

        public int DeleteCategory(int id)
        {
            xmlDocument.Descendants("Category").Where(c => c.Attribute("Id")!.Value.Equals(id.ToString())).Remove();
            xmlDocument.Save(xmlFilePath);
            return id;
        }

        public List<CategoryEntity> GetCategories()
        {
            var categories = xmlDocument.Descendants("Category")
              .Select(c => new CategoryEntity()
              {
                  Id = XmlConvert.ToInt32(c.Attribute("Id")!.Value),
                  Name = c.Attribute("Name")!.Value
              })
              .ToList();
            return categories;
        }

        public CategoryEntity? GetCategoryById(int id)
        {
            var category = xmlDocument.Descendants("Category")
              .Select(c => new CategoryEntity()
              {
                  Id = XmlConvert.ToInt32(c.Attribute("Id")!.Value),
                  Name = c.Attribute("Name")!.Value
              })
              .First();
            return category;
        }
    }
}
