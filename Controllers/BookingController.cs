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
return Content("POST HIT");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
        .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage)
        .ToList();

    return Content("MODEL ERROR ? " + string.Join(" | ", errors));
            }

            // -------------------------------
            // Generate Custom Booking ID
            // -------------------------------
            var lastBooking = _context.Bookings
                .OrderByDescending(b => b.Id)
                .FirstOrDefault();

            int nextNumber = 3000;

            if (lastBooking != null && !string.IsNullOrEmpty(lastBooking.CustomBookingId))
            {
                string numberPart = lastBooking.CustomBookingId.Replace("CCA", "");
                nextNumber = int.Parse(numberPart) + 1;
            }

            booking.CustomBookingId = $"CCA{nextNumber}";

            // -------------------------------
            // Vehicle Price Calculation
            // -------------------------------
            switch ((booking.VehicleType ?? "").ToLower())
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

            // Save to DB
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            // Redirect to Payment page
            return RedirectToAction("Payment", new { id = booking.Id });
        }

        // GET: Booking/Payment?id=5
        public IActionResult Payment(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

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
