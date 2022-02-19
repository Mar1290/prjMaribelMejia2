﻿using System;
using System.ComponentModel.DataAnnotations;

namespace prjMaribelMejia.Models
{
    public class Categorias
    {
        [Required]  
        [Key]
        public int IdCategoria { get; set; }
        public int IdClasificacion { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo categoria es requerido")]
        public string Categoria { get; set; }
        public string DescripcionCategoria { get; set; }

        //PARA ENVIAR LA FECHA DEL SERVIDOR
    
        public  DateTime FechaCreacionCategoria { get; set; }
 
    }
}
