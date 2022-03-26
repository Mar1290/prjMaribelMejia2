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
    public class OfertasController : Controller
    {
        private readonly MyDbContext _context;

        //2. creampos el constructor de la clase
        public OfertasController(ILogger<OfertasController> logger, MyDbContext context)
        { 
            _context = context;
        }
        public IActionResult Ofertas()
        {
            List<Ofertas> ofertas = _context.ofertas.ToList();
      
            //cargamos la lista de pdts    
            var listaproductos = _context.producto.ToList();
            ViewBag.ListaDeProducto = listaproductos;
            //cargamos la lista de modulos
            var Listamodulos = _context.modulos.ToList();
            ViewBag.ListaDeModulos = Listamodulos;
                  

            return View(_context.ofertas.ToList());
        }
        public IActionResult AgregarOferta()
        {   
            //cargamos la lista de categorias       
            var listaproductos = _context.producto.ToList();
            ViewBag.ListaDeProducto = listaproductos;

            //cargamos la lista de marcas
            var Listamodulos = _context.modulos.ToList();
            ViewBag.ListaDeModulos = Listamodulos;

            return View();
        }

        public IActionResult CrearNuevaOferta(Ofertas ofertas)
        {
            if ((ofertas.IdProducto) == 0)
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "No se selecciono producto"
                });

            }
            if ((ofertas.IdModulo) == 0)
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "No se selecciono producto"
                });
            }
            else
            {
                ofertas.FechaCreacionOferta = System.DateTime.Now;
                //generar código para crear a
                _context.ofertas.Add(ofertas);
                _context.SaveChanges();

                //Retornamos a la pagina principal

                return Json(new
                {
                    Success = true,
                    Message = "¡Su oferta ha sido registrada!"
                });
            }
        }
        [HttpGet]
        public IActionResult EditarOferta(int id)
        {
            //cargamos la lista de categorias       
            var listaproductos = _context.producto.ToList();
            ViewBag.ListaDeProducto = listaproductos;

            //cargamos la lista de marcas
            var Listamodulos = _context.modulos.ToList();
            ViewBag.ListaDeModulos = Listamodulos;

            List<Ofertas> listofertas = _context.ofertas.ToList();
            //1. recupera dato y envia al modelo
            Ofertas modeloOferta = _context.ofertas.Where(p => p.IdOferta == id).FirstOrDefault();
            //retorna
            if (modeloOferta != null)
            {                //retornamos
                return View("EditarOferta", modeloOferta);
            }
            else
            {
                return RedirectToAction("Ofertas");
            }

        }
        public IActionResult EditarRegistroOferta(Ofertas ofertas)
        {
           
            Ofertas ofertactual = _context.ofertas.
             Where(pa => pa.IdOferta == ofertas.IdOferta).FirstOrDefault();
            //actualizamos datos

            ofertactual.IdOferta = ofertas.IdOferta;
            ofertactual.IdProducto = ofertas.IdProducto;
            ofertactual.IdModulo = ofertas.IdModulo;

            _context.SaveChanges();
            List<Ofertas> lisofertas = _context.ofertas.ToList();
            //retornamos a la pagina
            return RedirectToAction("Ofertas");
        }

        public IActionResult EliminarOferta(int? IdOferta)
        {
            List<Ofertas> ofertas = _context.ofertas.ToList();
            //con entity framework. eliminamos el valor
            Ofertas ofer = _context.ofertas.Where(a => a.IdOferta == IdOferta).FirstOrDefault();
            if (ofer != null)
            {
                //elimina modulo
                _context.Remove(ofer);
                _context.SaveChanges();
                List<Ofertas> oferta = _context.ofertas.ToList();
                return Json(new
                {
                    Success = true,
                    //mostramos el mensaje
                    Message = "Oferta eliminada correctamente"
                });
            }
            else
            {
                List<Ofertas> ofera = _context.ofertas.ToList();

                return Json(new
                {
                    Success = false,
                    //mostramos el mensaje
                    Message = "¡No se eliminó el registro!"
                });
            }
        }

        public IActionResult UbicacionProducto(int IdProducto)
        {
            var ModuloProducto = (from o in _context.ofertas
                                  join p in _context.producto on o.IdProducto equals p.IdProducto
                                  join m in _context.modulos on o.IdModulo equals m.IdModulo
                                  join pr in _context.propietarios on m.IdPropietario equals pr.IdPropietario
                                  select new
                                  {
                                      Producto = p.Producto + " " + p.Descripcion,
                                      p.Precio,
                                      m.Modulo,
                                      m.DescripcionModulo,
                                      Contacto = pr.NombrePropietario + " " + pr.TelefonoPropietario,
                                      o.IdProducto


                                  }).Where(x => x.IdProducto == IdProducto).ToList();
            ViewBag.ListaBusqueda = ModuloProducto;
            return View();
        }



    }
}
