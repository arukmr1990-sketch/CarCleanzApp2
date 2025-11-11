using Microsoft.AspNetCore.Mvc;
using CarCleanz.Data;
using CarCleanz.Models;

namespace CarCleanz.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();

                // Redirect to Payment Page after successful booking
                return RedirectToAction("Payment", new
                {
                    name = booking.Name,
                    email = booking.Email,
                    phone = booking.Phone,
                    vehicleType = booking.VehicleType,
                    servicePackage = booking.ServicePackage
                });
            }
            return View(booking);
        }

        // Payment Page
       public IActionResult Payment(string name, string email, string phone, string vehicleType, string servicePackage)
{
    ViewBag.Name = name;
    ViewBag.Email = email;
    ViewBag.Phone = phone;
    ViewBag.VehicleType = vehicleType;
    ViewBag.ServicePackage = servicePackage;

    return View();
}   // ? this closing brace was missing

        // Booking Successful Page
       public IActionResult Success(string name, string vehicleType, string servicePackage)
{
    ViewBag.Name = name;
    ViewBag.VehicleType = vehicleType;
    ViewBag.ServicePackage = servicePackage;

    return View();
}
    // Pass booking data to the view
    return View(booking);
}
    }
}