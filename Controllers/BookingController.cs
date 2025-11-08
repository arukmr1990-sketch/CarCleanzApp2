using Microsoft.AspNetCore.Mvc;
using CarCleanz.Models;
using CarCleanz.Data;
using System.Threading.Tasks;

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
        public IActionResult Index()
{
    return View("Create");
}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid)
                return View(booking);

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
// Pass the booking object temporarily to the next request
    TempData["Name"] = booking.Name;
    TempData["Email"] = booking.Email;
    TempData["Phone"] = booking.Phone;
    TempData["VehicleType"] = booking.VehicleType;
    TempData["ServiceType"] = booking.Service;
    TempData["BookingDate"] = booking.BookingDate.ToString("dd MMM yyyy");

            //  Post-Redirect-Get pattern
            return RedirectToAction(nameof(Success));
        }

        [HttpGet]
        public IActionResult Success()
        {
 // Load TempData into ViewBag for display
    ViewBag.Name = TempData["Name"];
    ViewBag.Email = TempData["Email"];
    ViewBag.Phone = TempData["Phone"];
    ViewBag.VehicleType = TempData["VehicleType"];
    ViewBag.ServiceType = TempData["ServiceType"];
    ViewBag.BookingDate = TempData["BookingDate"];
            return View();
        }
    }
}