using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class CategoryController(AppDBContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
