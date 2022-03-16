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
        //1 crear esto
        //private readonly ILogger<HomeController> _logger;

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
                _context.producto.ToList();//debemos agregar la referencia to linq   

          

                //mejor usar esta forma:
                return View(_context.producto.ToList());
        }
        [HttpPost]
        public IActionResult obtenerCategorias()
        {
            /*
            Categorias model = new Categorias();
            model.LisCategoria = _context.categorias.ToList().Select(categorias => new SelectListItem() { Value = model.IdCategoria.ToString(), Text = model.Categoria.ToString() })
                .Reverse()
                .ToList();
            */

            Categorias model = _context.categorias.ToList().FirstOrDefault();

            model.LisCategoria = _context.categorias.ToList().Select(Categorias => new SelectListItem() { Value = model.IdCategoria.ToString(), Text = model.Categoria.ToString() }).Reverse().ToList();

            return View(model);
        }

        //Vista productos
        public IActionResult AgregarProducto()
        {
            obtenerCategorias();//15/3/22
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
            else if (string.IsNullOrEmpty(productos.Descripcion))
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "Campo Descripción del producto está vacío"
                });
            }
            //else if (!decimal.TryParse(productos.Precio,out decimal precio))//validar tipo de dato entero.
            //{
            //    //utilizando formato json para intercambio de datos
            //    return Json(new
            //    {
            //        Success = false,
            //        Message = "Campo Descripción del producto está vacío"
            //    });
            //}
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
        public IActionResult EditarProducto(int id)
        {
            List<Productos> productos = _context.producto.ToList();
            //1. recupera dato y envia al moelo
            Productos modelopdto = _context.producto.Where(p => p.IdProducto == id).FirstOrDefault();
            //retorna
            return View("EditarProducto", modelopdto);

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

        public IActionResult ObtenerDescripcion(int id)
        {
            //string descripcion = _context.categorias.Where(a => a.IdCategoria == id).FirstOrDefault().DescripcionCategoria;
            //otra manera de programar
            string descripcion = "Este producto no contiene descripción";
            Productos productos = _context.producto.Where(a => a.IdProducto == id).FirstOrDefault();

            if (productos != null && !string.IsNullOrEmpty(productos.Descripcion))
            {
                descripcion = productos.Descripcion+"- Marca:"+productos.IdMarca;
            }
            return Json(new { descripcion });
        }



    }
}
