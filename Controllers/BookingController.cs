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

        // ? POST: /Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("Success");
            }
            return View(booking);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
// ? GET: /Booking/Admin
[HttpGet]
public IActionResult Admin()
{
    // Fetch all bookings from DB
    var bookings = _context.Bookings.ToList();

    // Return the Admin view (Views/Booking/Admin.cshtml)
    return View(bookings);
}
}