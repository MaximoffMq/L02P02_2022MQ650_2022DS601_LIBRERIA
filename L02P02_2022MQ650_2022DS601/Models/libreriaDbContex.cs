using Microsoft.EntityFrameworkCore;

namespace L02P02_2022MQ650_2022DS601.Models
{
    public class libreriaDbContex : DbContext
    {
        public libreriaDbContex(DbContextOptions options) : base(options)
        {

        }
        public DbSet<autores> autores { get; set; }
        public DbSet<libros> libros { get; set; }
        public DbSet<comentarios_libros> comentarios_libros { get; set; }

    }
}
