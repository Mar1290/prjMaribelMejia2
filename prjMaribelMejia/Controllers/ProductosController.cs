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
    public class ProductosController : Controller
    {
        private readonly MyDbContext _context;

        //2. creampos el constructor de la clase
        public ProductosController(ILogger<ProductosController> logger, MyDbContext context)
        {
            // _logger= logger;    
            _context = context;
        }
        
        public IActionResult Productos()
        {
            List<Productos> productos = _context.producto.ToList();

            var listacategoria = _context.categorias.ToList();
            ViewBag.ListaCategorias = listacategoria;

            //cargamos la lista de marcas
            var listamarcas = _context.marcas.ToList();
            ViewBag.ListaMarcas = listamarcas;

            return View(_context.producto.ToList());
        }
        [HttpPost]
        public IActionResult obtenerCategorias()
        {
      
            Productos model = new Productos();
            var listacategoria = _context.categorias.Select(c => new { c.IdCategoria, c.Categoria }).ToList();       
            return View();

        }

        //Vista productos
        public IActionResult AgregarProducto()
        {    //cargamos la lista de categorias       
            var listacategoria = _context.categorias.ToList();
            ViewBag.ListaCategorias = listacategoria;
            //cargamos la lista de marcas
            var listamarcas = _context.marcas.ToList();
            ViewBag.ListaMarcas=listamarcas;    

            return View();
          
        }

        //ADD NUEVOS PDTOS
        public IActionResult CrearProducto(Productos productos)
        {            
            if (string.IsNullOrEmpty(productos.Producto))
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Campo producto esta vacío"
                });
            }
            else if ((productos.IdCategoria)==0)
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Seleccione categoría"
                });
            }
            else if ((productos.Precio) == 0)
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Ingrese precio del producto"
                });
            }
            else if (string.IsNullOrEmpty(productos.Descripcion))
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Campo Descripción del producto está vacío"
                });
            }
            else if ((productos.IdMarca) == 0)
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Seleccione marca"
                });
            }
            else
            {
                productos.FechaCreacionProducto = System.DateTime.Now;
                //generar código para crear esa categoria
                _context.producto.Add(productos);
                _context.SaveChanges();
                //retornar una vez mostrado el mensaje
                return Json(new
                {
                    Success = true,
                    Message = "¡Producto guardado correctamente!"
                });
            }
        }
        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            //cargamos la lista de categorias       
            var listacategoria = _context.categorias.ToList();
            ViewBag.ListaCategorias = listacategoria;
            //cargamos la lista de marcas
            var listaMarcas = _context.marcas.ToList();
            ViewBag.ListaMarcas = listaMarcas;

            List<Productos> productos = _context.producto.ToList();
            //1. recupera dato y envia al modelo
            Productos modelopdto = _context.producto.Where(p => p.IdProducto == id).FirstOrDefault();

            if (modelopdto == null)
            {
                return RedirectToAction("Productos");
            }
            //retorna
            return View(modelopdto);

        }

        public IActionResult EditarRegistroProducto(Productos productos)
        {
            Productos pdtoactual = _context.producto.
             Where(pa => pa.IdProducto == productos.IdProducto).FirstOrDefault();
            //actualizamos datos
            pdtoactual.Producto = productos.Producto;
            pdtoactual.IdCategoria = productos.IdCategoria;
            pdtoactual.Precio = productos.Precio;
            pdtoactual.Descripcion = productos.Descripcion;
            pdtoactual.IdMarca=productos.IdMarca;   
            _context.SaveChanges();
            List<Productos> producto = _context.producto.ToList();
              
            //retornamos a la pagina
            return RedirectToAction("Productos");

        }

        public IActionResult EliminarProducto(int? IdProducto)
        {
         
            List<Productos> productos = _context.producto.ToList();
            //con entity framework. eliminamos el valor
            Productos mod = _context.producto.Where(a => a.IdProducto == IdProducto).FirstOrDefault();
            if (mod != null)
            {
                //elimina modulo
                _context.Remove(mod);
                _context.SaveChanges();

                List<Productos> producto = _context.producto.ToList();

                return Json(new
                {
                    Success = true,
                    //mostramos el mensaje
                    Message = "¡Producto eliminado correctamente!"
                });
            }
            else
            {

                List<Productos> producto = _context.producto.ToList();

                return Json(new
                {
                    Success = false,
                    //mostramos el mensaje
                    Message = "¡Error: No se eliminó el registro!"
                });
            }
        }

        public IActionResult ObtenerDescripcion(int id)
        {
           
            //otra manera de programar
            string descripcion = "Este producto no contiene descripción";
            Productos productos = _context.producto.Where(a => a.IdProducto == id).FirstOrDefault();


            //Productos productos = _context.producto.Join
            //    (_context.marcas,
            //    product => product.IdMarca,
            //    marc => marc.IdMarca,
            //    (product, marc) => new { product, marc }).Select(p => p.product).Where(product => product.IdProducto == id).FirstOrDefault();

            //var _marproductos = from Productos in _context.marcas
            //                    join Marcas in _context.marcas on Productos.IdMarca equals Marcas.IdMarca
            //                    select new
            //                    {
            //                        Productos,
            //                        Marcas.NombreMarca
            //                    };


            if (productos != null && !string.IsNullOrEmpty(productos.Descripcion))
            {
                descripcion = productos.Descripcion + "- Marca: " ;
            }
            return Json(new { descripcion });

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

                                      m.Modulo,
                                      m.DescripcionModulo,
                                      Contacto = pr.NombrePropietario + " " + pr.TelefonoPropietario,
                                      o.IdProducto


                                  }).Where(x => x.IdProducto == IdProducto).ToList();

            //Ofertas objOferta = ModuloProducto.ToList();

            ViewBag.ListaBusqueda = ModuloProducto;

            if (ModuloProducto == null || ModuloProducto.Count == 0)
            {
                return RedirectToAction("Productos");
            }
            //retorna
            else
            {
                return View(ModuloProducto);

            }
           

        }


    }
}
