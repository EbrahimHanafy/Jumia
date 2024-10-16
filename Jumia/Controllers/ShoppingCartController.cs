using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class ShoppingCartController() : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart()
        {
            return View();
        }
    }
}
