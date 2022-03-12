using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;
using System.Collections.Generic;
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
        //Vista productos
        public IActionResult AgregarProducto()
        {
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
