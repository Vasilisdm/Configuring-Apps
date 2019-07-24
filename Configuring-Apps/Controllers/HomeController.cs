using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Configuring_Apps.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View(new Dictionary<string, string> {
            ["Message"] = "This is the Index action method."
        })
    }
}
