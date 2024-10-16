using Jumia.Models;
using Jumia.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class BrandController(IBrandServices brandService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand); // Return the form with validation errors
            }

            try
            {
                var newBrand = await brandService.AddBrand(brand);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(brand);
            }
        }
    }
}