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

        // Departments & Products Page
        public IActionResult DepartmentProducts()
        {
            ViewData["Title"] = "Departments & Products";
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

        // Departments Page
        public IActionResult Departments()
        {
            ViewData["Title"] = "Departments";
            return View();
        }

        // Categories Page
        public IActionResult Categories()
        {
            ViewData["Title"] = "Categories";
            return View();
        }

        // Sub Categories Page
        public IActionResult SubCategories()
        {
            ViewData["Title"] = "Sub Categories";
            return View();
        }

        // Brands Page
        public IActionResult Brands()
        {
            ViewData["Title"] = "Brands";
            return View();
        }

        // Add New Department Page
        public IActionResult AddNewDepartment()
        {
            ViewData["Title"] = "Add New Department";
            return View();
        }

        // Department Details Page
        public IActionResult DepartmentDetails(int id)
        {
            ViewData["Title"] = "Department Details";
            // you'll fetch the department details from the database using the id.
            return View();
        }

        // Add New Brand Page
        public IActionResult AddNewBrand()
        {
            ViewData["Title"] = "Add New Brand";
            return View();
        }

        // Brand Details Page
        public IActionResult BrandDetails(int id)
        {
            ViewData["Title"] = "Brand Details";
            return View();
        }

    }
}
