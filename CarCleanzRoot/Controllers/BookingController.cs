using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CarCleanz.Controllers
{
    public class BookingController : Controller
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public BookingController(IConfiguration config, HttpClient http)
        {
            _config = config;
            _http = http;
            _http.BaseAddress = new Uri(_config["Supabase:Url"]?.TrimEnd('/') + "/rest/v1/");
            _http.DefaultRequestHeaders.Add("apikey", _config["Supabase:Key"]);
            _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config["Supabase:Key"]}");
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Submit([FromForm] BookingModel model)
        {
            if(!ModelState.IsValid) return View("Index", model);

            var payload = new {
                name = model.Name,
                phone = model.Phone,
                car_type = model.CarType,
                service_date = model.ServiceDate.ToString("yyyy-MM-dd"),
                address = model.Address,
                created_at = DateTime.UtcNow.ToString("o")
            };

            var response = await _http.PostAsJsonAsync("Bookings", payload);
            if(response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Booking received! We'll contact you soon.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = $"Failed to save booking (HTTP {response.StatusCode}).";
                return View("Index", model);
            }
        }
    }

    public class BookingModel
    {
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string CarType { get; set; } = "";
        public DateTime ServiceDate { get; set; } = DateTime.UtcNow;
        public string Address { get; set; } = "";
    }
}
