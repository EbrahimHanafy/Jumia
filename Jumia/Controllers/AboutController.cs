using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View("About");
        }
    }
}
