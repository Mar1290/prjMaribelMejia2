using Microsoft.AspNetCore.Mvc;

namespace prjMaribelMejia.Controllers
{
    public class UNIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View("Posgrado");
        }
    }
}
