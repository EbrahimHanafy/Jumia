using Jumia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class BrandController : Controller
    {
        AppDBContext context = new AppDBContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}