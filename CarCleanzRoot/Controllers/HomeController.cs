using Microsoft.AspNetCore.Mvc;

namespace CarCleanz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
