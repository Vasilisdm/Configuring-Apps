using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Configuring_Apps.Infrastructure;

namespace Configuring_Apps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptime;

        public HomeController(UptimeService up)
        {
            _uptime = up;
        }

        public ViewResult Index(bool throwException = false)
        {
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
    }
}
