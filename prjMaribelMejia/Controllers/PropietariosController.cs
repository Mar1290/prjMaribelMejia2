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
  

        public IActionResult EditarPropietario(int id)
        {
            List<Propietarios> propietarios= _context.propietarios.ToList();
            //1. recupera dato y envia al moelo
            Propietarios modeloprop = _context.propietarios.Where(p => p.IdPropietario == id).FirstOrDefault();
            //retorna
            return View("EditarPropietario",modeloprop);    

        }


        public IActionResult EditarRegistroPropietario(Propietarios propietarios)
        {
            Propietarios propietarioactual = _context.propietarios.Where(pa => pa.IdPropietario == propietarios.IdPropietario).FirstOrDefault();
            //actualizamos datos
            propietarioactual.NombrePropietario = propietarios.NombrePropietario;
            propietarioactual.IdentificacionPropietario = propietarios.IdentificacionPropietario;
            propietarioactual.DireccionPropietario = propietarios.DireccionPropietario;
            propietarioactual.TelefonoPropietario = propietarioactual.TelefonoPropietario;

            List<Propietarios> propietario=_context.propietarios.ToList();
            _context.SaveChanges();

            //retornamos a la lista propietarios
            return View("Propietarios", propietarios);
        }

    }
}
