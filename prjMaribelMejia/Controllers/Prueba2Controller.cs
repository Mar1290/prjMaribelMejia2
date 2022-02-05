using Microsoft.AspNetCore.Mvc;
using prjMaribelMejia.Models;
using System.Collections.Generic;

namespace prjMaribelMejia.Controllers
{
    public class Prueba2Controller : Controller
    {
        public IActionResult Index()
        {
            //simular los datos como que estoy usando base de datos

            List<Pacientes> pacientes = new List<Pacientes>();
            pacientes.Add(new Pacientes()
            {
                Nombre = "Jose Mendez",
                Direccion="Managua",
                Edad=2,
                Telefono="8885554"

            });
            pacientes.Add(new Pacientes()
            {
                Nombre = "Jose Gonzalez",
                Direccion = "Managua",
                Edad = 32,
                Telefono = "451154785"

            });

            return View(pacientes);
        }

        public IActionResult Edit()
        {
            return View();

        }
}
}
