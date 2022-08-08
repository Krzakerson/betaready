using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Data
{
    public class CosDbContext: DbContext
    {
        public CosDbContext(DbContextOptions<CosDbContext> options) :base (options) {}
        public DbSet<Pracownik> Pracowniks { get; set; }
        public DbSet<Stanowisko> Stanowiskos { get; set; }

    }
}
