using Microsoft.AspNetCore.Mvc;

namespace Bilet_3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
