using Jumia.Models;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class DepartmentController(IUnitOfWork unitOfWork, IDepartmentService departmentService) : Controller
    {

        //// Action for get all departments
        //public IActionResult GetAllDepartments()
        //{
        //    var departments = context.Departments.ToList();
        //    ViewData["departments"] = departments;
        //    // Load the departments for the view

        //    return View("Index");  // Ensure this returns the correct view (e.g., Views/Department/Index.cshtml)
        //}

        // Action for getting department categories
        public async Task<IActionResult> GetCategoriesByDepartment(int departmentId, string departmentName)
        {
            var departmentCategories = await departmentService.GetCategoriesByDepartment(departmentId, departmentName);

            //var departmentCategories = await GetDepartmentCategories(departmentId, departmentName);
            //ViewData["DepartmentCategories"] = departmentCategories;
            ViewData["DepartmentName"] = departmentName;
            return View("Index", departmentCategories);
        }
        //public IActionResult GetDepartmentCategories(int departmentId, string departmentName)
        //{

        //    var categories = context.Categories
        //                            .Where(s => s.DepartmentId == departmentId)
        //                            .Include(c => c.SubCategories)
        //                            .ToList();
        //    ViewData["DepartmentCategories"] = categories;
        //    ViewData["DepartmentName"] = departmentName;

        //    return View("Index"); // Ensure this returns the correct view (e.g., Views/Department/Index.cshtml)
        //}

    }
}
