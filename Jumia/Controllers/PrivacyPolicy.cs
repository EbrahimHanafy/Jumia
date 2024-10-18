using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class PrivacyPolicy : Controller
    {
        public IActionResult Index()
        {
            return View("PP");
        }
    }
}
