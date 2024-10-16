using Jumia.Models;
using Jumia.Services.Implementations;
using Jumia.Services.IServices;
using Jumia.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Jumia.ViewModels;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class ProductController(IProductService productService, IMaterialsCareService materialsCareService, IProductColorSizeService productColorSizeService ,/*ISizeService sizeService, IColorService colorService,*/ IProductRateUserService productRateUserService, IProductRateService productRateService, UserManager<User> userManager, ILogger<ProductController> logger) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ProductProfile(int productId)
        {
            var productProfileVM = await LoadProductProfileViewModel(productId);
            return View(productProfileVM);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRate(ProductRate productRate)
        {
            if (!ModelState.IsValid)
            {
                logger.LogWarning("Invalid model state when adding rate");
                var productProfileVM = await LoadProductProfileViewModel(productRate.ProductId);
                productProfileVM.NewRate = productRate;
                return View("ProductProfile", productProfileVM);
            }
            try
            {
                // Retrieve the user's Identity Id (stored as a string)
                var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Find the user in the database by their Identity Id
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == identityUserId);

                // var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    logger.LogWarning("Unable to identify user when adding rate");
                    ModelState.AddModelError("", "Unable to identify user. Please try logging in again.");
                    var productProfileVM = await LoadProductProfileViewModel(productRate.ProductId);
                    productProfileVM.NewRate = productRate;
                    return View("ProductProfile", productProfileVM);
                }

                logger.LogInformation($"User identified with UserCode: {user.UserCode}");
                productRate.CreatedBy = user.UserCode;
                productRate.CreatedAt = DateTime.UtcNow;

                logger.LogInformation($"Saving product rate: ProductId={productRate.ProductId}, Rate={productRate.Rate}");
                var addedRate = await productRateService.AddProductRateService(productRate);
                logger.LogInformation($"Rate added successfully for product ID: {addedRate.ProductId}");

                return RedirectToAction("ProductProfile", new { productId = addedRate.ProductId });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while adding rate");
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                var productProfileVM = await LoadProductProfileViewModel(productRate.ProductId);
                productProfileVM.NewRate = productRate;
                return View("ProductProfile", productProfileVM);
            }
        }

        private async Task<ProductProfileViewModel> LoadProductProfileViewModel(int productId)
        {
            return new ProductProfileViewModel
            {
                Product = await productService.GetProductById(productId),
                AvailableQuantity = await productService.GetAvailableQunitityOfProductById(productId),
                ProductMaterialsCare = await materialsCareService.GetMaterialByProduct(productId),
				//Sizes = await sizeService.GetSizesByProduct(productId),
				//Colors = await colorService.GetColorByProductAndSize(productId),
				ColorSizes = await productColorSizeService.GetProductColorSize(productId),
				ProductRates = await productRateUserService.GetProductRatesByProductId(productId),
                ProductId = productId,
                ProductRateAverage = await productRateService.GetProductRatingAverage(productId),
                TotalNumberOfReviwws = await productRateService.GetNumberOfProductRates(productId),
                NewRate = new ProductRate { ProductId = productId }
            };
        }
        
        //[HttpGet]
        //public async Task<IActionResult> GetColorsBySize(int productId, int sizeId)
        //{
        //    var colors = await colorService.GetColorsBySize(productId, sizeId);

        //    if (colors == null || !colors.Any())
        //    {
        //        return Json(new { success = false, message = "No colors found for this size." });
        //    }

        //    // Return colors as JSON
        //    return Json(new { success = true, data = colors });
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetSizesByColor(int productId, int colorId)
        //{
        //    var sizes = await sizeService.GetSizesByColor(productId, colorId);

        //    if (sizes == null || !sizes.Any())
        //    {
        //        return Json(new { success = false, message = "No sizes found for this color." });
        //    }

        //    // Return sizes as JSON
        //    return Json(new { success = true, data = sizes });
        //}
    }
}