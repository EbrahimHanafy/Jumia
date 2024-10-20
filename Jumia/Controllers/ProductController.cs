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
using System.Collections.Generic;

namespace Jumia.Controllers
{
    public class ProductController(IProductService productService, IShoppingCartServices shoppingCartServices, IMaterialsCareService materialsCareService, IProductColorSizeService productColorSizeService,/*ISizeService sizeService, IColorService colorService,*/ IProductRateUserService productRateUserService, IProductRateService productRateService, UserManager<User> userManager, ILogger<ProductController> logger) : Controller
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

                if (user == null)
                {

                    return Redirect("/Account/Login");

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
                NewRate = new ProductRate { ProductId = productId },
                ShoppingCart = new ShoppingCart { ProductId = productId },
                TotalNumberOfReviwws = await productRateService.GetNumberOfProductRates(productId),
            };
        }

        public async Task<IActionResult> AddProductToCart(ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
            {
                logger.LogWarning("Invalid model state when adding rate");
                var productProfileVM = await LoadProductProfileViewModel(shoppingCart.ProductId);
                productProfileVM.ShoppingCart = shoppingCart;
                return View("ProductProfile", productProfileVM);
            }

            try
            {
                // Retrieve the user's Identity Id (stored as a string)
                var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Find the user in the database by their Identity Id
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == identityUserId);
                if (user == null)
                {

                    return Redirect("/Account/Login");
                }

                logger.LogInformation($"User identified with UserCode: {user.UserCode}");
                shoppingCart.UserCode = user.UserCode;
                shoppingCart.CreatedAt = DateTime.UtcNow;
                bool IsExisted = await shoppingCartServices.IsShoppingCartExisted(shoppingCart.ProductId, shoppingCart.ProductColorSizeId, user.UserCode);

                if (IsExisted == false)
                {
                    logger.LogInformation($"Saving product cart: ProductId={shoppingCart.ProductId}, Quantity={shoppingCart.Quantity}, ColorSize={shoppingCart.ProductColorSizeId}");
                    var addProduct = await shoppingCartServices.AddToCart(shoppingCart);

                    logger.LogInformation($"Cart added successfully for product ID: {addProduct.ProductId}");
                    return RedirectToAction("ProductProfile", new { productId = addProduct.ProductId });
                }
                else
                {

                    logger.LogInformation($"Cart added filed");
                    return RedirectToAction("ProductProfile", new { productId = shoppingCart.ProductId });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while adding cart");
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                var productProfileVM = await LoadProductProfileViewModel(shoppingCart.ProductId);
                productProfileVM.ShoppingCart = shoppingCart;
                return View("ProductProfile", productProfileVM);
            }
        }
        
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetAllProducts();
            return View("~/Views/Admin/Products.cshtml", products);
        }
    }
}