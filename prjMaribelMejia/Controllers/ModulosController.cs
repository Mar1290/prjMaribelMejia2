using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;
using System.Collections.Generic;

namespace prjMaribelMejia.Controllers
{
    public class ModulosController : Controller
    {
        private readonly MyDbContext _context;
        public ModulosController(ILogger<ModulosController> logger, MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Modulos()
        {
            return View();
        }
    }
}
