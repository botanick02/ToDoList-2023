using GraphQL.Types;
using ToDoList.DAL.SourceChanger;

namespace ToDoList.Server.GraphQL.StorageSources
{
    public class StorageSourcesQueries : ObjectGraphType
    {
        public StorageSourcesQueries(StorageSourcesProvider storageSourcesProvider) 
        {
            Field<ListGraphType<StringGraphType>>("GetStorageSources")
                .Resolve(context =>
                {
                    return storageSourcesProvider.GetStorageSourcesNames();
                });
        }
    }
}
