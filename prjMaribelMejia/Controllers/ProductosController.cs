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

            //List<SelectListItem> days = new List<SelectListItem>();
            // days.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            //model.Days = new SelectList(days, "Value", "Text");
            Categorias model = _context.categorias.ToList().FirstOrDefault();
            ////model.LisCategoria = _context.categorias.ToList().Select(Categorias => new SelectListItem() { Value = model.IdCategoria.ToString(), Text = model.Categoria.ToString() }).Reverse().ToList();

            //for (int i = 0; i <= _context.categorias.ToList().Count; i++)
            //{
            //    model.LisCategoria.Add(new SelectListItem { Value = model.IdCategoria.ToString(), Text = model.Categoria.ToString() });
            //}
           // model.LisCategoria = new SelectList(model.LisCategoria, "Value", "Text");
            model.LisCategoria = _context.categorias.ToList().Select(Categorias => new SelectListItem() { Value = model.IdCategoria.ToString(), Text = model.Categoria.ToString() }).Reverse().ToList();

            //if (categorias != null && !string.IsNullOrEmpty(categorias.DescripcionCategoria))
            //{
            //    descripcion = categorias.DescripcionCategoria;
            //}
            //return Json(new { descripcion });

            return View(model);
        }

        /*
        public IActionResult obtenerProductos()
        {
            Productos model = new Productos();
            model.listaProductos = _context.producto.ToList().Select(productos => new SelectListItem() { Value = model.IdProducto.ToString(), Text = model.Producto.ToString() })
                .Reverse()
                .ToList();
            return View(model);
        }
        */


        //Vista productos
        public IActionResult AgregarProducto()
        {
            obtenerCategorias();//15/3/22
            return View();
           
        }

        //ADD NUEVOS PDTOS
        public IActionResult CrearProducto(Productos productos)
        {
            productos.FechaCreacionProducto = System.DateTime.Now;
            //generar codigo para crear esa categoria
            _context.producto.Add(productos);
            _context.SaveChanges();

            //Retornamos a la pagina principal
            //return RedirectToAction("Categorias");
            return RedirectToAction("Productos");
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

 

    }
}
