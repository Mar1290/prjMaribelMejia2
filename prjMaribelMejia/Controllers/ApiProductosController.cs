using Microsoft.AspNetCore.Mvc;
using prjMaribelMejia.Data;
using prjMaribelMejia.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjMaribelMejia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductosController : ControllerBase
    {

        private readonly MyDbContext _context;
     public ApiProductosController(MyDbContext context)
     {
        _context = context; 
     }

        // GET: api/<ApiProductosController>
        [HttpGet]
        public IEnumerable<Productos> Get()
        {
            //List<Productos> productos = _context.producto.ToList();
            IEnumerable<Productos> productos = _context.producto.ToList();
            //_context.productos.ToList();//debemos agregar la referencia to linq      
            //validar valores null     
           return productos;              
   
        }

        // GET api/<ApiProductosController>/5
        [HttpGet("{id}")]
        public Productos Get(int id)
        {
           Productos productos = _context.producto.Where(a => a.IdProducto == id).FirstOrDefault();
            if (productos == null)
            { return new Productos(); }
            else
            {
                return productos;
            }          
        }

        // POST api/<ApiProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
