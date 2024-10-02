using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class CategoriesController : Controller
    {
        // Action for Men category
        public IActionResult Men()
        {
            ViewData["Title"] = "Men's Fashion";
            return View();  // Ensure this returns the correct view (Views/Categories/Men.cshtml)
        }

        // Action for Women category
        public IActionResult Women()
        {
            ViewData["Title"] = "Women's Fashion";
            return View();  // Ensure this returns the correct view (Views/Categories/Women.cshtml)
        }

        // Action for Kids category
        public IActionResult Kids()
        {
            ViewData["Title"] = "Kids' Fashion";
            return View();  // Ensure this returns the correct view (Views/Categories/Kids.cshtml)
        }
    }
}
