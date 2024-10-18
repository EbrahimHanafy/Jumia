using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class CarrersController : Controller
    {
        public IActionResult Index()
        {
            return View("Carrers");
        }
    }
}
