using Microsoft.EntityFrameworkCore;
using ServidorAPI.Models;

namespace ServidorAPI.Contenido
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plato> Platos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
