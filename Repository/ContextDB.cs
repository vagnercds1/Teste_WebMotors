using Microsoft.EntityFrameworkCore;
using WebMotors.Repository.Entity;

namespace WebMotors.Repository
{
    public class ContextDB : DbContext
    {
        public ContextDB() { }

        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        { }

        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>().ToTable("Anuncio");
        }
    }
}
