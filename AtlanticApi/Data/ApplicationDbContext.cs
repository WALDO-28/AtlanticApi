using Microsoft.EntityFrameworkCore;
using AtlanticApi.Models;

namespace AtlanticApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        // Agregar este constructor vacío
        public ApplicationDbContext() { }
        public DbSet<Asegurado> Asegurados { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asegurado>()
                .Property(a => a.NumeroIdentificacion)
                .ValueGeneratedNever(); // Evita que sea Identity

            base.OnModelCreating(modelBuilder);
        }

    }
}
