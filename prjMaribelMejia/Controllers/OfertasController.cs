﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMaribelMejia.Models;
using System.Diagnostics;
using prjMaribelMejia.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace prjMaribelMejia.Controllers
{
    public class OfertasController : Controller
    {
        private readonly MyDbContext _context;//MyDbCONTEXT:es ña clase que orquesta conexxion a la bd

        //2. creampos el constructor de la clase
        public OfertasController(ILogger<OfertasController> logger, MyDbContext context)
        { 
            _context = context;
        }
        public IActionResult Ofertas()
        {
            //cargamos la lista de categorias       
            var listaproductos = _context.producto.ToList();
            ViewBag.ListaDeProducto = listaproductos;
            //cargamos la lista de marcas
            var Listamodulos = _context.modulos.ToList();
            ViewBag.ListaDeModulos = Listamodulos;


            List<Ofertas> ofertas = _context.ofertas.ToList();
            _context.ofertas.ToList();//debemos agregar la referencia to linq

            return View(_context.ofertas.ToList());
        }
        public IActionResult AgregarOferta()
        {    //cargamos la lista de categorias       
            var listaproductos = _context.producto.ToList();
            ViewBag.ListaDeProducto = listaproductos;
            //cargamos la lista de marcas
            var Listamodulos = _context.modulos.ToList();
            ViewBag.ListaDeModulos = Listamodulos;

            return View();

        }

        [HttpGet]
        public IActionResult CrearOferta(Ofertas ofertas)
        {
            if ((ofertas.IdProducto)!=0)
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "No se selecciono producto"
                });

            }
            if ((ofertas.IdModulo) == 0)
            {
                //utilizando formato json para intercambio de datos
                return Json(new
                {
                    Success = false,
                    Message = "No se selecciono producto"
                });

            }
            else
            {
                ofertas.FechaCreacionOferta = System.DateTime.Now;
                //generar código para crear a
                _context.ofertas.Add(ofertas);
                _context.SaveChanges();

                //Retornamos a la pagina principal

                return Json(new
                {
                    Success = true,
                    Message = "¡Su oferta ha sido registrada!"

                });
            }

        }
    }
}