using Microsoft.AspNetCore.Mvc;

namespace prjMaribelMejia.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
