using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjMaribelMejia.Models
{
    public class Categorias
    {
        [Required]
        [Key]
        public int IdCategoria { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El campo categoria es requerido")]
        public string Categoria { get; set; }
        public string DescripcionCategoria { get; set; }

        //PARA ENVIAR LA FECHA DEL SERVIDOR    
        public DateTime FechaCreacionCategoria { get; set; }

        [NotMapped]
        public List<SelectListItem> LisCategoria { get; set; }
    }
}
