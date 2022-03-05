using System;
using System.ComponentModel.DataAnnotations;

namespace prjMaribelMejia.Models
{
    public class Marcas
    {
        [Key]
        public int IdMarca { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "El campo producto es requerido")]
        public string NombreMarca { get; set; }
        public DateTime FechaCreacionMarca { get; set; }
        public int UsuarioRegistraMarca { get; set; }
    }
}
