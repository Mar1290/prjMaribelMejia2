using Microsoft.AspNetCore.Mvc;

namespace prjMaribelMejia.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
