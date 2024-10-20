using Jumia.Models;
using Jumia.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class SubCategoryController( IProductService productService) : Controller
    {
        // Action for displaying all items under a subcategory
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetProductsBySubCategory(int subCategoryId, string subCategoryName) 
        {
            var subCategoryPrducts = await productService.GetProductsBySubCategory(subCategoryId);
            ViewData["SubCategoryName"] = subCategoryName;
            return View("Index", subCategoryPrducts);
        }
    }
}
