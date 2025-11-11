using Microsoft.AspNetCore.Mvc;
using CarCleanz.Data;
using CarCleanz.Models;
using System.Linq;

namespace CarCleanz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Booking/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }

            // Set price automatically based on vehicle type
            switch ((booking.VehicleType ?? "").ToLowerInvariant())
            {
                case "hatchback":
                    booking.Price = 499;
                    break;
                case "sedan":
                    booking.Price = 650;
                    break;
                case "suv":
                    booking.Price = 750;
                    break;
                default:
                    booking.Price = 0;
                    break;
            }

            // Save to DB permanently
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            // Redirect to Payment page by id (safer than ViewBag)
            return RedirectToAction("Payment", new { id = booking.Id });
        }

        // GET: Booking/Payment?id=5
        public IActionResult Payment(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            // Show the payment page with model
            return View(booking);
        }

        // GET: Booking/Success?id=5
        public IActionResult Success(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            return View(booking);
        }
    }
}