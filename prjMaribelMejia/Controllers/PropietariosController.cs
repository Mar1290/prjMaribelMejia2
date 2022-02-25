using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;
using System.Collections.Generic;

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
            List<Propietarios> propietarios = _context.propietarios.ToList();
            _context.propietarios.ToList();//debemos agregar la referencia to linq
      

            //mejor usar esta forma:
            return View(_context.propietarios.ToList());
        }

        public IActionResult AgregarPropietario()
        {
            return View();
        }

        public  IActionResult CrearPropietarios(Propietarios propietarios)
        {
          _context.propietarios.Add(propietarios);  
            _context.SaveChanges(); 
            //retornamos a la pagina
            return RedirectToAction("Propietarios");
        }

 

    }
}
