using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult CompletePayment()
        {
            return View();
        }
    }
}
