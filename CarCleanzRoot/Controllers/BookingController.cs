using Microsoft.AspNetCore.Mvc;
using CarCleanzApp.Models;
using System.Collections.Generic;

namespace CarCleanzApp.Controllers
{
    public class BookingController : Controller
    {
        private static List<Booking> bookings = new List<Booking>();

        // GET: Booking form
        public IActionResult Index()
        {
            return View();
        }

        // POST: Save booking
        [HttpPost]
        public IActionResult Submit(Booking booking)
        {
            bookings.Add(booking);
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }

        // Admin View
        public IActionResult Admin()
        {
            return View(bookings);
        }
    }
}
