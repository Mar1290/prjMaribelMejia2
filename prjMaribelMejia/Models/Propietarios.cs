using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjMaribelMejia.Models
{
    public class Propietarios
    {
        [Key]
        public int IdPropietario { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string NombrePropietario { get; set; }
        [StringLength(16)]
        [Required(ErrorMessage = "El campo identificación es requerido")]
        public string IdentificacionPropietario { get; set; }
        [StringLength(300)]
        [Required(ErrorMessage = "El campo dirección es requerido")]
        public string DireccionPropietario { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\\(?(\[0-9\]{3})\\)?\[-.●\]?(\[0-9\]{3})\[-.●\]?(\[0-9\]{4})$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string TelefonoPropietario { get; set; }
        public bool PropietarioActivo { get; set; }

    
    }
}
