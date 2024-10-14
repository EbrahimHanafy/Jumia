using Jumia.Models;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Jumia.Controllers
{
    public class ProductController(IProductService productService, IMaterialsCareService materialsCareService, ISizeService sizeService ) : Controller
    {
        public async Task<IActionResult> ProductProfile(int productId)
        {
            var product = await productService.GetProductById(productId);

            var productMaterialsCare = await materialsCareService.GetMaterialByProduct(productId);

            ViewData["ProductMaterialsCare"] = productMaterialsCare;

            /*var sizes = await sizeService.GetSizesByProduct(productId);
            ViewData["Sizes"] = sizes;*/

            return View("ProductProfile", product);
        }
    }
}
