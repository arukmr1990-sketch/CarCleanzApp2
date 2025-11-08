using Microsoft.AspNetCore.Mvc;
using CarCleanzApp.Models;

namespace CarCleanzApp.Controllers
{
    public class BookingController : Controller
    {
        // Default page — loads the booking form
        public IActionResult Index()
        {
            return View("Create");
        }

        // Shows the booking form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Handles form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking model)
        {
            if (ModelState.IsValid)
            {
                // Save booking to database (or file)
                // ... your logic here

                return RedirectToAction("Success");
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}