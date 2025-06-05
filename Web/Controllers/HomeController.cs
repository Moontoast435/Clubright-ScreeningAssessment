using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["currentCount"] = HttpContext.Session.GetInt32("updatedCount") ?? 1;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Clicks()
        {
            ViewData["currentCount"] = HttpContext.Session.GetInt32("updatedCount") ?? 1;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Increment(int currentCount)
        {  
            int updatedCount = currentCount + 1;

            // Store data in the session
            HttpContext.Session.SetInt32("updatedCount", updatedCount);

            return Json(new { success = true, updatedCount });
        }

    }
}
