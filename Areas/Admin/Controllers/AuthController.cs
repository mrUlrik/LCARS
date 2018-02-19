using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LCARS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        [HttpGet("/login")]
        public IActionResult Index(string returnUrl)
        {
            ViewBag.Return = returnUrl;
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(string password, string returnUrl)
        {
            if (string.IsNullOrEmpty(password))
                ModelState.AddModelError("password", "Enter a password.");

            if (password != "f0xkn0ts69")
                ModelState.AddModelError("password", "Incorrect password");

            if (!ModelState.IsValid) return View("Index");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, password)
            };

            var userIdentity = new ClaimsIdentity(claims, "login");

            var principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);

            if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Default", new { Area = "" });
        }
    }
}