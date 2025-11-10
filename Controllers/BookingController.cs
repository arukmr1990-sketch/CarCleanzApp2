using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CarCleanzApp.Controllers
{
   public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ? Login (GET)
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // ? Login (POST)
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "carcleanz@2025")
        {
            HttpContext.Session.SetString("AdminLoggedIn", "true");
            return RedirectToAction("Admin");
        }

        ViewBag.Error = "Invalid username or password";
        return View();
    }

    // ? Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("AdminLoggedIn");
        return RedirectToAction("Login");
    }
[HttpGet]
public IActionResult Create()
{
    return View();
}
public IActionResult Index()
{
    return RedirectToAction("Create");
}

    // ? Admin page
    public IActionResult Admin()
    {
        if (HttpContext.Session.GetString("AdminLoggedIn") != "true")
        {
            return RedirectToAction("Login");
        }

        var bookings = _context.Bookings.ToList();
        return View(bookings);
    }
}
}