using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjMaribelMejia.Models
{
    public class Clasificacion
    {
        [Key]
        public int IdClasificacion { get; set; }
        [Required]
        public string NombreClasificacion { get; set; }
    }
}
