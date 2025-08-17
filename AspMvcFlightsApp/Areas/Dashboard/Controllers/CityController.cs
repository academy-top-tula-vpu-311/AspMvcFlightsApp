using Microsoft.AspNetCore.Mvc;

namespace AspMvcFlightsApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CityController : Controller
    {
        [Area("Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
