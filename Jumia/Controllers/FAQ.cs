using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class FAQ : Controller
    {
        public IActionResult Index()
        {
            return View("FAQ");
        }
    }
}

