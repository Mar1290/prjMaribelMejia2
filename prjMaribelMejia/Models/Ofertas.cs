using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjMaribelMejia.Models
{
    public class Ofertas
    {
        
        [Required]
        [Key]
        public int IdOferta { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public Productos Productos { get; set; }
        public int IdModulo { get; set; }
        [ForeignKey("IdModulo")]
        public Modulos Modulos { get; set; }
        //PARA ENVIAR LA FECHA DEL SERVIDOR    
        public DateTime FechaCreacionOferta { get; set; }
    }
}
