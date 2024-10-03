using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class SubCategoryController : Controller
    {
        AppDBContext context = new AppDBContext();
        // Action for displaying all items under a subcategory
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetSubCategoryProducts(int subCategoryId = 1)
        {
            var Products = context.Products.Where(s => s.SubCategoryId == subCategoryId)
                                                 .Include(c => c.ProductImages.Where(x=>x.IsMainImage == true))
                                                 .ToList();
            ViewData["SubCategoryProducts"] = Products;
            return View("Index");
        }
    }
}
