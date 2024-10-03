using Jumia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class DepartmentController : Controller
    {
        AppDBContext context = new AppDBContext();
        public DepartmentController(AppDBContext _context) 
        {
            context = _context;
        }
        // Action for get all departments 
        public IActionResult GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            departments = context.Departments.ToList();
            ViewBag.Departments = departments;

            //ViewData["Title"] = "Men's Fashion";
            return View(departments);  // Ensure this returns the correct view (Views/Department/Men.cshtml)
        }

    }
}
