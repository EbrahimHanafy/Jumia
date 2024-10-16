using Jumia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class AdminController : Controller
    {
        // Admin Dashboard
        public IActionResult Index()
        {
            return View();
        }

        // Users Page
        public IActionResult Users()
        {
            ViewData["Title"] = "Users";
            return View();
        }

        // Roles Page
        public IActionResult Roles()
        {
            ViewData["Title"] = "Roles";
            return View();
        }

        // Clients Page
        public IActionResult Clients()
        {
            ViewData["Title"] = "Clients";
            return View();
        }

        // Products Page
        public IActionResult Products()
        {
            ViewData["Title"] = "Products";
            return View();
        }
        public IActionResult ProductDetailes()
        {
            ViewData["Title"] = "Product Detailes";
            return View();
        }
        // Add New Product Page
        public IActionResult NewProduct()
        {
            return View("NewProduct");
        }

        // Stores Page
        public IActionResult Stores()
        {
            ViewData["Title"] = "Stores";
            return View();
        }

        // More Settings Page
        public IActionResult MoreSettings()
        {
            ViewData["Title"] = "More Settings";
            return View();
        }

        // Discount Coupons Page
        public IActionResult DiscountCoupons()
        {
            ViewData["Title"] = "Discount Coupons";
            return View();
        }
    }
}
