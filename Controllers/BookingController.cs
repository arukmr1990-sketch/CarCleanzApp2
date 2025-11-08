using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Collections.Generic;
using System.Linq;
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
    // ? Fetch all bookings from SQLite
    var bookings = _context.Bookings.ToList();

    return View(bookings);
}        public IActionResult Success()
        {
            return View();
        }
    }
}