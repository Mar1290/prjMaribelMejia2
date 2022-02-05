using System.ComponentModel.DataAnnotations;

namespace prjMaribelMejia.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }

        [StringLength(100)]  
        [Required(ErrorMessage ="El campo producto es requerido")]  
        
        public string Producto { get; set; }

        [Required(ErrorMessage = "El campo Categoria es requerido")]        
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El campo Precio es requerido")]
        
        public decimal Precio { get; set; }
        [StringLength(500)]
       
        public string Descripcion { get; set; }
    }
}
