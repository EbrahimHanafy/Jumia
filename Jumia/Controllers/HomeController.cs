using Jumia.Models;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jumia.Controllers
{
    public class HomeController(IUnitOfWork _unitOfWork, ILogger<HomeController> logger, IProductService productService) : Controller
    {
        public async Task<IActionResult> Index()
        {
           
            var departments = await _unitOfWork.Repository<Department>().GetAllAsync();
            ViewData["departments"] = departments;

            var brands = await _unitOfWork.Repository<Brand>().GetAllAsync();
            ViewData["Brands"] = brands;

            var top10NewArrivalProducts = await productService.GetTop10NewArrivalProducts();
            ViewData["Top10NewArrivalProducts"] = top10NewArrivalProducts;

            return View();
        }
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
