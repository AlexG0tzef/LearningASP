using Microsoft.AspNetCore.Mvc;

namespace fASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
