using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using System.Collections.Generic;
namespace CarCleanzApp.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View("Create");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking model)
        {
            if (ModelState.IsValid)
            {
                // Optional: Save to DB here
                // _context.Bookings.Add(model);
                // _context.SaveChanges();

                // Pass data to Success view
                ViewBag.Name = model.Name;
                ViewBag.Email = model.Email;
                ViewBag.VehicleType = model.VehicleType;
                ViewBag.ServicePackage = model.ServicePackage; // ? fixed name
                ViewBag.BookingDate = model.BookingDate.ToString("dd-MM-yyyy");
                ViewBag.Phone = model.Phone;

                return View("Success");
            }

            return View(model);
        }
public IActionResult Admin()
{
    // ? Create an empty list (for now, until database connection is added)
    List<Booking> bookings = new List<Booking>();

    // Later, when you connect EF Core or SQLite, replace the above with:
    // var bookings = _context.Bookings.ToList();

    return View(bookings);
}
        public IActionResult Success()
        {
            return View();
        }
    }
}