using Microsoft.EntityFrameworkCore;
using prjMaribelMejia.Models;

namespace prjMaribelMejia.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base (options)
        {

        }
        public  DbSet<Productos> producto { get; set; }//realizar una propiedad de esta por cada tabla
        public DbSet<Categorias> categorias { get; set; }   
        public DbSet<Propietarios> propietarios { get; set;}
        public DbSet<Modulos> modulos { get; set; }
        public DbSet<Marcas> marcas { get; set; }
        public DbSet<Ofertas> ofertas { get; set; } 
    }
}
