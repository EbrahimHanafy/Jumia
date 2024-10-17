using Jumia.Models;
using Jumia.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Jumia.Controllers
{
    public class ShoppingCartController(IShoppingCartServices shoppingCartServices, UserManager<User> userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart()
        {
            return View();
        }

        public async Task<IActionResult> GetCartProducts( )
        {
            // Retrieve the user's Identity Id (stored as a string)
            var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find the user in the database by their Identity Id
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == identityUserId);

            if (user == null)
            {
                return Redirect("/Account/Login");
            }
            int userCode = user.UserCode;
            var CartProducts = await shoppingCartServices.GetShoppingCartProducts(userCode);
            return View("Index", CartProducts);
        }

        public async Task<IActionResult> RemoveProductFromCart(int shoppingCartId)
        {
            try
            {
                await shoppingCartServices.RemoveProductFromCart(shoppingCartId);
                return RedirectToAction("GetCartProducts");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return RedirectToAction("GetCartProducts");
            }
            
        }
    }
}
