using Microsoft.AspNetCore.Mvc;
using Stactive.Core.Models;

namespace Stactive.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Stactive.AddEvent(HttpContext, new StactiveEvent("Home Index view"));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
