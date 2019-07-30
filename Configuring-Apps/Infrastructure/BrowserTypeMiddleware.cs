using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Configuring_Apps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate _nextDelegate;

        public BrowserTypeMiddleware(RequestDelegate next)
        {
            _nextDelegate = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"]
                                               .Any(v => v.ToLower().Contains("edge"));

            await _nextDelegate.Invoke(httpContext);
        }
    }
}
