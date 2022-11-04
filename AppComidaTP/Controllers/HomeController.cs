using Microsoft.AspNetCore.Mvc;

namespace AppComidaTP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
