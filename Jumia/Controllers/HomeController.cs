using Jumia.Models;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jumia.Controllers
{
    public class HomeController(IUnitOfWork _unitOfWork, ILogger<HomeController> logger) : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            var departments = await _unitOfWork.Repository<Department>().GetAllAsync();

            //var departments = context.Departments.ToList();
            ViewData["departments"] = departments;
            //var brands = context.Brands.ToList();
            //ViewData["Brands"] = brands;
            return View();
        }
        /*
        public IActionResult GetBrands()
        {
            var Brands = context.Brands.ToList();
            ViewData["Brands"]=Brands;
            return View("Index");
        }
        */
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
