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


    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager , IUserAddressService useraddressService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _useraddressService= useraddressService;
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
                    // await _userManager.AddToRoleAsync(user, "User");
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
    public IActionResult Profile()
    {
        return View();
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
    public IActionResult Orders()
    {
      
        return View();
    }

    // GET: /Account/Wishlist
    [HttpGet]
    public IActionResult Wishlist()
    {
        return View();
    }
}