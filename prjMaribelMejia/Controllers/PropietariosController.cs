using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult CrearPropietarios(Propietarios propietarios)
        {
         //validamos los datos
            if (string.IsNullOrEmpty(propietarios.NombrePropietario))
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "No se ingreso nombre"
                });

            }
            else if (string.IsNullOrEmpty(propietarios.TelefonoPropietario))
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Ingrese teléfono"
                });
            }
            else if (string.IsNullOrEmpty(propietarios.DireccionPropietario))
            {
                return Json(new
                {
                    Success = false,
                    Message = "Debe especificar la dirección del propietario"
                });

            }
            else
            {
                propietarios.PropietarioActivo = true;

                _context.propietarios.Add(propietarios);
                _context.SaveChanges();
                //retornamos a la pagina
                return Json(new
                {
                    Success = true,
                    Message = "¡Propietari@ registrad@!"
                });

            }
        }

            public IActionResult EditarPropietario(int id)
        {


            List<Propietarios> propietarios= _context.propietarios.ToList();
            //1. recupera dato y envia al modelo
            Propietarios modeloprop = _context.propietarios.Where(p => p.IdPropietario == id).FirstOrDefault();
            //retorna     
            if (modeloprop != null)
            {                //retornamos
                return View("EditarPropietario", modeloprop);
            }
            else
            {
                return RedirectToAction("Propietarios");
            }

        }
        public IActionResult EditarRegistroPropietario(Propietarios propietarios)
        {

            Propietarios propietarioactual = _context.propietarios.
             Where(pa => pa.IdPropietario == propietarios.IdPropietario).FirstOrDefault();
            //actualizamos datos
            propietarioactual.NombrePropietario = propietarios.NombrePropietario;
            propietarioactual.IdentificacionPropietario = propietarios.IdentificacionPropietario;
            propietarioactual.DireccionPropietario = propietarios.DireccionPropietario;
            propietarioactual.TelefonoPropietario = propietarios.TelefonoPropietario;

      
            _context.SaveChanges();
            List<Propietarios> propietario = _context.propietarios.ToList();

            ////retornamos a la lista propietarios
            //return View("Propietarios", propietarios);
            //retornamos a la pagina
            return RedirectToAction("Propietarios");//lista de propietarios
        }

        public IActionResult EliminarPropietario(int? IdPropietario)
        {         
            List<Propietarios> propietarios = _context.propietarios.ToList();
            //con entity framework. eliminamos el valor
            Propietarios mod = _context.propietarios.Where(a => a.IdPropietario == IdPropietario).FirstOrDefault();
            if (mod != null)
            {
                //elimina modulo
                _context.Remove(mod);
                _context.SaveChanges();

                
                List<Propietarios> propietario = _context.propietarios.ToList();

                return Json(new
                {
                    Success = true,
                    //mostramos el mensaje
                    Message = "¡Propietario eliminado correctamente!"
                });
            }
            else
            {
                List<Propietarios> propietar = _context.propietarios.ToList();

                return Json(new
                {
                    Success = false,
                    //mostramos el mensaje
                    Message = "¡No se eliminó el propieatrio!"
                });
            }
        }

        public IActionResult AnularRegistroPropietario(Propietarios propietarios)
        {
            Propietarios propietarioactual = _context.propietarios.
             Where(pa => pa.IdPropietario == propietarios.IdPropietario).FirstOrDefault();
            //actualizamos datos
            propietarioactual.PropietarioActivo = false;

            _context.SaveChanges();
            List<Propietarios> propietario = _context.propietarios.ToList();

            ////retornamos a la lista propietarios
            return RedirectToAction("Propietarios");
        }

        

    }
}
