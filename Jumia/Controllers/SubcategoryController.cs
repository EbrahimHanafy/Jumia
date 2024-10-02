using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class SubcategoryController : Controller
    {
        // Action for displaying all items under a subcategory
        public IActionResult Index(string subcategory)
        {
            ViewData["Title"] = char.ToUpper(subcategory[0]) + subcategory.Substring(1);
            // Later, you'll fetch the subcategory items from the database
            // For now, you can pass dummy data to the view.

            return View(subcategory); // Make sure the view matches the subcategory name
        }
    }
}
