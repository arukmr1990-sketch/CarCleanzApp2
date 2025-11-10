using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CarCleanz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ? GET: /Booking/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ? GET: /Booking (redirects to /Booking/Create)
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // ? POST: /Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                // ? Redirect to Success page with booking ID
                return RedirectToAction("Success", new { id = booking.Id });
            }
            return View(booking);
        }

        // ? GET: /Booking/Success?id=#
       [HttpGet]
public IActionResult Success(int id)
{
    Console.WriteLine($"[DEBUG] Success() called with ID: {id}");

    var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);

    if (booking == null)
    {
        Console.WriteLine("[DEBUG] No booking found for this ID.");
        return RedirectToAction("Create");
    }

    Console.WriteLine($"[DEBUG] Booking found: {booking.Name}, {booking.Email}, {booking.VehicleType}");
    return View(booking);
}

        // ? GET: /Booking/Admin
        [HttpGet]
        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login", "Admin");
            }

            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }
    }
}