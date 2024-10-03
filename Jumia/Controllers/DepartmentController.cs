using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class DepartmentController : Controller
    {
        AppDBContext context = new AppDBContext();
        public IActionResult Index()
        {
            return View();
        }
        // Action for get all departments 
        public IActionResult GetAllDepartments()
        {
            ViewData["Title"] = "Men's Fashion";
            return View("Index");  // Ensure this returns the correct view (Views/Department/Men.cshtml)
        }
        public IActionResult GetDepartmentCategories(/*Department department*/)
        {
            var categories = context.Categories.Where(s => s.DepartmentId == 2)
                                               .Include(c => c.SubCategories)
                                               .ToList();
            ViewData["DepartmentCategories"] = categories;
            return View("Index");
        }

    }
}
