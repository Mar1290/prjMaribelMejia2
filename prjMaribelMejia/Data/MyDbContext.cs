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
    }
}
