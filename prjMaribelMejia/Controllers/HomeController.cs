using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace prjMaribelMejia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<mCarousel> carousels = new List<mCarousel>();
            carousels.Add(new mCarousel()
            {
                Id = 1,
                Title = "Imagen 1",
                Img="SLIDE1.JPG"
            });
         
            carousels.Add(new mCarousel()
            {
                Id = 2,
                Title = "Imagen 2",
                Img = "SLIDE2.JPG"
            });
         
            carousels.Add(new mCarousel()
            {
                Id = 3,
                Title = "Imagen 3",
                Img = "SLIDE3.JPG"
            });
            
            return View(carousels);
        }
        public IActionResult Prueba()
        {
            return View();
        }
        public IActionResult Categorias()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
