using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class JournalsController : Controller
    {
        public IActionResult Index()
        {
            return View("Journals");
        }
    }
}
