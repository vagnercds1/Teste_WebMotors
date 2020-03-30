using Microsoft.EntityFrameworkCore;
using Services;
using System.Collections.Generic;
using TesteWebMotors.Models;

namespace TesteWebMotors
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options)
        { }

        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>().ToTable("Anuncio"); 
        }
    }
}

