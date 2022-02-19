using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;
using System.Collections.Generic;

namespace prjMaribelMejia.Controllers
{
    public class CategoriasController : Controller
    {
        //1 crear esto
        //private readonly ILogger<HomeController> _logger;

        private readonly MyDbContext _context;//MyDbCONTEXT:es ña clase que orquesta conexxion a la bd

        //2. creampos el constructor de la clase
        public CategoriasController(ILogger<CategoriasController> logger, MyDbContext context)
        {
           // _logger= logger;    
            _context=context;   
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categorias()
        {
            return View();
        }

        public IActionResult CrearCategoria(Categorias categorias)
        {
            categorias.FechaCreacionCategoria = System.DateTime.Now;
            //generar codigo para crear esa categoria
           _context.categorias.Add(categorias);
            _context.SaveChanges(); 

            //Retornamos a la pagina principal
           //return RedirectToAction("Categorias");
            return RedirectToAction("ListaCategorias");

        }
        public IActionResult ListaCategorias()
        {
            List<Categorias> categorias = _context.categorias.ToList();
            _context.categorias.ToList();//debemos agregar la referencia to linq
            // List<Categorias> categoria = _context.categorias.ToList();
            //return View(categoria);

            //mejor usar esta forma:
            return View(_context.categorias.ToList());
        }
        public IActionResult EditarCategoria(int id)
        {
            List<Categorias> categorias = _context.categorias.ToList();
            //recuperamos los datos y lo pasamos a nuestro modelo
            Categorias modelo=_context.categorias.Where(c => c.IdCategoria == id).FirstOrDefault(); 
            //retornamos
            return View("EditarCategoria", modelo);
        }
        //esta accion recibe el objeto categoria
        public IActionResult EditarValorCategoria(Categorias categorias)
        {
            //recupero el valor actual en la base de datos
          Categorias categoriaActual=_context.categorias.
                Where(a => a.IdCategoria==categorias.IdCategoria).FirstOrDefault();
            //ahora actualizo los datos
            categoriaActual.Categoria = categorias.Categoria;
            categoriaActual.DescripcionCategoria= categorias.DescripcionCategoria;


            List<Categorias> categoria = _context.categorias.ToList();
            //persisto los datos en la bd
            _context.SaveChanges();
           
            //retornamos a la vista listacategorias
            return View("ListaCategorias", categoria);
        }
        public IActionResult EliminarCategoria(int id)
        {
            //en caso de que tengamos relacion con otra tabla
            List<Productos> productos = _context.producto.Where(a => a.IdCategoria==id).ToList();

            if (productos !=null)
            {
                //elimna todos los prorictos asociados
                _context.RemoveRange(productos);
            }

            // _context.SaveChanges();//no es recomendable poner el metodos varias veces para evitar ir a la bd constantemente.

            //con entity framework. eliminamos el valor
            Categorias categorias = _context.categorias.Where(a => a.IdCategoria == id).FirstOrDefault();
            if (categorias != null)
            {
                //elimna categorias
                _context.Remove(categorias);
            }     
          
            _context.SaveChanges(); 
            List<Categorias> categoria = _context.categorias.ToList();
            return View("ListaCategorias", categoria);
        }
    }
}
