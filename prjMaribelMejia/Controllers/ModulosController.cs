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
            _context.modulos.ToList();
            //mejor usar esta forma:
            return View(_context.modulos.ToList());
        }

        //Vista productos
        public IActionResult AgregarModulos()
        {
           
            //cargamos la lista de categorias       
            var listapropietarios= _context.propietarios.ToList();
            ViewBag.ListaCategorias = listapropietarios;

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
                    Message = "¡Modulo guardado correctamente!"
                });

            }
        }
        public IActionResult EditarModulo(int id)
        {
            List<Modulos> modulos = _context.modulos.ToList();
            //1. recupera dato y envia al moelo
            Modulos modeloModulo = _context.modulos.Where(p => p.IdModulo == id).FirstOrDefault();
            //retorna
            return View("EditarModulo", modeloModulo);

        }
        public IActionResult EditarRegistroModulo(Modulos modulos)
        {

            Modulos moduloactual = _context.modulos.
             Where(pa => pa.IdModulo == modulos.IdModulo).FirstOrDefault();
            //actualizamos datos
           
            moduloactual.IdPropietario = modulos.IdPropietario;
            moduloactual.Modulo = modulos.Modulo;
            _context.SaveChanges();
            List<Modulos> lismodulos = _context.modulos.ToList();

            //retornamos a la pagina
            return RedirectToAction("Modulos");
        }
        public IActionResult EliminarModulo(int id)
        {
            List<Modulos> modulos = _context.modulos.ToList();
            //con entity framework. eliminamos el valor
            Modulos mod = _context.modulos.Where(a => a.IdModulo == id).FirstOrDefault();
            if (mod != null)
            {
                //elimna categorias
                _context.Remove(mod);
            }
            _context.SaveChanges();
       
            List<Modulos> modulo = _context.modulos.ToList();
           // return RedirectToAction("Modulos",modulo);

                //retornar una vez mostrado el mensaje
                return Json(new
                {
                    Success = true,
                    Message = "¡Modulo guardado correctamente!"
                });

          

        }
    }
}
