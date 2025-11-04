using Microsoft.AspNetCore.Mvc;
using CarCleanzApp.Models; // adjust if your namespace differs

namespace CarCleanzApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Show Login Page
        [HttpGet]
        public IActionResult Login()
        {
            // If already logged in, redirect to Admin Dashboard
            if (HttpContext.Session.GetString("IsAdmin") == "true")
                return RedirectToAction("Index");

            return View();
        }

        // ✅ Handle Login POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Simple static check — replace with DB validation if needed
            if (username == "admin" && password == "carcleanz@123")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                HttpContext.Session.SetString("AdminName", "Car Cleanz Admin");
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        // ✅ Admin Dashboard — Show all bookings
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
                return RedirectToAction("Login");

            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }

        // ✅ Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
