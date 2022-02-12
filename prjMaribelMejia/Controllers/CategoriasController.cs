using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;

namespace prjMaribelMejia.Controllers
{
    public class CategoriasController : Controller
    {
        //1 crear esto
        private readonly ILogger<HomeController> _logger;

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

            //Retornamos a la pagina prinicpal
           return RedirectToAction("Categorias");
            
        }
        public IActionResult ListaCategorias()
        {
            return View();
        }
    }
}
