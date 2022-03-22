using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjMaribelMejia.Models
{
    public class Modulos
    {
        [Key]
        public int IdModulo { get; set; }
        [Required(ErrorMessage = "El campo propietario es requerido")]
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; } 
        public int IdPropietario { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo modulo es requerido")]
        public string Modulo { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "El campo modulo es requerido")]
        public string DescripcionModulo { get; set; }
        public DateTime FechaCreacionModulo { get; set; }
    }
}
