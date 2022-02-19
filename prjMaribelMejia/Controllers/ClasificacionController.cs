using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;

namespace prjMaribelMejia.Controllers
{
    public class ClasificacionController : Controller
    {
        //1 crear esto
        //private readonly ILogger<HomeController> _logger;

        private readonly MyDbContext _context;//MyDbCONTEXT:es ña clase que orquesta conexxion a la bd

        //2. creampos el constructor de la clase
        public ClasificacionController(ILogger<CategoriasController> logger, MyDbContext context)
        {
            // _logger= logger;    
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
