using System.Diagnostics;
using ToDoList.Business.SourceChanger.Enums;

namespace ToDoList.Buisness.SourceChanger
{
    public static class SourceStorage
    {
        public static StorageSources CurrentSource = StorageSources.MsSQL;

        public static bool SetCurrentSource(string source)
        {
            return Enum.TryParse(source, out CurrentSource);
        }
    }
}
