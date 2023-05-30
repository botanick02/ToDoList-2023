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

        public List<CategoryEntity> GetCategories(int pageNumber, int pageSize)
        {
            var categories = xmlDocument.Descendants("Category")
              .Select(c => new CategoryEntity()
              {
                  Id = XmlConvert.ToInt32(c.Attribute("Id")!.Value),
                  Name = c.Attribute("Name")!.Value
              }).ToList();

            var rangeStart = pageNumber * pageSize - pageSize;

            if (rangeStart > categories.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Requested page with requested page size is out of categories list range.");
            }

            pageSize = (rangeStart + pageSize) > categories.Count ? (categories.Count - rangeStart) : pageSize;

            var categoriesPaged = categories.GetRange(rangeStart, pageSize);

            return categoriesPaged;
        }

        public int GetCategoriesCount()
        {
            return xmlDocument.Descendants("Category").Count();
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
