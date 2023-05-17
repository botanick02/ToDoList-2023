using GraphQL;
using ToDoList.DAL.SourceChanger.Enums;

namespace ToDoList.Server.HttpContextHelpers
{
    public class HeaderSourceProviderParser
    {
        public StorageSources ParseContextHeaderSource(IResolveFieldContext context)
        {
            var httpContext = context.RequestServices.GetService<IHttpContextAccessor>().HttpContext;
            var sourceString = httpContext.Request.Headers["Source"];
            StorageSources source;

            if(Enum.TryParse(sourceString, out source))
            {
                return source;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"'{sourceString}' is not a valid value of {nameof(StorageSources)}, whic was sent in request header.", nameof(sourceString));
            }
        }
    }
}
