using Jumia.Models;
using Jumia.Services.Implementations;
using Jumia.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class BrandController(IBrandService brandService, IProductService productService) : Controller
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
        public async Task<IActionResult> GetBrandProducts(int brandId, string brandName) 
        {
            var brandProducts = await productService.GetProductsByBrand(brandId);
            ViewData["BrandName"] = brandName;
            return View("BrandDetails", brandProducts);
        }
    }
}