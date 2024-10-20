using Jumia.Models;
using Jumia.Repositories.Implementation;
using Jumia.Services.IServices;
using Jumia.SharedRepositories;
using Jumia.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AccountController  : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    IUserAddressService _useraddressService;
    IUserORderService _userorderService;
    IUserWishListService _userwishListService;
    IProductService _productService;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager , IUserAddressService useraddressService, IUserORderService userorderService, IUserWishListService userwishListService, IProductService productService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _useraddressService = useraddressService;
        _userorderService = userorderService;
        _userwishListService = userwishListService;
        _userwishListService = userwishListService;
        _productService = productService;
    }

    // GET: /Account/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Redirect to home page on success
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found.");
            }
        }

        return View(model);
    }

    // POST: /Account/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // GET: /Account/Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // POST: /Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel newAcount)
    {
        if (ModelState.IsValid == true)
        {
            User user = new User();
            user.Email = newAcount.Email;
            user.FirstName = newAcount.FirstName;
            user.LastName = newAcount.LastName;
            user.UserName = newAcount.UserName;
            user.PasswordHash = newAcount.Password;
            user.PhoneNumber = newAcount.Phone1;
            user.Gender = newAcount.Gender;
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = 1;
            user.DateOfBirth = DateTime.Now;
            try
            {
                IdentityResult result = await _userManager.CreateAsync(user, newAcount.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    //await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.InnerException.Message);
            }

        }
        return View(newAcount);
    }

    // GET: /Account/Profile
    [HttpGet]
    public async Task<IActionResult> Profile()
    {

        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);      
            return View(user);
        }
        else
            return RedirectToAction("Login", "Account");
    }

    // GET: /Account/Addresses
    [HttpGet]
    public async Task<IActionResult> Addresses()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var address = await _useraddressService.getall(user.UserCode);

            return View(address);
        }
        else
            return RedirectToAction("Login", "Account");
  
    }

    // GET: /Account/Orders
    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var orders = await _userorderService.getByUSerCode(user.UserCode);

            return View(orders);
        }
        else
            return RedirectToAction("Login", "Account");
    }

    // GET: /Account/Wishlist
    [HttpGet]
    public async Task<IActionResult> Wishlist()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var wishLists = await _userwishListService.getByUSerCode(user.UserCode);

            var wishListProducts = await _productService.GetWishListPeoducts(user.UserCode);

            return View(wishListProducts);
        }
        else
            return RedirectToAction("Login", "Account");
    }
}