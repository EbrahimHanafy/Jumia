using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult GetDepartmentCategories(Department department)
        //{
        //    var Categories = context.Categories.Where(s=>s.DepartmentId == department.DepartmentId).ToList();
        //    ViewData["DepartmentCategories"] = Categories;
        //    return View("/Department/Index");
        //}
    }
}
