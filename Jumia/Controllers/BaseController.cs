using Jumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Jumia.Controllers
{
    public class BaseController(AppDBContext context) : Controller
    {
        //protected readonly AppDBContext context = new AppDBContext();

        public override void OnActionExecuting(ActionExecutingContext _context)
        {
            var departments = context.Departments.ToList();
            ViewData["departments"] = departments;
            base.OnActionExecuting(_context);
        }
    }
}