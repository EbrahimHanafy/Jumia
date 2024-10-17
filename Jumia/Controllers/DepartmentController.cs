using Jumia.Models;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class DepartmentController(IUnitOfWork unitOfWork, IDepartmentService departmentService) : Controller
    {
        public async Task<IActionResult> GetCategoriesByDepartment(int departmentId, string departmentName)
        {
            var departmentCategories = await departmentService.GetCategoriesByDepartment(departmentId, departmentName);
            ViewData["DepartmentName"] = departmentName;
            return View("Index", departmentCategories);
        }
    }
}