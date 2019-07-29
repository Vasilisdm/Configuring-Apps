using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Configuring_Apps.Infrastructure
{
    public class ContentMiddleware
    {
        private RequestDelegate _nextDelegate;

        public ContentMiddleware(RequestDelegate next)
        {
            _nextDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware", Encoding.UTF8);
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
