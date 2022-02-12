using System;
using System.ComponentModel.DataAnnotations;

namespace prjMaribelMejia.Models
{
    public class Modulos
    {
        [Key]
        public int IdModulo { get; set; }
        [Required(ErrorMessage = "El campo propietario es requerido")]
        public int IdPropietario { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo modulo es requerido")]
        public string Modulo { get; set; }       
        public DateTime FechaCreacionModulo { get; set; }
    }
}
