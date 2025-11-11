using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CarCleanz.Models; // adjust if your namespace differs
using CarCleanz.Data;
using System.Linq;



namespace CarCleanz.Controllers
{
    public class AdminController : Controller
    {
        private const string AdminUser = "admin";
        private const string AdminPass = "1234";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == AdminUser && password == AdminPass)
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Admin", "Booking");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }
public IActionResult Index()
{
    // Check if admin is logged in
    if (HttpContext.Session.GetString("IsAdmin") != "true")
    {
        return RedirectToAction("Login");
    }

    // You can later show admin dashboard or summary data here
    return View();
}

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Login");
        }
    }
}