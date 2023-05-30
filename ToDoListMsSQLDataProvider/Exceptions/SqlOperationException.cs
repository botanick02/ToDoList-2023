namespace ToDoListMsSQLDataProvider.Exceptions
{

    public class SqlQueryException : Exception
    {
        public SqlQueryException(string message) : base(message)
        {
        }

        public SqlQueryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
