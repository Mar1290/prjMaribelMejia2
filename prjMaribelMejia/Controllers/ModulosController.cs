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
    public class ModulosController : Controller
    {
        private readonly MyDbContext _context;
        public ModulosController(ILogger<ModulosController> logger, MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Modulos()
        {
          
            List<Modulos> modulos = _context.modulos.ToList();

            var listapropietarios = _context.propietarios.ToList();
            ViewBag.ListaCategorias = listapropietarios;

            _context.modulos.ToList();
            //mejor usar esta forma:
            return View(_context.modulos.ToList());
        }

        //Vista productos
        public IActionResult AgregarModulos()
        {
           
            //cargamos la lista de de propietarios      
            var listapropietarios= _context.propietarios.ToList();
            ViewBag.ListaPropietario = listapropietarios;

            return View();
        }
        public IActionResult CrearModulo(Modulos modulos)
        {
            if (string.IsNullOrEmpty(modulos.Modulo))
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Campo módulo esta vacío"
                });
            }
            else
            {
                modulos.FechaCreacionModulo = System.DateTime.Now;
                //generar código para crear
                _context.modulos.Add(modulos);
                _context.SaveChanges();
                //retornar una vez mostrado el mensaje
                return Json(new
                {
                    Success = true,
                    Message = "¡Módulo guardado correctamente!"
                });

            }
        }
        public IActionResult EditarModulo(int id)
        {

            //cargamos la lista de categorias       
            var listapropietario = _context.propietarios.ToList();
            ViewBag.ListaPropietarios = listapropietario;

            List<Modulos> modulos = _context.modulos.ToList();
            //1. recupera dato y envia al modelo
            Modulos modeloModulo = _context.modulos.Where(p => p.IdModulo == id).FirstOrDefault();
            //retorna
            if (modeloModulo != null)
            {                //retornamos
                return View("EditarModulo", modeloModulo);
            }
            else
            {
                return RedirectToAction("Modelos");
            }

        }
        public IActionResult EditarRegistroModulo(Modulos modulos)
        {

            Modulos moduloactual = _context.modulos.
             Where(pa => pa.IdModulo == modulos.IdModulo).FirstOrDefault();
            //actualizamos datos
           
            moduloactual.IdPropietario = modulos.IdPropietario;
            moduloactual.Modulo = modulos.Modulo;
            moduloactual.DescripcionModulo = modulos.DescripcionModulo; 

            _context.SaveChanges();
            List<Modulos> lismodulos = _context.modulos.ToList();

            //retornamos a la pagina
            return RedirectToAction("Modulos");
        }

       // public IActionResult EliminarModulo(int id)
        public IActionResult EliminarModulo(int? IdModulo)
        {
            List<Modulos> modulos = _context.modulos.ToList();
            //con entity framework. eliminamos el valor
            Modulos mod = _context.modulos.Where(a => a.IdModulo == IdModulo).FirstOrDefault();
            if (mod != null)
            {
                //elimina modulo
                _context.Remove(mod);
                _context.SaveChanges();

                List<Modulos> modulo = _context.modulos.ToList();

                return Json(new
                {
                    Success = true,
                    //mostramos el mensaje
                    Message = "¡Módulo guardado correctamente!"
                });
            }
            else
            {
                List<Modulos> modulo = _context.modulos.ToList();

                return Json(new
                {
                    Success = false,
                    //mostramos el mensaje
                    Message = "¡No se eliminó el registro!"
                });
            }        

            //return RedirectToAction("Modulos","Modulos");
        }
    }
}
