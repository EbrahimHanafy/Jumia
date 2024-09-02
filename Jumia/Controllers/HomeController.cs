using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jumia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //welcome 
        public IActionResult Index()
        {
            return View();
        }
        
        // Ebrahim
        // turky wa7ed bs
        //IbrahimSaad10
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
