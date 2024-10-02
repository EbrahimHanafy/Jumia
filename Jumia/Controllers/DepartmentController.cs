using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class DepartmentController : Controller
    {
        // Action for get all departments 
        public IActionResult GetAllDepartments()
        {
            ViewData["Title"] = "Men's Fashion";
            return View("Index");  // Ensure this returns the correct view (Views/Department/Men.cshtml)
        }

    }
}
