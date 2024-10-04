using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class DepartmentController : BaseController
    {
        // Action for get all departments
        public IActionResult GetAllDepartments()
        {
            var departments = context.Departments.ToList();
            ViewData["departments"] = departments;
            // Load the departments for the view
            
            return View("Index");  // Ensure this returns the correct view (e.g., Views/Department/Index.cshtml)
        }

        // Action for getting department categories
        public IActionResult GetDepartmentCategories(int departmentId ,string departmentName)
        {

            var categories = context.Categories
                                    .Where(s => s.DepartmentId == departmentId)
                                    .Include(c => c.SubCategories)
                                    .ToList();
            ViewData["DepartmentCategories"] = categories;
            ViewData["DepartmentName"] = departmentName;

            return View("Index"); // Ensure this returns the correct view (e.g., Views/Department/Index.cshtml)
        }

    }
}
