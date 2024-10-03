using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class DepartmentController : Controller
    {
        // Action for get all departments 
        public IActionResult GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            departments = context.Departments.ToList();
            ViewBag.Departments = departments;

            //ViewData["Title"] = "Men's Fashion";
            return View(departments);  // Ensure this returns the correct view (Views/Department/Men.cshtml)
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
