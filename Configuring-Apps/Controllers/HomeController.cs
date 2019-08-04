using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Configuring_Apps.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Configuring_Apps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptime;
        private ILogger<HomeController> _logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            _uptime = up;
            _logger = log;
        }

        public ViewResult Index(bool throwException = false)
        {
            _logger.LogDebug($"Handled {Request.Path} at uptime: {_uptime.Uptime}");

            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            else
            {
                return View(new Dictionary<string, string>
                {
                    ["Message"] = "This is the Index action method.",
                    ["Uptime"] = $"{_uptime.Uptime} ms"
                });
            }
        }

        public ViewResult Error() => View(nameof(Index),
            new Dictionary<string, string>
            {
                ["Message"] = "This is an error action"
            });
    }
}
