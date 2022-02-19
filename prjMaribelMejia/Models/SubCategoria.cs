using System;
using System.ComponentModel.DataAnnotations;

namespace prjMaribelMejia.Models
{
    public class SubCategoria
    {
        [Key]
        public int IdSubCategoria { get; set; }
        [Required]
        public int IdCategoria { get; set; }
        [Required]
        public string DescripcionSubCategoria { get; set; }
        public int IdUsuarioRegistra { get; set; }


    }
}
