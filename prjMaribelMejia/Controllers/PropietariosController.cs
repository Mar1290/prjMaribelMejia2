using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;

namespace prjMaribelMejia.Controllers
{
   
    public class PropietariosController : Controller
    {
        private readonly MyDbContext _context;  
        private readonly ILogger _logger;   

        public PropietariosController(ILogger<PropietariosController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult Propietarios()
        {
            return View();
        }
        public  IActionResult crearPropietarios(Propietarios propietarios)
        {
          _context.propietarios.Add(propietarios);  
            return View();
        }

    }
}
