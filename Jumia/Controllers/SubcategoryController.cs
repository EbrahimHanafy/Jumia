using Jumia.Models;
using Jumia.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class SubCategoryController(AppDBContext context , IProductService productService) : Controller
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
        //public IActionResult GetSubCategoryProducts(int subCategoryId, string subCategoryName)
        //{
        //    var Products = context.Products.Where(s => s.SubCategoryId == subCategoryId)
        //                                         .Include(c => c.ProductImages.Where(x=>x.IsMainImage == true))
        //                                         .ToList();
        //    ViewData["SubCategoryProducts"] = Products;
        //    ViewData["SubCategoryName"] = subCategoryName;
        //    return View("Index");
        //}
    }
}
