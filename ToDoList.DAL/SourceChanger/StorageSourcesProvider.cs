using ToDoList.DAL.SourceChanger.Enums;

namespace ToDoList.DAL.SourceChanger
{
    public class StorageSourcesProvider
    {
        public List<string> GetStorageSourcesNames()
        {
            var sources = new List<String>();
            foreach (StorageSources source in (StorageSources[])Enum.GetValues(typeof(StorageSources)))
            {
                sources.Add(source.ToString());
            }
            return sources.ToList();
        }
    }
}
