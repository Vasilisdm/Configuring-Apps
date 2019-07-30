using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Configuring_Apps.Infrastructure
{
    public class ShortCircuitMiddleware
    {
        private RequestDelegate _nextDelegate;

        public ShortCircuitMiddleware(RequestDelegate next)
        {
            _nextDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
