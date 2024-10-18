using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class ReturnsController : Controller
    {
        public IActionResult Index()
        {
            return View("Returns");
        }
    }
}
