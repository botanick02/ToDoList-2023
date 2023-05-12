using System.Xml;
using System.Xml.Linq;
using ToDoList.RepositoryAbstractions.Entities;
using ToDoList.RepositoryAbstractions.IRepositories;

namespace ToDoList.XMLDataProvider
{
    public class XMLCategoryRepository : ICategoryRepository
    {
        private readonly string xmlFilePath;
        private readonly XDocument xmlDocument;
        public XMLCategoryRepository()
        {
            xmlFilePath = @"..\ToDoList.XMLDataProvider\ToDoList.xml";
            xmlDocument = XDocument.Load(xmlFilePath);
        }

        public CategoryEntity? AddCategory(CategoryEntity category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryEntity> GetCategories()
        {
            var categories = xmlDocument.Descendants("Category")
              .Select(c => new CategoryEntity()
              {
                  Id = XmlConvert.ToInt32(c.Attribute("Id").Value),
                  Name = c.Attribute("Name").Value
              })
              .ToList();
            return categories;
        }

        public CategoryEntity? GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
