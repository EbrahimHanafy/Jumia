using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
