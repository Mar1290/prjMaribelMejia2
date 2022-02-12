using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;

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
            _context.categorias.ToList();//debemos agregar la referencia to linq
            // List<Categorias> categoria = _context.categorias.ToList();
            //return View(categoria);

            //mejor usar esta forma:
            return View(_context.categorias.ToList());
        }
    }
}
