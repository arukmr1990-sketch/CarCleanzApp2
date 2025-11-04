using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CarCleanz.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _http;

        public AdminController(IConfiguration config, HttpClient http)
        {
            _config = config;
            _http = http;
            _http.BaseAddress = new Uri(_config["Supabase:Url"]?.TrimEnd('/') + "/rest/v1/");
            _http.DefaultRequestHeaders.Add("apikey", _config["Supabase:Key"]);
            _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config["Supabase:Key"]}");
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            var resp = await _http.GetAsync("Bookings?select=*");
            if(!resp.IsSuccessStatusCode) {
                ViewBag.Error = $"Failed to fetch bookings (HTTP {resp.StatusCode})";
                return View(Array.Empty<object>());
            }
            var json = await resp.Content.ReadAsStringAsync();
            ViewBag.BookingsJson = json;
            return View();
        }
    }
}
