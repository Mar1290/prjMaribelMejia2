using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjMaribelMejia.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }

        [StringLength(100)]  
        [Required(ErrorMessage ="El campo producto es requerido")]         
        public string Producto { get; set; }

        //hacemos esto para relacionar tablas
        [Required(ErrorMessage = "El campo Categoria es requerido")]        
        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categorias Categorias { get; set; }  

        [Required(ErrorMessage = "El campo Precio es requerido")]        
        public decimal Precio { get; set; }

        [StringLength(500)]       
        public string Descripcion { get; set; }
        public DateTime FechaCreacionProducto { get; set; }
        public int IdMarca { get; set; }
        [ForeignKey("IdMarca")]
        public Marcas Marcas { get; set; }
    }
}
