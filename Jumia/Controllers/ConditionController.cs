using Microsoft.AspNetCore.Mvc;

namespace Jumia.Controllers
{
    public class ConditionController : Controller
    {
        public IActionResult Index()
        {
            return View("Condition");
        }
    }
}
