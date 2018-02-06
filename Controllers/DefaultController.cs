using Microsoft.AspNetCore.Mvc;

namespace LCARS.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.IsInternetExplorer = Request.Headers["User-Agent"].ToString().Contains("Trident");
            return View();
        }
    }
}