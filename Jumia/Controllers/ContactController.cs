using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View("Contact");
        }
    }
}
