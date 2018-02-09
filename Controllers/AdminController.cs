using Microsoft.AspNetCore.Mvc;

namespace LCARS.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}